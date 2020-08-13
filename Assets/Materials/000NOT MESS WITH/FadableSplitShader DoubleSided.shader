Shader "Custom/FadableSplitShaderDoubleSided" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_HighlightColor("_HighlightColor", Color) = (1,1,1,1)
		_HighlightAmount("HighlightAmount", Range(0,1)) = 0.0
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.5
		_Fade("Fade", Range(0,1)) = 1.0
		_MaxTransparacy("Max", Range(0,1)) = 1

		_BumpMap("Bumpmap", 2D) = "bump" {}
		_NormScale("_NormScale", Range(0,1)) = 1.0

		_SpecMap("Specmap",2D) = "spec" {}
		_SpecScale("SpecScale", Range(0,1)) = 1.0

		_Emission("Emission", Float) = 0
		_EmissionColor("EmissionColor", Color) = (1,1,1,1)


		[Toggle] _Split("Split",Float) = 0

		_PlaneNormal("PlaneNormal",Vector) = (0,1,0,0)
		_PlanePosition("PlanePosition",Vector) = (0,0,0,1)
		[Toggle] _ShowBackSide("BackSide",Float) = 1



		[Toggle] _HighlightActive("HighlightActive",Float) = 0


		[Toggle] _Gradient("Gradient",Float) = 0
		_ColorA ("ColorA", Color) = (1,1,1,1)
		_ColorB ("ColorB", Color) = (1,1,1,1)
		_ColorC ("ColorC", Color) = (1,1,1,1)
		_ColorD ("ColorD", Color) = (1,1,1,1)
		_ColorE ("ColorE", Color) = (1,1,1,1)



		_ColorOffset("ColorOffset", Float) = .5

		_GradiantWidth("GradiantWidth", Float) = 40

	}

		

			
	SubShader {
		Tags{ "RenderType" = "Transparent" "Queue" = "Transparent" }
		Blend SrcAlpha OneMinusSrcAlpha
			//ColorMask 0
			ColorMask RGBA
		LOD 200
		Cull Off 
			ZWrite On
			AlphaToMask On
			Lighting Off
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf StandardSpecular fullforwardshadows keepalpha 

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _BumpMap;
		sampler2D _SpecMap;
		fixed4 _ColorA;
		fixed4 _ColorB;
		fixed4 _ColorC;
		fixed4 _ColorD;
		fixed4 _ColorE;


		float _ColorOffset;
		float _Gradient;

		float _GradiantWidth;
		struct Input {
			float2 uv_MainTex;
			float3 worldPos;
			float4 screenPos;
			float2 uv_BumpMap;
			float2 uv_SpecMap;
		};


		half _Glossiness;
		half _Metallic;
		half _HighlightAmount;
		half _Fade;
		float _MaxTransparacy;

		half _SpecScale;
		half _NormScale;

		float _Emission;
		fixed4 _Color;
		fixed4 _HighlightColor;
		fixed4 _EmissionColor;


		float _Split;
		float _PrevFade;

		//float _HighlightActive;
		//float _FadeActive;

		fixed3 _PlaneNormal;
		fixed3 _PlanePosition;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)
		bool checkVisability(fixed3 worldPos)
		{
			float dotProd1 = dot(worldPos - _PlanePosition, _PlaneNormal);
			return dotProd1 > 0;
		}
		void surf (Input IN, inout SurfaceOutputStandardSpecular o) {

			if (checkVisability(IN.worldPos) && _Split)discard;

			//half4 screenUV = IN.screenPos.x / IN.screenPos.w;
			float segment = _GradiantWidth/4;
			half4 screenUV = ((IN.worldPos.x+(_GradiantWidth/2)) /_GradiantWidth);

			half4 A = ((IN.worldPos.x + (_GradiantWidth/2)) / segment);
			half4 B = ((IN.worldPos.x + (_GradiantWidth/4)) / segment);
			half4 C = (IN.worldPos.x /  segment);
			half4 D = ((IN.worldPos.x - (_GradiantWidth/4)) / segment);
			

			//-20 to -10 

			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
			float pos = IN.worldPos.x;
			if(_Gradient){

				if(pos < -segment)
					c = c* lerp(_ColorA, _ColorB, A);
				else if(pos < 0 && pos > -segment)
					c = c* lerp(_ColorB, _ColorC, B);
				else if(pos > 0 && pos < segment)
					c = c* lerp(_ColorC, _ColorD, C);
				else if(pos > segment)
					c = c* lerp(_ColorD, _ColorE, D);

			}




			fixed4 hc = _HighlightColor;
			
			fixed4 result = (c* (1-_HighlightAmount)) + (hc * _HighlightAmount);

			o.Albedo = result;

			o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap) *_NormScale);

			o.Specular = tex2D(_SpecMap, IN.uv_SpecMap) * _SpecScale;
			o.Smoothness = _Glossiness;

			o.Alpha = clamp(_Fade, 0, _MaxTransparacy);
			//o.Emission = _EmissionColor.rgb * _Emission;
			o.Emission = c * _Emission;

		}
		ENDCG

			Cull Front
			CGPROGRAM
#pragma surface surf NoLighting  noambient blend 

			sampler2D _MainTex;
		sampler2D _BumpMap;
		sampler2D _SpecMap;

		struct Input {
			float2 uv_MainTex;
			float3 worldPos;
					
			float2 uv_BumpMap;
			float2 uv_SpecMap;
		};

		float _ShowBackSide;
		half _Glossiness;
		half _Metallic;
		half _HighlightAmount;
		half _Fade;
		half _SpecScale;
		half _NormScale;

		float _Emission;
		fixed4 _Color;
		fixed4 _HighlightColor;
		fixed4 _EmissionColor;
		float _MaxTransparacy;

		float _Split;

		fixed3 _PlaneNormal;
		fixed3 _PlanePosition;
		bool checkVisability(fixed3 worldPos)
		{
			float dotProd1 = dot(worldPos - _PlanePosition, _PlaneNormal);
			return dotProd1 >0;
		}
		fixed4 LightingNoLighting(SurfaceOutput s, fixed3 lightDir, fixed atten)
		{
			fixed4 c;
			c.rgb = s.Albedo;
			c.a = s.Alpha;
			return c;
		}

		void surf(Input IN, inout SurfaceOutput o)
		{
			if(!_Split)discard;
			if (checkVisability(IN.worldPos) || !_ShowBackSide)discard;
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			fixed4 hc = _HighlightColor;

			fixed4 result = (c* (1 - _HighlightAmount)) + (hc * _HighlightAmount);

			o.Albedo = result;
			o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap) *_NormScale);

			o.Specular = tex2D(_SpecMap, IN.uv_SpecMap) * _SpecScale;
			//o.Smoothness = _Glossiness;
			//o.Alpha = _Fade;
			o.Alpha = clamp(_Fade, 0, _MaxTransparacy);
			o.Emission = _EmissionColor.rgb * _Emission;


		}
		ENDCG

			

	}

	FallBack "Diffuse"
}
