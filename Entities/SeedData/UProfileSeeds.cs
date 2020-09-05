using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.SeedData
{
    static class UProfileSeeds
    {
        public static IEnumerable<UProfile> GetProfileSeeds()
        {
            var personalInfos = new List<UProfile>
            {
                new UProfile
                {
                    UserId = 1,
                    Name = "John Wick",
                    Dob = new DateTime(1975, 10, 30),
                    Sex = "Male"
                },
                new UProfile
                {
                    UserId = 2,
                    Name = "George Stone",
                    Dob = new DateTime(1982, 12, 22),
                    Sex = "Male"
                },
                new UProfile
                {
                    UserId = 3,
                    Name = "Thomas Anderson",
                    Dob = new DateTime(1993, 04, 13),
                    Sex = "Male"
                }

            };

            return personalInfos;
        }
    }
}
