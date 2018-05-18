//This script allows the player to move the camera with the mouse
//while in the editor

using UnityEngine;

public class CameraEditorControl : MonoBehaviour
{
	[SerializeField] bool m_MouseControl = true;	//Should the mouse control the camera? Use this to easily disable this script
	[SerializeField] float m_Speed = 5f;			//The speed the camera moves


	void Awake()
	{
		//If we aren't in the editor, remove this script component from the camera
	#if !UNITY_EDITOR
		Destroy (this);	
	#else
		//If the mouse is controller the camera, Lock the cursor
		if(m_MouseControl)
			LockCursor();

	#endif
	}


	//Detect mouse movements and move camera accordingly
	void Update()
	{
		if (!m_MouseControl)
			return;

		//Get the movement of the mouse
		float horizontal = Input.GetAxis("Mouse X") * m_Speed;
		float vertical = Input.GetAxis("Mouse Y") * m_Speed;
		//Rotate the camera accordingly
		transform.Rotate(0f, horizontal, 0f, Space.World);
		transform.Rotate(-vertical, 0f, 0f, Space.Self);
		//If the user presses "escape", unlock the cursor
		if (Input.GetButtonDown ("Cancel"))
			UnlockCursor ();
	}


	void LockCursor()
	{
		//Lock the cursor to the middle of the screen and then hide it
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void UnlockCursor()
	{
		//Release the cursor and show it
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
}
