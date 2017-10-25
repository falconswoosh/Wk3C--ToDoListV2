using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ToDoList;
using System;

namespace ToDoList.Models
{
  public class Task
  {
    private string _description;
    private int _id;
    // private static List<Task> _instances = new List<Task> {};

    public Task(string description, int Id = 0)
    {
      _description = description;
      _id = Id;
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
        bool idEquality = (this.GetId() == newTask.GetId());
        bool descriptionEquality = (this.GetDescription() == newTask.GetDescription());
        return (idEquality && descriptionEquality);
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

    public void SetDescription(string newDescription)
    {
      _description = newDescription;
    }

    public int GetId()
    {
      return _id;
    }

    public void SetId(int Id)
    {
      _id = Id;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
       conn.Open();

       var cmd = conn.CreateCommand() as MySqlCommand;
       cmd.CommandText = @"INSERT INTO 'tasks' ('description') VALUES (@TaskDescription);";

       MySqlParameter description = new MySqlParameter();
       description.ParameterName = "@TaskDescription";
       description.Value = this._description;
       cmd.Parameters.Add(description);

       cmd.ExecuteNonQuery();
       _id = (int) cmd.LastInsertedId;  // Notice the slight update to this line of code!

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
        Task newTask = new Task(taskDescription, taskId);
        allTasks.Add(newTask);
      }
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      return allTasks;
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM tasks;";

      cmd.ExecuteNonQuery();

       conn.Close();
       if (conn != null)
       {
           conn.Dispose();
       }
    }

    public static Task Find(int id)
     {
         Task foundTask= new Task("testDescription");
         return foundTask;
     }

  }
}
