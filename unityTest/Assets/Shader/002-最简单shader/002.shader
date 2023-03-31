Shader "Unlit/002"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            //POSITION SV_POSITION ����
            float4 vert(float4 v:POSITION):SV_POSITION
            {
                return UnityObjectToClipPos(v);
            }
            float4 frag():SV_TARGET
            {
                return fixed4(1,1,1,1);
            }
            ENDCG
        }
    }
     FallBack "Diffuse"
}
