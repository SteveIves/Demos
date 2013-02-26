using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Effects;

namespace silverscreenPrototype.Effects.Shaders
{
    public class Pinch : ShaderEffect
    {
        private static PixelShader m_Shader = new PixelShader() { UriSource = new Uri("/silverscreenPrototype;component/Effects/Shaders/Pinch.ps", UriKind.RelativeOrAbsolute) };

        public Pinch()
        {
            PixelShader = m_Shader;
            UpdateShaderValue(InputProperty);
            UpdateShaderValue(XProperty);
            UpdateShaderValue(YProperty);
            UpdateShaderValue(RadiusProperty);
            UpdateShaderValue(StrengthProperty);
            UpdateShaderValue(AspectRatioProperty);
        }

        public Brush Input
        {
            get
            {
                return (Brush)GetValue(InputProperty);
            }
            set
            {
                SetValue(InputProperty, value);
            }
        }

        public float Radius
        {
            get
            {
                return (float)GetValue(RadiusProperty);
            }
            set
            {
                SetValue(RadiusProperty, value);
            }
        }

        public float Strength
        {
            get
            {
                return (float)GetValue(StrengthProperty);
            }
            set
            {
                SetValue(StrengthProperty, value);
            }
        }

        public float AspectRatio
        {
            get
            {
                return (float)GetValue(AspectRatioProperty);
            }
            set
            {
                SetValue(AspectRatioProperty, value);
            }
        }

        public float X
        {
            get
            {
                return (float)GetValue(XProperty);
            }
            set
            {
                SetValue(XProperty, value);
            }
        }

        public float Y
        {
            get
            {
                return (float)GetValue(YProperty);
            }
            set
            {
                SetValue(YProperty, value);
            }
        }

        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(Pinch), 0);


        public static readonly DependencyProperty XProperty = DependencyProperty.Register("X", typeof(float), typeof(Pinch), new PropertyMetadata(-10.25f, PixelShaderConstantCallback(0)));
        public static readonly DependencyProperty YProperty = DependencyProperty.Register("Y", typeof(float), typeof(Pinch), new PropertyMetadata(-10.25f, PixelShaderConstantCallback(1)));
        public static readonly DependencyProperty RadiusProperty = DependencyProperty.Register("Radius", typeof(float), typeof(Pinch), new PropertyMetadata(0.4f, PixelShaderConstantCallback(2)));
        public static readonly DependencyProperty StrengthProperty = DependencyProperty.Register("Strength", typeof(float), typeof(Pinch), new PropertyMetadata(0.0f, PixelShaderConstantCallback(3)));
        public static readonly DependencyProperty AspectRatioProperty = DependencyProperty.Register("AspectRatio", typeof(float), typeof(Pinch), new PropertyMetadata(1.5f, PixelShaderConstantCallback(4)));
    }
}
