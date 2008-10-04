/**
 * SearchData.cs
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

using System.Runtime.Serialization;

namespace Google.API.Search
{
    internal interface ISearchData<TResult>
    {
        TResult[] Results { get; }
    }

    [DataContract]
    internal class SearchData<TResult> : ISearchData<TResult>
    {
        [DataContract]
        public class CursorObject
        {
            [DataContract]
            public class Page
            {
                [DataMember(Name = "start")]
                public long Start { get; private set; }

                [DataMember(Name = "label")]
                public long Label { get; private set; }

                public override string ToString()
                {
                    return string.Format("start : {0}, label : {1}", Start, Label);
                }
            }

            [DataMember(Name = "pages")]
            public Page[] Pages { get; private set; }

            [DataMember(Name = "estimatedResultCount")]
            public long EstimatedResultCount { get; private set; }

            [DataMember(Name = "currentPageIndex")]
            public long CurrentPageIndex { get; private set; }

            [DataMember(Name = "moreResultsUrl")]
            public string MoreResultsUrl { get; private set; }
        }

        [DataMember(Name = "results")]
        public TResult[] Results { get; private set; }

        [DataMember(Name = "cursor")]
        public CursorObject Cursor { get; private set; }
    }
}
