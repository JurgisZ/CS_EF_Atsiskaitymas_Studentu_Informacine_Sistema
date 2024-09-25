using Microsoft.VisualStudio.TestTools.UnitTesting;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Contexts;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Repositories.Interfaces;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Repositories;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Services.Tests
{
    [TestClass()]
    public class DepartmentServiceTests
    {
        private DepartmentService _testService;
        private StudentsDbContext _context;

        [TestInitialize]

        public void OnInit()
        {            
            var _options = new DbContextOptionsBuilder<StudentsDbContext>()
                .UseInMemoryDatabase(databaseName: "DepartmentsTest" + Guid.NewGuid())
                .Options;

            // Create a new context instance
            _context = new StudentsDbContext(_options);

            // Initialize the repository and service
            IDepartmentRepository repository = new DepartmentRepository(_context);
            var _repository = new DepartmentRepository(_context);
            _testService = new DepartmentService(_repository);
            _context.Database.EnsureCreated();
        }
        [TestCleanup]
        public void Cleanup() 
        { 
            _context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void IsValidNewDepartmentName_ShouldReturnFalse_WhenNameIsNull()
        {
            // Arrange
            string? departmentName = null;

            // Act
            bool result = _testService.IsValidNewDepartmentName(departmentName);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidNewDepartmentName_ShouldReturnFalse_WhenNameIsEmpty()
        {
            // Arrange
            string departmentName = string.Empty;

            // Act
            bool result = _testService.IsValidNewDepartmentName(departmentName);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidNewDepartmentName_ShouldReturnFalse_WhenNameIsTooShort()
        {
            // Arrange
            string departmentName = "IT"; // < 3 chars

            // Act
            bool result = _testService.IsValidNewDepartmentName(departmentName);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidNewDepartmentName_ShouldReturnFalse_WhenDepartmentAlreadyExists()
        {
            // Arrange
            string departmentName = "IT";

            // Act
            bool result = _testService.IsValidNewDepartmentName(departmentName);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidNewDepartmentName_ShouldReturnTrue_WhenNameIsValidAndDoesNotExist()
        {
            // Arrange
            string departmentName = "FilologijosDpt";

            // Act
            bool result = _testService.IsValidNewDepartmentName(departmentName);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsValidNewDepartmentCode_ShouldReturnFalse_WhenCodeIsNull()
        {
            // Arrange
            string? departmentCode = null;

            // Act
            bool result = _testService.IsValidNewDepartmentCode(departmentCode);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidNewDepartmentCode_ShouldReturnFalse_WhenCodeIsEmpty()
        {
            // Arrange
            string departmentCode = string.Empty;

            // Act
            bool result = _testService.IsValidNewDepartmentCode(departmentCode);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidNewDepartmentCode_ShouldReturnFalse_WhenCodeLengthIsNotSix()
        {
            // Arrange
            string departmentCode = "IT"; // <6 chars

            // Act
            bool result = _testService.IsValidNewDepartmentCode(departmentCode);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidNewDepartmentCode_ShouldReturnFalse_WhenDepartmentCodeAlreadyExists()
        {
            // Arrange
            string departmentCode = "MTH567"; //egzituojantis

            // Act
            bool result = _testService.IsValidNewDepartmentCode(departmentCode);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidNewDepartmentCode_ShouldReturnTrue_WhenCodeIsValidAndDoesNotExist()
        {
            // Arrange
            string departmentCode = "NEW123"; // Ensure this code does NOT exist in the database

            // Act
            bool result = _testService.IsValidNewDepartmentCode(departmentCode);

            // Assert
            Assert.IsTrue(result);
        }
    }
}