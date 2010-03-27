//-----------------------------------------------------------------------
// <copyright file="NewsTopic.cs" company="iron9light">
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

namespace Google.API.Search
{
    /// <summary>
    /// The topic of news.
    /// </summary>
    public sealed class NewsTopic : Enumeration<NewsTopic>
    {
        /// <summary>
        /// All topics.
        /// </summary>
        public static readonly NewsTopic All = new NewsTopic("All", string.Empty, true);

        /// <summary>
        /// The Headlines.
        /// </summary>
        public static readonly NewsTopic Headlines = new NewsTopic("Headlines", "h");

        /// <summary>
        /// The World.
        /// </summary>
        public static readonly NewsTopic World = new NewsTopic("World", "w");

        /// <summary>
        /// The Nation.
        /// </summary>
        public static readonly NewsTopic Nation = new NewsTopic("Nation", "n");

        /// <summary>
        /// The Business.
        /// </summary>
        public static readonly NewsTopic Business = new NewsTopic("Business", "b");

        /// <summary>
        /// The Technology.
        /// </summary>
        public static readonly NewsTopic Technology = new NewsTopic("Technology", "t");

        /// <summary>
        /// The Entertainment.
        /// </summary>
        public static readonly NewsTopic Entertainment = new NewsTopic("Entertainment", "e");

        /// <summary>
        /// The Sports.
        /// </summary>
        public static readonly NewsTopic Sports = new NewsTopic("Sports", "s");

        /// <summary>
        /// The Health.
        /// </summary>
        public static readonly NewsTopic Health = new NewsTopic("Health", "m");

        /// <summary>
        /// The Elections.
        /// </summary>
        public static readonly NewsTopic Elections = new NewsTopic("Elections", "el");

        /// <summary>
        /// The Politics.
        /// </summary>
        public static readonly NewsTopic Politics = new NewsTopic("Politics", "p");

        /// <summary>
        /// The Spotlight.
        /// </summary>
        public static readonly NewsTopic Spotlight = new NewsTopic("Spotlight", "ir");

        /// <summary>
        /// The MostPopular.
        /// </summary>
        public static readonly NewsTopic MostPopuler = new NewsTopic("MostPopular", "po");

        private NewsTopic(string value)
            : base(value)
        {
        }

        private NewsTopic(string name, string value)
            : base(name, value)
        {
        }

        private NewsTopic(string name, string value, bool isDefault)
            : base(name, value, isDefault)
        {
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="Google.API.Search.NewsTopic"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator NewsTopic(string value)
        {
            return Convert(value, s => new NewsTopic(s));
        }
    }
}