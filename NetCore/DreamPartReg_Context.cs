using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Reflection;

namespace NetCore
{
    public class DreamsPartReg_Context : DbContext
    {
        private IConfigurationRoot _config;
        private DreamsPartReg_Context _localContext;

        public DreamsPartReg_Context(IConfigurationRoot config, DbContextOptions<DreamsPartReg_Context> options)
            : base(options)
        {
            _config = config;
            _localContext = this;
        }

        //public DbSet<Customer> Customers { get; set; }
        //public DbSet<Contact> Contacts { get; set; }
        //public DbSet<Test> Tests { get; set; }
        //public DbSet<Demo> Demo { get; set; }

        // calling generic methods of entity framework :


        public List<T> ExecuteStoredProcedure<T>(string storedProcedure,

           List<SqlParameter> parameters) where T : new()

        {

            using (var cmd =

               this.Database.GetDbConnection().CreateCommand())

            {

                cmd.CommandText = storedProcedure;

                cmd.CommandType = CommandType.StoredProcedure;



                // set some parameters of the stored procedure

                foreach (var parameter in parameters)

                {

                    cmd.Parameters.Add(parameter);

                }



                if (cmd.Connection.State != ConnectionState.Open)

                    cmd.Connection.Open();



                using (var dataReader = cmd.ExecuteReader())

                {

                    var result = DataReaderMapToList<T>(dataReader);

                    return result;

                }

            }

        }



        public List<T> ExecuteStoredProcedure<T>(string storedProcedure,

           List<SqlParameter>[][] parameters) where T : new()

        {

            using (var cmd =

               this.Database.GetDbConnection().CreateCommand())

            {

                cmd.CommandText = storedProcedure;

                cmd.CommandType = CommandType.StoredProcedure;



                // set some parameters of the stored procedure

                foreach (var parameter in parameters)

                {

                    cmd.Parameters.Add(parameter);

                }



                if (cmd.Connection.State != ConnectionState.Open)

                    cmd.Connection.Open();



                using (var dataReader = cmd.ExecuteReader())

                {

                    var result = DataReaderMapToList<T>(dataReader);

                    return result;

                }

            }

        }



        public List<T> ExecuteStoredProcedure<T>(string storedProcedure, bool isTransactionEnable,

           List<SqlParameter> parameters) where T : new()

        {

            using (var cmd =

               this.Database.GetDbConnection().CreateCommand())

            {

                SqlTransaction transaction = (SqlTransaction)this.Database.CurrentTransaction.GetDbTransaction();

                cmd.CommandText = storedProcedure;

                cmd.Transaction = transaction;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Transaction = transaction;

                // set some parameters of the stored procedure

                foreach (var parameter in parameters)

                {

                    cmd.Parameters.Add(parameter);

                }



                if (cmd.Connection.State != ConnectionState.Open)

                    cmd.Connection.Open();



                using (var dataReader = cmd.ExecuteReader())

                {

                    var result = DataReaderMapToList<T>(dataReader);

                    return result;

                }

            }

        }



        public List<T> ExecuteStoredProcedure<T>(string storedProcedure, SqlTransaction oTran, List<SqlParameter> parameters) where T : new()

        {

            using (var cmd =

               this.Database.GetDbConnection().CreateCommand())

            {

                //SqlTransaction transaction = (SqlTransaction)this.Database.CurrentTransaction.GetDbTransaction();

                cmd.CommandTimeout = 500;

                cmd.CommandText = storedProcedure;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Transaction = oTran;

                // set some parameters of the stored procedure

                foreach (var parameter in parameters)

                {

                    cmd.Parameters.Add(parameter);

                }



                if (cmd.Connection.State != ConnectionState.Open)

                    cmd.Connection.Open();



                using (var dataReader = cmd.ExecuteReader())

                {

                    var result = DataReaderMapToList<T>(dataReader);

                    return result;

                }

            }

        }





        public List<T> ExecuteStoredProcedure<T>(string storedProcedure, SqlTransaction oTran, SqlParameter parameter) where T : new()

        {

            using (var cmd =

               this.Database.GetDbConnection().CreateCommand())

            {

                //SqlTransaction transaction = (SqlTransaction)this.Database.CurrentTransaction.GetDbTransaction();

                //cmd.CommandTimeout = 180;

                cmd.CommandText = storedProcedure;

                cmd.Transaction = oTran;

                cmd.CommandType = CommandType.StoredProcedure;

                parameter.SqlDbType = SqlDbType.Structured;

                //parameter.TypeName = typeName;

                cmd.Parameters.Add(parameter);

                //}



                if (cmd.Connection.State != ConnectionState.Open)

                    cmd.Connection.Open();



                using (var dataReader = cmd.ExecuteReader())

                {

                    var result = DataReaderMapToList<T>(dataReader);

                    return result;

                }

            }

        }



        public List<T> ExecuteStoredProcedure<T>(string storedProcedure) where T : new()

        {

            using (var cmd =

               this.Database.GetDbConnection().CreateCommand())

            {

                cmd.CommandText = storedProcedure;

                cmd.CommandType = CommandType.StoredProcedure;



                if (cmd.Connection.State != ConnectionState.Open)

                    cmd.Connection.Open();



                using (var dataReader = cmd.ExecuteReader())

                {

                    var result = DataReaderMapToList<T>(dataReader);

                    return result;

                }

            }

        }



        private static List<T> DataReaderMapToList<T>(DbDataReader dr)

        {

            List<T> list = new List<T>();

            while (dr.Read())

            {

                var obj = Activator.CreateInstance<T>();

                foreach (PropertyInfo prop in obj.GetType().GetProperties())

                {

                    if (!Equals(dr[prop.Name], DBNull.Value))

                    {



                        prop.SetValue(obj, dr[prop.Name], null);

                    }

                }

                list.Add(obj);

            }

            return list;

        }
    }
}
