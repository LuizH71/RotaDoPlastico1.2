Shader "Custom/IsometricWaterShader"
{
    Properties
    {
        _MainTex("Base Texture", 2D) = "white" {}
        _Color("Color", Color) = (1, 1, 1, 1)
        _ScrollSpeed("Scroll Speed", Range(0, 10)) = 1
        _Tiling("Tiling", Vector) = (1, 1, 0, 0)
    }
        SubShader
        {
            Tags { "RenderType" = "Opaque" }
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
                    float4 pos : POSITION;
                    float2 uv : TEXCOORD0;
                };

                sampler2D _MainTex;
                float4 _MainTex_ST;
                float4 _Color;
                float _ScrollSpeed;
                float2 _Tiling;

                v2f vert(appdata_t v)
                {
                    v2f o;
                    o.pos = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv * _Tiling.xy + _MainTex_ST.xy;
                    o.uv.y += _Time.y * _ScrollSpeed; // Scroll effect
                    return o;
                }

                half4 frag(v2f i) : SV_Target
                {
                    half4 col = tex2D(_MainTex, i.uv) * _Color;
                    return col;
                }
                ENDCG
            }
        }
            FallBack "Diffuse"
}
