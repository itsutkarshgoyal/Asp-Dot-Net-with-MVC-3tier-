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
    public class CommentsControllerTest
    {


    [TestMethod]
    public void CommentsTestMethod2()
    {
        CommentsController controller = new CommentsController();

        // Act
        ViewResult result = controller.CommentsTestMethod2() as ViewResult;

        // Assert
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void CommentsTestMethod3()
    {
        CommentsController controller = new CommentsController();

        // Act
        ViewResult result = controller.CommentsTestMethod3() as ViewResult;

        // Assert
        Assert.IsNotNull(result);
    }

        [TestMethod]
        public void CommentsTestMethod4()
        {
            CommentsController controller = new CommentsController();

            // Act
            ViewResult result = controller.CommentsTestMethod4() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
