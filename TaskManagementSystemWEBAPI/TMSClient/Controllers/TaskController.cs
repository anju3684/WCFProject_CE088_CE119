using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using TMSClient.Models;

namespace TMSClient.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        Uri badd = new Uri("http://localhost:63659/api");
        HttpClient client;
        private List<TaskViewModel1> tasklist;

        public TaskController()
        {
            client = new HttpClient();
            client.BaseAddress = badd;
        }

        public ActionResult Users()
        {
            List<UserViewModel> users = null;
            HttpResponseMessage res = client.GetAsync(client.BaseAddress + "/user/").Result;
            if (res.IsSuccessStatusCode)
            {
                string content = res.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<UserViewModel>>(content);
                return View(users);
            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserViewModel u)
        {
            string data = JsonConvert.SerializeObject(u);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage res = client.PostAsync(client.BaseAddress + "/user/find", content).Result;
            if (res.IsSuccessStatusCode)
            {
                string obj = res.Content.ReadAsStringAsync().Result;
                UserViewModel user = JsonConvert.DeserializeObject<UserViewModel>(obj);
                if(user != null)
                {
                    ViewBag.User = user.email;
                    if (user.email != "admin@gmail.com")
                    {
                        HttpContext.Session["user"] = user.email;
                        HttpContext.Session["pswd"] = user.password;
                        string newobj = JsonConvert.SerializeObject(user);
                        StringContent cont = new StringContent(newobj, Encoding.UTF8, "application/json");
                        HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/task/find", cont).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            string d = response.Content.ReadAsStringAsync().Result;
                            List<TaskViewModel1> tasks = JsonConvert.DeserializeObject<List<TaskViewModel1>>(d);
                            return View("UserPage", tasks);
                        }
                    }
                    return RedirectToAction("Index");
                }
                ViewBag.error = "Email and Password doesn't match";
                return View(u);
            }
            return View(u);
        }

        public ActionResult Index() 
        {
            HttpResponseMessage res = client.GetAsync(client.BaseAddress + "/task").Result;
            if(res.IsSuccessStatusCode)
            {
                string content = res.Content.ReadAsStringAsync().Result;
                tasklist = JsonConvert.DeserializeObject<List<TaskViewModel1>>(content);
            }
            ViewBag.User = "admin@gmail.com";
            return View(tasklist);
        }
        public ActionResult Details(int id)
        {
            TaskViewModel1 model = null;
            HttpResponseMessage res = client.GetAsync(client.BaseAddress + "/task/" + id).Result;
            if (res.IsSuccessStatusCode)
            {
                string content = res.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<TaskViewModel1>(content);
                TaskViewModel mode = new TaskViewModel();
                mode.TaskId = model.TaskId;
                mode.Description = model.Description;
                mode.LastDate = model.LastDate;
                mode.subject = model.subject;
                mode.Time = model.Time;
                mode.priority = (Models.TaskViewModel.Priority)Enum.Parse(typeof(Models.TaskViewModel.Priority), model.Priority, true);
                mode.status = (Models.TaskViewModel.Status)Enum.Parse(typeof(Models.TaskViewModel.Status), model.Status, true);
                return View(mode);
            }
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            TaskViewModel1 model = null;
            HttpResponseMessage res = client.GetAsync(client.BaseAddress + "/task/" + id).Result;
            if (res.IsSuccessStatusCode)
            {
                string content = res.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<TaskViewModel1>(content);
                TaskViewModel mode = new TaskViewModel();
                mode.TaskId = model.TaskId;
                mode.Description = model.Description;
                mode.LastDate = model.LastDate;
                mode.subject = model.subject;
                mode.Time = model.Time;
                mode.priority = (Models.TaskViewModel.Priority)Enum.Parse(typeof(Models.TaskViewModel.Priority), model.Priority, true);
                mode.status = (Models.TaskViewModel.Status)Enum.Parse(typeof(Models.TaskViewModel.Status), model.Status, true);
                return View(mode);
            }
            return View();
        }

        public ActionResult DeleteUser(int id)
        {
            HttpResponseMessage res = client.GetAsync(client.BaseAddress + "/user/" + id).Result;
            if(res.IsSuccessStatusCode)
            {
                string content = res.Content.ReadAsStringAsync().Result;
                UserViewModel model = JsonConvert.DeserializeObject<UserViewModel>(content);
                return View(model);
            }
            return View();
        }

        public ActionResult Create()
        {
            List<UserViewModel> users = null;
            HttpResponseMessage res = client.GetAsync(client.BaseAddress + "/user/").Result;
            if (res.IsSuccessStatusCode)
            {
                string content = res.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<UserViewModel>>(content);
            }
            List<string> unames = new List<string>();
            foreach(var u in users)
            {
                unames.Add(u.email);
            }
            ViewBag.users = unames;
            return View();
        }

        public ActionResult Edit(int id)
        {
            TaskViewModel1 model = null;
            HttpResponseMessage res = client.GetAsync(client.BaseAddress + "/task/" + id).Result;
            if (res.IsSuccessStatusCode)
            {
                string content = res.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<TaskViewModel1>(content);
                List<UserViewModel> users = null;
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/user/").Result;
                if (response.IsSuccessStatusCode)
                {
                    string cont = response.Content.ReadAsStringAsync().Result;
                    users = JsonConvert.DeserializeObject<List<UserViewModel>>(cont);
                }
                List<string> unames = new List<string>();
                foreach (var u in users)
                {
                    unames.Add(u.email);
                }
                ViewBag.users = unames;
                TaskViewModel mode = new TaskViewModel();
                mode.TaskId = model.TaskId;
                mode.Description = model.Description;
                mode.LastDate = model.LastDate;
                mode.subject = model.subject;
                mode.Time = model.Time;
                mode.priority = (Models.TaskViewModel.Priority)Enum.Parse(typeof(Models.TaskViewModel.Priority),model.Priority, true);
                mode.status = (Models.TaskViewModel.Status)Enum.Parse(typeof(Models.TaskViewModel.Status), model.Status, true);
                return View("Create", mode);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(TaskViewModel1 task,string users)
        {
            task.AssignedTo = users;
            string data = JsonConvert.SerializeObject(task);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage res = client.PostAsync(client.BaseAddress + "/task", content).Result;
            if(res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(TaskViewModel1 task,string users)
        {
            task.AssignedTo = users;
            string data = JsonConvert.SerializeObject(task);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage res = client.PutAsync(client.BaseAddress + "/task/"+task.TaskId, content).Result;
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            List<UserViewModel> user = null;
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/user/").Result;
            if (response.IsSuccessStatusCode)
            {
                string cont = response.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<List<UserViewModel>>(cont);
            }
            List<string> unames = new List<string>();
            foreach (var u in user)
            {
                unames.Add(u.email);
            }
            ViewBag.users = unames;
            return View("Create",task);
        }

        [HttpPost]
        public ActionResult Delete(int id,string description)
        {
            HttpResponseMessage res = client.DeleteAsync(client.BaseAddress + "/task/" + id).Result;
            if(res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserModel user)
        {
            UserViewModel u = new UserViewModel();
            u.email = user.email;
            u.password = user.password;
            string data = JsonConvert.SerializeObject(u);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage res = client.PostAsync(client.BaseAddress + "/user/",content).Result;
            if(res.IsSuccessStatusCode)
            {
                return RedirectToAction("Users");
            }
            return View();
        }
        [HttpPost]
        public ActionResult DeleteUser(int id,string email)
        {
            HttpResponseMessage res = client.DeleteAsync(client.BaseAddress + "/user/" + id).Result;
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Users");
            }
            return RedirectToAction("Users");
        }

        public ActionResult SubmitTask(int id)
        {
            TaskViewModel1 model = null;
            HttpResponseMessage res = client.GetAsync(client.BaseAddress + "/task/" + id).Result;
            if (res.IsSuccessStatusCode)
            {
                string content = res.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<TaskViewModel1>(content);
                /*TaskViewModel mode = new TaskViewModel();
                mode.TaskId = model.TaskId;
                mode.Description = model.Description;
                mode.LastDate = model.LastDate;
                mode.subject = model.subject;
                mode.Time = model.Time;
                mode.priority = (Models.TaskViewModel.Priority)Enum.Parse(typeof(Models.TaskViewModel.Priority), model.Priority, true);
                mode.status = (Models.TaskViewModel.Status)Enum.Parse(typeof(Models.TaskViewModel.Status), model.Status, true);*/
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public ActionResult SubmitTask(int id,string desciption)
        {
            HttpResponseMessage res = client.GetAsync(client.BaseAddress + "/task/" + id).Result;
            if(res.IsSuccessStatusCode)
            {
                string content = res.Content.ReadAsStringAsync().Result;
                TaskViewModel1 model = JsonConvert.DeserializeObject<TaskViewModel1>(content);
                model.Status = "Completed";
                DateTime now = DateTime.Now;
                if (now.Date <= model.LastDate.Date)
                {
                    if (now.Date == model.LastDate.Date)
                    {
                        if (now.TimeOfDay <= model.Time.TimeOfDay)
                        {
                            model.submited = "Before";
                        }
                        else
                            model.submited = "After";
                    }
                    else
                    {
                        model.submited = "Before";
                    }
                }
                else
                    model.submited = "After";
                string data = JsonConvert.SerializeObject(model);
                StringContent cont = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/task/" + model.TaskId, cont).Result;
                if(response.IsSuccessStatusCode)
                {
                    UserViewModel user = new UserViewModel();
                    user.email = HttpContext.Session["user"].ToString();
                    user.password = HttpContext.Session["pswd"].ToString();
                    string newobj = JsonConvert.SerializeObject(user);
                    StringContent con = new StringContent(newobj, Encoding.UTF8, "application/json");
                    HttpResponseMessage respons = client.PostAsync(client.BaseAddress + "/task/find", con).Result;
                    if (respons.IsSuccessStatusCode)
                    {
                        string d = respons.Content.ReadAsStringAsync().Result;
                        List<TaskViewModel1> tasks = JsonConvert.DeserializeObject<List<TaskViewModel1>>(d);
                        ViewBag.User = user.email;
                        return View("UserPage", tasks);
                    }
                }
            }
            return View();
        }
    }
}