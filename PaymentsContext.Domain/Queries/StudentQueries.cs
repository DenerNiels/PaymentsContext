using PaymentsContext.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsContext.Domain.Queries
{
    public static class StudentQueries
    {
        public static Expression<Func<Student, bool>> GetStudent(string document)
        {
            return x => x.Document.Number == document;
        }

        public static Expression<Func<Student, bool>> GetStudentInfo(string v)
        {
            throw new NotImplementedException();
        }
    }
}
