using RecordRatings.Clases;
using GLReferences;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordRatings.Controladores
{
    class CtrlBackup
    {
        public static DataSet RealizarBackup(String ubicacionNombreArchivo, String nombreDatabase, String nombreDesc)
        {
            SqlParameter[] dbParametros = new SqlParameter[]
            {
                DBHelper.MakeParam("@UbicacionNombreArchivo",SqlDbType.VarChar,0,ubicacionNombreArchivo), 
                DBHelper.MakeParam("@NombreDatabase",SqlDbType.VarChar,0,nombreDatabase),       
                DBHelper.MakeParam("@NombreDesc",SqlDbType.VarChar,0,nombreDesc),         
            };

            return DBHelper.ExecuteDataSet("PA_Backupdb", dbParametros);
        }
       
    }
}
