using System.Collections.Generic;
using IdentityServer4.Models;
using IdentityServer4.Test;

public class Configurations {
    public static IEnumerable<ApiResource> ApiResources() => 
         new [] {
            new ApiResource("weatherForecast", "Weather Forecast")
        };

     public static IEnumerable<ApiScope> ApiScopes() => 
         new [] {
            new ApiScope("weatherForecast")
        };

    public static IEnumerable<Client> Clients() => 
         new [] {
            new Client {
                ClientId = "WeatherForecast",
                ClientSecrets = new [] { new Secret("secret".Sha256()) },
                AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                AllowedScopes = new[] {"weatherForecast"}
            }
        };

    public static IEnumerable<TestUser> Users() => 
        new []{
            new TestUser {
                SubjectId = "1",
                Username = "diya",
                Password = "password"
            }
        };
}