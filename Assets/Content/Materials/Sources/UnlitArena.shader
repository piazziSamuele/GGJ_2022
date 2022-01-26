Shader "Unlit/UnlitArena"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _Tint("Tint", Color) = (1,1,1,1)
        _GridOffset("Grid Offset", float) = 0
        _GridOffsetSpeed("Grid Offset Speed", float) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST, _Tint;
            float _GridOffset, _GridOffsetSpeed;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed grid_one = (1 - tex2D(_MainTex, i.uv).r )* _Tint.r;
                fixed grid_two = (1 - tex2D(_MainTex, i.uv + float2(_GridOffset + (_Time.x * _GridOffsetSpeed),0)).r) * _Tint.g;
                fixed grid_three = (1 - tex2D(_MainTex, i.uv + float2(0, _GridOffset + (_Time.x * _GridOffsetSpeed))).r) * _Tint.b;

                float4 col = float4(grid_one, grid_two, grid_three, 1) * _Tint.a;

                
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
