using System;
using System.Collections.Generic;
using Entities.Models;

namespace DAL.UCredentialData
{
    public class MockUCredentialData : ICRUDRepo<UCredential>
    {
        public void CreateRow(UCredential uCredential)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<UCredential> GetAllRows()
        {
            var creds = new List<UCredential>
            {
                new UCredential
                {
                    Id = 1,
                    Username = "john",
                    Email = "john@tracker.com",
                    Password = "john1234"
                },

                new UCredential
                {
                    Id = 2,
                    Username = "george",
                    Email = "george@tracker.com",
                    Password = "goerge1234"
                },

                new UCredential
                {
                    Id = 3,
                    Username = "thomas",
                    Email = "thomas@tracker.com",
                    Password = "thomas1234"
                }

            };

            return creds;
        }

        public UCredential GetRowById(int id)
        {
            return new UCredential
            {
                Id = 1,
                Username = "john",
                Email = "john@tracker.com",
                Password = "john1234"
            };
        }


        public void UpdateRow(UCredential uCredential)
        {
            throw new NotImplementedException();
        }


        public void DeleteRow(UCredential uCredential)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public UCredential GetRowByKey(string key)
        {
            throw new NotImplementedException();
        }
    }
}
