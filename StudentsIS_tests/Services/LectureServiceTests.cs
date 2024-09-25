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
using Microsoft.EntityFrameworkCore;

namespace CS_EF_Atsiskaitymas_Studentu_Informacine_Sistema.Services.Tests
{
    [TestClass()]
    public class LectureServiceTests
    {
        private LectureService _testService;
        private StudentsDbContext _context;

        [TestInitialize]

        public void OnInit()
        {
            var _options = new DbContextOptionsBuilder<StudentsDbContext>()
                .UseInMemoryDatabase(databaseName: "LectureTests" + Guid.NewGuid())
                .Options;

            // Create a new context instance
            _context = new StudentsDbContext(_options);

            // Initialize the repository and service
            ILectureRepository repository = new LectureRepository(_context);
            IDepartmentLectureRepository departmentLectureRepository = new DepartmentLectureRepository(_context);

            _testService = new LectureService(repository, departmentLectureRepository);
            _context.Database.EnsureCreated();
        }
        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
        }
        public void Setup()
        {
            var context = new StudentsDbContext();
            ILectureRepository repository = new LectureRepository(context);
            IDepartmentLectureRepository departmentLectureRepository = new DepartmentLectureRepository(context);
            _testService = new LectureService(repository, departmentLectureRepository);
        }
        [TestMethod]
        public void IsValidTime_ShouldReturnTrue_ForValidTime()
        {
            // Arrange
            TimeSpan time = new TimeSpan(14, 0, 0); // 14:00:00

            // Act
            bool result = _testService.IsValidTime(time);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidTime_ShouldReturnFalse_ForNegativeHours()
        {
            // Arrange
            TimeSpan time = new TimeSpan(-1, 0, 0); // Invalid: -1 hours

            // Act
            bool result = _testService.IsValidTime(time);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidTime_ShouldReturnFalse_ForHoursGreaterThan23()
        {
            // Arrange
            TimeSpan time = new TimeSpan(24, 0, 0); // Invalid: 24 hours

            // Act
            bool result = _testService.IsValidTime(time);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidTime_ShouldReturnFalse_ForValidTimeWithNonZeroSeconds()
        {
            // Arrange
            TimeSpan time = new TimeSpan(12, 30, 15); // Invalid: 12:30:15

            // Act
            bool result = _testService.IsValidTime(time);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidTime_ShouldReturnFalse_ForMinutesGreaterThan59()
        {
            // Arrange
            TimeSpan time = new TimeSpan(0, 60, 0); // Invalid: 0 hours, 60 minutes

            // Act
            bool result = _testService.IsValidTime(time);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidTime_ShouldReturnTrue_ForMidnight()
        {
            // Arrange
            TimeSpan time = new TimeSpan(0, 0, 0); // Valid: 00:00:00

            // Act
            bool result = _testService.IsValidTime(time);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidTime_ShouldReturnTrue_ForEndOfDay()
        {
            // Arrange
            TimeSpan time = new TimeSpan(23, 59, 0); // Valid: 23:59:00

            // Act
            bool result = _testService.IsValidTime(time);

            // Assert
            Assert.IsTrue(result);
        }


    }
}