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
using System.ComponentModel;

namespace silverscreenPrototype
{
    public class EffectSetting
    {
        public string Name
        {
            get;
            set;
        }

        private Control m_Control;
        public Control Control
        {
            get
            {
                DependencyObject obj = VisualTreeHelper.GetParent(m_Control);
                if (obj is ContentPresenter)
                {
                    (obj as ContentPresenter).Content = null;//.Remove(m_Control);
                }
                return m_Control;
            }
            set
            {
                if (m_Control == value)
                {
                    return;
                }
                m_Control = value;
            }
        }
    }

    public class EffectSettingGroup
    {
        public EffectSetting[] Settings
        {
            get;
            set;
        }
    }

    public class SilverScreenEffect : INotifyPropertyChanged
    {
        public string Name
        {
            get;
            set;
        }

        private ShaderEffect m_ShaderEffect;
        protected ShaderEffect ShaderEffect
        {
            get
            {
                return m_ShaderEffect;
            }
            set
            {
                if (m_ShaderEffect == value)
                {
                    return;
                }
                m_ShaderEffect = value;
                if (IsOn)
                {
                    Shader = m_ShaderEffect;
                }
                else
                {
                    Shader = null;
                }
                NotifyPropertyChanged("ShaderEffect");
            }
        }

        public virtual void ResetDefaults()
        {
        }

        private bool m_IsOn=true;
        public bool IsOn
        {
            get
            {
                return m_IsOn;
            }
            set
            {
                if (m_IsOn == value)
                {
                    return;
                }
                if ((m_IsOn = value))
                {
                    Shader = ShaderEffect;
                }
                else
                {
                    Shader = null;
                }

                NotifyPropertyChanged("IsOn");
            }
        }

        private ShaderEffect m_Shader;
        public ShaderEffect Shader
        {
            get
            {
                return m_Shader;
            }
            private set
            {
                if (m_Shader == value)
                {
                    return;
                }
                m_Shader = value;
                NotifyPropertyChanged("Shader");
            }
        }

        public EffectSettingGroup[] EffectSettings
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Name;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public virtual void OnDisplayMouseDown(Point point)
        {
        }

        public virtual void OnDisplayMouseDrag(Point point)
        {
        }

        public virtual void OnDisplayMouseUp(Point point)
        {
        }
    }
}
