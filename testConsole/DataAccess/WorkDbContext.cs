using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testConsole.Models;

namespace testConsole.DataAccess
{
    public class WorkDbContext : DbContext
    {

        public DbSet<Maps> Maps{ get; set; }
        public DbSet<MapSource> mapSource { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=185.88.179.152; Database=Work_DataBase; User Id=user1; Password=QAZwsxEDC123!@#;");

            base.OnConfiguring(optionsBuilder);
        }


    }


   
}
