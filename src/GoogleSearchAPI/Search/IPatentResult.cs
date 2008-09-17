/**
 * IPatentResult.cs
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

namespace Google.API.Search
{
    /// <summary>
    /// Patent search result.
    /// </summary>
    public interface IPatentResult
    {
        /// <summary>
        /// Get the title of the result.
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Get a snippet style description of the patent.
        /// </summary>
        string Content { get; }

        /// <summary>
        /// Get the URL of the result.
        /// </summary>
        string Url { get; }

        /// <summary>
        /// Get the application filing date of the patent.
        /// </summary>
        DateTime ApplicationDate { get; }

        /// <summary>
        /// Get the patent number for issued patents, and the application number for filed, but not yet issued patents.
        /// </summary>
        string PatentNumber { get; }

        /// <summary>
        /// Get the status of the patent which can either be "filed" for filed, but not yet issued patents, or "issued" for issued patents.
        /// </summary>
        string PatentStatus { get; }

        /// <summary>
        /// Get the assignee of the patent.
        /// </summary>
        string Assignee { get; }

        /// <summary>
        /// Get a thumbnail image which visually represents the patent.
        /// </summary>
        ITbImage TbImage { get; }
    }
}