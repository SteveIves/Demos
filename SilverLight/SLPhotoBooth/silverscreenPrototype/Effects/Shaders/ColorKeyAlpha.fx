float4 ColorKey : register(C0);
float Threshold : register(C1);
sampler2D Input : register(s0);

float4 main(float2 uv : TEXCOORD):COLOR
{
	float4 color = tex2D(Input, uv.xy);
	
	float3 diff = abs(color.rgb - ColorKey.rgb);
	if (all(diff < Threshold)) {
      color *= (diff.r+diff.g+diff.b)/3/Threshold;
   }
   
	return color;
}
