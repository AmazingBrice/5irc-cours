using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WSConvertisseur.Controllers;
using WSConvertisseur.Models;

namespace WSConvertisseurUnitTestProject
{
    [TestClass]
    public class UnitTest
    {

        public DeviseController _controller { get; set;}

        [TestInitialize]
        public void InitialisationDesTests()
        {
            _controller = new DeviseController();
        }


        [TestMethod]
        public void GetById_ExistingIdPassed_ReturnsOkObjectResult()
        {
            // Act
            var result = _controller.GetById(1);
            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult), "Pas un OkObjectResult");
        }

        [TestMethod]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            // Act
            var result = _controller.GetById(1) as OkObjectResult;
            // Assert
            Assert.IsInstanceOfType(result.Value, typeof(Devise), "Pas une Devise");
            Assert.AreEqual(new Devise(1, "Dollar", 1.08), (Devise)result.Value, "Devises identiques");
        }

        [TestMethod]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            
            // Act
            var result = _controller.GetById(20);
            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult), "Pas un NotFoundResult");
        }

        [TestMethod]
        public void GetAllItems_ReturnsNotNullResult()
        {
            // Act
            var result = _controller.GetAll();
            // Assert
            CollectionAssert.AllItemsAreNotNull(result.ToList(), "Null element found");
        }

        [TestMethod]
        public void PostOneItem_ReturnsOkObjectResult()
        {
            // Act
            Devise devise = new Devise() { Id = 4, NomDevise = "Yuan", Taux = 7.58 };
            CreatedAtRouteResult result = (CreatedAtRouteResult) _controller.Post(devise);

            Assert.AreEqual(result.StatusCode, 201, "Post request did not work");
        }

        [TestMethod]
        public void PutOneItem_ReturnsOkObjectResult()
        {
            // Act
            Devise devise = new Devise() { Id = 3, NomDevise = "Yen", Taux = 129.52 };
            NoContentResult result = (NoContentResult) _controller.Put(3, devise);

            Assert.AreEqual(result.StatusCode, 204, "Put request did not work");
        }

        [TestMethod]
        public void DeleteOneItem_ReturnsOkObjectResult()
        {
            // Act
            OkResult result = (OkResult) _controller.Delete(1);
            // Assert
            Assert.AreEqual(result.StatusCode, 200, "Delete request did not work");
        }

        [TestCleanup]
        public void NettoyageDesTests()
        {
            _controller = null;// Nettoyer les variables, ... après chaque test
        }
    }
}