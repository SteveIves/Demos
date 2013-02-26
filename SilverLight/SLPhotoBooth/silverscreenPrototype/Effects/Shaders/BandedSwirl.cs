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
    public class BandedSwirl : ShaderEffect
    {
        private static PixelShader m_Shader = new PixelShader() { UriSource = new Uri("/silverscreenPrototype;component/Effects/Shaders/BandedSwirl.ps", UriKind.RelativeOrAbsolute) };

        public BandedSwirl()
        {
            PixelShader = m_Shader;
            UpdateShaderValue(InputProperty);
            UpdateShaderValue(BandsProperty);
            UpdateShaderValue(StrengthProperty);
            UpdateShaderValue(AspectRatioProperty);
            UpdateShaderValue(OffsetProperty);
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

        public float Bands
        {
            get
            {
                return (float)GetValue(BandsProperty);
            }
            set
            {
                SetValue(BandsProperty, value);
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

        public float Offset
        {
            get
            {
                return (float)GetValue(OffsetProperty);
            }
            set
            {
                SetValue(OffsetProperty, value);
            }
        }

        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(BandedSwirl), 0);


        public static readonly DependencyProperty BandsProperty = DependencyProperty.Register("Bands", typeof(float), typeof(BandedSwirl), new PropertyMetadata(0.25f, PixelShaderConstantCallback(0)));
        public static readonly DependencyProperty StrengthProperty = DependencyProperty.Register("Strength", typeof(float), typeof(BandedSwirl), new PropertyMetadata(0.25f, PixelShaderConstantCallback(1)));
        public static readonly DependencyProperty AspectRatioProperty = DependencyProperty.Register("AspectRatio", typeof(float), typeof(BandedSwirl), new PropertyMetadata(1.5f, PixelShaderConstantCallback(2)));
        public static readonly DependencyProperty OffsetProperty = DependencyProperty.Register("Offset", typeof(float), typeof(BandedSwirl), new PropertyMetadata(0.25f, PixelShaderConstantCallback(3)));
    }
}
