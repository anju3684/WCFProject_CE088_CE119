using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TMSWebApi.Database;

namespace TMSWebApi.Controllers
{
    public class UserController : ApiController
    {
        TaskDbContext db = new TaskDbContext();

        //api/user/
        public IEnumerable<User> GetUsers()
        {
            return db.users.ToList();
        }
        //api/user/1
        public User GetUsers(int id)
        {
            return db.users.FirstOrDefault(m => m.UserId == id);
        }

        //api/user/2
        [Route("api/user/find")]
        public User FindUser([FromBody]User u)
        {
            return db.users.FirstOrDefault(us => (us.email == u.email) && (us.password == u.password));
        }

        [HttpPost]
        public HttpResponseMessage AddUser(User t)
        {
            HttpResponseMessage res;
            try
            {
                db.users.Add(t);
                db.SaveChanges();
                res = new HttpResponseMessage(HttpStatusCode.Created);
                return res;
            }
            catch
            {
                res = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return res;
            }
        }

        [HttpPut]
        public HttpResponseMessage UpdateUser(int id, User t)
        {
            HttpResponseMessage res;
            try
            {
                if (t.UserId == id)
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
        public HttpResponseMessage DeleteUser(int id)
        {
            HttpResponseMessage res;
            try
            {
                User t = db.users.Find(id);
                if (t != null)
                {
                    db.users.Remove(t);
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
