Shader "Double Sided/Cutoff"
{
Properties {
    _MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
    _Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
}
 
SubShader {
    Tags {"Queue"="AlphaTest" "IgnoreProjector"="True" "RenderType"="TransparentCutout"}
    LOD 100
   
    Pass {
        Cull Off
        Lighting Off
        Alphatest Greater [_Cutoff]
        SetTexture [_MainTex] { combine texture }
    }
}
}
