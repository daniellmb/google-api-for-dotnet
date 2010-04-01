//-----------------------------------------------------------------------
// <copyright file="ImageSize.cs" company="iron9light">
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
    /// The image size.
    /// </summary>
    public sealed class ImageSize : Enumeration<ImageSize>
    {
        /// <summary>
        /// All sizes. Default value.
        /// </summary>
        public static readonly ImageSize All = new ImageSize("All", string.Empty, true);

        /// <summary>
        /// Icon size.
        /// </summary>
        public static readonly ImageSize Icon = new ImageSize("Icon", "icon");

        /// <summary>
        /// Small size.
        /// </summary>
        public static readonly ImageSize Small = new ImageSize("Small", "small");

        /// <summary>
        /// Medium size.
        /// </summary>
        public static readonly ImageSize Medium = new ImageSize("Medium", "medium");

        /// <summary>
        /// Large size.
        /// </summary>
        public static readonly ImageSize Large = new ImageSize("Large", "large");

        /// <summary>
        /// Large plus size.
        /// </summary>
        public static readonly ImageSize Xlarge = new ImageSize("Xlarge", "xlarge");

        /// <summary>
        /// Large plus plus size.
        /// </summary>
        public static readonly ImageSize Xxlarge = new ImageSize("Xxlarge", "xxlarge");

        /// <summary>
        /// Huge size.
        /// </summary>
        public static readonly ImageSize Huge = new ImageSize("Huge", "huge");

        private ImageSize(string value)
            : base(value)
        {
        }

        private ImageSize(string name, string value)
            : base(name, value)
        {
        }

        private ImageSize(string name, string value, bool isDefault)
            : base(name, value, isDefault)
        {
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="Google.API.Search.ImageSize"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator ImageSize(string value)
        {
            return Convert(value, s => new ImageSize(s));
        }
    }
}