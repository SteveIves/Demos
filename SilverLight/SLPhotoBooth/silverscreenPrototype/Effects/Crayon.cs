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
using System.Windows.Data;

namespace silverscreenPrototype.Effects
{
    public class Crayon : SilverScreenEffect
    {
        private Effects.Shaders.Crayon m_CrayonEffect;
        public Crayon()
        {
            Name = "Crayon";
            ShaderEffect = m_CrayonEffect = new Effects.Shaders.Crayon();

            EffectSettings = new EffectSettingGroup[]
            {
                new EffectSettingGroup
                {
                    Settings = new EffectSetting[]
                    {
                        new EffectSetting()
                        {
                             Control = new Slider{ Maximum = 1.0, Minimum = 0.0 },
                             Name = "Threshold"
                        }
                    }
                }
            };

            Binding binding = new Binding("Threshold");
            binding.Source = m_CrayonEffect;
            binding.Mode = BindingMode.TwoWay;
            EffectSettings[0].Settings[0].Control.SetBinding(Slider.ValueProperty, binding);

        }

        public override void ResetDefaults()
        {
            m_CrayonEffect.Threshold = 0.5f;
        }


        private float m_InputWidth;
        public float InputWidth
        {
            get
            {
                return m_InputWidth;
            }
            set
            {
                if (m_InputWidth == value)
                {
                    return;
                }
                m_InputWidth = value;

                m_CrayonEffect.Width = value;
                NotifyPropertyChanged("InputWidth");
            }
        }

        private float m_InputHeight;
        public float InputHeight
        {
            get
            {
                return m_InputHeight;
            }
            set
            {
                if (m_InputHeight == value)
                {
                    return;
                }
                m_InputHeight = value;
                
                m_CrayonEffect.Height = value;
                NotifyPropertyChanged("InputHeight");
            }
        }
    }
}
