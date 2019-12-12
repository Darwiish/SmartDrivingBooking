using Microsoft.EntityFrameworkCore;
using SmartDrivingMVCDAL.Data;
using SmartDrivingMVCDAL.DomainModels;
using System.Collections.Generic;
using System.Linq;

namespace SmartDrivingMVCDAL
{

    public class EvaluationRepository : IRepository<Evaluation>
    {
        public IEnumerable<Evaluation> ReadAll()
        {
            using (var ctx = new SmartDrivingContext())
            {
                return ctx.Evaluations.Include(x => x.Activity).ToList();
            }
        }

        public Evaluation Get(int id)
        {
            using (var ctx = new SmartDrivingContext())
            {
                return ctx.Evaluations.FirstOrDefault();
            }
        }

        public void Add(Evaluation evaluation)
        {
            using (var ctx = new SmartDrivingContext())
            {
                ctx.Evaluations.Add(evaluation);
                ctx.SaveChanges();
            }
        }

        public void Update(Evaluation evaluation)
        {
            using (var ctx = new SmartDrivingContext())
            {
                Evaluation e = ctx.Evaluations.Where(x => x.EvaluationId == evaluation.EvaluationId).First();

                e.Resulte = evaluation.Resulte;

                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new SmartDrivingContext())
            {
                Evaluation e = ctx.Evaluations.Where(x => x.EvaluationId == id).FirstOrDefault();
                if (e != null)
                {
                    ctx.Evaluations.Attach(e);
                    ctx.Evaluations.Remove(e);
                    ctx.SaveChanges();
                }
            }
        }
    }
}

