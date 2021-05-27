using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepositoryPattern.Models.CoreLayer;

namespace RepositoryPattern.Models.PersistenceLayer
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(AppContext context) :base(context)
        {

        }
        public IEnumerable<Student> GetStudentsByDesendingOrder()
        {
            return AppContext.Students.OrderByDescending(s => s.Id).ToList();
        }

        public AppContext AppContext
        {
            get { return Context as AppContext; } // Context is inherited from Repository class
        }
    }
}