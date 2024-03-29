﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_DATOS
{
    public class EntityClass
    {
        public List<T> Get<T>()
        {
            var Data = SqlADOConexion.SQLM.TakeList<T>(this);
            return Data;
        }
        public T FindObject<T>()
        {
            var Data = SqlADOConexion.SQLM.TakeObject<T>(this);
            return Data;
        }
        public List<T> Get<T>(string condition)
        {
            var Data = SqlADOConexion.SQLM.TakeList<T>(this, condition);
            return Data;
        }
        public object Save()
        {
            return SqlADOConexion.SQLM.InsertObject(this);
        }
        public object Update(string Id)
        {
            SqlADOConexion.SQLM.UpdateObject(this, Id);
            return 1;
        }
        public bool Update(string[] Id)
        {
            SqlADOConexion.SQLM.UpdateObject(this, Id);
            return true;
        }
        public bool Delete()
        {
            SqlADOConexion.SQLM.Delete(this);
            return true;
        }

        public object GetExecuteQueryResult(string query)
        {
            var data = SqlADOConexion.SQLM.ExecuteSqlQuery(query);
            return data;
        }
    }
}
