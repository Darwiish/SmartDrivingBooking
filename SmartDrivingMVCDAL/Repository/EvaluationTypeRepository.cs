using SmartDrivingMVCDAL.Data;
using SmartDrivingMVCDAL.DomainModels;
using System.Collections.Generic;
using System.Linq;

namespace SmartDrivingMVCDAL
{

    public class EvaluationTypeRepository : IRepository<EvaluationType>
    {
        public IEnumerable<EvaluationType> ReadAll()
        {
            using (var ctx = new SmartDrivingContext())
            {
                return ctx.EvaluationTypes.ToList();
            }
        }

        public EvaluationType Get(int id)
        {
            using (var ctx = new SmartDrivingContext())
            {
                return ctx.EvaluationTypes.FirstOrDefault();
            }
        }

        public void Add(EvaluationType evaluationType)
        {
            using (var ctx = new SmartDrivingContext())
            {
                ctx.EvaluationTypes.Add(evaluationType);
                ctx.SaveChanges();
            }
        }

        public void Update(EvaluationType evaluationType)
        {
            using (var ctx = new SmartDrivingContext())
            {
                EvaluationType e = ctx.EvaluationTypes.Where(x => x.EvaluationTypeId == evaluationType.EvaluationTypeId).First();

                e.Title = evaluationType.Title;
                e.Description = evaluationType.Description;

                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new SmartDrivingContext())
            {
                EvaluationType e = ctx.EvaluationTypes.Where(x => x.EvaluationTypeId == id).FirstOrDefault();
                if (e != null)
                {
                    ctx.EvaluationTypes.Attach(e);
                    ctx.EvaluationTypes.Remove(e);
                    ctx.SaveChanges();
                }
            }
        }
    }
}

