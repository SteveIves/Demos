/// <class>PinchEffect</class>
/// <namespace>Shazzam.Shaders</namespace>
/// <description>An effect that pinches a circular region.</description>

//-----------------------------------------------------------------------------------------
// Shader constant register mappings (scalars - float, double, Point, Color, Point3D, etc.)
//-----------------------------------------------------------------------------------------

/// <summary>The radius of the pinched region.</summary>
/// <minValue>0</minValue>
/// <maxValue>1</maxValue>
/// <defaultValue>0.25</defaultValue>
float X : register(C0);

/// <summary>The radius of the pinched region.</summary>
/// <minValue>0</minValue>
/// <maxValue>1</maxValue>
/// <defaultValue>0.25</defaultValue>
float Y : register(C1);

/// <summary>The radius of the pinched region.</summary>
/// <minValue>0</minValue>
/// <maxValue>1</maxValue>
/// <defaultValue>0.25</defaultValue>
float Radius : register(C2);

/// <summary>The strength of the effect.</summary>
/// <minValue>0</minValue>
/// <maxValue>2</maxValue>
/// <defaultValue>1</defaultValue>
float Strength : register(C3);

/// <summary>The aspect ratio (width / height) of the input.</summary>
/// <minValue>0.5</minValue>
/// <maxValue>2</maxValue>
/// <defaultValue>1.5</defaultValue>
float AspectRatio : register(C4);

//--------------------------------------------------------------------------------------
// Sampler Inputs (Brushes, including ImplicitInput)
//--------------------------------------------------------------------------------------

sampler2D implicitInputSampler : register(S0);


//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float2 dir = float2(X,Y) - uv;
    float2 scaledDir = dir;
    scaledDir.y /= AspectRatio;
    float dist = length(scaledDir);
    float range = saturate(1 - (dist / (abs(-sin(Radius * 8) * Radius) + 0.00000001F)));
    float2 samplePoint = uv + dir * range * Strength;
    return tex2D(implicitInputSampler, samplePoint);
}


