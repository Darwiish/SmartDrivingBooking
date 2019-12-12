using SmartDrivingMVCDAL.Data;
using SmartDrivingMVCDAL.DomainModels;
using System.Collections.Generic;
using System.Linq;

namespace SmartDrivingMVCDAL
{

    public class BookingEvaluationRepository : IRepository<BookingEvaluation>
    {
        public IEnumerable<BookingEvaluation> ReadAll()
        {
            using (var ctx = new SmartDrivingContext())
            {
                return ctx.BookingEvaluations.ToList();
            }
        }

        public BookingEvaluation Get(int id)
        {
            using (var ctx = new SmartDrivingContext())
            {
                return ctx.BookingEvaluations.FirstOrDefault();
            }
        }

        public void Add(BookingEvaluation bookingEvaluation)
        {
            using (var ctx = new SmartDrivingContext())
            {
                ctx.BookingEvaluations.Add(bookingEvaluation);
                ctx.SaveChanges();
            }
        }

        public void Update(BookingEvaluation bookingEvaluation)
        {
            using (var ctx = new SmartDrivingContext())
            {
                BookingEvaluation b = ctx.BookingEvaluations.Where(x => x.BookingEvaluationId == bookingEvaluation.BookingEvaluationId).First();

                b.EvaluationResulte = bookingEvaluation.EvaluationResulte;

                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new SmartDrivingContext())
            {
                BookingEvaluation b = ctx.BookingEvaluations.Where(x => x.BookingEvaluationId == id).FirstOrDefault();
                if (b != null)
                {
                    ctx.BookingEvaluations.Attach(b);
                    ctx.BookingEvaluations.Remove(b);
                    ctx.SaveChanges();
                }
            }
        }
    }
}

