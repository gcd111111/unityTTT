Shader "Unlit/003"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color("Color" ,Color)=(1,1,1,1)
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

            //#include "UnityCG.cginc"

            //ֻ����CGPROGRAM���ٴζ���һ�������Կ�����������ͬ�ı��������Կ��Ӧ�ı�������������
            fixed4 _Color;

            struct a2v//a application  dao  vert
            {
                //��ģ�Ͷ������v����
                float4 vertex:POSITION;
                //��ģ�ͷ������n����
                float3 normal:NORMAL;
                //��ģ�͵ĵ�һ��uv���texcoord
                float4 texcoord:TEXCOORD;
            };

            struct v2f//v vert dao frag
            {
                //SV_POSITION�������unity posΪ�ü��ռ��λ����Ϣ 
                float4 pos:SV_POSITION;
                //COLOR0 ������Դ洢��ɫ��Ϣ
                fixed3 color:COLOR0;
            };

            v2f vert(a2v v)
            {
                v2f o;
                o.pos=UnityObjectToClipPos(v.vertex);
                //����-1��1��ת��Ϊ��0��1�� x/2+0.5;
                o.color=v.normal *0.5+fixed3(0.5,0.5,0.5);
                return o ;
            }
            fixed4 frag(v2f i):SV_TARGET
            {
                fixed3 c =i.color;
                //.xyzw .rgba .x .y .xw
                c*=_Color.rgb;
                //return fixed4(0,0,0,1);
                return fixed4(c,1);
            }
            ENDCG
        }
    }
     FallBack "Diffuse"
}
