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
    public class Embossed : ShaderEffect
    {
        private static PixelShader m_Shader = new PixelShader() { UriSource = new Uri("/silverscreenPrototype;component/Effects/Shaders/Embossed.ps", UriKind.RelativeOrAbsolute) };

        public Embossed()
        {
            PixelShader = m_Shader;
            UpdateShaderValue(InputProperty);
            UpdateShaderValue(AmountProperty);
            UpdateShaderValue(WidthProperty);
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

        public float Amount
        {
            get
            {
                return (float)GetValue(AmountProperty);
            }
            set
            {
                SetValue(AmountProperty, value);
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
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(Embossed), 0);


        public static readonly DependencyProperty AmountProperty = DependencyProperty.Register("Amount", typeof(float), typeof(Embossed), new PropertyMetadata(0.5f, PixelShaderConstantCallback(0)));
        public static readonly DependencyProperty WidthProperty = DependencyProperty.Register("Width", typeof(float), typeof(Embossed), new PropertyMetadata(0.003f, PixelShaderConstantCallback(1)));
    }
}
