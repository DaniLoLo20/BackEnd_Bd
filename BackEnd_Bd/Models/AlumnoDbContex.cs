using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BackEnd_Bd.Models
{
    public class AlumnoDbContex: DbContext
    {
        private const string ConnectionString = "DefaultConnection";
        public AlumnoDbContex() : base(ConnectionString)
        {

        }
        public DbSet<Alumnos> Alumnos { get; set; }

        public DbSet<Maestros> Maestros { get; set; }
    }
    
}