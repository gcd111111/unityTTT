Shader "Unlit/015"
{
    Properties
    {
        _MainTex("MainTex",2D)="white"{}
        _BumpMap("Normal Map",2D)="bump" {}
        _BumpScale("Bump Scale",float)=1
        _SpecularMask("Specular Mask",2D)="white"{}
        _SpecularScale("Specular Scale", float)=1
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
            sampler2D _SpecularMask;
            float4 _SpecularMask_ST;
            float _SpecularScale;
            float _BumpScale;
            fixed4 _Diffuse;
            fixed4 _Specular;
            float _Gloss;


            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 lightDir : TEXCOORD0;
                float3 viewDir : TEXCOORD1;
                float4 uv:TEXCOORD2;
                float2 maskUv:TEXCOORD3;
            };

        

            v2f vert (appdata_tan v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv.xy=TRANSFORM_TEX(v.texcoord,_MainTex);//.uv=v.texcoord.xy*_MainTex_ST.xy+_MainTex_ST.zw;
                o.uv.zw=TRANSFORM_TEX(v.texcoord,_BumpMap);
                o.maskUv=TRANSFORM_TEX(v.texcoord,_SpecularMask);

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

                fixed4 packedNormal=tex2D(_BumpMap,i.uv.zw);
        

                //�����ó�normal map
                fixed3 tangentNormal =UnpackNormal(packedNormal);
                tangentNormal.xy*=_BumpScale;
                //������
                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz;
                //��ԭ��ͼ�Ĳ���
                fixed3 albedo =tex2D(_MainTex,i.uv.xy).rgb;

                //������
                fixed3 diffuse = _LightColor0.rgb *albedo* _Diffuse.rgb * (max(0.0, dot(tangeLightDir, tangentNormal))*0.5+0.5);
                //�߹�����
                fixed3 specularMask=tex2D(_SpecularMask,i.maskUv).r*_SpecularScale;
                //�߹ⷴ��       
                fixed3 halfDir=normalize(tangeLightDir+ tangeViewDir);
                fixed3 specular = _LightColor0.rgb * _Specular.rgb * pow(saturate(dot(tangeLightDir, halfDir)), _Gloss)*specularMask;


                fixed3 color = ambient + diffuse + specular;
                return fixed4(color, 1.0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
