﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_List_2.Models
{
    public class Tasks
    {
        public int TaskId { get; private set; } = 0;
        public List<Task> ListOfTasks { get; set; }

        public Tasks()
        {
            ListOfTasks = new List<Task>();
        }

        public void Add(Task task)
        {
            TaskId = TaskId++;
            task.Id = TaskId;
            ListOfTasks.Add(task);
        }

        public void Delete(int taskId)
        {
            for (int i = 0; i < ListOfTasks.Count; i++)
            {
                if (ListOfTasks[i].Id == taskId)
                {
                    ListOfTasks.RemoveAt(i);
                }
            }
        }
    }
}