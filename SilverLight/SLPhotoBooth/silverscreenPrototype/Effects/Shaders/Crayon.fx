//-----------------------------------------------------------------------------------------
// Shader constant register mappings (scalars - float, double, Point, Color, Point3D, etc.)
//-----------------------------------------------------------------------------------------

/// <summary>Width of the input.</summary>
/// <minValue>1</minValue>
/// <maxValue>1024</maxValue>
/// <defaultValue>700</defaultValue>
float Width : register(C0);

/// <summary>Height of the input.</summary>
/// <minValue>1</minValue>
/// <maxValue>1024</maxValue>
/// <defaultValue>400</defaultValue>
float Height : register(C1);

/// <summary>Height of the input.</summary>
/// <minValue>0</minValue>
/// <maxValue>1</maxValue>
/// <defaultValue>0.5</defaultValue>
float Threshold : register(C2);

//--------------------------------------------------------------------------------------
// Sampler Inputs (Brushes, including ImplicitInput)
//--------------------------------------------------------------------------------------

sampler2D Input : register(S0);

static float kernel[9] = 
{ 
	1.0, 0.0, -1.0,
	2.0, 0.0, -2.0,
	1.0, 0.0, -1.0 
};

static float threshSq = Threshold*Threshold;
static float xNeighbor = 1.0/Width;
static float yNeighbor = 1.0/Height;
static float2 offsets[9] = 
	{
		float2(-xNeighbor, -yNeighbor),	float2(0.0, -yNeighbor),	float2(xNeighbor, -yNeighbor),
		float2(-xNeighbor, 0.0), 		float2(0.0, 0.0),			float2(xNeighbor, 0.0), 
		float2(-xNeighbor, yNeighbor),	float2(0.0, yNeighbor),		float2(xNeighbor, yNeighbor) 
	};

float4 main(float2 uv : TEXCOORD) : COLOR
{
	
	float4 sum = 0;
	for( int i=0; i<9; i++ )
	{
			sum += tex2D(Input, uv + offsets[i]) * kernel[i];
	}
	
	float4 sq = sum*sum;
	float4 edge = 1 - float4(sq.r <= threshSq, sq.g <= threshSq, sq.b <= threshSq, 0);
    return edge;
}


