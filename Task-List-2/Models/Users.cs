using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_List_2.Models
{
    public class Users
    {
        public int UserId { get; private set; } = 0;
        public List<User> ListOfUsers { get; set; }

        public Users()
        {
            ListOfUsers = new List<User>();
        }

        public void Add(User user)
        {
            UserId = UserId++;
            user.Id = UserId;
            ListOfUsers.Add(user);
        }

        public void Delete(int userId)
        {
            for (int i = 0; i < ListOfUsers.Count; i++)
            {
                if (ListOfUsers[i].Id == userId)
                {
                    ListOfUsers.RemoveAt(i);
                }
            }
        }
    }
}