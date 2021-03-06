Shader "DCI/Self-Illumin/Diffuse_Alpha" {
Properties 
{
	[Enum(UnityEngine.Rendering.CullMode)] _Cull ("Cull Mode", Float) = 2

	_Color ("Main Color", Color) = (1,1,1,1)
	_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
	_Illum ("Illumin (A)", 2D) = "white" {}
	_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
}
SubShader {
	Tags { "Queue"="AlphaTest" "IgnoreProjector"="True" "RenderType"="TransparentCutout" }
	LOD 200
	Cull [_Cull]
	
CGPROGRAM
#pragma surface surf Lambert alphatest:_Cutoff

sampler2D _MainTex;
sampler2D _Illum;
fixed4 _Color;

struct Input 
{
	float2 uv_MainTex;
	float2 uv_Illum;
};

void surf (Input IN, inout SurfaceOutput o) 
{
	fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);
	fixed4 c = tex * _Color;
	o.Albedo = c.rgb;
	o.Emission = c.rgb * tex2D(_Illum, IN.uv_Illum).a;
	o.Alpha = c.a;
}
ENDCG
} 
Fallback "Legacy Shaders/Transparent/Cutout/VertexLit"
CustomEditor "LegacyIlluminShaderGUI"
}
