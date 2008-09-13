/**
 * TranslateException.cs
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

namespace Google.API.Translate
{
    /// <summary>
    /// Google API translate exception.
    /// </summary>
    [Serializable]
    public class TranslateException : GoogleAPIException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TranslateException"/> class.
        /// </summary>
        public TranslateException()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslateException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public TranslateException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslateException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (<b>Nothing</b> in Visual Basic) if no inner exception is specified.</param>
        public TranslateException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
