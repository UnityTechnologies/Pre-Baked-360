Shader "Double Sided/Normal" {

    Properties {

        _Color ("Main Color", Color) = (1,1,1,1)
        _MainTex ("Base (RGB)", 2D) = "white" {}
        //_BumpMap ("Bump (RGB) Illumin (A)", 2D) = "bump" {}

    }

    SubShader {     
        //UsePass "Self-Illumin/VertexLit/BASE"
        //UsePass "Bumped Diffuse/PPL"

        // Ambient pass
        Pass {
        Name "BASE"
        Tags {"LightMode" = "Always" /* Upgrade NOTE: changed from PixelOrNone to Always */}
        Color [_PPLAmbient]

        SetTexture [_MainTex] {
            constantColor [_Color]
            Combine texture * previous DOUBLE, texture*constant
        }
    }
    
    // Vertex lights
    Pass {
        Name "BASE"
        Tags {"LightMode" = "Vertex"}
        Material {
            Diffuse [_Color]
            Emission [_PPLAmbient]
            Shininess [_Shininess]
            Specular [_SpecColor]
            }
        SeparateSpecular On
        Lighting Off
        Cull Off
        SetTexture [_BumpMap] {
            constantColor (0,0,0)
            combine constant lerp (texture) previous
            }
        SetTexture [_MainTex] {
            Combine texture * previous DOUBLE, texture*primary
            }
        }
    } 
    FallBack "Diffuse", 1
}
