using BackEnd_Bd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackEnd_Bd.Controllers
{
    public class MaestrosController : Controller
    {
        // GET: Maestros
        public ActionResult Index()
        {
            using (AlumnoDbContex dbAlumnos = new AlumnoDbContex())
            {
                //select * from alumnos

                return View(dbAlumnos.Maestros.ToList());
            }
        }
        public ActionResult Details(int id)
        {
            using (AlumnoDbContex dbMaestros = new AlumnoDbContex())
            {
                Maestros maestros = dbMaestros.Maestros.Find(id);
                if (maestros == null)
                {
                    return HttpNotFound();
                }
                return View(maestros);
            }

        }
        public ActionResult Edit(int? id)
        {
            using (AlumnoDbContex dbMaestros = new AlumnoDbContex())
            {
                return View(dbMaestros.Maestros.Where(x => x.Id == id).FirstOrDefault());
            }

        }
        [HttpPost]
        public ActionResult Edit(Maestros maes)
        {
            using (AlumnoDbContex dbMaestros = new AlumnoDbContex())
            {
                dbMaestros.Entry(maes).State = System.Data.Entity.EntityState.Modified;
                dbMaestros.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        //Aqui empieza el Delete
        public ActionResult Delete(int? id)
        {
            using (AlumnoDbContex dbMaestros = new AlumnoDbContex())
            {
                return View(dbMaestros.Maestros.Where(x => x.Id == id).FirstOrDefault());
            }

        }
        [HttpPost]
        public ActionResult Delete(Maestros maes, int id)
        {
            using (AlumnoDbContex dbMaestros = new AlumnoDbContex())
            {
                Maestros ma = dbMaestros.Maestros.Where(x => x.Id == id).FirstOrDefault();
                dbMaestros.Maestros.Remove(ma);
                dbMaestros.SaveChanges();
            }
            return RedirectToAction("Index");
        }
     
        //Aqui termina el Delete
        [HttpPost]
        public ActionResult Create(Maestros maes)
        {
            using (AlumnoDbContex dbMaestros = new AlumnoDbContex())
            {
                dbMaestros.Maestros.Add(maes);
                dbMaestros.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            return View();
        }

    }
}