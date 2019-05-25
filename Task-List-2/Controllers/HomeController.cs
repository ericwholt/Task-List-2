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
            Users listOfUsers;
            if (Session["Users"] == null)
            {
                listOfUsers = new Users();
                listOfUsers.ListOfUsers.Add(user);
                Session["Users"] = listOfUsers;
            }
            return View();
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
            if (Session["User"] == null)
            {
                Users listOfUsers;
                    if (Session["Users"] == null)
                    {
                        listOfUsers = new Users();
                        foreach (User u in listOfUsers.ListOfUsers)
                        {
                            if (user.Email == u.Email && user.Password == u.Password)
                                Session["User"] = user;
                            return RedirectToAction("TaskList");
                        }
                    }
                    else
                    {
                        listOfUsers = (Users)Session["Users"];
                        foreach (User u in listOfUsers.ListOfUsers)
                        {
                            if (user.Email == u.Email && user.Password == u.Password)
                                Session["User"] = user;
                            return RedirectToAction("TaskList");
                        }

                    }
            }
            return View();
        }

        public ActionResult TaskList()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Index");
        }
    }
}