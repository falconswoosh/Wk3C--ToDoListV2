using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ProjectC.Models;

namespace ProjectC.Tests
{
  [TestClass]
  public class TaskTest
  {

   [TestMethod]
   public void GetDescription_ReturnsDescription_String()
   {
     //Arrange
     string description = "Walk the dog.";
     Task newTask = new Task(description);

     //Act
     string result = newTask.GetDescription();

     //Assert
     Assert.AreEqual(description, result);
   }

   

  }
}
