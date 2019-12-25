using STEM_backend.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STEM_backend.Repositories.Interfaces
{
    public interface ISTEMStatusRepository
    {
        List<STEMStatu> GetSTEMStatus();
    }
}