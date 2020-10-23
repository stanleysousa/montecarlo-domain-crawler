namespace MCDomainCrawler.Infrastructure

module QueryWebDomain=

   open FSharp.Data

   let WebDomainExists(uri) =
      try
         Http.Request(uri, [], [], "HEAD").StatusCode = 200
      with
         | :? System.Net.WebException -> false
         | _ -> reraise()

