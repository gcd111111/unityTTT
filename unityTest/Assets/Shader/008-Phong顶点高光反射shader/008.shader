Shader "Unlit/008"
{
    properties
    {
        _Diffuse("Diffuse",color)=(1,1,1,1)
        _Specular("Specular",color)=(1,1,1,1)
        _Gloss("Gloss",Range(1,256))=5
    }
    subshader
    {
        tags { "rendertype"="opaque" }
        lod 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "unitycg.cginc"
            #include "lighting.cginc"
            fixed4 _Diffuse;
            fixed4 _Specular;
            float _Gloss;

            struct v2f 
            {
                float4 vertex :SV_POSITION;

                fixed3 color :Color;
            };

            v2f vert (appdata_base v)
            {
                v2f o;
                o.vertex=UnityObjectToClipPos(v.vertex);

                //fixed3 worldPos=UnityObjectToWorldDir(v.vertex);
                fixed3 worldPos=mul(unity_ObjectToWorld,v.vertex);

                fixed3 ambient=UNITY_LIGHTMODEL_AMBIENT.xyz;
                fixed3 worldNormal=UnityObjectToWorldNormal(v.normal);
                //fixed3 worldLight=normalize(_WorldSpaceLightPos0.xyz);
                fixed3 worldLight=normalize( UnityWorldSpaceLightDir(worldPos));
                fixed3 diffuse=_LightColor0.rgb * _Diffuse.rgb*max(0,dot(worldNormal,worldLight));

                fixed3 reflectDir=normalize(reflect(-worldLight,worldNormal));
                //fixed3 viewDir=(_WorldSpaceCameraPos.xyz-UnityObjectToWorldDir(v.vertex));
                fixed3 viewDir=normalize( UnityWorldSpaceViewDir(worldPos));
                //fixed3 viewDir=normalize( UnityWorldSpaceViewDir(v.vertex));
                fixed3 specular=_LightColor0.rgb*_Specular.rgb*pow(max(0,dot(reflectDir,viewDir)),_Gloss);
                o.color=diffuse+ambient+specular;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
               return fixed4(i.color,1);
            }
            ENDCG
        }
    }
     FallBack "Diffuse"
}
