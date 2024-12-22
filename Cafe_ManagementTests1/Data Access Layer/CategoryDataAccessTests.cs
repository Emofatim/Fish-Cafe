using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cafe_Management.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Management.Data_Access_Layer.Tests
{
    [TestClass()]
    public class CategoryDataAccessTests
    {
        [TestMethod()]
        public void CreateCategoryTest()
        {

            CategoryDataAccess dataAccess = new CategoryDataAccess();
            string categoryName = "Test Category";
            bool expected = true;

            // Act
            bool actual = dataAccess.CreateCategory(categoryName);

            // Assert
            Assert.AreEqual(expected, actual, "The method should return true for a valid category name.");
        }

    }
}