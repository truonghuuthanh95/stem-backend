using STEM_backend.Models.DAO;
using STEM_backend.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace STEM_backend.Repositories.Implements
{
    public class STEMReportRepository : ISTEMReportRepository
    {
        STEMDB _db;

        public STEMReportRepository(STEMDB db)
        {
            _db = db;
        }

        public STEMReport CreateSTEMReport(STEMReport sTEMPReport)
        {
            _db.STEMReports.Add(sTEMPReport);
            _db.SaveChanges();
            return sTEMPReport;
        }

        public STEMReport DeleteSTEMPReport(STEMReport sTEMPReport)
        {
            _db.Entry(sTEMPReport).State = EntityState.Modified;
            _db.SaveChanges();
            return sTEMPReport;
        }

        public STEMReport GetSTEMReportById(int id)
        {
            STEMReport sTEMPlan = _db.STEMReports.AsNoTracking().Where(s => s.Id == id).SingleOrDefault();
            return sTEMPlan;
        }

        public List<STEMReport> GetSTEMReports()
        {
            var sTEMPReports = _db.STEMReports.AsNoTracking().Where(s => s.IsActive == true).ToList();
            return sTEMPReports;
        }

        public List<STEMReport> GetSTEMReportsByTeacherId(string teacherId)
        {
            var sTEMPReports = _db.STEMReports.AsNoTracking().Where(s => s.TeacherId == teacherId).ToList();
            return sTEMPReports;
        }

        public STEMReport UpdateSTEMReport(STEMReport sTEMPReport)
        {
            _db.Entry(sTEMPReport).State = EntityState.Modified;
            _db.SaveChanges();
            return sTEMPReport;
        }
    }
}