using STEM_backend.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STEM_backend.Repositories.Interfaces
{
    public interface ISTEMReportRepository
    {
        STEMReport CreateSTEMReport(STEMReport sTEMPReport);
        STEMReport UpdateSTEMReport(STEMReport sTEMPReport);
        List<STEMReport> GetSTEMReports();
        STEMReport GetSTEMReportById(int id);
        List<STEMReport> GetSTEMReportsByTeacherId(string teacherId);

        STEMReport DeleteSTEMPReport(STEMReport sTEMPReport);
    }
}