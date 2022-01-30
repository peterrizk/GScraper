# GScraper

This is WPF project intended to scrape google urls. It searches google and counts for a particular term in the results. To run in windows, confirm GScraper.Wpf is the startup project and press f5.

# If I had more time would have liked to do the following
* add an assumptions section in the readme file
* test the viewmodel objects 
* make the count parser smarter to be able to tell if a term appears twice in the same section of a search result and only count it once.
* add an in memory cache for the http calls
* add a polly circuit breaker for the http calls
* handle error messages on the screen
