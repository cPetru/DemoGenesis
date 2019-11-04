using Moq;
using NUnit.Framework;
using ContactsApi.Repositories;
using System;
using ContactsApi.Controllers;
using System.Threading.Tasks;
using ContactsApi.Models;

namespace Tests
{
    public class ContanctTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task When_AddContact_Then_ObjectFromRepositoryIsPresent()
        {
            // Arrange
            var mockRepo = new Mock<ICompanyRepository>();
            mockRepo.Setup(repo => repo.AddContact(It.IsAny<Guid>(), It.IsAny<Guid>()))
                .ReturnsAsync(true);

            var guid = Guid.NewGuid();
            var company = new Company() { Id = guid, Name = guid.ToString().Substring(10), VAT = guid.ToString().Substring(1, 5) };
            mockRepo.Setup(repo => repo.GetById(It.IsAny<Guid>()))
                           .ReturnsAsync(company);

            var controller = new CompanyController(mockRepo.Object, null);

            // Act
            var result = await controller.AddContact(It.IsAny<Guid>(), It.IsAny<Guid>());

            // Check
            Assert.IsNotNull(result);
            Assert.AreEqual(company, result);
        }
    }
}