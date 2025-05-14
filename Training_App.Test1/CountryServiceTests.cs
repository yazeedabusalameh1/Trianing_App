using DAL.Data;
using DAL.ModelsDAL;
using DAL.RepositoryDAL;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_App.Tests
{
    [TestClass]
    public class CityRepositoryDALTests
    {
        [TestMethod]
        public void GivenValidCity_WhenInsertCity_ThenReturnsTrue()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DBContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;

            using var context = new DBContext(options);
            var repo = new CityRepositoryDAL(context);

            var city = new CityDAL
            {
                CityID = 1,
                CityName = "Jenin",
                Population = 100000,
                Governorate = "Jenin",
                Country = "Palestine",
                CityRank = 1
            };

            // Act
            var result = repo.InsertCity(city);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, context.Citys.Count());
        }
    }
}
