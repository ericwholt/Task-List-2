using System;
using System.Web.Mvc;
using Task_List_2.Models;

namespace Task_List_2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(User user)
        {
            Users users;
            if (string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.Password))
            {
                Session["Failure"] = "You must enter a email and/or password";
                return View();
            }
            if (Session["Users"] == null)
            {
                Session["Failure"] = null;
                Session["RegSuccess"] = "You have successfully registered. Please login to begin!";
                users = new Users();
                users.Add(user);
                Session["Users"] = users;
                return RedirectToAction("Login");
            }
            else
            {
                Session["Failure"] = null;
                Session["RegSuccess"] = "You have successfully registered. Please login to begin!";
                users = (Users)Session["Users"];
                users.Add(user);
                Session["Users"] = users;
                return RedirectToAction("Login");
            }
        }

        public ActionResult Login()
        {
            if (Session["User"] != null)
            {
                return RedirectToAction("TaskList");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            Session["RegSuccess"] = null;
            if (Session["User"] == null)
            {
                Users listOfUsers;
                if (Session["Users"] == null)
                {

                            Session["Failure"] = "You need to register first";
                            return RedirectToAction("Registration");
                }
                else
                {
                    
                    listOfUsers = (Users)Session["Users"];
                    foreach (User u in listOfUsers.ListOfUsers)
                    {
                        if (user.Email == u.Email && user.Password == u.Password)
                        {
                            Session["Failure"] = null;
                            Session["User"] = u;
                            return RedirectToAction("TaskList");
                        }
                        
                    }
                    Session["Failure"] = "Incorrect email or password";
                    return View();
                }
            }
            return View();
        }

        public ActionResult TaskList()
        {
            if (Session["User"] == null)
            {
                Session["RegSuccess"] = null;
                Session["Failure"] = "You have been logged out due to being idle";
                return RedirectToAction("Login");
            }
            Session["Failure"] = null;
            Tasks tasks;
            if (Session["Tasks"] == null)
            {
                tasks = new Tasks();
                Session["Tasks"] = tasks;
            }
            return View();
        }

        public ActionResult AddTask()
        {
            if (Session["User"] == null)
            {
                Session["RegSuccess"] = null;
                Session["Failure"] = "You have been logged out due to being idle";
                return RedirectToAction("Login");
            }
            Session["Failure"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult AddTask(Task task)
        {
            if (Session["User"] == null)
            {
                Session["RegSuccess"] = null;
                Session["Failure"] = "You have been logged out due to being idle";
                return RedirectToAction("Login");
            }
            Session["Failure"] = null;
            Tasks tasks = (Tasks)Session["Tasks"];
            tasks.Add(task);
            return RedirectToAction("TaskList");
        }

        public ActionResult CompleteTask()
        {
            if (Session["User"] == null)
            {
                Session["RegSuccess"] = null;
                Session["Failure"] = "You have been logged out due to being idle";
                return RedirectToAction("Login");
            }
            Session["Failure"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult CompleteTask(Task task)
        {
            if (Session["User"] == null)
            {
                Session["RegSuccess"] = null;
                Session["Failure"] = "You have been logged out due to being idle";
                return RedirectToAction("Login");
            }
            Session["Failure"] = null;
            if (Session["User"] == null)
            {
                Session["RegSuccess"] = null;
                Session["Failure"] = "You have been logged out due to being idle";
                return RedirectToAction("Login");
            }
            Session["Failure"] = null;
            Tasks tasks = (Tasks)Session["Tasks"];
            tasks.CompleteToggler(task.Id);
            return RedirectToAction("TaskList");
        }

        public ActionResult DeleteTask()
        {
            if (Session["User"] == null)
            {
                Session["RegSuccess"] = null;
                Session["Failure"] = "You have been logged out due to being idle";
                return RedirectToAction("Login");
            }
            Session["Failure"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult DeleteTask(Task task)
        {
            if (Session["User"] == null)
            {
                Session["RegSuccess"] = null;
                Session["Failure"] = "You have been logged out due to being idle";
                return RedirectToAction("Login");
            }
            Session["Failure"] = null;
            Tasks tasks = (Tasks)Session["Tasks"];
            tasks.Delete(task.Id);
            return RedirectToAction("TaskList");
        }

        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("AddTask");
        }
    }
}