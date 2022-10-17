Shader "GlassCube"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _BumpMap("NormalMap", 2D) = "bump" {}
        _CubeMap("CubeMap", Cube) = "Skybox"{}
        _Distortion("Distortion", Range(0,100)) = 10
        _RefractAmount("RefractAmount", Range(0,1)) = 0.3
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Opaque" }
        GrabPass { "_RefractionTex" }
        Pass
        {
        CGPROGRAM
        #pragma vertex vert
        #pragma fragment frag
        #include "UnityCG.cginc"

        sampler2D _MainTex;
        float4 _MainTex_ST;
        sampler2D _BumpMap;
        float4 _BumpMap_ST;
        samplerCUBE _CubeMap;
        float _Distortion;
        float _RefractAmount;
        sampler2D _RefractionTex;
        float4 _RefractionTex_TexelSize;

        struct appdata
        {
            float4 vertex : POSITION;
            float4 tangent : TANGENT;
            float3 normal : NORMAL;
            float2 uv : TEXCOORD0;
        };

        struct v2f
        {
            float4 pos : SV_POSITION;
            float4 scrPos : TEXCOORD0;
            float4 uv : TEXCOORD1;
            float4 TtoW0 : TEXCOORD2;
            float4 TtoW1 : TEXCOORD3;
            float4 TtoW2 : TEXCOORD4;
        };

        v2f vert(appdata v)
        {
            v2f o;
            o.pos = UnityObjectToClipPos(v.vertex);
            o.scrPos = ComputeGrabScreenPos(o.pos);
            o.uv.xy = TRANSFORM_TEX(v.uv, _MainTex);
            o.uv.zw = TRANSFORM_TEX(v.uv, _BumpMap);
            float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
            float3 worldNormal = UnityObjectToWorldNormal(v.normal);
            float3 worldTangent = UnityObjectToWorldDir(v.tangent.xyz);
            float3 worldBinormal = cross(worldNormal, worldTangent) * v.tangent.w;
            o.TtoW0 = float4(worldTangent.x, worldBinormal.x, worldNormal.x, worldPos.x);
            o.TtoW1 = float4(worldTangent.y, worldBinormal.y, worldNormal.y, worldPos.y);
            o.TtoW2 = float4(worldTangent.z, worldBinormal.z, worldNormal.z, worldPos.z);
            return o;
        }
        float4 frag(v2f i) : SV_Target
        {
            float3 worldPos = float3(i.TtoW0.w,i.TtoW1.w,i.TtoW2.w);
            float3 worldViewDir = normalize(UnityWorldSpaceViewDir(worldPos));
            float3 bump = UnpackNormal(tex2D(_BumpMap, i.uv.zw));
            float2 offset = bump.xy * _Distortion * _RefractionTex_TexelSize.xy;
            i.scrPos.xy = offset * i.scrPos.z + i.scrPos.xy;
            float3 refrCol = tex2D(_RefractionTex, i.scrPos.xy / i.scrPos.w).rgb;
            bump = normalize(float3(dot(i.TtoW0.xyz, bump), dot(i.TtoW1.xyz, bump), dot(i.TtoW2.xyz, bump)));
            float3 reflDir = reflect(-worldViewDir, bump);
            float4 texColor = tex2D(_MainTex, i.uv.xy);
            float3 reflCol = texCUBE(_CubeMap, reflDir).rgb * texColor.rgb;
            float3 finalColor = reflCol * (1 - _RefractAmount) + refrCol * _RefractAmount;
            return float4(finalColor, 1);
        }
        ENDCG
        }
    }
    FallBack "Diffuse"
}
