//-----------------------------------------------------------------------
// <copyright file="Enumeration.Generic.cs" company="iron9light">
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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public abstract class Enumeration<T> : Enumeration, IEquatable<T>
        where T : Enumeration<T>
    {
        private static T @default;

        private static IDictionary<string, T> dictionary;

        protected Enumeration(string value)
            : base(value)
        {
        }

        protected Enumeration(string name, string value)
            : base(name, value)
        {
        }

        protected Enumeration(string name, string value, bool isDefault)
            : base(name, value, isDefault)
        {
        }

        protected static IDictionary<string, T> Dictionary
        {
            get
            {
                Initialize();
                return dictionary;
            }
        }

        public static T GetDefault()
        {
            Initialize();
            return @default;
        }

        public static ICollection<T> GetEnums()
        {
            return Dictionary.Values;
        }

        public bool Equals(T other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Value == other.Value;
        }

        protected static void Initialize()
        {
            if (dictionary == null)
            {
                dictionary = new Dictionary<string, T>();

                var type = typeof(T);

                ////var enums =
                ////    from propertyInfo in
                ////        type.GetProperties(
                ////        BindingFlags.Static | BindingFlags.Public)
                ////    where
                ////        propertyInfo.PropertyType.IsAssignableFrom(typeof(T)) &&
                ////        propertyInfo.GetIndexParameters().Length == 0
                ////    select propertyInfo.GetValue(null, null) as T;

                var enums =
                    from fieldInfo in
                        type.GetFields(
                        BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.GetField)
                    where fieldInfo.FieldType.IsAssignableFrom(type)
                    select fieldInfo.GetValue(null);

                foreach (var x in enums)
                {
                    var @enum = x as T;

                    dictionary[@enum.Value] = @enum;

                    if (@default == null && @enum.IsDefault)
                    {
                        @default = @enum;
                    }
                }
            }
        }

        protected static T Convert(string value, Func<string, T> construct)
        {
            if (value == null)
            {
                return GetDefault();
            }

            T @enum;

            if (!Dictionary.TryGetValue(value, out @enum))
            {
                @enum = construct(value);
            }

            return @enum;
        }
    }
}