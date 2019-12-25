using STEM_backend.Models.DAO;
using STEM_backend.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STEM_backend.Repositories.Implements
{
    public class STEMStatusRepository : ISTEMStatusRepository
    {
        STEMDB _db;

        public STEMStatusRepository(STEMDB db)
        {
            _db = db;
        }

        public List<STEMStatu> GetSTEMStatus()
        {
            var status = _db.STEMStatus.AsNoTracking().Where(s => s.IsActive == true).ToList();
            return status;
        }

        
    }
}