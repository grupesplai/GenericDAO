using NMock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Generic.Common.DAO.Contracts.ServiceLibrary.Connection;
using Generic.Common.DAO.Impl.ServiceLibrary.Configuration;
using Generic.Common.DAO.Contracts.ServiceLibrary;
using Generic.Common.DAO.Impl.ServiceLibrary;
using Generic.Common.DAO.Contracts.ServiceLibrary.DTO;
using System.Collections.Generic;

namespace Generic.Common.DAO.UnitTest.ServiceLibrary.ImplementationTest
{
    [TestClass]
    public class UnitTest1
    {
        private const string DATABASE_CONN_STRING = @"CONNECTION_STRING _FROM_DATABASE";

        private MockFactory mockFactory;
        private IDaoServiceCrud _crudService;

        [TestInitialize]
        public void TestInitialize()
        {
            mockFactory = new MockFactory();
            Mock<IConnectionString> _connStringMock = mockFactory.CreateMock<IConnectionString>();
            _connStringMock.Stub.Out.GetProperty(x => x.ConnectionString).WillReturn(DATABASE_CONN_STRING);
            Mock<ISqlServerDatabase> _sqlPricingMock = mockFactory.CreateMock<ISqlServerDatabase>();
            _sqlPricingMock.Stub.Out.GetProperty(y => y.DatabaseConnString).WillReturn(_connStringMock.MockObject);

            _crudService = new DatabaseService(_sqlPricingMock.MockObject);

        }

        [TestMethod]
        public void TestWhen_FlowIsStarted()
        {
           List<CovalcoDTO> dtos =  _crudService.GetAllData();

            Assert.AreEqual(dtos[0].ArrivalStation, "PMI");
            Assert.AreEqual(dtos[0].Class, "D");
            Assert.AreEqual(dtos[0].FeeConnection, new decimal(23));
            Assert.AreEqual(dtos[0].LongConnection, Status.Close);
        }
    }
}
