Shader"DCI/Dota2like(Cutout)_002"
{
	Properties
	{
		[Enum(UnityEngine.Rendering.CullMode)] _Cull ("Cull Mode", Float) = 2

		[Space(10)]
		_ColorTex("Color(RGB)+Alpha", 2D) = "white"{}
		_Cutoff("Alpha Cutoff", Range(0,1)) = 0.1
		[Space(10)]
		_Tint("Tint", Color) = (1,1,1,1)
		_TintByBaseTex("Tint Mask(灰階,黑=無 白=1)",2D) = "white"{}
		[Space(10)]
		_NormalTex("Normal(RGB)", 2D)="bump"{}
		_Normal("Normal強度", Range(0.01,3)) = 1.0
		[Space(10)]
		_MetalnessTex("Metalness 金屬度(灰階,黑=非金屬 白=全金屬)", 2D) = "white"{}
		_Metalness("Metalness強度", Range(0,1)) = 0.0
		[Space(10)]
		_SpecularExpTex("Smoothness平滑度(灰階,黑=粗糙 白=光滑)", 2D) = "black"{}
		_Specular("Smoothness強度", Range(0,1)) = 0.0
		[Space(10)]
		_SelfIllumTex("SelfIllum自發光(灰階,黑=無 白=1)", 2D) = "black"{}
		_SelfIllum("SelfIllum強度", Range(0,1)) = 0.0
		[Space(10)]
		_RimTex("Rim邊光(灰階,黑=0 白=1)", 2D) = "black"{}
		_RimColor("Rim Color", Color) = (1,1,1,1)
		_Rim("Rim強度", Range(0,1)) = 0.0
		//[Space(10)]
		//_TranslucencyTex("Alpha Cutoff透空(灰階,黑=無 白=1)", 2D) = "white"{}
		

	}
	SubShader
	{
		Tags
		{
			"Queue" = "AlphaTest"
			"IgnoreProjector" = "True"
			"RenderType" = "TransparentCutout"
		}
		Cull [_Cull]

		//Blend [_SrcBlend] [_DstBlend]
		//ZWrite [_ZWrite]
		//ZTest [_ZTest]


		CGPROGRAM
		#pragma surface surf CustomStandard fullforwardshadows alphatest:_Cutoff vertex:vert addshadow
		#pragma target 3.0
		#include "UnityPBSLighting.cginc"

		//PBS Lighting
		inline void LightingCustomStandard_GI(SurfaceOutputStandard s, UnityGIInput data, inout UnityGI gi)
		{
			gi = UnityGlobalIllumination(data, s.Occlusion, s.Smoothness, s.Normal);
		}
		inline half4 LightingCustomStandard(SurfaceOutputStandard s, half3 viewDir, UnityGI gi)
		{
			s.Normal = normalize(s.Normal);

			half oneMinusReflectivity;
			half3 specColor;
			s.Albedo = DiffuseAndSpecularFromMetallic(s.Albedo, s.Metallic, specColor, oneMinusReflectivity);

			// shader relies on pre-multiply alpha-blend (_SrcBlend = One, _DstBlend = OneMinusSrcAlpha)
			// this is necessary to handle transparency in physically correct way - only diffuse component gets affected by alpha
			half outputAlpha;
			s.Albedo = PreMultiplyAlpha(s.Albedo, s.Alpha, oneMinusReflectivity, outputAlpha);

			half4 c = UNITY_BRDF_PBS(s.Albedo, specColor, oneMinusReflectivity, s.Smoothness, s.Normal, viewDir, gi.light, gi.indirect);
			c.rgb += UNITY_BRDF_GI(s.Albedo, specColor, oneMinusReflectivity, s.Smoothness, s.Normal, viewDir, s.Occlusion, gi);
			c.a = outputAlpha;

			return c;
		}

		struct Input 
		{
			float2 uv_ColorTex;
			float3 viewDir;
			float3 worldRefl;
			INTERNAL_DATA
		};

		sampler2D _ColorTex;
		sampler2D _TintByBaseTex;
		sampler2D _NormalTex;
		sampler2D _MetalnessTex;
		sampler2D _SpecularExpTex;
		sampler2D _SelfIllumTex;
		sampler2D _RimTex;
		//sampler2D _TranslucencyTex;

		fixed _Normal;
		fixed _Specular;
		fixed _Metalness;
		fixed _SelfIllum;
		fixed _Rim;
		fixed3 _RimColor;
		fixed3 _Tint;

		void vert(inout appdata_full v) 
		{
			
		}

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			//效果增強數值
			fixed multipler = 2;

			//Diffuse
			fixed tintByBaseMask = tex2D(_TintByBaseTex, IN.uv_ColorTex);
			half4 color = tex2D(_ColorTex, IN.uv_ColorTex);
			half3 colorTinted = color.rgb * _Tint;
			half3 albedo = lerp(color, colorTinted, tintByBaseMask);

			//NormalMap
			half3 normal = UnpackNormal(tex2D(_NormalTex,IN.uv_ColorTex));
			normal.z = normal.z/_Normal;

			//Metal
			fixed metalnessTexed = tex2D(_MetalnessTex, IN.uv_ColorTex);
			fixed metallic = lerp(0, metalnessTexed * multipler, _Metalness);

			//Smoothness
			fixed speculerExpTexed = tex2D(_SpecularExpTex, IN.uv_ColorTex) * multipler;
			fixed smoothness = lerp(0, speculerExpTexed, _Specular);

			//Emission
			half3 emission = lerp(0, (albedo * tex2D(_SelfIllumTex, IN.uv_ColorTex) * multipler), _SelfIllum);

			//RimLight
			fixed rimTexed = tex2D(_RimTex, IN.uv_ColorTex);
			fixed3 rim = lerp(0, _Rim * _RimColor * saturate(1 - saturate(dot(normal, IN.viewDir)) * 1.8), rimTexed);

			//Alpha
			//fixed alpha = tex2D(_TranslucencyTex, IN.uv_ColorTex);

			o.Albedo = albedo.rgb;
			o.Normal = normal * _Normal;
			o.Metallic = metallic;
			o.Smoothness = smoothness;
			o.Emission = emission + rim;
			o.Alpha = color.a;
		}
		ENDCG
	}
	Fallback "Diffuse"
}