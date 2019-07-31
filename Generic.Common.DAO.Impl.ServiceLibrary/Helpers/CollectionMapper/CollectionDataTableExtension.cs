using System;
using System.Linq;
using System.Data;
using System.Reflection;
using System.ComponentModel;
using System.Collections.Generic;

namespace Generic.Common.DAO.Impl.ServiceLibrary.Helpers.CollectionMapper
{
    public static class CollectionDataTableExtension
    {
        public static DataTable ConvertToDataTable<T>(this IEnumerable<T> data, IDictionary<string, string> columnMappings = null)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));

            columnMappings = columnMappings ?? properties.OfType<PropertyDescriptor>().ToDictionary(k => k.Name, v => v.Name);

            DataTable table = new DataTable();

            foreach (PropertyDescriptor prop in properties)
            {
                if (columnMappings.ContainsKey(prop.Name))
                {
                    table.Columns.Add(columnMappings[prop.Name], Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
            }

            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    if (columnMappings.ContainsKey(prop.Name))
                    {
                        string columnName = columnMappings[prop.Name];
                        row[columnName] = prop.GetValue(item) ?? DBNull.Value;
                    }
                }
                table.Rows.Add(row);
            }
            return table;
        }

        public static IList<T> ToList<T>(this DataSet table) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            IList<T> result = new List<T>();

            foreach (var row in table.Tables[0].Rows)
            {
                var item = CreateItemFromRow<T>((DataRow)row, properties);
                result.Add(item);
            }

            return result;
        }

        public static T ToObject<T>(this DataSet table) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();

            return CreateItemFromRow<T>(table.Tables[0].Rows[0], properties);
        }

        private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
        {
            T item = new T();
            try
            {
                foreach (var property in properties)
                {
                    DataColumn columnValue = row.Table.Columns[property.Name];
                    if (columnValue != null)
                    {
                        if (row[property.Name] == DBNull.Value)
                            property.SetValue(item, null);
                        else
                        {
                            object objectValue = TypeDescriptor.GetConverter(property.PropertyType).ConvertFrom(row[property.Name].ToString());
                            property.SetValue(item, objectValue);
                        }
                    }
                }
                return item;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
