/////////////////////////////////////////////////////////////
//
// InvalidXamlException.cs
//
// © 2007 Microsoft Corporation. All Rights Reserved.
//
// This file is licensed with terms as outlined here:
// http://go.microsoft.com/fwlink/?LinkID=89145&clcid=0x409
//
/////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;

namespace Mix07
{
    /// <summary>
    /// Exception to be raised when provided invalid Xaml markup
    /// </summary>
    public class InvalidXamlException : Exception
    {
        private string _xaml;

        /// <summary>
        /// Xaml markup that caused the exception
        /// </summary>
        public string Xaml
        {
            get
            {
                return _xaml;
            }
            set
            {
                _xaml = value;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public InvalidXamlException()
            : this(null)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Reason the Xaml markup caused the exception</param>
        public InvalidXamlException(string message)
            : this(message, (string)null)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Reason the Xaml markup caused the exception</param>
        /// <param name="xaml">Xaml markup that caused the exception</param>
        public InvalidXamlException(string message, string xaml)
            : this(message, xaml, null)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Reason the Xaml markup caused the exception</param>
        /// <param name="innerException">Inner exception</param>
        public InvalidXamlException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Reason the Xaml markup caused the exception</param>
        /// <param name="xaml">Xaml markup that caused the exception</param>
        /// <param name="innerException">Inner exception</param>
        public InvalidXamlException(string message, string xaml, Exception innerException)
            : base(message, innerException)
        {
            _xaml = xaml;
        }
    }
}
