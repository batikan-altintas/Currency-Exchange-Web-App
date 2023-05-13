# Data API

This Api retrieves the exchange rate data of the last two months from the TCMB(Central Bank of the Republic of Türkiye)'s site in XML format and saves it to the database.

Tech: .Net Core 6, Web Api, Entity Framework Core, MsSql

# Business API

The Api fetches the requested exchange rate from the cache. The cache do not use in memory but distributed cache.

Tech: .Net Core 6, Web Api, Entity Framework Core, MsSql, Redis Cache

# Currency Website

Web page call the Business API with Ajax and use jQuery Framework. Chart generates using by d3js framework.

Tech: .Net MVC Core, Html, Css, Javascript 

