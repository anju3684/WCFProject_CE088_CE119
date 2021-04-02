using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TMSWebApi.Models;

namespace TMSWebApi.Database
{
    public class TaskDbContext: DbContext
    {
        public TaskDbContext():base("DefaultConnection")
        {
        }
        public DbSet<Task> tasks { get; set; }
        public DbSet<User> users { get; set; }
    }
}