using WSTP3.Controllers;
using WSTP3.Models.DataManager;
using WSTP3.Models.EntityFramework;
using WSTP3.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;

namespace WSTP3UnitTestProject
{
    [TestClass]
    public class CompteUnitTest
    {
        private CompteController _controller;
        private TP3DBContext _context;
        private ICompteRepository _dataRepository;

        public CompteUnitTest()
        {
            var builder = new DbContextOptionsBuilder<TP3DBContext>().UseNpgsql("Server=localhost;port=5432;Database=tp3-db; uid=admin;password=admin;");
            _context = new TP3DBContext(builder.Options);
            _dataRepository = new CompteManager(_context);
            _controller = new CompteController(_dataRepository);
        }

        [TestMethod]
        public async Task GetById_ExistingIdPassed_ReturnsOkObjectResult()
        {
            var input = 1;
            // Act
            var result = await _controller.GetCompteById(input);
            var expectedResult = await _context.Comptes.FirstOrDefaultAsync(c => c.CompteId == input);
            // Assert
            Assert.AreEqual(expectedResult, result.Value, "Incorrect Result");
        }

        [TestMethod]
        public async Task GetByEMail_ExistingIdPassed_ReturnsOkObjectResult()
        {
            var input = "paul.durand@gmail.com";
            // Act
            var result = await _controller.GetCompteByEmail(input);
            var expectedResult = await _context.Comptes.FirstOrDefaultAsync(c => c.Mel == input);
            // Assert
            Assert.AreEqual(expectedResult, result.Value, "Incorrect Result");
        }

        [TestMethod]
        public async Task GetAll_ReturnsOkObjectResult()
        {
            // Act
            var result = await _controller.GetAll();
            var expectedResult = await _context.Comptes.ToListAsync();
            // Assert
            CollectionAssert.AllItemsAreNotNull(result.Value.ToList(), "Null element found");
            Assert.AreEqual(expectedResult.First(), result.Value.ToList().First(), "Incorrect Result");
        }

        [TestMethod]
        public async Task PutCompte_ExistingIdPassed_ReturnsOkObjectResult()
        {
            Compte input = new Compte()
            {
              CompteId = 1,
              Nom = "DURAND",
              Prenom = "Paulette",
              TelPortable = null,
              Mel = "paul.durand@gmail.com",
              Pwd = "Info123/",
              Rue = "Chemin de Bellevue",
              CodePostal = "74940",
              Ville = "Annecy-le-Vieux",
              Pays = "France",
              Latitude = (float?) 45.921154,
              Longitude = (float?) 6.153794,
              DateCreation = Convert.ToDateTime("2021 - 09-24T00:00:00"),
              FavorisCompte = null
            };

            // Act
            await _controller.PutCompte(1, input);
            var result = await _controller.GetCompteById(1);
            var expectedResult = await _context.Comptes.FirstOrDefaultAsync(c => c == input);
            // Assert
            Assert.AreEqual(expectedResult, result.Value, "Incorrect Result");
        }

        [TestMethod]
        public async Task PostCompte_ExistingIdPassed_ReturnsOkObjectResult()
        {
            Compte input = new Compte()
            {
                Nom = "DURAND",
                Prenom = "Paulette",
                TelPortable = null,
                Mel = "paulette.durand@gmail.com",
                Pwd = "Info123/",
                Rue = "Chemin de Bellevue",
                CodePostal = "74940",
                Ville = "Annecy-le-Vieux",
                Pays = "France",
                Latitude = (float?)45.921154,
                Longitude = (float?)6.153794,
                DateCreation = Convert.ToDateTime("2021 - 09-24T00:00:00"),
                FavorisCompte = null
            };

            // Act
            CreatedAtActionResult result = (CreatedAtActionResult) (await _controller.PostCompte(input)).Result;

            // Assert
            Assert.AreEqual(result.StatusCode, 201, "Delete request did not work");

            // Delete created compte to clean database
            var resultEmail = await _controller.GetCompteByEmail(input.Mel);
            await _controller.DeleteCompte(resultEmail.Value.CompteId);
        }

        [TestMethod]
        public async Task DeleteCompte_ExistingIdPassed_ReturnsOkObjectResult()
        {
            // Create compte to not delete element from database

            Compte input = new Compte()
            {
                Nom = "DURAND",
                Prenom = "Paulette",
                TelPortable = null,
                Mel = "paulette.durand@gmail.com",
                Pwd = "Info123/",
                Rue = "Chemin de Bellevue",
                CodePostal = "74940",
                Ville = "Annecy-le-Vieux",
                Pays = "France",
                Latitude = (float?)45.921154,
                Longitude = (float?)6.153794,
                DateCreation = Convert.ToDateTime("2021 - 09-24T00:00:00"),
                FavorisCompte = null
            };

            // Act
            await _controller.PostCompte(input);
            var resultEmail = await _controller.GetCompteByEmail(input.Mel);
            NoContentResult resultDelete = (NoContentResult) await _controller.DeleteCompte(resultEmail.Value.CompteId);

            // Assert
            Assert.AreEqual(resultDelete.StatusCode, 204, "Delete request did not work");
        }

        [TestMethod]
        public async Task PatchCompte_ExistingIdPassed_ReturnsOkObjectResult()
        {
            var replaceValue = "toto";

            JsonPatchDocument<Compte> patchDoc = new JsonPatchDocument<Compte>();
            patchDoc.Replace(e => e.Nom, replaceValue);

            // Act
            await _controller.PatchCompte(1, patchDoc);
            var result = await _controller.GetCompteById(1);

            // Assert
            Assert.AreEqual(result.Value.Nom, replaceValue, "Patch request did not work");
        }
    }
}
