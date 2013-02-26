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
    public class Crayon : ShaderEffect
    {
        private static PixelShader m_Shader = new PixelShader() { UriSource = new Uri("/silverscreenPrototype;component/Effects/Shaders/Crayon.ps", UriKind.RelativeOrAbsolute) };

        public Crayon()
        {
            PixelShader = m_Shader;
            UpdateShaderValue(InputProperty);
            UpdateShaderValue(WidthProperty);
            UpdateShaderValue(ThresholdProperty);
            UpdateShaderValue(HeightProperty);
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

        public float Threshold
        {
            get
            {
                return (float)GetValue(ThresholdProperty);
            }
            set
            {
                SetValue(ThresholdProperty, value);
            }
        }

        public float Width
        {
            get
            {
                return (float)GetValue(WidthProperty);
            }
            set
            {
                SetValue(WidthProperty, value);
            }
        }

        public float Height
        {
            get
            {
                return (float)GetValue(HeightProperty);
            }
            set
            {
                SetValue(HeightProperty, value);
            }
        }


        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(Crayon), 0);

        public static readonly DependencyProperty WidthProperty = DependencyProperty.Register("Width", typeof(float), typeof(Crayon), new PropertyMetadata(320.0f, PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty HeightProperty = DependencyProperty.Register("Height", typeof(float), typeof(Crayon), new PropertyMetadata(240.0f, PixelShaderConstantCallback(1)));


        public static readonly DependencyProperty ThresholdProperty = DependencyProperty.Register("Threshold", typeof(float), typeof(Crayon), new PropertyMetadata(0.5f, PixelShaderConstantCallback(2)));
    }
}
