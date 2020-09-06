using Entities.Models;
using System;
using System.Collections.Generic;

namespace DAL.UProfileData
{
    public class MockUProfileRepo : ICRUDRepo<UProfile>
    {
        public void CreateRow(UProfile pinfo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UProfile> GetAllRows()
        {
            var personalInfos = new List<UProfile>
            {
                new UProfile
                {
                    UserId = 0,
                    Name = "John Adams",
                    //Email = "john@Tracker.com",
                    Dob = new DateTime(1735, 10, 30),
                    Sex = "Male"
                },
                new UProfile
                {
                    UserId = 1,
                    Name = "George Washington",
                    //Email = "george@Tracker.com",
                    Dob = new DateTime(1732, 02, 22),
                    Sex = "Male"
                },
                new UProfile
                {
                    UserId = 2,
                    Name = "Thomas Jefferson",
                    //Email = "thomas@Tracker.com",
                    Dob = new DateTime(1743, 04, 13),
                    Sex = "Male"
                }

            };

            return personalInfos;
        }

        public UProfile GetRowById(int id)
        {
            return new UProfile
            {
                UserId = 0,
                Name = "John Adams",
                //Email = "john@Tracker.com",
                Dob = new DateTime(1735, 10, 30),
                Sex = "Male"
            };
        }

        public void UpdateRow(UProfile pinfo)
        {
            throw new NotImplementedException();
        }

        public void DeleteRow(UProfile pinfo)
        {
            throw new NotImplementedException();
        }


        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public UProfile GetRowByKey(string key)
        {
            throw new NotImplementedException();
        }
    }
}