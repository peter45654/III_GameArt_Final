// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "DCI/Gem1"
{
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
		_ReflectionStrength ("Reflection Strength", Range(0.0,10.0)) = 1.0
		_EnvironmentLight ("Environment Light", Range(0.0,10.0)) = 1.0
		_Emission ("Emission", Range(0.0,10.0)) = 0.0
		[NoScaleOffset] _RefractTex ("Refraction Texture", Cube) = "" {}
	}
	SubShader {
		Tags {
			"RenderType"="Opaque"  //"Queue" = "Transparent"
		}

		// Second pass - here we render the front faces of the diamonds.
		Pass {
			ZWrite On
			//Blend One One
			
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct appdata{
        		float4 v : POSITION;
        		float3 n : NORMAL ;
                float2 uv : TEXCOORD0;
            };

			struct v2f {
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
				float3 uv1 : TEXCOORD1;
				half fresnel : TEXCOORD2;
				//float2 uv_MainTex;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;

			v2f vert (appdata v)
			{
				
				//v2f o;
				//o.pos = mul(UNITY_MATRIX_MVP, v);

				// TexGen CubeReflect:
				// reflect view direction along the normal, in view space.
				//float3 viewDir = normalize(ObjSpaceViewDir(v));
				//o.uv = -reflect(viewDir, n);
				//o.uv = mul(_Object2World, float4(o.uv,0));
				//o.fresnel = 1.0 - saturate(dot(n,viewDir));
				//return o;
				v2f o;
				o.pos = UnityObjectToClipPos(v.v);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				// TexGen CubeReflect:
				// reflect view direction along the normal, in view space.
				float3 viewDir = normalize(ObjSpaceViewDir(v.v));
				o.uv1 = -reflect(viewDir, v.n);
				o.uv1 = mul(unity_ObjectToWorld, float4(o.uv1,0));
				o.fresnel = 1.0 - saturate(dot(v.n,viewDir));

				return o;
			}

			fixed4 _Color;
			samplerCUBE _RefractTex;
			half _ReflectionStrength;
			half _EnvironmentLight;
			half _Emission;
			half4 frag (v2f i) : SV_Target
			{
				fixed4 tex = tex2D(_MainTex, i.uv);
				half3 refraction = texCUBE(_RefractTex, i.uv1).rgb * _Color.rgb;
				half4 reflection = UNITY_SAMPLE_TEXCUBE(unity_SpecCube0, i.uv1);
				reflection.rgb = DecodeHDR (reflection, unity_SpecCube0_HDR);
				half3 reflection2 = reflection * _ReflectionStrength * i.fresnel;
				half3 multiplier = reflection.rgb * _EnvironmentLight + _Emission;
				//* multiplier
				return fixed4((tex.rgb*refraction.rgb + reflection2)* multiplier , 1.0f);
			}
			ENDCG
		}

		// Shadow casting & depth texture support -- so that gems can
        // cast shadows
        UsePass "VertexLit/SHADOWCASTER"
	}
}
