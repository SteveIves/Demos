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

namespace silverscreenPrototype
{
    public class ColorKeyAlpha : ShaderEffect
    {
        private static PixelShader m_Shader = new PixelShader() { UriSource = new Uri("/silverscreenPrototype;component/Effects/Shaders/ColorKeyAlpha.ps", UriKind.RelativeOrAbsolute) };

        public ColorKeyAlpha()
        {
            PixelShader = m_Shader;
            UpdateShaderValue(InputProperty);
            UpdateShaderValue(BackgroundProperty);
            UpdateShaderValue(ThresholdProperty);
            UpdateShaderValue(ColorKeyProperty);
            //UpdateShaderValue(WidthProperty);
            //UpdateShaderValue(HeightProperty);
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

        public Brush Background
        {
            get
            {
                return (Brush)GetValue(BackgroundProperty);
            }
            set
            {
                SetValue(BackgroundProperty, value);
            }
        }

        public Color ColorKey
        {
            get 
            { 
                return (Color)GetValue(ColorKeyProperty); 
            }
            set 
            { 
                SetValue(ColorKeyProperty, value); 
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

        //public float Width
        //{
        //    get
        //    {
        //        return (float)GetValue(WidthProperty);
        //    }
        //    set
        //    {
        //        SetValue(WidthProperty, value);
        //    }
        //}

        //public float Height
        //{
        //    get
        //    {
        //        return (float)GetValue(HeightProperty);
        //    }
        //    set
        //    {
        //        SetValue(HeightProperty, value);
        //    }
        //}

        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(ColorKeyAlpha), 0);

        public static readonly DependencyProperty BackgroundProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Background", typeof(ColorKeyAlpha), 1);

        public static readonly DependencyProperty ColorKeyProperty = DependencyProperty.Register("ColorKey", typeof(Color), typeof(ColorKeyAlpha), new PropertyMetadata(Colors.Green, PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty ThresholdProperty = DependencyProperty.Register("Threshold", typeof(float), typeof(ColorKeyAlpha), new PropertyMetadata(0.1f, PixelShaderConstantCallback(1)));
        //public static readonly DependencyProperty WidthProperty = DependencyProperty.Register("Width", typeof(float), typeof(ColorKeyAlpha), new PropertyMetadata(0.1f, PixelShaderConstantCallback(2)));
        //public static readonly DependencyProperty HeightProperty = DependencyProperty.Register("Height", typeof(float), typeof(ColorKeyAlpha), new PropertyMetadata(0.1f, PixelShaderConstantCallback(3)));
    }
}
