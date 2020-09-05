using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.UCredentialData
{
    public class SqlUCredentialRepo : ICRUDRepo<UCredential>
    {
        private TrackerContext _context;

        public SqlUCredentialRepo(TrackerContext context)
        {
            _context = context;
        }


        public void CreateRow(UCredential uCredential)
        {
            if(uCredential == null)
            {
                throw new ArgumentNullException(nameof(uCredential));
            }

            _context.Add(uCredential);
        }

        

        public IEnumerable<UCredential> GetAllRows()
        {
            return _context.UCredentials.ToList();
        }

        public UCredential GetRowByKey(string username)
        {
            return _context.UCredentials.FirstOrDefault(p => p.Username ==  username );
        }

        public UCredential GetRowById(int id)
        {
            return _context.UCredentials.FirstOrDefault(p => p.Id == id);
        }


        public UCredential GetRowByUsername(string username)
        {
            return _context.UCredentials.FirstOrDefault(p => p.Username == username);
        }


        public void UpdateRow(UCredential uCredential)
        {
            //Nothing: sql ef dbcontext autohandles update
        }


        public void DeleteRow(UCredential uCredential)
        {
            if (uCredential == null)
            {
                throw new ArgumentNullException(nameof(uCredential));
            }

            _context.Remove(uCredential);
        }


        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
