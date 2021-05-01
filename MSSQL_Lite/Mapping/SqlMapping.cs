﻿using MSSQL_Lite.Reflection;
using System;
using System.Reflection;

namespace MSSQL_Lite.Mapping
{
    public class SqlMapping : IDisposable
    {
        public string GetTableName<T>(bool enclosedInSquareBrackets = false)
        {
            string objectName = Obj.GetObjectName<T>();
            return (enclosedInSquareBrackets) ? "[" + objectName + "]" : objectName;
        }

        public string GetTableName(object obj, bool enclosedInSquareBrackets = false)
        {
            string objectName = Obj.GetObjectName(obj);
            return (enclosedInSquareBrackets) ? "[" + objectName + "]" : objectName;
        }

        public string GetTableName(PropertyInfo propertyInfo, bool enclosedInSquareBrackets = false)
        {
            Type type = propertyInfo.PropertyType;
            object obj = Activator.CreateInstance(type);
            string objectName = GetTableName(obj);
            return (enclosedInSquareBrackets) ? "[" + objectName + "]" : objectName;
        }

        public string GetPropertyName(PropertyInfo propertyInfo, bool enclosedInSquareBrackets = false)
        {
            return (enclosedInSquareBrackets) ? "[" + propertyInfo.Name + "]" : propertyInfo.Name;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
