using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ToDoList.Models;

namespace ToDoList.Tests
{
  [TestClass]
  public class TaskTests : IDisposable
  {

    public void Dispose()
    {
      Task.ClearAll();
    }

    public TaskTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=todo_test;";
    }

    // [TestMethod]
    // public void GetDescription_ReturnsDescription_String()
    // {
    //  //Arrange
    //  string description = "Walk the dog.";
    //  Task newTask = new Task(description);
    //
    //  //Act
    //  string result = newTask.GetDescription();
    //
    //  //Assert
    //  Assert.AreEqual(description, result);
    // }

    [TestMethod]
    public void GetAll_DatabaseEmptyAtFirst_0()
    {
      //Arrange, Act
      int result = Task.GetAll().Count;
      Console.WriteLine("result: "+ result);
      //Assert
      Assert.AreEqual(0, result);
    }



  }
}
