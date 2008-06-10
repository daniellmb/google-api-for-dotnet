/**
 * ArgumentAttribute.cs
 *
 * Copyright (C) 2008,  iron9light
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using System;

namespace Google.API
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class ArgumentAttribute : Attribute
    {
        /// <summary>
        /// Constructor of ArgumentAttribute
        /// </summary>
        /// <param name="name">The argument name.</param>
        public ArgumentAttribute(string name)
        {
            Name = name;
            Optional = true;
            DefaultValue = null;
            NeedEncode = false;
        }

        /// <summary>
        /// Constructor of ArgumentAttribute
        /// </summary>
        /// <param name="name">The argument name.</param>
        /// <param name="defaultValue">Default value.</param>
        public ArgumentAttribute(string name, object defaultValue)
        {
            Name = name;
            if (defaultValue == null)
            {
                Optional = true;
            }
            else
            {
                Optional = false;
            }
            DefaultValue = defaultValue;
            NeedEncode = false;
        }

        /// <summary>
        /// Get the argument name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Get or set whether this argument is optional.
        /// The default value is true.
        /// </summary>
        public bool Optional { get; set; }

        /// <summary>
        /// Get the default value. Or return null is no default value.
        /// </summary>
        public object DefaultValue { get; private set; }

        /// <summary>
        /// Get or set whether this argument need to be encoded.
        /// The default value is false.
        /// </summary>
        public bool NeedEncode { get; set; }
    }
}
