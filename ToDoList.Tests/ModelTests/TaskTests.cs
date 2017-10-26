using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using ToDoList.Models;

namespace ToDoList.Tests
{

   [TestClass]
   public class TaskTests : IDisposable
   {
       public TaskTests()
       {
           DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=todo_test;";
       }
        public void Dispose()
       {
         Task.DeleteAll();
         Category.DeleteAll();
       }

      //  [TestMethod]
      //  public void Equals_OverrideTrueForSameDescription_Task()
      //  {
      //    //Arrange, Act
      //    Task firstTask = new Task("Mow the lawn", 1);
      //    Task secondTask = new Task("Mow the lawn", 1);
       //
      //    //Assert
      //    Assert.AreEqual(firstTask, secondTask);
      //  }
      //
      //  [TestMethod]
      //  public void Save_SavesTaskToDatabase_TaskList()
      //  {
      //    //Arrange
      //    DateTime currentDate = DateTime.Now;
      //    string currentDateinMySql = currentDate.ToString("yyyy-MM-dd HH:mm:ss");
      //    Task testTask = new Task("Mow the lawn", currentDateinMySql);
      //    testTask.Save();
       //
      //    //Act
      //    List<Task> result = Task.GetAll();
      //    List<Task> testList = new List<Task>{testTask};
       //
      //    //Assert
      //    CollectionAssert.AreEqual(testList, result);
      //  }
      // [TestMethod]
      //  public void Save_DatabaseAssignsIdToObject_Id()
      //  {
      //    //Arrange
      //    Task testTask = new Task("Mow the lawn", 1);
      //    testTask.Save();
      //
      //    //Act
      //    Task savedTask = Task.GetAll()[0];
      //
      //    int result = savedTask.GetId();
      //    int testId = testTask.GetId();
      //
      //    //Assert
      //    Assert.AreEqual(testId, result);
      //  }
      //
      //  [TestMethod]
      //  public void Find_FindsTaskInDatabase_Task()
      //  {
      //    //Arrange
      //    Task testTask = new Task("Mow the lawn", 1);
      //    testTask.Save();
      //
      //    //Act
      //    Task foundTask = Task.Find(testTask.GetId());
      //
      //    //Assert
      //    Assert.AreEqual(testTask, foundTask);
      //  }

      [TestMethod]
      public void DeleteAll_Tasks()
      {
        Task taskA = new Task("some stuff","1212/12/12",0);
        Task taskB = new Task("some other stuff","1212/12/12",1);

        taskA.Save();
        taskB.Save();

        foreach(Task n in Task.GetAll())
        { Console.WriteLine(n.GetDescription() + " : " + n.GetDueDate()); }

        Task.DeleteAll();

        foreach(Task n in Task.GetAll())
        { Console.WriteLine(n.GetDescription() +" : "+ n.GetDueDate()); }

        Assert.AreEqual(true, Task.GetAll().Count == 0);
      }
   }
}
