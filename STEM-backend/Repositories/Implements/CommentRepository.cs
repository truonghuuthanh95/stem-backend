using STEM_backend.Models.DAO;
using STEM_backend.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STEM_backend.Repositories.Implements
{
    public class CommentRepository : ICommentRepository
    {
        STEMDB _db;

        public CommentRepository(STEMDB db)
        {
            _db = db;
        }

        public STEMPlanComment CreateSTEMPlanComment(STEMPlanComment comment)
        {
            _db.STEMPlanComments.Add(comment);
            _db.SaveChanges();
            return comment;
        }

        public STEMReportComment CreateSTEMReportComment(STEMReportComment comment)
        {
            _db.STEMReportComments.Add(comment);
            _db.SaveChanges();
            return comment;
        }

        public STEMPlanComment GetSTEMPlanCommentById(int id)
        {
            var comment = _db.STEMPlanComments.AsNoTracking().Where(s => s.STEMPlanId == id).SingleOrDefault();
            return comment;
        }

        public STEMReportComment GetSTEMReportCommentById(int id)
        {
            var comment = _db.STEMReportComments.AsNoTracking().Where(s => s.STEMReportId == id).SingleOrDefault();
            return comment;
        }
    }
}