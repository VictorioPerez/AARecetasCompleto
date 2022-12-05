using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using RecetasSLN.Domino;

namespace RecetasSLN.Datos
{
//PARA GUIARME: Receta--<>->DetalleReceta-->Ingrediente
//1-Creo carpetas = (1)Datos,(2)Servicios,Dominio,Presentacion
//2-Empiezo HelperDao en(1), creo carpetas(1.1)interfaz e(1.2)implementacion 
//3-InombreDao dentro de(1.1)
//4-nombreDao dentro de(1.2)
//5-En(2) creo la carpeta(2.1)implementacion e(2.2)interfaz
//(ISERVICIO PRIMERO DESPUES SERVICIONOMBRE)
//6-ServicioNombre dentro de(2.1)
//7-IServicio dentro de(2.2)
//8-abstractFactoryService dentro(2)
//9-serviceFactoryImpl dentro(2)
    internal class helperDao
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private static helperDao instancia;

        public helperDao()
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-169QEF9\SQLEXPRESS;Initial Catalog=recetas_db;Integrated Security=True");
            cmd = new SqlCommand();
        }

        public static helperDao obtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new helperDao();
            }
            return instancia;
        }
        public int proximoID(string SP_PROX_ID, string parametros_SP)
        {
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = SP_PROX_ID;

            SqlParameter pOUT = new SqlParameter();
            pOUT.ParameterName = parametros_SP;
            pOUT.DbType = DbType.Int32;
            pOUT.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(pOUT);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            conn.Close();
            return (int)pOUT.Value;
        }
        public bool CrearMaestroDetalleReceta(string insertSP, string insertDetSP, receta Recetas)
        {
            bool aux = false;
            SqlTransaction t = null;
            try
            {
                conn.Open();
                t = conn.BeginTransaction();

                SqlCommand comando = new SqlCommand(insertSP, conn, t);
                comando.CommandType = CommandType.StoredProcedure;
                //comando.Parameters.AddWithValue("nombreColumnaSQL", parametroDeDato primeraTabla)
                comando.Parameters.AddWithValue("@nombre", Recetas.nombre);
                comando.Parameters.AddWithValue("@tipo_receta", Recetas.recetaNro);
                comando.Parameters.AddWithValue("cheff", Recetas.nombreChef);

                SqlParameter pOut = new SqlParameter();
                pOut.ParameterName = "@id";
                pOut.DbType = DbType.Int32;
                pOut.Direction = ParameterDirection.Output;
                comando.Parameters.Add(pOut);

                comando.ExecuteNonQuery();
                int identificador = (int)pOut.Value;
                SqlCommand comandoD = null;
                foreach (detalleReceta det in Recetas.detalleRecetaList)
                {
                    comandoD = new SqlCommand(insertDetSP, conn, t);
                    comandoD.CommandType = CommandType.StoredProcedure;
                    //INGRESO LAS COLUMNAS QUE ESTAN EN EL DETALLE
                    //comandoD.Parameters.AddWithValue("nombreColumnaSQLDetalles", parametroDato);
                    //comandoD.Parameters.AddWithValue("@id_receta", identificador);
                    comandoD.Parameters.AddWithValue("@id_receta", det.ingredientes.ingredienteID);
                    comandoD.Parameters.AddWithValue("@cantidad", det.cantidad);
                    comandoD.ExecuteNonQuery();

                }
                t.Commit();
                aux = true;
            }
            catch (Exception ex)
            {
                if (t != null)
                    t.Rollback();
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return aux;
        }
        public DataTable combo(string nombreSP)
        {
            DataTable dt = new DataTable();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = nombreSP;
            cmd.Parameters.Clear();
            dt.Load(cmd.ExecuteReader());
            conn.Close();
            return dt;
        }
    }
}

