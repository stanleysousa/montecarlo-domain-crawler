# montecarlo-domain-crawler
Estimates the number of subdomains with k or less characters and n samples using the Monte Carlo method. For more information see the [documentation](./docs/mc_crawler.pdf).

## How to use
- You need [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1) runtime
- Change [appsettings.json](./app/Worker/appsettings.json):
- Run [Worker.csproj]: On a terminal go to [\app\MCDomainCrawler.Worker](./app/MCDomainCrawler.Worker) folder and execute "dotnet run"


## Results for k=3, n=10^4
dbug: Worker.Services.DomainProcessor[0] lps found on n=2365\
dbug: Worker.Services.DomainProcessor[0] olq is invalid\
dbug: Worker.Services.DomainProcessor[0] reu is invalid\
dbug: Worker.Services.DomainProcessor[0] Found: 18 subdomains\
info: Worker.Program[0] Estimated number of subdomains: 54\
info: Worker.Program[0] Done.
