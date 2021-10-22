using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkDemo.Models
{
    class StudentDBContext :DbContext
    {
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder  builders)
        {
            builders.UseSqlServer("data source=adminvm\\SQLEXPRESS;initial catalog=practiceDb; user id=sa;password=pass@123");
               
        }
        
    }
}
