using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ProjectC;
using System;

namespace ProjectC.Models
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
    public void SetId(int Id);
    {
      _id = Id;
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

      // public static void ClearAll()
      // {
      //   _instances.Clear();
      // }
      // public static Task Find(int searchId)
      // {
      //   return _instances[searchId-1];
      // }

  }
}
