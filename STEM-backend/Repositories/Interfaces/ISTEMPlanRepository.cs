using STEM_backend.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STEM_backend.Repositories.Interfaces
{
    public interface ISTEMPlanRepository
    {
        STEMPlan CreateSTEMPlan(STEMPlan sTEMPost);
        STEMPlan UpdateSTEMPlan(STEMPlan sTEMPost);
        List<STEMPlan> GetSTEMPlans();
        STEMPlan GetSTEMPlanById(int id);
        List<STEMPlan> GetSTEMPlansByTeacherId(string teacherId);

        STEMPlan DeleteSTEMPlan(STEMPlan sTEMPost);
    }
}