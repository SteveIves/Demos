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
using silverscreenPrototype.Effects;
using System.ComponentModel;

namespace silverscreenPrototype
{
    public class EffectChangedArgs :EventArgs
    {
        public SilverScreenEffect Effect
        {
            get;
            private set;
        }
        public EffectChangedArgs(SilverScreenEffect effect)
        {
            Effect = effect;
        }
    }

    public class MainViewModel :INotifyPropertyChanged
    {
        public event EventHandler<EffectChangedArgs> EffectChanged;

        public MediaElement Video
        {
            get;
            set;
        }

        public SilverScreenEffect[] Effects
        {
            get;
            set;
        }

        public MainViewModel()
        {
            Effects = new SilverScreenEffect[] 
            { 
                new None(),
                new Crayon(),
                new ChromaKey(),
                new Pinch(),
                new AudioPinch(),
                new Embossed(),
                new AudioSwirl()
            };
        }

        private int m_SelectedShaderIndex = -1;
        public int SelectedEffectIndex
        {
            get
            {
                return m_SelectedShaderIndex;
            }
            set
            {
                if (m_SelectedShaderIndex == value)
                {
                    return;
                }
                m_SelectedShaderIndex = value;
                if (EffectChanged != null)
                {
                    EffectChanged(this, new EffectChangedArgs(SelectedEffect));
                }
                NotifyPropertyChanged("SelectedEffectIndex");
            }
        }

        public SilverScreenEffect SelectedEffect
        {
            get
            {
                return m_SelectedShaderIndex == -1 || m_SelectedShaderIndex >= Effects.Length ? null : Effects[m_SelectedShaderIndex];
            }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        public event PropertyChangedEventHandler  PropertyChanged;
}
}
