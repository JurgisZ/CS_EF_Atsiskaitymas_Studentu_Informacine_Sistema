using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Repositories;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Repositories.Interfaces;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Services;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Services.Interfaces;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Entities;


namespace StudentsIS_tests.Services
{
    [TestClass]
    public class StudentServiceTests
    {
        //[TestInitialize]
        private StudentService _testService;
        public void Setup()
        {
            var context = new StudentsDbContext();
            IStudentRepository repository = new StudentRepository(context);
            IStudentLectureRepository studentLectureRepository = new StudentLectureRepository(context);
            _testService = new StudentService(repository, studentLectureRepository);
        }

        [TestMethod]
        public void IsValidStudentName_ShouldReturnFalse_WhenNameIsNull()
        {
            // Arrange
            Setup();
            string? name = null;

            // Act
            bool result = _testService.IsValidStudentName(name);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidStudentName_ShouldReturnFalse_WhenNameIsEmpty()
        {
            // Arrange
            Setup();
            string name = string.Empty;

            // Act
            bool result = _testService.IsValidStudentName(name);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidStudentName_ShouldReturnFalse_WhenNameIsTooShort()
        {
            // Arrange
            Setup();
            string name = "A"; // Less than 2 characters

            // Act
            bool result = _testService.IsValidStudentName(name);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidStudentName_ShouldReturnFalse_WhenNameIsTooLong()
        {
            // Arrange
            Setup();
            string name = new string('A', 51); // More than 50 characters

            // Act
            bool result = _testService.IsValidStudentName(name);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidStudentName_ShouldReturnTrue_WhenNameIsValid()
        {
            // Arrange
            Setup();
            string name = "John"; // Valid name

            // Act
            bool result = _testService.IsValidStudentName(name);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidStudentName_ShouldReturnTrue_WhenNameIsExactlyTwoCharacters()
        {
            // Arrange
            Setup();
            string name = "Al"; // Exactly 2 characters

            // Act
            bool result = _testService.IsValidStudentName(name);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidStudentName_ShouldReturnTrue_WhenNameIsExactlyFiftyCharacters()
        {
            // Arrange
            Setup();
            string name = new string('A', 50); // Exactly 50 characters

            // Act
            bool result = _testService.IsValidStudentName(name);

            // Assert
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void IsValidStudentLastName_ShouldReturnFalse_WhenNameIsNull()
        {
            // Arrange
            Setup();
            string? name = null;

            // Act
            var result = _testService.IsValidStudentLastName(name);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidStudentLastName_ShouldReturnFalse_WhenNameIsEmpty()
        {
            // Arrange
            Setup();
            string name = string.Empty;

            // Act
            var result = _testService.IsValidStudentLastName(name);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidStudentLastName_ShouldReturnFalse_WhenNameIsTooShort()
        {
            // Arrange
            Setup();
            string name = "a";

            // Act
            var result = _testService.IsValidStudentLastName(name);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidStudentLastName_ShouldReturnFalse_WhenNameIsTooLong()
        {
            // Arrange
            Setup();
            string name = new string('a', 51); // > 50 chars

            // Act
            var result = _testService.IsValidStudentLastName(name);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidStudentLastName_ShouldReturnTrue_WhenNameIsValid()
        {
            // Arrange
            Setup();
            string name = "Jonas";

            // Act
            var result = _testService.IsValidStudentLastName(name);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsValidNewStudentCode_ShouldReturnFalse_WhenCodeIsNotEightDigits()
        {
            // Arrange
            Setup();
            int studentCode = 1234567; // 7 skaiciai

            // Act
            bool result = _testService.IsValidNewStudentCode(studentCode);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidNewStudentCode_ShouldReturnFalse_WhenCodeExistsInRepository()
        {
            // Arrange
            Setup();
            int studentCode = 12345678; // 8 digits

            // Act
            bool result = _testService.IsValidNewStudentCode(studentCode);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidNewStudentCode_ShouldReturnTrue_WhenCodeIsValid()
        {
            // Arrange
            Setup();
            int studentCode = 78940532; // 8 digits

            // Act
            bool result = _testService.IsValidNewStudentCode(studentCode);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsValidEmail_ShouldReturnTrue_ForValidEmail()
        {
            // Arrange
            Setup();
            string email = "example@example.com";

            // Act
            bool result = _testService.IsValidEmail(email);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidEmail_ShouldReturnFalse_ForInvalidEmail_NoAtSymbol()
        {
            // Arrange
            Setup();
            string email = "example.com";

            // Act
            bool result = _testService.IsValidEmail(email);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidEmail_ShouldReturnFalse_ForInvalidEmail_EmptyString()
        {
            // Arrange
            Setup();
            string email = "";

            // Act
            bool result = _testService.IsValidEmail(email);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidEmail_ShouldReturnFalse_ForInvalidEmail_MultipleAtSymbols()
        {
            // Arrange
            Setup();
            string email = "example@@example.com";

            // Act
            bool result = _testService.IsValidEmail(email);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidEmail_ShouldReturnFalse_ForInvalidEmail_InvalidDomain()
        {
            // Arrange
            Setup();
            string email = "example@.com";

            // Act
            bool result = _testService.IsValidEmail(email);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidEmail_ShouldReturnFalse_ForInvalidEmail_NoDomain()
        {
            // Arrange
            Setup();
            string email = "example@";

            // Act
            bool result = _testService.IsValidEmail(email);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidEmail_ShouldReturnFalse_ForInvalidEmail_Whitespace()
        {
            // Arrange
            Setup();
            string email = "example @example.com";

            // Act
            bool result = _testService.IsValidEmail(email);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidEmail_ShouldReturnTrue_ForEmailWithSubdomain()
        {
            // Arrange
            Setup();
            string email = "example@mail.example.com";

            // Act
            bool result = _testService.IsValidEmail(email);

            // Assert
            Assert.IsTrue(result);
        }

    }
}
