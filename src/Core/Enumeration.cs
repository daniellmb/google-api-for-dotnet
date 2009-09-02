//-----------------------------------------------------------------------
// <copyright file="Enumeration.cs" company="iron9light">
// Copyright (c) 2009 iron9light
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// </copyright>
// <author>iron9light@gmail.com</author>
//-----------------------------------------------------------------------

namespace Google.API
{
    public abstract class Enumeration
    {
        private readonly string name;

        private readonly string value;

        private readonly bool isDefault;

        protected Enumeration(string value)
            : this(value, value)
        {
        }

        protected Enumeration(string name, string value)
            : this(name, value, false)
        {
        }

        protected Enumeration(string name, string value, bool isDefault)
        {
            this.name = name;
            this.isDefault = isDefault;
            this.value = value;
        }

        public bool IsDefault
        {
            get
            {
                return this.isDefault;
            }
        }

        public string Value
        {
            get
            {
                return this.value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public static implicit operator string(Enumeration enumeration)
        {
            return enumeration.Value;
        }

        public override string ToString()
        {
            return this.Name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj == null)
            {
                return false;
            }

            if (!this.GetType().IsInstanceOfType(obj))
            {
                return false;
            }

            return this.Value == ((Enumeration)obj).Value;
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}
