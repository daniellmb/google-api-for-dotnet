//-----------------------------------------------------------------------
// <copyright file="TestEnumeration.cs" company="iron9light">
// Copyright (c) 2010 iron9light
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

namespace Google.API.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using NUnit.Framework;

    public abstract class TestEnumeration<T> where T : Enumeration<T>
    {
        protected static ICollection<T> Enums
        {
            get
            {
                return Enumeration<T>.GetEnums();
            }
        }

        protected static T Default
        {
            get
            {
                return Enumeration<T>.GetDefault();
            }
        }

        [Test]
        public void EnumCountMoreThanOne()
        {
            Assert.That(Enums.Count, Is.GreaterThan(1));
        }

        [Test]
        public void NoEnumIsNull()
        {
            Assert.That(Enums, Has.None.Null);
        }

        [Test]
        public void HasDefaultEnum()
        {
            Assert.That(Default, Is.Not.Null);
        }

        [Test]
        public void HasOnlyOneDefaultEnum()
        {
            Assert.That(Enums.Where(@enum => @enum.IsDefault).Count(), Is.EqualTo(1));
        }

        [Test]
        public void NoEnumValueIsNull()
        {
            Assert.That(Enums, Has.None.Matches<T>(@enum => @enum.Value == null));
        }

        [Test]
        public void NoEnumNameIsNull()
        {
            Assert.That(Enums, Has.None.Matches<T>(@enum => @enum.Name == null));
        }

        [Test]
        public void NoDuplicatedEnumValue()
        {
            Assert.That(Enums.Select(@enum => @enum.Value), Is.Unique);
        }

        [Test]
        public void NoDuplicatedEnumName()
        {
            Assert.That(Enums.Select(@enum => @enum.Name), Is.Unique);
        }
    }
}