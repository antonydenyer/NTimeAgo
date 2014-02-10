NTimeAgo
========

Port of jQuery TimeAgo that provides DateTime and TimeSpan extensions to display time in natural language (e.g. 4 seconds ago)

QuickStart
==========

* Open the Package Manager Console:  
Tools → Library Package Manager → Package Manager Console
* Execute `Install-Package NTimeAgo`
* Reference the NTimeAgo namespace
* use the extention methods


```csharp
using NTimeAgo;

    ...
    
    string threeMinutesAgo = DateTime.Now.AddMinutes(-3);
    // 3 minutes ago
    string fourHoursAgo = TimeSpan.FromHours(-4).InWordsAgo();
    // 4 hours ago
    
    string threeMinutesFromNow = DateTime.Now.AddMinutes(3);
    // 3 minutes from now
    string fourHoursFromNow = TimeSpan.FromHours(4).InWordsFromNow();
    // 4 hours from now

```
