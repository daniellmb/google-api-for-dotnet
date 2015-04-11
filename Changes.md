# Change Log #

**0.4 alpha (1.April.2010)**
  * Back to Json.NET as json transfer.
  * Now support 4 .NET versions (.NET 3.5, .NET 2.0, .NET CF 3.5 and Silverlight 3.0)
  * Add asynchronize methods along with every request methods.
  * Auto build via psake.
  * Fixed some bugs and updated APIs(for GwebSearch).
  * Now all timeout properties are useless.
**0.3.1**
  * Fixed [Issue 26](https://code.google.com/p/google-api-for-dotnet/issues/detail?id=26).
**0.3:**
  * No more default http referrer. User must set it as a parameter of constructor.
  * Delete old Translator and Searcher classes.
  * Updated comments for better document.
**0.3 beta:**
  * Change all API Using string parameter instead of enum parameter.
  * Add new Enumeration class and enumerations for API parameters.
**0.3 alpha:**
  * All codes are refacted (StyleCop format).
  * Update the APIs to support latest Google APIs.
  * Now can customize referrer, accept language, API key and timeout times.
  * Add GoogleAPIAllInOne solution.
**0.2:**
  * Update supported language list.
  * Set "http://code.google.com/p/google-api-for-dotnet/" as the default http referrer.
**0.2 beta:**
  * Support strong name.
  * Replace Json.NET 2.0 by WCF.
  * Implement HttpUtility.
  * Cancel Timeout property.
**Search API 0.1:**
  * Support Google local search API (now support all Google search APIs)
  * Update other APIs (Google news search API etc.)
  * Fixed some bugs.
**Translate API 0.1.1:**
  * Add more languages.
  * Fixed some bugs.