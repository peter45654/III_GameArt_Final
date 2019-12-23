Shader "DCI/ToonShader_Eviroment" 
{
	Properties 
	{
		[Enum(UnityEngine.Rendering.CullMode)] _Cull ("Cull Mode", Float) = 2
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)+Alpha", 2D) = "white" {}
		_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5

		[Space(10)]
		_SelfIllluminTex("Self-Illlumin (B&W)", 2D) = "white" {}
		_SelfIllluminPower("Self-Illlumin Power",Range(0.0,10.0)) = 0.0
		[Space(10)]
		_Ramp("Toon Ramp", 2D) = "white" {}

		[Space(20)]
		[Toggle(SPECULAR_ENABLE)] _SpecularEnable("Enable Specular", Int) = 0
		_SpecTex("Specular (B&W)", 2D) = "white" {}
		_SpecularPower("Specular Power", Range(0.0,1.0)) = 0.01

	}
	SubShader 
	{
		Tags {"Queue"="AlphaTest" "IgnoreProjector"="True" "RenderType"="TransparentCutout"}
		LOD 200
		Cull [_Cull]
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma shader_feature SPECULAR_ENABLE
		#pragma surface surf Ramp fullforwardshadows alphatest:_Cutoff

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _Ramp;

		half4 LightingRamp(SurfaceOutput s, half3 lightDir, half3 viewDir, half atten) 
		{
			half NdotL = dot(s.Normal, lightDir);
			half diff = NdotL * 0.5 + 0.5;
			half3 ramp = tex2D(_Ramp, float2(diff, diff)).rgb;
			half4 c;

			#if SPECULAR_ENABLE
			half3 h = normalize(lightDir + viewDir);
			float nh = max(0, dot(s.Normal, h));
			float spec = pow(nh, s.Specular * 128.0);
			c.rgb = (s.Albedo * _LightColor0.rgb * ramp + spec * _LightColor0.rgb) * atten;

			#else
			c.rgb = s.Albedo * _LightColor0.rgb * ramp * atten;
			#endif

			c.a = s.Alpha;
			return c;
		}

		struct Input 
		{
			float2 uv_MainTex;
			float3 viewDir;
		};

		sampler2D _MainTex;
		sampler2D _SpecTex;
		sampler2D _SelfIllluminTex;
		float _SelfIllluminPower;
		float _SpecularPower;
		fixed4 _Color;

		void surf (Input IN, inout SurfaceOutput o) 
		{
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
			o.Specular = _SpecularPower * tex2D(_SpecTex, IN.uv_MainTex);
			fixed4  selfilllumincolor = c*tex2D(_SelfIllluminTex , IN.uv_MainTex)*_SelfIllluminPower ;
			o.Emission += selfilllumincolor ;
		}
		ENDCG
	}
	Fallback "Legacy Shaders/Transparent/Cutout/VertexLit"
}
