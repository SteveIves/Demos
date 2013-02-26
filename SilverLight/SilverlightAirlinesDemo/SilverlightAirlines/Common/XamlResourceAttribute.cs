/////////////////////////////////////////////////////////////
//
// XamlResourceAttribute.cs
//
// © 2007 Microsoft Corporation. All Rights Reserved.
//
// This file is licensed with terms as outlined here:
// http://go.microsoft.com/fwlink/?LinkID=89145&clcid=0x409
//
/////////////////////////////////////////////////////////////

using System;

namespace Mix07
{
    /// <summary>
    /// Attribute for specifying a XAML resource
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class XamlResourceAttribute : Attribute
    {
        private string _resourceName;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="resourceName">name of the embedded XAML resource</param>
        public XamlResourceAttribute(string resourceName)
        {
            _resourceName = resourceName;
        }

        /// <summary>
        /// Property for accessing the resource name
        /// </summary>
        public string ResourceName
        {
            get
            {
                return _resourceName;
            }
        }
    }
}
