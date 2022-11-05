using BackEnd_Bd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackEnd_Bd.Controllers
{
    public class AlumnosController : Controller
    {
        // GET: Alumnos
        public ActionResult Index()
        {
            using(AlumnoDbContex dbAlumnos=new AlumnoDbContex())
            {
                //select * from alumnos

                return View(dbAlumnos.Alumnos.ToList());
            }
        }
        public ActionResult Details(int id)
        {
            using (AlumnoDbContex dbAlumnos = new AlumnoDbContex())
            {
                Alumnos alumnos = dbAlumnos.Alumnos.Find(id);
                if(alumnos==null)
                {
                    return HttpNotFound();
                }
                return View(alumnos);
            }
            
        }
        public ActionResult Edit(int? id)
        {
            using (AlumnoDbContex dbAlumnos = new AlumnoDbContex())
            {
               return View(dbAlumnos.Alumnos.Where(x=>x.Id==id).FirstOrDefault());
            }

        }
        [HttpPost]
        public ActionResult Edit(Alumnos alum)
        {
            using (AlumnoDbContex dbAlumnos = new AlumnoDbContex())
            {
                dbAlumnos.Entry(alum).State = System.Data.Entity.EntityState.Modified;
                dbAlumnos.SaveChanges();
            }
            return RedirectToAction("Index");
        }
       

        //Aqui empieza el Delete
        public ActionResult Delete(int? id)
        {
            using (AlumnoDbContex dbAlumnos = new AlumnoDbContex())
            {
                return View(dbAlumnos.Alumnos.Where(x => x.Id == id).FirstOrDefault());
            }

        }
        [HttpPost]
        public ActionResult Delete(Alumnos alum, int id)
        {
            using (AlumnoDbContex dbAlumnos = new AlumnoDbContex())
            {
                Alumnos al = dbAlumnos.Alumnos.Where(x => x.Id == id).FirstOrDefault();
                dbAlumnos.Alumnos.Remove(al);
                dbAlumnos.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        //Aqui termina el Delete
        public ActionResult Create(Alumnos alum)
        {
            using (AlumnoDbContex dbAlumnos = new AlumnoDbContex())
            {
                dbAlumnos.Alumnos.Add(alum);
                dbAlumnos.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            return View();  
        }

        
       
    }
}