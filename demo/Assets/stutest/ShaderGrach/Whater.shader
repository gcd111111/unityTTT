Shader "Hsj/Whater" {
 
		Properties
		{
		_MainTex("MainTex",2D) = "white"{}
		_MainColor("MainColor",COLOR) = (1,1,1,1)
		_AddTex("AddTex",2D) = "white"{}
		_Maxset("Max",Range(0.1,1.0)) = 0.1
		}
			SubShader
		{
		Tags{"RenderType" = "Transparent" "Queue" = "Transparent" "IgnoreProjector" = "True"}
		LOD 200
		pass
		{
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#include "UnityCG.cginc"
 
		float4 _MainColor;
		sampler2D _MainTex;
		sampler2D _AddTex;
		float4 _MainTex_ST;
		float _Maxset;
		struct appdata
		{
		float4 vertex:POSITION;
		float2 texcoord:TEXCOORD0;
		};
		struct v2f
		{
		float4 pos:POSITION;
		float2 uv:TEXCOORD0;
		};
		v2f vert(appdata v)
		{
		v2f o;
		o.pos = UnityObjectToClipPos(v.vertex);
		o.uv = TRANSFORM_TEX(v.texcoord,_MainTex);
		return o;
		}
 
 
		float4 frag(v2f o) :SV_Target
		{
		float2 c = (tex2D(_AddTex,o.uv.xy + float2(0,_Time.x)).gb + tex2D(_AddTex,o.uv.xy + float2(_Time.x,0)).gb) - 1;
		float2 ruv = o.uv.xy + c.xy*_Maxset;
		half4 h = tex2D(_MainTex,ruv)*_MainColor;
		return h;
		}
		ENDCG
		}
		}
			FallBack "Diffuse"
 
	}