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

namespace silverscreenPrototype.Effects
{
    public class AudioSwirl : SilverScreenEffect
    {
        private Effects.Shaders.BandedSwirl m_SwirlEffect;
        double m_VolumeAccumulator;
        double m_Offset;
        public AudioSwirl()
        {
            Name = "Audio Swirl";
            ShaderEffect = m_SwirlEffect = new Effects.Shaders.BandedSwirl();

            EffectSettings = new EffectSettingGroup[]
            {
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
                        }
                    }
                }
            };

            m_Volume = EffectSettings[0].Settings[0].Control as Slider;
            m_Sensitivity = EffectSettings[0].Settings[1].Control as Slider;
            Storyboard updater = new Storyboard();
            updater.Completed += new EventHandler(OnFrameRendered);
            updater.Begin();
            
            m_VolumeCapture = new VolumeCapture();

        }

        Slider m_Volume;
        Slider m_Sensitivity;
        VolumeCapture m_VolumeCapture;
        void OnFrameRendered(object sender, EventArgs e)
        {
            (sender as Storyboard).Begin();

            if (Shader == null)
            {
                m_VolumeCapture.CaptureSource = null;
                return;
            }
            if( m_VolumeCapture.CaptureSource == null )
            {
                m_VolumeCapture.CaptureSource = Main.MediaSource;
            }
            m_VolumeAccumulator += m_Volume.Value;
            if (m_VolumeAccumulator > 1.0)
                m_VolumeAccumulator = 1.0;
            m_VolumeAccumulator *= 0.8;
            m_Offset += m_VolumeAccumulator/3.0;
            if (m_Offset >= 10.0)
                m_Offset = m_Offset-10.0;

            m_SwirlEffect.Strength = (float)m_VolumeAccumulator;
            m_SwirlEffect.Bands = (float)m_VolumeAccumulator*10;
            m_SwirlEffect.Offset = (float)-m_Offset;
            m_Volume.Value = m_VolumeCapture.Volume*m_Sensitivity.Value;
        }
    }
}
