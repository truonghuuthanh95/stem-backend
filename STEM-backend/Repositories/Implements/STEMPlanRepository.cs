using STEM_backend.Models.DAO;
using STEM_backend.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace STEM_backend.Repositories.Implements
{
    public class STEMPlanRepository : ISTEMPlanRepository
    {
        STEMDB _db;

        public STEMPlanRepository(STEMDB db)
        {
            _db = db;
        }

        public STEMPlan CreateSTEMPlan(STEMPlan sTEMPost)
        {
            _db.STEMPlans.Add(sTEMPost);
            _db.SaveChanges();
            return sTEMPost;
        }

        public STEMPlan DeleteSTEMPlan(STEMPlan sTEMPost)
        {
            _db.Entry(sTEMPost).State = EntityState.Modified;
            _db.SaveChanges();
            return sTEMPost;
        }

        public STEMPlan GetSTEMPlanById(int id)
        {
            STEMPlan sTEMPost = _db.STEMPlans.AsNoTracking().Where(s => s.Id == id).SingleOrDefault();
            return sTEMPost;
        }

        public List<STEMPlan> GetSTEMPlans()
        {
            var sTEMPosts = _db.STEMPlans.AsNoTracking().Where(s => s.IsActive == true).ToList();
            return sTEMPosts;
        }

        public List<STEMPlan> GetSTEMPlansByTeacherId(string teacherId)
        {
            var sTEMPosts = _db.STEMPlans.AsNoTracking().Where(s => s.TeacherId == teacherId).ToList();
            return sTEMPosts;
        }


        public STEMPlan UpdateSTEMPlan(STEMPlan sTEMPlan)
        {
            _db.Entry(sTEMPlan).State = EntityState.Modified;
            _db.SaveChanges();
            return sTEMPlan;
        }
    }
}