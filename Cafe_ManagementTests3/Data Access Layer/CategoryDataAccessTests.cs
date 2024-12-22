using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cafe_Management.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cafe_Management.Entities;

namespace Cafe_Management.Data_Access_Layer.Tests
{
    [TestClass()]
    public class CategoryDataAccessTests
    {
        [TestMethod()]
        public void GetCategoryByIdTest()
        {
            int categoryId = 1002;
            //int categoryId = 9;
            string expectedCategoryName = "Cofee";
            var categoryDataAccess = new CategoryDataAccess(); // Your data access class
            // You may add the logic to simulate or set data within the method directly here

            // Simulate the behavior of the GetCategoryById method (you will manually set these values for testing)
            Category expectedCategory = new Category
            {
                CategoryId = categoryId,
                CategoryName = expectedCategoryName
            };

            // Act
            Category actualCategory = categoryDataAccess.GetCategoryById(categoryId);

            // Assert
            Assert.IsNotNull(actualCategory, "Category should not be null");
            Assert.AreEqual(expectedCategory.CategoryId, actualCategory.CategoryId, "Category ID should match.");
            Assert.AreEqual(expectedCategory.CategoryName, actualCategory.CategoryName, "Category Name should match.");

           // Assert.Fail();
        }
    }
}