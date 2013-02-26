/////////////////////////////////////////////////////////////
//
// MixControl.cs
//
// © 2007 Microsoft Corporation. All Rights Reserved.
//
// This file is licensed with terms as outlined here:
// http://go.microsoft.com/fwlink/?LinkID=89145&clcid=0x409
//
/////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Mix07
{
    /// <summary>
    /// MixControl is a base control with a number of useful services that will
    /// automatically load a resource specified with the XamlResourceAttribute as
    /// its template.
    /// </summary>
    public abstract partial class MixControl : Control
    {
        /// <summary>
        /// Default resource to use if no source of Xaml is found.  It contains
        /// a placeholder message.
        /// </summary>
        private const string DefaultXamlResource = "Mix07.Common.DefaultXaml.xaml";

        private Canvas _root;

        /// <summary>
        /// Root canvas of the control's template Xaml
        /// </summary>
        public Canvas Root
        {
            get
            {
                return _root;
            }
            set
            {
                _root = value;
            }
        }

        /// <summary>
        /// Bounds of the root element
        /// </summary>
        public Rect RootBounds
        {
            get
            {
                if (_root == null)
                {
                    return new Rect();
                }
                return new Rect((double) _root.GetValue(Canvas.LeftProperty), (double) _root.GetValue(Canvas.TopProperty), _root.Width, _root.Height);
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        protected MixControl()
        {
            // Get the control's template Xaml
            string xaml = null;
            XamlResourceAttribute attribute = Attribute.GetCustomAttribute(GetType(), typeof(XamlResourceAttribute), true) as XamlResourceAttribute;
            if (attribute != null)
            {
                xaml = LoadXamlResource(attribute.ResourceName);
            }
            if (string.IsNullOrEmpty(xaml))
            {
                xaml = LoadXamlResource(DefaultXamlResource);
            }

            // Load the control's template Xaml
            FrameworkElement frameworkElement = InitializeFromXaml(xaml);
            _root = frameworkElement as Canvas;
            if (frameworkElement != null && _root == null)
            {
                throw new InvalidXamlException("", xaml);
            }

            // Handle to the Loaded event
            Loaded += new EventHandler(MixControl_Loaded);
        }

        /// <summary>
        /// Load the Xaml for a specified resource name
        /// </summary>
        /// <param name="resourceName">Name of the Xaml resource file</param>
        /// <returns>Xaml contents of the resource file</returns>
        private string LoadXamlResource(string resourceName)
        {
            string xaml = null;
            using (Stream resource = GetType().Assembly.GetManifestResourceStream(resourceName))
            {
                if (null != resource)
                {
                    using (StreamReader reader = new StreamReader(resource))
                    {
                        xaml = reader.ReadToEnd();
                    }
                }
            }
            return xaml;
        }

        /// <summary>
        /// Handle the Loaded event (and call OnLoaded)
        /// </summary>
        private void MixControl_Loaded(object sender, EventArgs e)
        {
            OnLoaded(e);
        }

        /// <summary>
        /// Called once the control has been loaded
        /// </summary>
        /// <param name="e">EventArgs</param>
        protected virtual void OnLoaded(EventArgs e)
        {
        }

        /// <summary>
        /// "Override" FindName to automatically look in the loaded Xaml
        /// </summary>
        /// <param name="name">Name of the object</param>
        /// <returns>DependencyObject with that name</returns>
        public new DependencyObject FindName(string name)
        {
            return base.FindName(name) ?? Root.FindName(name);
        }

        /// <summary>
        /// Get an element and all of its children
        /// </summary>
        /// <param name="element">Element</param>
        /// <returns>Element and all of its children</returns>
        protected IEnumerable<Visual> GetAllElements(Visual element)
        {
            if (element == null)
            {
                yield break;
            }
            yield return element;

            Panel current = element as Panel;
            if (current == null)
            {
                yield break;
            }

            Stack<Panel> containers = new Stack<Panel>();
            containers.Push(current);
            while (containers.Count > 0)
            {
                current = containers.Pop();
                foreach (Visual child in current.Children)
                {
                    yield return child;
                    Panel p = child as Panel;
                    if (p != null)
                    {
                        containers.Push(p);
                    }
                }
            }
        }

        /// <summary>
        /// Recursively sets the width/height of all children to the specified value
        /// </summary>
        /// <param name="parentElement">starting element</param>
        /// <param name="width">width to set</param>
        /// <param name="height">height to set</param>
        public void RecursivelySetWidthAndHeight(FrameworkElement parentElement, double width, double height)
        {
            RecursivelySetWidthAndHeight(parentElement, width, height, true);
        }

        /// <summary>
        /// Recursively sets the width/height of all children to the specified value
        /// </summary>
        /// <param name="parentElement">starting element</param>
        /// <param name="width">width to set</param>
        /// <param name="height">height to set</param>
        /// <param name="adjustTextBlocks">true iff TextBlock elements are to be centered</param>
        public void RecursivelySetWidthAndHeight(FrameworkElement parentElement, double width, double height, bool adjustTextBlocks)
        {
            // Set parent element
            parentElement.Width = width;
            parentElement.Height = height;

            // If adjusting text blocks
            if (adjustTextBlocks)
            {
                TextBlock parentTextBlock = parentElement as TextBlock;
                if (null != parentTextBlock)
                {
                    // Center the parentElement TextBlock
                    parentTextBlock.SetValue(Canvas.LeftProperty, (width - parentTextBlock.ActualWidth) / 2);
                    parentTextBlock.SetValue(Canvas.TopProperty, (height - parentTextBlock.ActualHeight) / 2);
                }
            }

            // Recurse through the children
            Panel parentElementPanel = parentElement as Panel;
            if (null != parentElementPanel)
            {
                foreach (FrameworkElement childElement in parentElementPanel.Children)
                {
                    RecursivelySetWidthAndHeight(childElement, width, height, adjustTextBlocks);
                }
            }
        }
    }
}
