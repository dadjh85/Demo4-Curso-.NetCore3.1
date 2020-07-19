using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids
            => new  List<IdentityResource>
               {
                  new IdentityResources.OpenId(),
                  new IdentityResources.Profile()
               };

        public static IEnumerable<ApiResource> Apis
            => new List<ApiResource>
            {
                new ApiResource("Demo4CursoNetCore", "Demo4 Api Net Core")
            };

        public static IEnumerable<Client> Clients
            => new List<Client>()
               {
                    new Client()
                    {
                        ClientId = "demo4",
                        ClientSecrets = { new Secret("secret".Sha256()) },
                        AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                        AllowOfflineAccess = true,
                        AllowedScopes = { "Demo4CursoNetCore" }
                    }
               };


        public static List<TestUser> Users 
            => new List<TestUser>
               {
                    new TestUser() 
                    { 
                        SubjectId = "1", 
                        Username = "user1",   
                        Password = "pass1",
                        Claims = {
                            new Claim("name", "User1"),
                            new Claim("given_name", "User1"),
                            new Claim("family_name", "User1"),
                            new Claim("email", "emailUser1@emailUser1.com"),
                            new Claim("email_verified", "true",  ClaimValueTypes.Boolean),
                            new Claim("role", "administrator")
                        }
                    },
                    new TestUser() 
                    { 
                        SubjectId = "2", 
                        Username = "user2", 
                        Password = "pass2",
                        Claims = {
                            new Claim("name", "User2"),
                            new Claim("given_name", "User2"),
                            new Claim("family_name", "User2"),
                            new Claim("email", "emailUser2@emailUser2.com"),
                            new Claim("email_verified", "true", ClaimValueTypes.Boolean),
                            new Claim("role", "Client")
                        }
                    },
                    new TestUser()
                    {
                        SubjectId = "3",
                        Username = "user3",
                        Password = "pass3",
                        Claims = {
                            new Claim("name", "User2"),
                            new Claim("given_name", "User3"),
                            new Claim("family_name", "User3"),
                            new Claim("email", "emailUser3@emailUser3.com"),
                            new Claim("email_verified", "true", ClaimValueTypes.Boolean),
                            new Claim("role", "User")
                        }
                    }
               };
    }
}