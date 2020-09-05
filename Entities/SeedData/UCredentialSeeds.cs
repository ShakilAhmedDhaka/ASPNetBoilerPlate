using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.SeedData
{
    static class UCredentialSeeds
    {
        public static IEnumerable<UCredential> GetCredSeeds()
        {
            var creds = new List<UCredential>
            {
                new UCredential
                {
                    Id = 1,
                    Username = "john",
                    Email = "john@tracker.com",
                    Password = "john1234",
                    Role = "Admin"
                },

                new UCredential
                {
                    Id = 2,
                    Username = "george",
                    Email = "george@tracker.com",
                    Password = "goerge1234",
                    Role = "User"
                },

                new UCredential
                {
                    Id = 3,
                    Username = "thomas",
                    Email = "thomas@tracker.com",
                    Password = "thomas1234",
                    Role = "User"
                }

            };

            return creds;
        }
    }

    
}
