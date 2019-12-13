using Microsoft.EntityFrameworkCore;
using SmartDrivingMVC.Models;
using SmartDrivingMVCDAL.Data;
using System.Collections.Generic;
using System.Linq;

namespace SmartDrivingMVC.Repository
{

    public class EvaluationRepository : IRepository<Evaluation>
    {
        private SmartDrivingContext smartDrivingContext;

        public EvaluationRepository(SmartDrivingContext sdc)
        {
            this.smartDrivingContext = sdc;
        }

        public IEnumerable<Evaluation> ReadAll()
        {
            using (smartDrivingContext)
            {
                return smartDrivingContext.Evaluation.Include(x => x.BookingLog).ToList();
            }
        }

        public Evaluation Get(int id)
        {
            using (smartDrivingContext)
            {
                return smartDrivingContext.Evaluation.FirstOrDefault();
            }
        }

        public void Add(Evaluation evaluation)
        {
            using (smartDrivingContext)
            {
                smartDrivingContext.Evaluation.Add(evaluation);
                smartDrivingContext.SaveChanges();
            }
        }

        public void Update(Evaluation evaluation)
        {
            using (smartDrivingContext)
            {
                Evaluation e = smartDrivingContext.Evaluation.Where(x => x.EvaluationId == evaluation.EvaluationId).First();

                e.Resulte = evaluation.Resulte;

                smartDrivingContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (smartDrivingContext)
            {
                Evaluation e = smartDrivingContext.Evaluation.Where(x => x.EvaluationId == id).FirstOrDefault();
                if (e != null)
                {
                    smartDrivingContext.Evaluation.Attach(e);
                    smartDrivingContext.Evaluation.Remove(e);
                    smartDrivingContext.SaveChanges();
                }
            }
        }
    }
}

