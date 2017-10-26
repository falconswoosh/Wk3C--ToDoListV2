using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace ToDoList.Models
{
    public class Task
    {
        private string _description;
        private string _dueDate;
        private int _id;
        private int _categoryId;

        public Task(string description, string dueDate, int categoryId = 0, int id = 0)
        {
            _description = description;
            _dueDate = dueDate;
            _categoryId = categoryId;
            _id = id;
        }


        public override bool Equals(System.Object otherTask)
        {
          if (!(otherTask is Task))
          {
            return false;
          }
          else
          {
             Task newTask = (Task) otherTask;
             bool idEquality = this.GetId() == newTask.GetId();
             bool descriptionEquality = this.GetDescription() == newTask.GetDescription();
             bool categoryEquality = this.GetCategoryId() == newTask.GetCategoryId();
             return (idEquality && descriptionEquality && categoryEquality);
           }
        }
        public override int GetHashCode()
        {
             return this.GetDescription().GetHashCode();
        }

        public string GetDescription()
        {
            return _description;
        }
        public string GetDueDate()
        {
          return _dueDate;
        }
        public int GetId()
        {
            return _id;
        }
        public int GetCategoryId()
        {
            return _categoryId;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO tasks (description, dueDate, category_id) VALUES (@description, @dueDate, @category_id);";

            MySqlParameter description = new MySqlParameter();
            description.ParameterName = "@description";
            description.Value = this._description;
            cmd.Parameters.Add(description);

            MySqlParameter dueDate = new MySqlParameter();
            dueDate.ParameterName = "@dueDate";
            dueDate.Value = this._dueDate;
            cmd.Parameters.Add(dueDate);


            MySqlParameter categoryId = new MySqlParameter();
            categoryId.ParameterName = "@category_id";
            categoryId.Value = this._categoryId;
            cmd.Parameters.Add(categoryId);


            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Task> GetAll()
        {
            List<Task> allTasks = new List<Task> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM tasks;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
              int taskId = rdr.GetInt32(0);
              string taskDescription = rdr.GetString(1);
              int taskCategoryId = rdr.GetInt32(2);
              string taskDueDate = rdr.GetDateTime(3).ToString();
              Task newTask = new Task(taskDescription, taskDueDate, taskCategoryId, taskId);
              allTasks.Add(newTask);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allTasks;
        }
        public static Task Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM tasks WHERE id = (@searchId);";

            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = id;
            cmd.Parameters.Add(searchId);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int taskId = 0;
            string taskName = "";
            string taskDueDate = "";
            int taskCategoryId = 0;

            while(rdr.Read())
            {
              taskId = rdr.GetInt32(0);
              taskName = rdr.GetString(1);
              taskCategoryId = rdr.GetInt32(2);
              taskDueDate = rdr.GetString(3);
            }
            Task newTask = new Task(taskName, taskDueDate, taskCategoryId, taskId);
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return newTask;
        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM tasks;";
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}
