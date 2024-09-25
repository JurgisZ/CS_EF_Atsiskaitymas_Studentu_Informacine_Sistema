using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Services;
using CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Services.Interfaces;
namespace StudentuSI_Tests
{
    internal class StudentTests
    {
        [TestClass]
        public class StudentValidationTests
        {
            [TestMethod]
            public void IsValidStudentLastName_ShouldReturnFalse_WhenNameIsNull()
            {
                // Arrange
                string? name = null;

                // Act
                var result = IsValidStudentLastName//IsValidStudentLastName(name);

                // Assert
                Assert.IsFalse(result);
            }

            [TestMethod]
            public void IsValidStudentLastName_ShouldReturnFalse_WhenNameIsEmpty()
            {
                // Arrange
                string name = string.Empty;

                // Act
                var result = IsValidStudentLastName(name);

                // Assert
                Assert.IsFalse(result);
            }

            [TestMethod]
            public void IsValidStudentLastName_ShouldReturnFalse_WhenNameIsTooShort()
            {
                // Arrange
                string name = "I"; // Less than 2 characters

                // Act
                var result = IsValidStudentLastName(name);

                // Assert
                Assert.IsFalse(result);
            }

            [TestMethod]
            public void IsValidStudentLastName_ShouldReturnFalse_WhenNameIsTooLong()
            {
                // Arrange
                string name = new string('X', 51); // More than 50 characters

                // Act
                var result = IsValidStudentLastName(name);

                // Assert
                Assert.IsFalse(result);
            }

            [TestMethod]
            public void IsValidStudentLastName_ShouldReturnTrue_WhenNameIsValid()
            {
                // Arrange
                string name = "Jonas"; // Valid length

                // Act
                var result = IsValidStudentLastName(name);

                // Assert
                Assert.IsTrue(result);
            }
        }
    }
}

