using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RsnDigitalApi.Helper
{
    public static class Config
    {
        public static IEnumerable<Client> Clients =>
    new List<Client>
    {
        new Client
        {
            ClientId = "receipeservice",
            // no interactive user, use the clientid/secret for authentication
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            // secret for authentication
            ClientSecrets =
            {
                new Secret("secret".Sha256())
            },
            // scopes that client has access to
            AllowedScopes = { "rsndigitalservice" }
        }
    };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("rsndigitalservice","rsndigital service")
            };
    }
}
