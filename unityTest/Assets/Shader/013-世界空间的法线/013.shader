// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Unlit/013"
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

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float4 uv:TEXCOORD0;
                float4 Ttiw0:TEXCOORD1;
                float4 Ttiw1:TEXCOORD2;
                float4 Ttiw2:TEXCOORD3;
            };

        

            v2f vert (appdata_tan v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv.xy=TRANSFORM_TEX(v.texcoord,_MainTex);//.uv=v.texcoord.xy*_MainTex_ST.xy+_MainTex_ST.zw;
                o.uv.zw=TRANSFORM_TEX(v.texcoord,_BumpMap);

                //�������������µĶ���λ�ã����ߣ����ߣ�������
                float3 worldPos=mul(unity_ObjectToWorld,v.vertex).xyz;
                float3 worldNormal=UnityObjectToWorldNormal(v.normal);
                fixed3 worldTangent=UnityObjectToWorldDir(v.tangent.xyz);
                fixed3 worldBinormal=cross( worldNormal,worldTangent)*v.tangent.w;
                //���аڷŵõ������߿ռ䵽��������ı任����
                o.Ttiw0=float4(worldTangent.x,worldBinormal.x,worldNormal.x,worldPos.x);
                o.Ttiw1=float4(worldTangent.y,worldBinormal.y,worldNormal.y,worldPos.y);
                o.Ttiw2=float4(worldTangent.z,worldBinormal.z,worldNormal.z,worldPos.z);
                return o;
            }
            fixed4 frag (v2f i) : SV_Target
            {
                //����������
                float3 worldPos=float3(i.Ttiw0.w,i.Ttiw1.w,i.Ttiw2.w);
                //��������ռ��µĹ������ӽ�
                fixed3 lightDir=normalize(UnityWorldSpaceLightDir(worldPos));
                fixed3 viewDir=normalize(UnityWorldSpaceViewDir(worldPos));

                //��÷�������
               fixed4 packedNormal=tex2D(_BumpMap,i.uv.zw);
               fixed3 tangentNormal=UnpackNormal(packedNormal);
               tangentNormal.xy*=_BumpScale;
               //tangentNormal.z=sqrt(1-saturate(dot(normal.xy,normal.xy)));

               //���߿ռ䷨��ת������������
               fixed3 worldNormal=normalize(float3(dot(i.Ttiw0.xyz,tangentNormal),dot(i.Ttiw1.xyz,tangentNormal),dot(i.Ttiw2.xyz,tangentNormal)));

                //������
                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz;
                //��ԭ��ͼ�Ĳ���
                fixed3 albedo =tex2D(_MainTex,i.uv).rgb;

                //������
                fixed3 diffuse = _LightColor0.rgb *albedo* _Diffuse.rgb * (max(0.0, dot(lightDir, worldNormal))*0.5+0.5);
                //�߹ⷴ��       
                fixed3 halfDir=normalize(lightDir+ viewDir);
                fixed3 specular = _LightColor0.rgb * _Specular.rgb * pow(saturate(dot(worldNormal, halfDir)), _Gloss);

                fixed3 color = ambient + diffuse + specular;
                return fixed4(color, 1.0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
