Shader "Unlit/shader"
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
            #include "UnityCG.cginc"

          
            struct v2f//v vert dao frag
            {
                //SV_POSITION�������unity posΪ�ü��ռ��λ����Ϣ 
                float4 pos:SV_POSITION;
                //COLOR0 ������Դ洢��ɫ��Ϣ
                fixed3 color:COLOR0;
            };

            v2f vert(appdata_full v)
            {
                v2f o;
                o.pos=UnityObjectToClipPos(v.vertex);
                //����
                o.color=v.normal *0.5+fixed3(0.5,0.5,0.5);
                //����
                o.color=v.tangent.xyz*0.5+fixed3(0.5,0.5,0.5);
                //UV
                o.color=fixed4(v.texcoord.xy,0,1);
                //������ɫ
                o.color=v.color;
                return o ;
            }
            fixed4 frag(v2f i):SV_TARGET
            {
                return fixed4(i.color,1);
            }
            ENDCG
        }
    }
     FallBack "Diffuse"
}
