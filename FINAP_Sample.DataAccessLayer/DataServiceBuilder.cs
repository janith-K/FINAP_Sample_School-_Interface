using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Text;

namespace FINAP_Sample.DataAccessLayer
{
    public class DataServiceBuilder
    {
        public static IDataService CreateDataService()
        {
            return new SqlDataService();
        }

        public static DbParameter CreateDBParameter(string paramName, DbType paramType, ParameterDirection paramDirection, object value, [Optional] int size, [Optional] bool isImageType)
        {
            SqlParameter param = new SqlParameter();
            if (isImageType)
                param.SqlDbType = SqlDbType.Image;
            else
                param.DbType = paramType;
            param.ParameterName = paramName;
            param.Direction = paramDirection;
            param.Value = value;

            if (value == null)
                param.Value = DBNull.Value;
            if (size != 0)
                param.Size = size;
            return param;

        }
        public static DbParameter CreateDataListParameter(string paramName, ParameterDirection paramDirection, object value)
        {
            SqlParameter param = new SqlParameter();
            param.SqlDbType = SqlDbType.Structured;
            param.ParameterName = paramName;
            param.Direction = paramDirection;
            param.Value = value;
            if (value == null)
                param.Value = DBNull.Value;
            return param;

        }
        public static DbParameter CreateImageDBParameter(string paramName, ParameterDirection paramDirection, object value)
        {
            SqlParameter param = new SqlParameter();
            param.SqlDbType = SqlDbType.Image;
            param.ParameterName = paramName;
            param.Direction = paramDirection;
            param.Value = value;
            if (value == null)
                param.Value = DBNull.Value;
            return param;

        }

        internal static DbParameter CreateDBParameter1(string paramName, SqlDbType structured, ParameterDirection paramDirection, object dataTable, [Optional] int size, [Optional] bool isImageType, [Optional] byte precision, [Optional] byte scale)
        {
            SqlParameter param = new SqlParameter();
            try
            {

                if (isImageType)
                    param.SqlDbType = SqlDbType.Image;
                else
                    param.SqlDbType = structured;
                param.ParameterName = paramName;
                param.Direction = paramDirection;
                param.Value = dataTable;
                param.Precision = precision;
                param.Scale = scale;


                if (dataTable == null)
                    param.Value = DBNull.Value;
                if (size != 0)
                    param.Size = size;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return param;
        }
    }
}
