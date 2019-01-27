Shader "Custom/ShapeLand"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _xColor ("X Color", Color) = (1,1,1,1)
        _zColor ("Z Color", Color) = (1,1,1,1)
        _emissiveStr ("_emissiveStr", Range(0, 1)) = 0.3

        _topFadeY ("TopFade", Range(-10, 100)) = 0
        _bottomFadeY ("BottomFade", Range(-10, 100)) = 1
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0

        
		_MainTex ("Sparkle", 2D) = "white" {}
        _scale ("sparkle scale", Range(0, 100)) = 1
        _sparkleIntensity ("sparkle intensity", Range(0, 2)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows 

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        struct Input
        {
            float2 uv_MainTex;
            float3 worldNormal;
            float3 worldPos;
            float3 worldRefl;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
        fixed4 _xColor;
        fixed4 _zColor;
        half _topFadeY;
        half _bottomFadeY;
        half _emissiveStr;
        float _scale;
        float _sparkleIntensity;

        sampler2D _MainTex;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = float4(.5, .5, .5 ,1);


            float first =  dot( normalize(float3(0.5, 0, -0.5)), IN.worldNormal);
            float second = dot( normalize(float3(0.5, 0, 0.5)), IN.worldNormal);
            float remainder = 1 - clamp(first + second, 0, 1);

            float2 uv = IN.worldPos.xz * _scale;
            float sparkle = tex2D(_MainTex, uv).r * remainder * _sparkleIntensity * clamp(dot(float3(0, 1, 0), IN.worldNormal), 0, 1);

           sparkle = sparkle * abs(sin(IN.worldPos.x + _Time[3]));

            // Make the ground sparkle based on the dot product of the viewing angle onto this surface AND the light direction (which is hardcoded here)
          //  float sparkleAmount =  (1- abs(dot(IN.worldRefl, float3(0.5, 0.5, 0))) );
            //sparkle = sparkle * sparkleAmount;

            float3 emission =  _xColor * first
                             + _zColor * second
                             + _Color * remainder;

//                             emission = float3(1, 0, 0);

            c = float4(emission.rgb, 1);

            float s = (IN.worldPos.y - _bottomFadeY) / (_topFadeY - _bottomFadeY);
            c *= 1 - clamp(s * 0.4 + 0.6, 0, 1);

            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;

            _emissiveStr = _emissiveStr + sparkle * _emissiveStr;

            o.Emission = emission *_emissiveStr ;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
