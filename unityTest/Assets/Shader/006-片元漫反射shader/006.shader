Shader "Unlit/006"
{
     properties
    {
        _Diffuse("diffuse",color)=(1,1,1,1)
    }
    subshader
    {
        tags { "rendertype"="opaque" }
        lod 100

        pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "unitycg.cginc"
            #include "lighting.cginc"
            fixed4 _Diffuse;

            struct v2f 
            {
                float4 vertex :SV_POSITION;

                fixed3 worldNormal :TEXCOORD0;
            };

            v2f vert (appdata_base v)
            {
                v2f o;
                o.vertex=UnityObjectToClipPos(v.vertex);
                fixed3 worldNormal=UnityObjectToWorldNormal(v.normal);
                o.worldNormal=worldNormal;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
            fixed3 ambient=UNITY_LIGHTMODEL_AMBIENT.xyz;
            fixed3 worldLightDir=normalize(_WorldSpaceLightPos0.xyz);
            fixed3 diffuse=_LightColor0.rgb*_Diffuse.rgb*max(0,dot(worldLightDir,i.worldNormal));
            fixed3 color =ambient+diffuse;
               return fixed4(color,1);
            }
            ENDCG
        }
    }
     FallBack "Diffuse"
}
