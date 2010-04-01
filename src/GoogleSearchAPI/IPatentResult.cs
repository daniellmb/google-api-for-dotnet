//-----------------------------------------------------------------------
// <copyright file="IPatentResult.cs" company="iron9light">
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
    /// Patent search result.
    /// </summary>
    public interface IPatentResult
    {
        /// <summary>
        /// Gets the title of the result.
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Gets a snippet style description of the patent.
        /// </summary>
        string Content { get; }

        /// <summary>
        /// Gets the URL of the result.
        /// </summary>
        string Url { get; }

        /// <summary>
        /// Gets the application filing date of the patent.
        /// </summary>
        DateTime ApplicationDate { get; }

        /// <summary>
        /// Gets the patent number for issued patents, and the application number for filed, but not yet issued patents.
        /// </summary>
        string PatentNumber { get; }

        /// <summary>
        /// Gets the status of the patent which can either be "filed" for filed, but not yet issued patents, or "issued" for issued patents.
        /// </summary>
        string PatentStatus { get; }

        /// <summary>
        /// Gets the assignee of the patent.
        /// </summary>
        string Assignee { get; }

        /// <summary>
        /// Gets a thumbnail image which visually represents the patent.
        /// </summary>
        ITbImage TbImage { get; }
    }
}