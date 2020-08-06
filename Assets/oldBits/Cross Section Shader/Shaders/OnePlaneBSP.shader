Shader "CrossSection/OnePlaneBSP" {
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

		_NoiseTex("Noisetex",2D)= "noise" {}
		//_Offset("NoiseOffset",Vector) = (0,0,0,0)

		//_MinNoise("Min", Float) = 2.5
		_MaxNoise("Max", Float) = 2.51

		_NoiseSpeed("NoiseSpeed", Range(0,1)) = 1
		_NoiseSpread("NoiseSpread", Range(0,2)) = .5


		_DrawLine("DrawLine", Range(0,1)) = 0
		_LineColor("Cross Line Color", Color) = (1,1,1,1)

		_NegativeColor("Negative Space  Color", Color) = (0,0,0,0)
		_NegativeTrimColor("Negative Space TRIM Color", Color) = (0,0,0,0)
		_TrimVisability("Negative Space Trim amount ", Range(.29,1)) = .29


		_InsideNegativeColor("Inside Negative Space  Color", Color) = (0,0,0,0)
		_InsideColor("Inside  Color", Color) = (1,1,1,1)
		_UseAltInternalColor("Use alternative internal color ", Range(0,1)) = 0

		_FadeLength("FadeLength", Range(0,1)) = .5
		_FadeAmount("FadeAmount", Range(0,2)) = 1
			//_NoiseArray("NoiseArr", 2DArray )= ""{}
		//_YOffset("YOffset", Range(-1,1)) = 0
	}
	SubShader {
		Tags { "RenderType"="Transparent" "Queue" = "Transparent" }
		//ColorMask 0
		//LOD 200
		Blend SrcAlpha OneMinusSrcAlpha
		ColorMask RGBA
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
#pragma surface surf Standard fullforwardshadows keepalpha 

			// Use shader model 3.0 target, to get nicer looking lighting
#pragma target 3.0

			sampler2D _MainTex;
			sampler2D _BumpMap;
			sampler2D _SpecMap;
			sampler2D _NoiseTex;
		struct Input {
			float2 uv_MainTex;
			float2 uv_BumpMap;
			float2 uv_SpecMap;
			float3 worldPos;
			float2 uv_NoiseTex;
		};

		half _Glossiness;
		half _Metallic;
		half _SpecScale;
		half _NormScale;

		fixed4 _Offset;
		float _MinNoise;
		float _MaxNoise;

		fixed4 _Color;
		fixed4 _CrossColor;
		fixed3 _PlaneNormal;
		fixed3 _PlanePosition;

		float _FadeLength;

		float _NoiseSpeed;
		float _NoiseSpread;

		float _DrawLine;
		fixed4 _LineColor;

		fixed4 _NegativeColor;
		fixed4 _NegativeTrimColor;
		float _TrimVisability;
		float _FadeAmount;
		float UseNormal = 1;

		//float _YOffset;

		bool checkVisability(fixed3 worldPos)
		{
			_PlanePosition.y = _PlanePosition.y-.01;
			float dotProd1 = dot(worldPos - _PlanePosition, _PlaneNormal);
			return dotProd1 > 0  ;
		}
		bool CheckLineVisability(fixed3 worldPos)
		{
			_PlanePosition.y = _PlanePosition.y-.005 ;
			float dotProd1 = dot(worldPos - _PlanePosition, _PlaneNormal);
			return dotProd1 > 0  ;
		}
		bool CheckFadeVisability(fixed3 worldPos){
			_PlanePosition.y = _PlanePosition.y-(.1* _FadeLength) ;
			float dotProd1 = dot(worldPos - _PlanePosition, _PlaneNormal);
			return dotProd1 > 0  ;
		}
		float GetFadeAmount(fixed3 worldPos){
			_PlanePosition.y = _PlanePosition.y-(.02 * _FadeLength) ;
			float dotProd1 = dot(worldPos - _PlanePosition, _PlaneNormal);
			return dotProd1;
		}
		UNITY_DECLARE_TEX2DARRAY(_NoiseArray);
		void surf(Input IN, inout SurfaceOutputStandard o) {
			if (checkVisability(IN.worldPos))discard;//if above and true then dont show, end here
				fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
 			if(_DrawLine >.5 && CheckLineVisability(IN.worldPos)){//On Line
 					c = _LineColor;
					o.Alpha=1;
					UseNormal=0;
					o.Smoothness = 1 ;

 			}else if(CheckFadeVisability(IN.worldPos)){//On Fade
			//as we go further up, alpha down
			//135  97 74

				fixed4 noise = tex2D(_NoiseTex, IN.uv_NoiseTex );
				//c.b = c.b+(GetFadeAmount(IN.worldPos)*10);

				o.Alpha =c.a;

 				float p1 = tex2D(_NoiseTex, IN.uv_NoiseTex  + float2(_Time.y/ (800*_NoiseSpeed),0)).r;
				float p2 = tex2D(_NoiseTex, IN.uv_NoiseTex).g;
				float p3 = tex2D(_NoiseTex, IN.uv_NoiseTex).b;
				float p4 = tex2D(_NoiseTex, IN.uv_NoiseTex).a;
 
				float sum = p1+p2+p3+p4;
				float ScaledMax =  _MaxNoise + (GetFadeAmount(IN.worldPos)*(100 * _NoiseSpread))-1.1;

				
				if(sum >_MaxNoise && sum < ScaledMax ){
					if(sum < _MaxNoise + (_MaxNoise/10) || sum >  ScaledMax - (_MaxNoise/10)){
					//Green trim on noise
						c= _NegativeTrimColor;			
						o.Alpha =1-(GetFadeAmount(IN.worldPos)*(30*_TrimVisability));
					}else{
						c= _NegativeColor;
						o.Alpha =1-(GetFadeAmount(IN.worldPos)*10);
						//Gaps in fade area
					}
				}
			}else{//BelowFade/RegulareTexture
				o.Metallic = _Metallic;
				o.Smoothness = tex2D(_SpecMap, IN.uv_SpecMap) *(_Glossiness) ;
				o.Alpha = 1;
			}

			o.Albedo = c.rgb;

//if(UseNormal>.5)
				o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap) *_NormScale);


		}
		ENDCG
		
			Cull Front
			CGPROGRAM
#pragma surface surf NoLighting  noambient keepalpha
		struct Input {
			half2 uv_MainTex;
			float3 worldPos;
			half2 uv_SpecMap;
			half2 uv_BumpMap;

			float2 uv_NoiseTex;
		};
		sampler2D _MainTex;
		sampler2D _BumpMap;
		sampler2D _SpecMap;
		sampler2D _NoiseTex;
		half _SpecScale;
		half _NormScale;
		fixed4 _Color;
		fixed4 _CrossColor;
		fixed3 _PlaneNormal;
		fixed3 _PlanePosition;

		float _MinNoise;
		float _MaxNoise;

		fixed4 _InsideNegativeColor;
		fixed4 _InsideColor;
		float _UseAltInternalColor;
		

		//float _YOffset;

		bool checkVisability(fixed3 worldPos)
		{
			_PlanePosition.y = _PlanePosition.y-.02 ;
			float dotProd1 = dot(worldPos - _PlanePosition, _PlaneNormal);
			return dotProd1 > 0  ;
		}
		bool CheckLineVisability(fixed3 worldPos)
		{
			_PlanePosition.y = _PlanePosition.y-.015 ;
			float dotProd1 = dot(worldPos - _PlanePosition, _PlaneNormal);
			return dotProd1 > 0  ;
		}
		bool CheckFadeVisability(fixed3 worldPos){
			_PlanePosition.y = _PlanePosition.y-.05;
			float dotProd1 = dot(worldPos - _PlanePosition, _PlaneNormal);
			return dotProd1 > 0  ;
		}
		float GetFadeAmount(fixed3 worldPos){
			_PlanePosition.y = _PlanePosition.y-.01;
			float dotProd1 = dot(worldPos - _PlanePosition, _PlaneNormal);
			return dotProd1;
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
		

			if(CheckFadeVisability(IN.worldPos)){
				fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _CrossColor;
				fixed4 noise = tex2D(_NoiseTex, IN.uv_NoiseTex);
				//c.b = c.b+(GetFadeAmount(IN.worldPos)*10);

				o.Alpha =c.a;

 				float p1 = tex2D(_NoiseTex, IN.uv_NoiseTex  + float2(_Time.y/800,0)).r;
				float p2 = tex2D(_NoiseTex, IN.uv_NoiseTex).g;
				float p3 = tex2D(_NoiseTex, IN.uv_NoiseTex).b;
				float p4 = tex2D(_NoiseTex, IN.uv_NoiseTex).a;
 
				float sum = p1+p2+p3+p4;
				float ScaledMax =  _MaxNoise + (GetFadeAmount(IN.worldPos)*50)-1.1;

				if(sum >_MaxNoise && sum < ScaledMax ){
					if(sum < _MaxNoise + (_MaxNoise/10) || sum >  ScaledMax - (_MaxNoise/10)){
						//c.b = 0;
						////c.r = 1;
						//c.g =0-(GetFadeAmount(IN.worldPos)*15);
						//c.a = 0;
						//o.Alpha =1-(GetFadeAmount(IN.worldPos)*15);
						if(_UseAltInternalColor > .5)
							c = _InsideNegativeColor;
						o.Alpha = 0;
					}else{
						c=_InsideColor;
						o.Alpha =1-(GetFadeAmount(IN.worldPos)*15);
						o.Alpha = 0;
					}
				}

				o.Albedo = c.rgb ;
				o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap) *_NormScale);


			}else{
				o.Albedo = _CrossColor;
			}	

			o.Alpha = 0;

			
		}
			ENDCG
		
	}
	//FallBack "Diffuse"
}
