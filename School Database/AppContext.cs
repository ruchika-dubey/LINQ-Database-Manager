using Microsoft.EntityFrameworkCore;
using School_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School_Database
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions options) : base(options)
        {
        }



        public DbSet<StudentModel> StudentModel { get; set; }

        public DbSet<SubjectModel> SubjectModel { get; set; }

    }
}
