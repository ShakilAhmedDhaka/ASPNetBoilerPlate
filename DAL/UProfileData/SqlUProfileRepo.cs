using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.UProfileData
{
    public class SqlUProfileRepo : ICRUDRepo<UProfile>
    {
        private TrackerContext _context;

        public SqlUProfileRepo(TrackerContext context)
        {
            _context = context;
        }

        public void CreateRow(UProfile pinfo)
        {
            if(pinfo == null)
            {
                throw new ArgumentNullException(nameof(pinfo));
            }

            _context.UProfiles.Add(pinfo);
        }

        

        public IEnumerable<UProfile> GetAllRows()
        {
            return _context.UProfiles.ToList();
        }

        public UProfile GetRowByKey(string id)
        {
            return _context.UProfiles.FirstOrDefault(p => p.UserId == Convert.ToInt32(id) );
        }


        public UProfile GetRowById(int id)
        {
            return GetRowByKey(id.ToString());
        }


        public void UpdateRow(UProfile pinfo)
        {
            //Nothing: sql ef dbcontext autohandles update
        }



        public void DeleteRow(UProfile pinfo)
        {
            if (pinfo == null)
            {
                throw new ArgumentNullException(nameof(pinfo));
            }

            _context.UProfiles.Remove(pinfo);
        }



        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }
    }
}