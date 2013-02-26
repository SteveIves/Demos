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
using System.Collections;
using System.Windows.Data;

namespace silverscreenPrototype.Effects
{

    public class ChromaKey : SilverScreenEffect
    {
        private ColorKeyAlpha m_ColorKeyAlpha;
        public ChromaKey()
        {
            Name = "Chroma Key";
            ShaderEffect = m_ColorKeyAlpha = new ColorKeyAlpha();

            VideoBrush videoBrush = new VideoBrush
            {
                Stretch = Stretch.UniformToFill
            };
            Main.HiddenVideo.Source = new Uri("imaging.wmv", UriKind.Relative);
            Main.HiddenVideo.MediaEnded += new RoutedEventHandler(delegate(object sender, RoutedEventArgs e)
            {
                Main.HiddenVideo.Position = TimeSpan.FromSeconds(0);
                Main.HiddenVideo.Play();
            });
            videoBrush.SetSource(Main.HiddenVideo);


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
                        },
                        new EffectSetting()
                        {
                             Control = new ScreenColorPicker(),
                             Name = "Color"
                        }
                    }
                },
                new EffectSettingGroup
                {
                    Settings = new EffectSetting[]
                    {
                        new EffectSetting()
                        {
                             Control = new BgColorPicker
                             { 
                                 ItemsSource = new Brush[] 
                                 { 
                                     new LinearGradientBrush
                                     {  
                                         StartPoint = new Point(0.5,1.0),
                                         EndPoint = new Point(0.5,0.0),
                                         GradientStops = new GradientStopCollection
                                         { 
                                             new GradientStop{ Color=Color.FromArgb(255,237,33,36) },
                                             new GradientStop{ Color=Color.FromArgb(255,166,29,33) }
                                         }
                                     },
                                     new LinearGradientBrush
                                     { 
                                         StartPoint = new Point(0.5,1.0),
                                         EndPoint = new Point(0.5,0.0),
                                         GradientStops = new GradientStopCollection
                                         { 
                                             new GradientStop{ Color=Color.FromArgb(255,73,148,208) },
                                             new GradientStop{ Color=Color.FromArgb(255,61,91,169) }
                                         }
                                     },
                                     new LinearGradientBrush
                                     { 
                                         StartPoint = new Point(0.5,1.0),
                                         EndPoint = new Point(0.5,0.0),
                                         GradientStops = new GradientStopCollection
                                         { 
                                             new GradientStop{ Color=Color.FromArgb(255,255,255,255) },
                                             new GradientStop{ Color=Color.FromArgb(255,173,173,174) }
                                         }
                                     },
                                     new LinearGradientBrush
                                     { 
                                         StartPoint = new Point(0.5,1.0),
                                         EndPoint = new Point(0.5,0.0),
                                         GradientStops = new GradientStopCollection
                                         { 
                                             new GradientStop{ Color=Color.FromArgb(255,103,188,69) },
                                             new GradientStop{ Color=Color.FromArgb(255,25,154,72) }
                                         }
                                     },
                                     new LinearGradientBrush
                                     { 
                                         StartPoint = new Point(0.5,1.0),
                                         EndPoint = new Point(0.5,0.0),
                                         GradientStops = new GradientStopCollection
                                         { 
                                             new GradientStop{ Color=Color.FromArgb(255,251,225,7) },
                                             new GradientStop{ Color=Color.FromArgb(255,208,137,41) }
                                         }
                                     },
                                     new LinearGradientBrush
                                     { 
                                         StartPoint = new Point(0.5,1.0),
                                         EndPoint = new Point(0.5,0.0),
                                         GradientStops = new GradientStopCollection
                                         { 
                                             new GradientStop{ Color=Color.FromArgb(255,162,80,159) },
                                             new GradientStop{ Color=Color.FromArgb(255,129,48,146) }
                                         }
                                     },
                                     videoBrush 
                                 }
                             },
                             Name = "BG"
                        }
                    }
                }
            };
            
            Binding binding = new Binding("Threshold");
            binding.Source = m_ColorKeyAlpha;
            binding.Mode = BindingMode.TwoWay;
            EffectSettings[0].Settings[0].Control.SetBinding(Slider.ValueProperty,binding);

            binding = new Binding("ColorKey");
            binding.Source = m_ColorKeyAlpha;
            binding.Mode = BindingMode.TwoWay;
            EffectSettings[0].Settings[1].Control.SetBinding(ScreenColorPicker.ColorProperty, binding);

            //binding = new Binding("Background");
            //binding.Source = m_ColorKeyAlpha;
            //binding.Mode = BindingMode.TwoWay;
            //EffectSettings[1].Settings[0].Control.SetBinding(BgColorPicker.SelectedItemProperty, binding);

            binding = new Binding("BackgroundBrush");
            binding.Source = this;
            binding.Mode = BindingMode.TwoWay;
            (EffectSettings[1].Settings[0].Control as BgColorPicker).ItemsList.SetBinding(SelectableItemsControl.SelectedItemProperty, binding);
        }

        public override void ResetDefaults()
        {
            m_ColorKeyAlpha.Threshold = 0.15f;
            m_ColorKeyAlpha.ColorKey = Colors.Green;
            //m_PinchEffect.Y = 0.25f;
            //m_PinchEffect.X = 0.25f;
        }


        //private float m_InputWidth;
        //public float InputWidth
        //{
        //    get
        //    {
        //        return m_InputWidth;
        //    }
        //    set
        //    {
        //        if (m_InputWidth == value)
        //        {
        //            return;
        //        }
        //        m_InputWidth = value;

        //        m_ColorKeyAlpha.Width = value;
        //        NotifyPropertyChanged("InputWidth");
        //    }
        //}

        //private float m_InputHeight;
        //public float InputHeight
        //{
        //    get
        //    {
        //        return m_InputHeight;
        //    }
        //    set
        //    {
        //        if (m_InputHeight == value)
        //        {
        //            return;
        //        }
        //        m_InputHeight = value;

        //        m_ColorKeyAlpha.Height = value;
        //        NotifyPropertyChanged("InputHeight");
        //    }
        //}

        private Brush m_Brush;
        public Brush BackgroundBrush
        {
            get
            {
                return m_Brush;
            }
            set
            {
                if (m_Brush == value)
                {
                    return;
                }
                m_Brush = value;
                NotifyPropertyChanged("BackgroundBrush");
            }
        }
    }
}
