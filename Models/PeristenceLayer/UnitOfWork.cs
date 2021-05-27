using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepositoryPattern.Models.PersistenceLayer;
using RepositoryPattern.Models.CoreLayer;

namespace RepositoryPattern.Models.PersistenceLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppContext _context;
        public IStudentRepository Students { get; private set; } //implementing the property in IUnitOfWork

        public UnitOfWork(AppContext context)
        {
            _context = context;
            Students = new StudentRepository(_context); //initializing every repository with same context
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}