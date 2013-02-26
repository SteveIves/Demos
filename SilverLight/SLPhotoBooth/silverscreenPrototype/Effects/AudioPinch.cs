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
    public class AudioPinch : SilverScreenEffect
    {
        DateTime m_StartTime = DateTime.Now;
        Slider m_Volume;
        Slider m_Sensitivity;
        Slider m_Strength;
        Slider m_Noise;
        CheckBox m_Invert;
        VolumeCapture m_VolumeCapture;

        private Effects.Shaders.Pinch m_PinchEffect;
        public AudioPinch()
        {
            Name = "Audio Bulge";
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
                },
                new EffectSettingGroup
                {
                    Settings = new EffectSetting[]
                    {
                        new EffectSetting()
                        {
                             Control = new Slider{ Maximum = 1.0, Minimum = 0.0 },
                             Name = "Volume"
                        },
                        new EffectSetting()
                        {
                             Control = new Slider{ Maximum = 10.0, Minimum = 0.1, Value = 1.0 },
                             Name = "Sensitivity"
                        },
                        new EffectSetting()
                        {
                             Control = new CheckBox{ Content = ""},
                             Name = "Invert"
                        },
                        new EffectSetting()
                        {
                             Control = new Slider{ Maximum = 1.0, Minimum = 0.0, Value = 0.0 },
                             Name = "Noise Lvl"
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

            m_Volume = EffectSettings[2].Settings[0].Control as Slider;
            m_Sensitivity = EffectSettings[2].Settings[1].Control as Slider;
            m_Strength = EffectSettings[1].Settings[1].Control as Slider;
            m_Invert = EffectSettings[2].Settings[2].Control as CheckBox;
            m_Noise = EffectSettings[2].Settings[3].Control as Slider;
            Storyboard updater = new Storyboard();
            updater.Completed += new EventHandler(OnFrameRendered);
            updater.Begin();

            m_VolumeCapture = new VolumeCapture();
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
            base.OnDisplayMouseDown(point);
        }

        public override void OnDisplayMouseDrag(Point point)
        {
            m_PinchEffect.X = (float)point.X;
            m_PinchEffect.Y = (float)point.Y;
            base.OnDisplayMouseDrag(point);
        }

        void OnFrameRendered(object sender, EventArgs e)
        {
            (sender as Storyboard).Begin();

            if (Shader == null)
            {
                m_VolumeCapture.CaptureSource = null;
                return;
            }
            if (m_VolumeCapture.CaptureSource == null)
            {
                m_VolumeCapture.CaptureSource = Main.MediaSource;
            }
            double volume = m_VolumeCapture.Volume * m_Sensitivity.Value;
            double scaledVolume = m_Noise.Value == 1.0 ? 0 : Math.Max(0,(volume - m_Noise.Value)) * (1.0 / (1.0 - m_Noise.Value));
            double volumeNormal = scaledVolume * (m_Invert.IsChecked == true ? m_Strength.Minimum :  m_Strength.Maximum);
            m_Strength.Value += (volumeNormal - m_Strength.Value) / 10.0;
            //System.Diagnostics.Debug.WriteLine(volumeNormal);
            m_Volume.Value = scaledVolume;
        }
    }
}
