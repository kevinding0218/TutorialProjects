﻿using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4.Models;

namespace RothschildHouse.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
            => new List<ApiResource>
            {
                new ApiResource("RothschildHouseWebAPI", "Rothschild House Web API")
            };

        public static IEnumerable<Client> GetClients()
            => new List<Client>
            {
                new Client
                {
                    ClientId = "onlinestoreclient",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret("onlinestoreclientsecret1".Sha256())
                    },
                    AllowedScopes =
                    {
                        "RothschildHouseWebAPI"
                    },
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Role, "Customer")
                    }
                }
            };
    }
}
