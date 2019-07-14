using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookReadingEvent;
using BookReadingEvent.Controllers;


namespace BookReadingEvent.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void Testmethod1()
        {
            UserController controller = new UserController();

            // Act
            ViewResult result = controller.UnitTestMethod1() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Testmethod2()
        {
            UserController controller = new UserController();

            // Act
            ViewResult result = controller.UnitTestMethod2() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
