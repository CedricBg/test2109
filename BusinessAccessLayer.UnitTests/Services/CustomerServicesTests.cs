using AutoMapper;
using BusinessAccessLayer.Models.Customers;
using BusinessAccessLayer.Services;
using DataAccess.Repository;

using Moq;


namespace BusinessAccessLayer.UnitTests.Services
{
    [TestFixture]
    public class CustomerServicesTests
    {
        private Mock<IMapper> _mapperMock;
        private Mock<ICustomerServices> _servicesMock;

        [SetUp]
        public void Setup()
        {
            _mapperMock = new Mock<IMapper>();
            _servicesMock = new Mock<ICustomerServices>();
        }

        [Test]
        public void DeleteContact_WhenCalled_ReturnASiteObject()
        {
            var expectedSite = new Site();
            _servicesMock.Setup(x => x.deleteContact(It.IsAny<int>())).Returns(new DataAccess.Models.Customer.Site());
            _mapperMock.Setup(y=>y.Map<Site>(It.IsAny<DataAccess.Models.Customer.Site>())).Returns(expectedSite);
            var customerService = new CustomerService(_mapperMock.Object, _servicesMock.Object);
            var result = customerService.deleteContact(1);
            Assert.That(result, Is.EqualTo(expectedSite));
        }

        [Test]
        public void SiteDelete_WhenCalled_ReturnAString()
        {
            string expectedString = "Deleted";
            _servicesMock.Setup(x => x.SiteDelete(It.IsAny<int>())).Returns(expectedString);
            var customerService = new CustomerService(_mapperMock.Object, _servicesMock.Object);
            string result = customerService.SiteDelete(1);
            Assert.That(result, Is.EqualTo("Deleted"));
        }

        [Test]
        public void GetOne_WhenCalled_ReturnACustomer()
        {
            Customers customers = new Customers();
            _servicesMock.Setup(x=>x.GetOne(It.IsAny<int>()))
                .Returns(new DataAccess.Models.Customer.Customers());
            _mapperMock.Setup(y=>y.Map<Customers>(It.IsAny<DataAccess.Models.Customer.Customers>()))
                .Returns(customers);
            var customerService = new CustomerService(_mapperMock.Object, _servicesMock.Object);
            var result = customerService.GetOne(1);
            Assert.That(result, Is.EqualTo(customers));
        }

        [Test]
        public void UpdateCustomer_WhenCalled_ReturnAListOfCustomer()
        {
            List<Customers> ExpectedList = new List<Customers>();  
            _servicesMock.Setup(y => y.UpdateCustomer(It.IsAny<DataAccess.Models.Customer.AllCustomers>()))
                .Returns(new List<DataAccess.Models.Customer.Customers>());
            _mapperMock.Setup(m => m.Map<List<BusinessAccessLayer.Models.Customers.Customers>>(It.IsAny<List<DataAccess.Models.Customer.Customers>>()))
                .Returns(new List<Customers>());

            var customerService = new CustomerService(_mapperMock.Object, _servicesMock.Object);

            List<Customers> result = customerService.UpdateCustomer(new AllCustomers());

            Assert.That(result,Is.EqualTo(ExpectedList));

        }
    }
}
