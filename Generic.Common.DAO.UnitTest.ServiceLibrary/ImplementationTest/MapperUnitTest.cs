﻿using Generic.Common.DAO.Contracts.ServiceLibrary.DTO;
using Generic.Common.DAO.Impl.ServiceLibrary.Helpers.CollectionMapper;
using Generic.Common.DAO.UnitTest.ServiceLibrary.DTOMocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;

namespace Vueling.Pricing.DAO.Impl.ServiceLibrary.UnitTest.UnitTest
{
    [TestClass]
    public class MapperUnitTest
    {
        private IList<DataToMapper> mockList;
        private DataToMapper mockObject;

        [TestInitialize]
        public void Initialize()
        {
            DataTable objectsTable = new DataTable();
            objectsTable.Columns.Add(new DataColumn()
            {
                ColumnName = "Id",
                DataType = typeof(string)
            });
            objectsTable.Columns.Add(new DataColumn()
            {
                ColumnName = "Key",
                DataType = typeof(string)
            });
            objectsTable.Columns.Add(new DataColumn()
            {
                ColumnName = "CreatedDate",
                DataType = typeof(DateTime)
            });
            objectsTable.Columns.Add(new DataColumn()
            {
                ColumnName = "Status",
                DataType = typeof(string)
            });
            objectsTable.Columns.Add(new DataColumn()
            {
                ColumnName = "CodeValue",
                DataType = typeof(string)
            });
            objectsTable.Columns.Add(new DataColumn()
            {
                ColumnName = "Order",
                DataType = typeof(int)
            });
            objectsTable.Columns.Add(new DataColumn()
            {
                ColumnName = "Amount",
                DataType = typeof(double)
            });
            objectsTable.Rows.Add(new object[] { "bb3d0049-8fbe-4126-809b-098d32de2d55", "1234567890", "2019-07-29 11:12:20.000", "Close", "YYY", 1, "12,5" });
            objectsTable.Rows.Add(new object[] { "832c7bb0-e409-4e86-b5a9-f08335af8919", "0987654321", "2019-07-29 00:00:00.000", "Open", "XXX", "200", "10" });

            DataSet _objectsDataSet = new DataSet();
            _objectsDataSet.Tables.Add(objectsTable);

            mockList = _objectsDataSet.ToList<DataToMapper>();
            mockObject = _objectsDataSet.ToObject<DataToMapper>();
        }

        [TestMethod]
        public void TestWhen_MapEnumValuesFromString()
        {
            Assert.AreEqual(mockObject.Status, Status.Close);
            Assert.AreEqual(mockObject.CodeValue, Code.YYY);
        }

        [TestMethod]
        public void TestWhen_MapDifferentObjectTypes()
        {
            Assert.IsInstanceOfType(mockList, typeof(List<DataToMapper>));
            Assert.IsInstanceOfType(mockObject, typeof(DataToMapper));
        }

        [TestMethod]
        public void TestWhen_PropertyDoesntMatchInDataTable()
        {
            Assert.AreEqual(mockObject.IdOptional, default(Guid));
            Assert.AreEqual(mockObject.IdOptional, Guid.Empty);
            Assert.AreEqual(mockObject.IdOptional, Guid.Parse("00000000-0000-0000-0000-000000000000"));
        }

        [TestMethod]
        public void TestWhen_MapGuidTypeFromDataTable()
        {
            Assert.AreEqual(mockList[0].Id, Guid.Parse("bb3d0049-8fbe-4126-809b-098d32de2d55"));
            Assert.AreEqual(mockList[1].Id, Guid.Parse("832c7bb0-e409-4e86-b5a9-f08335af8919"));
        }

        [TestMethod]
        public void TestWhen_MapDateTimeFromString()
        {
            Assert.AreEqual(mockList[0].CreatedDate, new DateTime(2019, 07, 29, 11, 12, 20));
            Assert.AreEqual(mockList[1].CreatedDate, new DateTime(2019, 07, 29));
        }

        [TestMethod]
        public void TestWhen_MapTextTypeFromDataTable()
        {
            Assert.AreEqual(mockList[0].Key, "1234567890");
            Assert.AreEqual(mockList[1].Key, "0987654321");
        }

        [TestMethod]
        public void TestWhen_ConvertDoubleFromString()
        {
            Assert.AreEqual(mockList[0].Amount, (decimal)12.5);
            Assert.AreEqual(mockList[1].Amount, 10);
        }

        [TestMethod]
        public void TestWhen_ConvertIntFromDataTable()
        {
            Assert.AreEqual(mockList[0].Order, 1);
            Assert.AreEqual(mockList[1].Order, 200);
        }

        [TestMethod]
        public void TestWhen_NumberOfObjectsInList()
        {
            Assert.AreEqual(mockList.Count, 2);
        }
    }
}
