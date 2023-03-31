Shader "Unlit/001"
{
    //���Կ�
    Properties
    {
        _Int("Int",Int)=2
        _Float("Float",float)=1.5
        _Range("Range",Range(0.0,2.0))=1.0
        _Color("Color",Color)=(1,1,1,1)
        _Vector("Vector",Vector)=(1,4,3,8)
        _MainTex ("Texture", 2D) = "white" {}
        _Cube("Cube",Cube) = "white"{}
        _3D("3D",3D) = "black"{}
    }
    //�����
    SubShader
    {
        //��ǩ ��ѡ  key = value
        Tags 
        {         
                "Queue"="Transparent"//��Ⱦ˳��
                "RenderType"="Opaque"//��Ⱦ���ͣ���ɫ���滻����
                "DisableBatching"="True"//�Ƿ���к���
                "ForceNoShadowCasting"="True"//�Ƿ�Ͷ����Ӱ
                "IgnoreProjector"="True"//�ܲ���projector��Ӱ�죬ͨ������͸������
                "CanUseSpriteAltas"="False"//�Ƿ�����ͼƬ��shader��ͨ������UI
                "PreviewType"="Plane"//����shader���Ԥ��������
        }
        //Render���� ��ѡ
        //Cull off/back/front  //ѡ����Ⱦ�Ǹ���
        //ZTest Always/Less Greater/LEqual/GEqual/Equal/NotEqual     //��Ȳ���
        //Zwrite off/on  //���д��
        //Blend SrcFactor DstFactor //���
        //LOD 100 //��ͬ�����ʹ�ò�ͬ��LOD�ﵽ��������

        //����
        Pass
        {
            //Name "Defalut"  //passͨ������
            Tags
            {
                "LightMode"="ForwardBase"//����Passͨ����Unity��Ⱦ��ˮ�еĽ�ɫ
               //"RequireOptions"="SoftVegetation"//����ĳЩ����ʱ����Ⱦpassͨ��
            }// ������ÿ��passͨ������ж���
            //Render���� ������ÿ��passͨ������ж���
            
            //CG����д�Ĵ��룬��Ҫ�Ƕ���ƬԪ��ɫ��
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }    
            ENDCG
        }
    }
     FallBack "Diffuse"
    //Fallback "Legacy Shaders/Transparent/VertextLit" Fallback Off  //������shader���в���ʱ��ʹ�������shader
}
