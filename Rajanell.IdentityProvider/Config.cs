// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace Rajanell.IdentityProvider
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                 new ApiScope("ApiScope", "Api Scope")
            };

        public static IEnumerable<Client> Clients =>
            new Client[] 
            {
            new Client
                {
                    ClientId = "3f686012-fe0b-49b9-90a5-12d98d303a35",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,// no interactive user, use the clientid/secret for authentication               
                    ClientSecrets =
                    {
                        new Secret("U2VjcmV0ZQ==".Sha256())     // secret for authentication
                    },
                    // scopes that client has access to
                    AllowedScopes = { "ApiScope" }
                }
            };
    }
}