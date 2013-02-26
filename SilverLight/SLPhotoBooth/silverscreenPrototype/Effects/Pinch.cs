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
    public class Pinch : SilverScreenEffect
    {
        private Effects.Shaders.Pinch m_PinchEffect;
        public Pinch()
        {
            Name = "Bulge";
            ShaderEffect = m_PinchEffect = new Effects.Shaders.Pinch();

            EffectSettings = new EffectSettingGroup[]
            {
                new EffectSettingGroup
                {
                    Settings = new EffectSetting[]
                    {
                        new EffectSetting()
                        {
                             Control = new Slider{ Maximum = 1.0, Minimum = 0.0 },
                             Name = "X"
                        },
                        new EffectSetting()
                        {
                            Control = new Slider{ Maximum = 1.0, Minimum = 0.0 },
                             Name = "Y"
                        }
                    }
                },
                new EffectSettingGroup
                {
                    Settings = new EffectSetting[]
                    {
                        new EffectSetting()
                        {
                             Control = new Slider{ Maximum = 1.0, Minimum = 0.0 },
                             Name = "Radius"
                        },
                        new EffectSetting()
                        {
                            Control = new Slider{ Maximum = 2.0, Minimum = -2.0 },
                             Name = "Strength"
                        },
                        new EffectSetting()
                        {
                            Control = new Slider{ Maximum = 2.0, Minimum = 0.5 },
                             Name = "Aspect"
                        }
                    }
                }
            };

            Binding binding = new Binding("X");
            binding.Source = m_PinchEffect;
            binding.Mode = BindingMode.TwoWay;
            EffectSettings[0].Settings[0].Control.SetBinding(Slider.ValueProperty, binding);

            binding = new Binding("Y");
            binding.Source = m_PinchEffect;
            binding.Mode = BindingMode.TwoWay;
            EffectSettings[0].Settings[1].Control.SetBinding(Slider.ValueProperty, binding);

            binding = new Binding("Radius");
            binding.Source = m_PinchEffect;
            binding.Mode = BindingMode.TwoWay;
            EffectSettings[1].Settings[0].Control.SetBinding(Slider.ValueProperty, binding);

            binding = new Binding("Strength");
            binding.Source = m_PinchEffect;
            binding.Mode = BindingMode.TwoWay;
            EffectSettings[1].Settings[1].Control.SetBinding(Slider.ValueProperty, binding);

            binding = new Binding("AspectRatio");
            binding.Source = m_PinchEffect;
            binding.Mode = BindingMode.TwoWay;
            EffectSettings[1].Settings[2].Control.SetBinding(Slider.ValueProperty, binding);
        }

        public override void ResetDefaults()
        {
            m_PinchEffect.AspectRatio = 1.5f;
            m_PinchEffect.Strength = 1.0f;
            m_PinchEffect.Radius = 0.25f;
            //m_PinchEffect.Y = 0.25f;
            //m_PinchEffect.X = 0.25f;
        }


        public override void OnDisplayMouseDown(Point point)
        {
            m_PinchEffect.X = (float)point.X;
            m_PinchEffect.Y = (float)point.Y;
            if (m_PinchEffect.Strength == 0)
            {
                m_PinchEffect.Strength = 1;
            }
            base.OnDisplayMouseDown(point);
        }

        public override void OnDisplayMouseDrag(Point point)
        {
            m_PinchEffect.X = (float)point.X;
            m_PinchEffect.Y = (float)point.Y;
            base.OnDisplayMouseDrag(point);
        }
    }
}
