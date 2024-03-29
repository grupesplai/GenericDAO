﻿using NMock;
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
        private const string DATABASE_CONN_STRING = @"Data Source=(localdb)\HarryServer;Initial Catalog=Connectio;Integrated Security=True";

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
           IList<CovalcoDTO> dtos =  _crudService.GetAllData();

            _crudService.insertBulk(dtos);
        }
    }
}
