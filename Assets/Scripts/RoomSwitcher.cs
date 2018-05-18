using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RoomSwitcher : MonoBehaviour {

    //public int RenderQ;

    GameObject[] masks;
    GameObject[] rooms;
    Material[] rooms_M;
    Material[] masks_M;

    CinemachineVirtualCamera vcam;
    //CinemachineBrain brain;
    CinemachineClearShot CSCamera;

	// Use this for initialization
	void Start () {
        rooms = GameObject.FindGameObjectsWithTag("Room");
        masks = GameObject.FindGameObjectsWithTag("Mask");
        //rooms_M = GameObject.FindGameObjectsWithTag("Room").
        //brain = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CinemachineBrain>();
        CSCamera = GameObject.FindGameObjectWithTag("ClearShot").GetComponent<CinemachineClearShot>();
       

		
	}
	
	// Update is called once per frame
    public void VCamSwitcher() {

        int LiveCamID;
        int roomID;
        int maskID;
        string LiveCamName;
        string roomName;
        string maskName;

        LiveCamName = CSCamera.LiveChildOrSelf.Name.Substring(0,1);
        LiveCamID = int.Parse(LiveCamName);

        //Debug.Log(LiveCamID);
        //Debug.Log(brain.ActiveVirtualCamera);
        // Debug.Log(CSCamera.LiveChildOrSelf);

        for (int i = 0; i < rooms.Length; i++)
        {
            //get room ID
            roomName = rooms[i].name.Substring(0, 1);
            roomID = int.Parse(roomName);
          
            //if go with change render queue way
            Material room_M = rooms[i].GetComponent<MeshRenderer>().material;

            if (roomID == LiveCamID)
            {
                //change material render queue
                room_M.renderQueue = 2000;

                //active gameobject
                //rooms[i].transform.gameObject.SetActive(true);
            }
            else
            {
                //set render queue to 0
                room_M.renderQueue = 0;
                //deactive gameobject
                //rooms[i].transform.gameObject.SetActive(false);
            }
        }

        for (int i = 0; i < masks.Length; i++)
        {

            //get mask ID
            maskName = masks[i].name.Substring(0, 1);
            maskID = int.Parse(maskName);

            //if go with change render queue way
            Material mask_M = masks[i].GetComponent<MeshRenderer>().material;

            if (maskID == LiveCamID)
            {
                //change material render queue
                mask_M.renderQueue = 3000;

                //active mask game object
                //masks[i].transform.gameObject.SetActive(true);

            }
            else
            {
                //change render queue to 0
                mask_M.renderQueue = 0;

                //deactive gameobject
                //masks[i].transform.gameObject.SetActive(false);

            }
        }
	}
}