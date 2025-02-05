Shader "Custom/MagnifyShader"
{
    Properties
    {
        _MainTex ("Render Texture", 2D) = "white" {}
        _MagnifyStrength ("Magnify Strength", Range(0, 2)) = 1.2
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _MagnifyStrength;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                
                // Modify UVs to create a magnification effect
                float2 center = float2(0.5, 0.5);
                float2 offset = v.uv - center;
                o.uv = center + offset * _MagnifyStrength;
                
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                return tex2D(_MainTex, i.uv);
            }
            ENDCG
        }
    }
}