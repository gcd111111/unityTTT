Shader "Unlit/012"
{
     Properties
    {
        _MainTex("MainTex",2D)="white"{}
        _BumpMap("Normal Map",2D)="bump" {}
        _BumpScale("Bump Scale",float)=1
        _Diffuse ("Diffuse", Color) = (1,1,1,1)
        _Specular ("Specular", Color) = (1,1,1,1)
        _Gloss ("Gloss", Range(1,256)) = 5
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
            #include "UnityCG.cginc"
            #include "Lighting.cginc"

            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _BumpMap;
            float4 _BumpMap_ST;
            float _BumpScale;
            fixed4 _Diffuse;
            fixed4 _Specular;
            float _Gloss;

            //struct appdata
            //{
            //    float4 vertex : POSITION;
            //    float3 normal : NORMAL;
            //};

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 lightDir : TEXCOORD0;
                float3 viewDir : TEXCOORD1;
                float2 uv:TEXCOORD2;
                float2 normalUv:TEXCOORD3;
            };

        

            v2f vert (appdata_tan v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv=TRANSFORM_TEX(v.texcoord,_MainTex);//.uv=v.texcoord.xy*_MainTex_ST.xy+_MainTex_ST.zw;
                o.normalUv=TRANSFORM_TEX(v.texcoord,_BumpMap);

                //������
                //float3 binormal=cross(normalize(v.normal),normalize(v.tangent.xyz))*v.tangent.w;
                //float3x3 roatiton=float3(v.tangent.xyz,binormal,v.normal);

                TANGENT_SPACE_ROTATION;

                //�����߿ռ��Դ�����ӽǷ���
                o.lightDir=mul(rotation,ObjSpaceLightDir(v.vertex)).xyz;
                o.viewDir=mul(rotation,ObjSpaceViewDir(v.vertex)).xyz;

                return o;
            }
            fixed4 frag (v2f i) : SV_Target
            {
                fixed3 tangeLightDir=normalize(i.lightDir);
                fixed3 tangeViewDir=normalize(i.viewDir);

                fixed4 packedNormal=tex2D(_BumpMap,i.normalUv);
                //û�����ó�normal Map
                //fixed3 tangentNormal;
                //tangentNormal.xy=(packedNormal.xy*2-1)*_BumpScale;
                //tangentNormal.z=sqrt(1-saturate(dot(tangentNormal.xy,tangentNormal.xy)));

                //�����ó�normal map
                fixed3 tangentNormal =UnpackNormal(packedNormal);
                tangentNormal.xy*=_BumpScale;
               //tangentNormal.z=sqrt(1-saturate(dot(normal.xy,normal.xy)));
                //tangentNormal.z=sqrt(1-saturate(dot(tangentNormal.xy,tangentNormal.xy)));
                //������
                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.rgb;
                //��ԭ��ͼ�Ĳ���
                fixed3 albedo =tex2D(_MainTex,i.uv).rgb;

                //������
                fixed3 diffuse = _LightColor0.rgb *albedo* _Diffuse.rgb * (max(0.0, dot(tangeLightDir, tangentNormal))*0.5+0.5);
                //�߹ⷴ��       
                fixed3 halfDir=normalize(tangeLightDir+ tangeViewDir);
                fixed3 specular = _LightColor0.rgb * _Specular.rgb * pow(saturate(dot(tangeLightDir, halfDir)), _Gloss);

                fixed3 color = ambient + diffuse + specular;
                return fixed4(color, 1.0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
