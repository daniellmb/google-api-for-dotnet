//-----------------------------------------------------------------------
// <copyright file="ImageColor.cs" company="iron9light">
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
    /// The images of the specified color.
    /// </summary>
    public sealed class ImageColor : Enumeration<ImageColor>
    {
        /// <summary>
        /// The All.
        /// </summary>
        public static readonly ImageColor All = new ImageColor("All", string.Empty, true);

        /// <summary>
        /// The Black.
        /// </summary>
        public static readonly ImageColor Black = new ImageColor("Black", "black");

        /// <summary>
        /// The Blue.
        /// </summary>
        public static readonly ImageColor Blue = new ImageColor("Blue", "blue");

        /// <summary>
        /// The Brown.
        /// </summary>
        public static readonly ImageColor Brown = new ImageColor("Brown", "brown");

        /// <summary>
        /// The Gray.
        /// </summary>
        public static readonly ImageColor Gray = new ImageColor("Gray", "gray");

        /// <summary>
        /// The Green.
        /// </summary>
        public static readonly ImageColor Green = new ImageColor("Green", "green");

        /// <summary>
        /// The Orange.
        /// </summary>
        public static readonly ImageColor Orange = new ImageColor("Orange", "orange");

        /// <summary>
        /// The Pink.
        /// </summary>
        public static readonly ImageColor Pink = new ImageColor("Pink", "pink");

        /// <summary>
        /// The Purple.
        /// </summary>
        public static readonly ImageColor Purple = new ImageColor("Purple", "purple");

        /// <summary>
        /// The Red.
        /// </summary>
        public static readonly ImageColor Red = new ImageColor("Red", "red");

        /// <summary>
        /// The Teal.
        /// </summary>
        public static readonly ImageColor Teal = new ImageColor("Teal", "teal");

        /// <summary>
        /// The White.
        /// </summary>
        public static readonly ImageColor White = new ImageColor("White", "white");

        /// <summary>
        /// The Yellow.
        /// </summary>
        public static readonly ImageColor Yellow = new ImageColor("Yellow", "yellow");

        private ImageColor(string value)
            : base(value)
        {
        }

        private ImageColor(string name, string value)
            : base(name, value)
        {
        }

        private ImageColor(string name, string value, bool isDefault)
            : base(name, value, isDefault)
        {
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="Google.API.Search.ImageColor"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator ImageColor(string value)
        {
            return Convert(value, s => new ImageColor(s));
        }
    }
}