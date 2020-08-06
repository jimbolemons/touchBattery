﻿Shader "CrossSection/SimpleOnePlaneBSP" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_CrossColor("Cross Section Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
		_PlaneNormal("PlaneNormal",Vector) = (0,1,0,0)
		_PlanePosition("PlanePosition",Vector) = (0,0,0,1)
		_StencilMask("Stencil Mask", Range(0, 255)) = 255
		_BumpMap("Bumpmap", 2D) = "bump" {}
		_NormScale("_NormScale", Range(0,1)) = 0.0
		
		_SpecMap("Specmap",2D) = "spec" {}
		_SpecScale("SpecScale", Range(0,1)) = 0.0
		
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		//LOD 200
		Stencil
		{
			Ref [_StencilMask]
			CompBack Always
			PassBack Replace

			CompFront Always
			PassFront Zero
		}
		Cull Back
			CGPROGRAM
			// Physically based Standard lighting model, and enable shadows on all light types
#pragma surface surf Standard fullforwardshadows

			// Use shader model 3.0 target, to get nicer looking lighting
#pragma target 3.0

			sampler2D _MainTex;
			sampler2D _BumpMap;
			sampler2D _SpecMap;
		struct Input {
			float2 uv_MainTex;
			float2 uv_BumpMap;
			float2 uv_SpecMap;
			float3 worldPos;
		};

		half _Glossiness;
		half _Metallic;
		half _SpecScale;
		half _NormScale;
		fixed4 _Color;
		fixed4 _CrossColor;
		fixed3 _PlaneNormal;
		fixed3 _PlanePosition;
		bool checkVisability(fixed3 worldPos)
		{
			float dotProd1 = dot(worldPos - _PlanePosition, _PlaneNormal);
			return dotProd1 > 0  ;
		}
		void surf(Input IN, inout SurfaceOutputStandard o) {
			if (checkVisability(IN.worldPos))discard;
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			//o.Specular = tex2D(_SpecMap, IN.uv_SpecMap);
			o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap) *_NormScale);
			// Metallic and smoothness come from slider variables
			//o.Metallic = _Metallic;
			//o.Metallic = tex2D(_SpecMap, IN.uv_SpecMap);
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
		
			Cull Front
			CGPROGRAM
#pragma surface surf NoLighting  noambient

		struct Input {
			half2 uv_MainTex;
			float3 worldPos;
			half2 uv_SpecMap;
			half2 uv_BumpMap;
		};
		sampler2D _MainTex;
		sampler2D _BumpMap;
		sampler2D _SpecMap;
		half _SpecScale;
		half _NormScale;
		fixed4 _Color;
		fixed4 _CrossColor;
		fixed3 _PlaneNormal;
		fixed3 _PlanePosition;
		bool checkVisability(fixed3 worldPos)
		{
			float dotProd1 = dot(worldPos - _PlanePosition, _PlaneNormal);
			return dotProd1 >0 ;
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
			if (checkVisability(IN.worldPos))discard;
			o.Albedo = _CrossColor;
			//o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap) * _NormScale);
			//o.Specular = tex2D(_SpecMap, IN.uv_SpecMap)*_SpecScale;
			
		}
			ENDCG
		
	}
	//FallBack "Diffuse"
}
