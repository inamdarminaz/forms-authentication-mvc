using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepositoryPattern.Auth;
namespace RepositoryPattern.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Marks { get; set; }
        public string Standard { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}