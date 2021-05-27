using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepositoryPattern.Models.CoreLayer
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository Students { get; }
        int Save();
        
    }
}