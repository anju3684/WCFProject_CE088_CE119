using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TMSWebApi.Database;
using TMSWebApi.Models;

namespace TMSWebApi.Controllers
{
    public class TaskController : ApiController
    {
        TaskDbContext db = new TaskDbContext();

        //api/task/
        public IEnumerable<Task> GetTasks()
        {
            return db.tasks.ToList();
        }

        //api/task/2
        public Task GetTask(int id)
        {
            return db.tasks.Find(id);
        }

        [Route("api/task/find")]
        public IEnumerable<Task> FindTasks(User u)
        {
            string email = db.users.FirstOrDefault(us => (us.email == u.email) && (us.password == u.password)).email;
            List<Task> t = new List<Task>();
            List<Task> tem = db.tasks.ToList();
            foreach(var task in tem)
            {
                if(task.AssignedTo == email)
                {
                    t.Add(task);
                }
            }
            return t;
        }

        [HttpPost]
        public HttpResponseMessage AddTask(Task t)
        {
            HttpResponseMessage res;
            try
            {
                db.tasks.Add(t);
                db.SaveChanges();
                res = new HttpResponseMessage(HttpStatusCode.Created);
                return res;
            }
            catch(Exception ex)
            {
                res = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return res;
            }
        }

        [HttpPut]
        public HttpResponseMessage UpdateTask(int id,Task t)
        {
            HttpResponseMessage res;
            try
            {
                if (t.TaskId == id)
                {
                    db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    res = new HttpResponseMessage(HttpStatusCode.OK);
                    return res;
                }
                else
                {
                    res = new HttpResponseMessage(HttpStatusCode.NotModified);
                    return res;
                }
            }
            catch
            {
                res = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return res;
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteTask(int id)
        {
            HttpResponseMessage res;
            try
            {
                Task t = db.tasks.Find(id);
                if(t != null)
                {
                    db.tasks.Remove(t);
                    db.SaveChanges();
                    res = new HttpResponseMessage(HttpStatusCode.OK);
                    return res;
                }
                else
                {
                    res = new HttpResponseMessage(HttpStatusCode.NotFound);
                    return res;
                }

            }
            catch
            {
                res = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return res;
            }
        }
    }
}
