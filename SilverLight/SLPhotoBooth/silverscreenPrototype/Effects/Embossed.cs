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
    public class Embossed : SilverScreenEffect
    {
        private Effects.Shaders.Embossed m_EmbossedEffect;
        public Embossed()
        {
            Name = "Embossed";
            ShaderEffect = m_EmbossedEffect = new Effects.Shaders.Embossed();

            EffectSettings = new EffectSettingGroup[]
            {
                new EffectSettingGroup
                {
                    Settings = new EffectSetting[]
                    {
                        new EffectSetting()
                        {
                             Control = new Slider{ Maximum = 1.0, Minimum = 0.0 },
                             Name = "Amount"
                        },
                        new EffectSetting()
                        {
                            Control = new Slider{ Maximum = 0.01, Minimum = 0.0 },
                             Name = "Width"
                        }
                    }
                }
            };

            Binding binding = new Binding("Amount");
            binding.Source = m_EmbossedEffect;
            binding.Mode = BindingMode.TwoWay;
            EffectSettings[0].Settings[0].Control.SetBinding(Slider.ValueProperty, binding);

            binding = new Binding("Width");
            binding.Source = m_EmbossedEffect;
            binding.Mode = BindingMode.TwoWay;
            EffectSettings[0].Settings[1].Control.SetBinding(Slider.ValueProperty, binding);
        }

        public override void ResetDefaults()
        {
            m_EmbossedEffect.Amount = 0.5f;
            m_EmbossedEffect.Width = 0.003f;
        }

    }
}
