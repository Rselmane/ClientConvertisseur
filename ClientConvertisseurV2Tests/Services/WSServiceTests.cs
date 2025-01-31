using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientConvertisseurV2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientConvertisseurV2.ViewModels;

namespace ClientConvertisseurV2.Services.Tests
{
    [TestClass()]
    public class WSServiceTests
    {
        [TestMethod()]
        public void GetDevisesAsyncTest()
        {
            //Arrange
            WSService service = new WSService("https://localhost:7232/api/");
            //Act
            var result = service.GetDevisesAsync("devises").Result;
            //Assert
            Assert.IsNotNull(result);

        }
        [TestMethod()]
        public void WSServiceTest()
        {
            //Arrange
            WSService service = new WSService("https://localhost:7232/api/");

            //Assert
            Assert.IsNotNull(service);

        }
    }
}