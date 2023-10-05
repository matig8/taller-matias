using WEB_TALLER.Models;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using WEB_TALLER.Controllers;

namespace WEB_TALLER.Datos
{
    public class Auto_Moto
    {
        //PROCEDIMIENTO QUE INCERTA AUTOS 
        public bool Guardar(Auto OAuto)
        {
            bool rpta;

            try {
                var cn = new Conexion();
                PresupuestoController presupuesto = new PresupuestoController();
                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("INCERTAR_VEHICULO", conexion);
                    cmd.Parameters.AddWithValue("P_MARCA", OAuto.MARCA);
                    cmd.Parameters.AddWithValue("P_MODELO", OAuto.MODELO);
                    cmd.Parameters.AddWithValue("P_PATENTE", OAuto.PATENTE);
                    cmd.Parameters.AddWithValue("P_TIPO", OAuto.TIPO);
                    cmd.Parameters.AddWithValue("P_PUERTAS", OAuto.CANTIDAD_PUERTAS);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta= true;

                
            }
            catch (Exception e) 
            {
            string error = e.Message;   
            rpta = false;
            
            }   

            return rpta;
        }
        //TERMINA PROCEDIMIENTO QUE INCERTA AUTOS 

        //PROCEDIMIENTO QUE INCERTA LAS MOTOS 
        public bool Guardar_moto(Moto OMoto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("INCERTAR_MOTO", conexion);
                    cmd.Parameters.AddWithValue("P_MARCA", OMoto.MARCA);
                    cmd.Parameters.AddWithValue("P_MODELO", OMoto.MODELO);
                    cmd.Parameters.AddWithValue("P_PATENTE", OMoto.PATENTE);
                    cmd.Parameters.AddWithValue("P_CILINDRADAS", OMoto.CILINDRADAS);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;

            }

            return rpta;
        }
        //TERMINA PROCEDIMIENTO QUE INCERTA LAS MOTOS  


        //COMIENZA EL PROCEDIMIENTO PARA INCERTAR PRESUPUESTO 
        public bool Cargar_presupuesto(Presupuesto OPresupuesto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("CARGAR_PRESUPUESTO", conexion);
                    cmd.Parameters.AddWithValue("P_NOMBRE", OPresupuesto.NOMBRE);
                    cmd.Parameters.AddWithValue("P_APELLIDO", OPresupuesto.APELLIDO);
                    cmd.Parameters.AddWithValue("P_E_MAIL", OPresupuesto.E_MAIL);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;

            }

            return rpta;
        }
        //TERMINA EL PROCEDIMIENTO PARA INCERTAR PRESUPUESTO 

        //COMIENZA EL DESPERFECTO PARA INCERTAR PRESUPUESTO 
        public bool Cargar_desperfecto(Desperfecto ODespefecto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("desperfecto", conexion);
                    cmd.Parameters.AddWithValue("P_DESCRIPCION", ODespefecto.DESCRIPCION);
                    cmd.Parameters.AddWithValue("P_MANO_OBRA", ODespefecto.MANO_OBRA);
                    cmd.Parameters.AddWithValue("P_TIEMPO", ODespefecto.TIEMPO);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;

            }

            return rpta;
        }
        //TERMINA EL DESPERFECTO PARA INCERTAR PRESUPUESTO 

        //COMIENSA EL REPUESTO PARA INCERTAR PRESUPUESTO
        public bool Cargar_repuesto(Grepuesto ORepuesto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("REPUESTO", conexion);
                    cmd.Parameters.AddWithValue("ID_REPUESTO", ORepuesto.ID_REPUESTO);
                    cmd.Parameters.AddWithValue("CANTIDAD", ORepuesto.CANTIDAD);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;

            }

            return rpta;
        }
       
        //TERMINA EL REPUESTO PARA INCERTAR PRESUPUESTO 
        public List<Repuesto> RepuestoL()
        {
            var OLrpuesto = new List<Repuesto>();
            var cn = new Conexion();


                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("trae_repuesto", conexion);

                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader()) { 
                        while (dr.Read())
                        {
                        OLrpuesto.Add(new Repuesto() { 
                            NOMBRE = dr["NOMBRE"].ToString(),
                            PRECIO = Convert.ToDecimal( dr["PRECIO"]),
                            ID_REPUESTO = Convert.ToInt32(dr["ID_REPUESTO"])
                        });
                        }
                
                    }
                    cmd.ExecuteNonQuery();
                }
   
           return OLrpuesto;
        }

         public List<Total> TotalL()
         {
            var OTotal = new List<Total>();
            var cn = new Conexion();


                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("TOTAL", conexion);

                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader()) { 
                        while (dr.Read())
                        {
                        OTotal.Add(new Total() {
                            TOTAL = Convert.ToDecimal(dr["TOTAL"])
                        });
                        }
                
                    }
                    cmd.ExecuteNonQuery();
                }
   
           return OTotal;
         }
    }

}
