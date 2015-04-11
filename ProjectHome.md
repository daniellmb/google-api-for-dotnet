### **Anyone wanna use Google APIs, read [this post](http://googlecode.blogspot.com/2011/05/spring-cleaning-for-some-of-our-apis.html?utm_source=feedburner&utm_medium=feed&utm_campaign=Feed%3A+blogspot%2FDcni+%28Google+Code+Blog%29) frist plz** ###

Provides simple, unofficial, .NET Framework APIs for using Google Ajax RestFULL APIs (Search API, Language API etc.)

### Google Translate API for .NET 0.4 alpha ###

**Description:**

Provides a simple, unofficial, .NET Framework API for using Google Ajax Language API service.

**Feature:**
  * Support all functions of Google Ajax Language API.
  * CLS compatible. It can be used by any .NET languages (VB.NET, C++/CLI etc.)

**Versions:**
Google Search API for .NET comes in different versions for the various .NET frameworks.
  * .NET Framework 3.5 Client Profile.
  * .NET Framework 2.0
  * .NET Compact Framework 3.5
  * Silverlight 3.0

**Example:**
```
    string text = "我喜欢跑步。";
    TranslateClient client = new TranslateClient(/* Enter the URL of your site here */);
    string translated = client.Translate(text, Language.ChineseSimplified, Language.English);
    Console.WriteLine(translated);
    // I like running.
```

### Google Search API for .NET 0.4 alpha ###


**Description:**

Provides a simple, unofficial, .NET Framework API for using Google Ajax Search API service.

**Feature:**
  * Support all 8 Google Search APIs.
  * CLS compatible. It can be used by any .NET languages (VB.NET, C++/CLI etc.)

| **Google Search APIs** | **State** |
|:-----------------------|:----------|
| Google Web Search API | supported |
| Google Local Search API | supported |
| Google Video Search API | supported |
| Google Blog Search API | supported |
| Google News Search API | supported |
| Google Book Search API | supported |
| Google Image Search API | supported |
| Google Patent Search API | supported |

**Versions:**
Google Translate API for .NET comes in different versions for the various .NET frameworks.
  * .NET Framework 3.5 Client Profile.
  * .NET Framework 2.0
  * .NET Compact Framework 3.5
  * Silverlight 3.0

**Example:**
```
    // Search 32 results of keyword : "Google APIs for .NET"
    GwebSearchClient client = new GwebSearchClient(/* Enter the URL of your site here */);
    IList<IWebResult> results = client.Search("Google API for .NET", 32);  
    foreach(IWebResult result in results)  
    {  
        Console.WriteLine("[{0}] {1} => {2}", result.Title, result.Content, result.Url);  
    } 
```