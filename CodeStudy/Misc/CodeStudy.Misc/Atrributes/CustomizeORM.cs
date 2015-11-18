using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CodeStudy.Misc.Atrributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class TableAttribute : Attribute
    {
        public string TableName { get; set; }

        public TableAttribute()
        {
        }

        public TableAttribute(string tableName)
        {
            this.TableName = tableName;
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class ColumnAttribute : Attribute
    {
        public string ColumnName { get; set; }
        public DbType DbType { get; set; }

        public ColumnAttribute()
        {
        }

        public ColumnAttribute(string columnName)
        {
            this.ColumnName = columnName;
        }

        public ColumnAttribute(string colunmName, DbType dbType)
        {
            this.ColumnName = colunmName;
            this.DbType = dbType;
        }
    }

    [Table("Users")]
    public class User
    {
        [Column(ColumnName = "Id", DbType = DbType.Int32)]
        public int UserId { get; set; }
        [Column(ColumnName = "Name", DbType = DbType.String)]
        public string UserName { get; set; }
        [Column(ColumnName = "Age", DbType = DbType.Int32)]
        public int Age { get; set; }
    }

    public class CustomizeORM
    {
        public void Insert(object table)
        {
            Type type = table.GetType();
            Dictionary<string, string> columnValueDict = new Dictionary<string, string>();
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("insert into ");
            TableAttribute tableAttribute = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), false).First();
            sqlStr.Append(tableAttribute.TableName);
            sqlStr.Append("(");

            foreach (PropertyInfo prop in type.GetProperties())
            {
                foreach (Attribute attr in prop.GetCustomAttributes())
                {
                    string value = prop.GetValue(table).ToString();
                    ColumnAttribute columnAttribute = attr as ColumnAttribute;
                    if (columnAttribute != null)
                    {
                        columnValueDict.Add(columnAttribute.ColumnName, value);
                    }
                }
            }

            foreach (var item in columnValueDict)
            {
                sqlStr.Append(item.Key);
                sqlStr.Append(",");

            }
            sqlStr.Remove(sqlStr.Length - 1, 1);
            sqlStr.Append(") values('");
            foreach (var item in columnValueDict)
            {
                sqlStr.Append(item.Value);
                sqlStr.Append("','");
            }
            sqlStr.Remove(sqlStr.Length - 2, 2);
            sqlStr.Append(")");
            Console.WriteLine(sqlStr.ToString());
        }
    }
}
