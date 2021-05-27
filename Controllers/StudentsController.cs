using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepositoryPattern.Models;
using RepositoryPattern.Models.CoreLayer;

namespace RepositoryPattern.Controllers
{
    [Authorize(Roles ="Student")]
    public class StudentsController : Controller
    {     
        private readonly IUnitOfWork _unitOfWork;

        //[InjectionConstructor]               
        public StudentsController(IUnitOfWork unitOfWork)
        {
            //_unitOfWork = new UnitOfWork(new Models.AppContext());        <--- tightly coupled
            _unitOfWork = unitOfWork;                            
        }

        public ActionResult Index()
        {
            var students = _unitOfWork.Students.GetAll();
            return View(students);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            _unitOfWork.Students.Add(student);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }


    }
}