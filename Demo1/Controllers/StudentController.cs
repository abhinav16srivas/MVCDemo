using Demo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo1.Controllers
{
    public class StudentController : Controller
    {
        static List<Student> students = new List<Student>
        {
            new Student(1, "Abhinav", Convert.ToDateTime("16/08/1997"), Gender.Male),
            new Student(2, "Aayushi", Convert.ToDateTime("22/07/1999"), Gender.Female)
        };
        static int count = 2;
        // GET: Student
        public ActionResult Index()
        {
            return View(students);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            Student student = students.Find(s => s.Id == id);
            if (student == null) return RedirectToAction(nameof(Index));
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    student.Id = ++count;
                    students.Add(student);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            //Student s3 = students.FirstOrDefault(foundStudent => foundStudent.Id == id);
            //Student s2 = (from s1 in students where s1.Id == id select s1).FirstOrDefault();
            Student student = students.Find(s => s.Id == id);
            if (student == null) return RedirectToAction(nameof(Index));
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == student.Id)
                    {
                        Student existing = students.Find(s => s.Id == id);
                        existing.Name = student.Name;
                        existing.Gender = student.Gender;
                        existing.DateOfBirth = student.DateOfBirth;
                        return RedirectToAction(nameof(Index));
                    }
                    else return View();
                }
                else return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            Student student = students.Find(s => s.Id == id);
            if (student == null) return RedirectToAction(nameof(Index));
            return View(student);
        }

        [HttpPost]
        public ActionResult Delete(int id, Student student1)
        {
            try
            {
                Student s = students.Find(student => student.Id == id);
                if(students.Remove(s))
                return RedirectToAction("Index");
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult StudentByGenre()
        {
            return View();
        }

        [HttpPost]
        public ActionResult StudentByGenre(Gender gender)
        {
            var student = students.FindAll(s => s.Gender == gender);
            return View(student);
        }
    }
}
