Shader "DCI/FX_TwoMap_Overlay1M_Linear" 
{
    Properties 
	{
		[Enum(UnityEngine.Rendering.CullMode)] _Cull ("Cull Mode", Float) = 2
		_Color ("Tint", Color) = (1.0, 1.0, 1.0, 1.0)
		_MainTex ("Texture", 2D) = "white" {}
		_BlendTex ("Blend (RGB)", 2D) = "white" {}
		_BlendPower ("BlendPower", float) = 1.0
		_AlphaTex ("Texture", 2D) = "white" {}

}
    SubShader 
    {
		Tags {"Queue"="Transparent+5" "IgnoreProjector"="True" "RenderType"="Transparent"}
		LOD 200

		Blend SrcAlpha One
		//ColorMask RGB
		Cull [_Cull] Lighting Off ZWrite Off

		CGPROGRAM
		#pragma surface surf Lambert alpha:fade
		fixed4 _Color;
     
		struct Input 
		{
			float2 uv_AlphaTex;
			float2 uv_MainTex;
			float2 uv_BlendTex;
		};
      
		sampler2D _MainTex;
		sampler2D _BlendTex;
		sampler2D _AlphaTex;
		float _BlendPower;
      
		void surf (Input IN, inout SurfaceOutput o) 
		{
      		fixed4 MainColor = tex2D( _MainTex, IN.uv_MainTex );	
			fixed4 AplhaColor = tex2D (_AlphaTex, IN.uv_AlphaTex);
      		fixed4 d = (MainColor * tex2D (_BlendTex, IN.uv_BlendTex)) *_Color *_BlendPower* AplhaColor.r;		
			o.Albedo = d.rgb;
			o.Emission = d.rgb;
			d.rgb = dot(d.rgb, float3(0.3, 0.59, 0.11));
			o.Alpha = saturate(d.r*AplhaColor.r*_Color.a);
		}
		ENDCG
    }

    Fallback "Legacy Shaders/Transparent/VertexLit"

  }

