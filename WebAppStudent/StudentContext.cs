using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAppStudent.Models;

namespace WebAppStudent
{
    public class StudentContext : DbContext
    {
        public StudentContext() : base("DefaultConnection")
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}