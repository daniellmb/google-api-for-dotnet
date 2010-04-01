//-----------------------------------------------------------------------
// <copyright file="Colorization.cs" company="iron9light">
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
    /// A specified colorization of images.
    /// </summary>
    public sealed class Colorization : Enumeration<Colorization>
    {
        /// <summary>
        /// All colorizations. Default value.
        /// </summary>
        public static readonly Colorization All = new Colorization("All", string.Empty, true);

        /////// <summary>
        /////// The black and white images.
        /////// </summary>
        ////public static readonly Colorization Mono = new Colorization("Mono", "mono");

        /// <summary>
        /// The grayscale images.
        /// </summary>
        public static readonly Colorization Gray = new Colorization("Gray", "gray");

        /// <summary>
        /// The color images.
        /// </summary>
        public static readonly Colorization Color = new Colorization("Color", "color");

        private Colorization(string value)
            : base(value)
        {
        }

        private Colorization(string name, string value)
            : base(name, value)
        {
        }

        private Colorization(string name, string value, bool isDefault)
            : base(name, value, isDefault)
        {
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="Google.API.Search.Colorization"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Colorization(string value)
        {
            return Convert(value, s => new Colorization(s));
        }
    }
}