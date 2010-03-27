//-----------------------------------------------------------------------
// <copyright file="IVideoResult.cs" company="iron9light">
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
    using System;

    /// <summary>
    /// Video search result.
    /// </summary>
    public interface IVideoResult
    {
        /// <summary>
        /// Gets the title of the video result.
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Gets a snippet style description of the video clip.
        /// </summary>
        string Content { get; }

        /// <summary>
        /// Gets the url of a playable version of the video result.
        /// </summary>
        string Url { get; }

        /// <summary>
        /// Gets the published date of the video.
        /// </summary>
        DateTime PublishedDate { get; }

        /// <summary>
        /// Gets the name of the video's publisher.
        /// </summary>
        string Publisher { get; }

        /// <summary>
        /// Gets the approximate duration, in seconds, of the video.
        /// </summary>
        int Duration { get; }

        /// <summary>
        /// Gets a thumbnail image which visually represents the video.
        /// </summary>
        ITbImage TbImage { get; }

        /// <summary>
        /// Gets the url of the flash version of the video that can be played inline on your page.
        /// </summary>
        string PlayUrl { get; }

        /// <summary>
        /// Gets the video type of the video result.
        /// </summary>
        string VideoType { get; }

        /// <summary>
        /// Gets the author. If present, this property supplies the YouTube user name of the author of the video.
        /// </summary>
        string Author { get; }

        /// <summary>
        /// Gets the view count. If present, this property supplies a count of the number of plays for this video. 
        /// </summary>
        int ViewCount { get; }

        /// <summary>
        /// Gets the rating. If present, this property supplies the rating of the video on a scale of 1 to 5. 
        /// </summary>
        float Rating { get; }
    }
}