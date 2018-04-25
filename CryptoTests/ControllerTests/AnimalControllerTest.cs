using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CryptoSanctuary.Controllers;
using CryptoSanctuary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CryptoTests.ControllerTests
{
    [TestClass]
    public class AnimalControllerTest
    {
        Mock<IAnimalRepository> mock = new Mock<IAnimalRepository>();

        private void DbSetup()
        {
            mock.Setup(m => m.Animals).Returns(new Animal[]
           {
            new Animal {AnimalId = 1, Name = "Wash the dog" },
            new Animal {AnimalId = 2, Name = "Do the dishes" },
            new Animal {AnimalId = 3, Name = "Sweep the floor" }
           }.AsQueryable());
        }

        [TestMethod]
        public void Mock_GetViewResultIndex_ActionResult()
        {   
            //Arrange
            DbSetup();
            AnimalController controller = new AnimalController(mock.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }
       
        [TestMethod]
        public void AnimalController_IndexModelContainsCorrectData_List()
        {
            //Arrange
            DbSetup();
            ViewResult indexView = new AnimalController(mock.Object).Index() as ViewResult;

            //Act
            var result = indexView.ViewData.Model;

            //Assert
            Assert.IsInstanceOfType(result, typeof(List<Animal>));
        }

        [TestMethod]
        public void Mock_IndexModelContainsAnimal_Collection() // Confirms presence of known entry
        {
            // Arrange
            DbSetup();
            AnimalController controller = new AnimalController(mock.Object);
            Animal testAnimal = new Animal();
            testAnimal.Name = "Wash the dog";
            testAnimal.AnimalId = 1;

            // Act
            ViewResult indexView = controller.Index() as ViewResult;
            List<Animal> collection = indexView.ViewData.Model as List<Animal>;

            // Assert
            CollectionAssert.Contains(collection, testAnimal);
        }
        [TestMethod]
        public void Mock_PostViewResultCreate_ViewResult()
        {
            // Arrange
            Animal testAnimal = new Animal
            {
                AnimalId = 1,
                Name = "Wash the dog"
            };

            DbSetup();
            AnimalController controller = new AnimalController(mock.Object);

            // Act
            var resultView = controller.Create(testAnimal);


            // Assert
            Assert.IsInstanceOfType(resultView, typeof(RedirectToActionResult));

        }
        [TestMethod]
        public void Mock_GetDetails_ReturnsView()
        {
            // Arrange
            Animal testAnimal = new Animal
            {
                AnimalId = 1,
                Name = "Wash the dog"
            };

            DbSetup();
            AnimalController controller = new AnimalController(mock.Object);

            // Act
            var resultView = controller.Details(testAnimal.AnimalId) as ViewResult;
            var model = resultView.ViewData.Model as Animal;

            // Assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));
            Assert.IsInstanceOfType(model, typeof(Animal));
        }
    }
}
