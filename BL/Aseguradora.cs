using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Aseguradora
    {
        //------------------------- Stored Procedures --------------------------
        public static ML.Result Add(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "AseguradoraAdd";
                        cmd.Connection = context;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[2];

                        collection[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        collection[0].Value = aseguradora.Nombre;

                        collection[1] = new SqlParameter("@IdUsuario", System.Data.SqlDbType.TinyInt);
                        collection[1].Value = aseguradora.Usuario.IdUsuario;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                        cmd.Connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Delete(int idAseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "AseguradoraDelete";
                        cmd.Connection = context;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter parameter = new SqlParameter("@IdAseguradora", System.Data.SqlDbType.Int);
                        parameter.Value = idAseguradora;

                        cmd.Parameters.Add(parameter);
                        cmd.Connection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                        cmd.Connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Update(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "AseguradoraUpdate";
                        cmd.Connection = context;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[3];

                        collection[0] = new SqlParameter("@IdAseguradora", System.Data.SqlDbType.Int);
                        collection[0].Value = aseguradora.IdAseguradora;

                        collection[1] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        collection[1].Value = aseguradora.Nombre;

                        collection[2] = new SqlParameter("@IdUsuario", System.Data.SqlDbType.TinyInt);
                        collection[2].Value = aseguradora.Usuario.IdUsuario;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                        cmd.Connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetById(int idAseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "AseguradoraGetById";
                        cmd.Connection = context;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter parameter = new SqlParameter("@IdAseguradora", System.Data.SqlDbType.Int);
                        parameter.Value = idAseguradora;

                        cmd.Parameters.Add(parameter);
                        cmd.Connection.Open();

                        DataTable tablaAseguradora = new DataTable();

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(tablaAseguradora);

                        if (tablaAseguradora.Rows.Count > 0)
                        {
                            DataRow row = tablaAseguradora.Rows[0];

                            ML.Aseguradora aseguradora = new ML.Aseguradora();

                            aseguradora.IdAseguradora = int.Parse(row[0].ToString());
                            aseguradora.Nombre = row[1].ToString();
                            aseguradora.FechaCreacion = row[2].ToString();
                            aseguradora.FechaModificacion = row[3].ToString();
                            aseguradora.Usuario = new ML.Usuario();
                            aseguradora.Usuario.IdUsuario = byte.Parse(row[4].ToString());

                            result.Object = aseguradora;
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                        cmd.Connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "AseguradoraGetAll";
                        cmd.Connection = context;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection.Open();

                        DataTable tablaAseguradora = new DataTable();

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(tablaAseguradora);

                        if (tablaAseguradora.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in tablaAseguradora.Rows)
                            {
                                ML.Aseguradora aseguradora = new ML.Aseguradora();

                                aseguradora.IdAseguradora = int.Parse(row[0].ToString());
                                aseguradora.Nombre = row[1].ToString();
                                aseguradora.FechaCreacion = row[2].ToString();
                                aseguradora.FechaModificacion = row[3].ToString();
                                aseguradora.Usuario = new ML.Usuario();
                                aseguradora.Usuario.IdUsuario = byte.Parse(row[4].ToString());
                                
                                result.Objects.Add(aseguradora);
                            }
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                        cmd.Connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        //------------------------- Entity Framework --------------------------

        public static ML.Result AddEF(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JGonzalezProgramacionNCapasEntities context = new DL_EF.JGonzalezProgramacionNCapasEntities())
                {
                    var query = context.AseguradoraAdd(aseguradora.Nombre,aseguradora.Usuario.IdUsuario);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el registro";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result DeleteEF(int idAseguradora)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JGonzalezProgramacionNCapasEntities context = new DL_EF.JGonzalezProgramacionNCapasEntities())
                {
                    var query = context.AseguradoraDelete(idAseguradora);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se eliminó el registro";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result UpdateEF(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JGonzalezProgramacionNCapasEntities context = new DL_EF.JGonzalezProgramacionNCapasEntities())
                {
                    var query = context.AseguradoraUpdate(aseguradora.IdAseguradora, aseguradora.Nombre, aseguradora.Usuario.IdUsuario);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actuazlizó el registro";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result GetByIdEF(int idAseguradora)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JGonzalezProgramacionNCapasEntities context = new DL_EF.JGonzalezProgramacionNCapasEntities())
                {
                    var query = context.AseguradoraGetById(idAseguradora).ToList()[0];

                    if (query != null)
                    {
                        ML.Aseguradora aseguradora = new ML.Aseguradora();

                        aseguradora.IdAseguradora = query.IdAseguradora;
                        aseguradora.Nombre = query.Nombre;
                        aseguradora.FechaCreacion = query.FechaCreacion.Value.ToString("dd-MM-yyyy");
                        aseguradora.FechaModificacion = query.FechaModificacion.Value.ToString("dd-MM-yyyy");
                        aseguradora.Usuario = new ML.Usuario();
                        aseguradora.Usuario.IdUsuario = query.IdUsuario.Value;
                        aseguradora.Usuario.Nombre = query.UsuarioNombre;
                        aseguradora.Usuario.ApellidoPaterno = query.ApellidoPaterno;
                        aseguradora.Usuario.ApellidoMaterno = query.ApellidoMaterno;

                        result.Object = aseguradora;
                        result.Correct=true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontró el registro";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JGonzalezProgramacionNCapasEntities context = new DL_EF.JGonzalezProgramacionNCapasEntities())
                {
                    var query = context.AseguradoraGetAll().ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var row in query)
                        {
                            ML.Aseguradora aseguradora = new ML.Aseguradora();

                            aseguradora.IdAseguradora = row.IdAseguradora;
                            aseguradora.Nombre = row.Nombre;
                            aseguradora.FechaCreacion = row.FechaCreacion.Value.ToString("dd-MM-yyyy");
                            aseguradora.FechaModificacion = row.FechaModificacion.Value.ToString("dd-MM-yyyy");
                            aseguradora.Usuario = new ML.Usuario();
                            aseguradora.Usuario.IdUsuario = row.IdUsuario.Value;
                            aseguradora.Usuario.Nombre = row.UsuarioNombre;
                            aseguradora.Usuario.ApellidoPaterno = row.ApellidoPaterno;
                            aseguradora.Usuario.ApellidoMaterno = row.ApellidoMaterno;

                            result.Objects.Add(aseguradora);
                        }
                        result.Correct=true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        //------------------------- LINQ --------------------------

        public static ML.Result AddLINQ(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JGonzalezProgramacionNCapasEntities context = new DL_EF.JGonzalezProgramacionNCapasEntities())
                {
                    DL_EF.Aseguradora aseguradoraDL = new DL_EF.Aseguradora();

                    aseguradoraDL.Nombre = aseguradora.Nombre;
                    aseguradoraDL.IdUsuario = aseguradora.Usuario.IdUsuario;
                    aseguradoraDL.FechaCreacion = DateTime.Now;
                    aseguradoraDL.FechaModificacion = DateTime.Now;

                    context.Aseguradoras.Add(aseguradoraDL);
                    int rowsAffected = context.SaveChanges();

                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se añadió registro.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result DeleteLINQ(int idAseguradora)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JGonzalezProgramacionNCapasEntities context = new DL_EF.JGonzalezProgramacionNCapasEntities())
                {
                    var query = (from Aseguradora in context.Aseguradoras
                                 where Aseguradora.IdAseguradora == idAseguradora select Aseguradora).First();
                    
                    if (query != null)
                    {
                        context.Aseguradoras.Remove(query);
                        context.SaveChanges();

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se eliminó registro.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result UpdateLINQ(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JGonzalezProgramacionNCapasEntities context = new DL_EF.JGonzalezProgramacionNCapasEntities())
                {
                    var query = (from Aseguradora in context.Aseguradoras
                                 where Aseguradora.IdAseguradora == aseguradora.IdAseguradora
                                 select Aseguradora).SingleOrDefault();

                    if (query != null)
                    {
                        query.Nombre = aseguradora.Nombre;
                        query.FechaModificacion = DateTime.Now;
                        query.IdUsuario = aseguradora.Usuario.IdUsuario;

                        context.SaveChanges();
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se modificó registro.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result GetByIdLINQ(int idAseguradora)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JGonzalezProgramacionNCapasEntities context = new DL_EF.JGonzalezProgramacionNCapasEntities())
                {
                    var query = (from Aseguradora in context.Aseguradoras
                                 where Aseguradora.IdAseguradora == idAseguradora
                                 select new
                                 {
                                     Aseguradora.IdAseguradora,
                                     Aseguradora.Nombre,
                                     Aseguradora.FechaCreacion,
                                     Aseguradora.FechaModificacion,
                                     Aseguradora.IdUsuario
                                 }).SingleOrDefault();

                    if (query != null)
                    {
                        ML.Aseguradora aseguradora = new ML.Aseguradora();

                        aseguradora.IdAseguradora = query.IdAseguradora;
                        aseguradora.Nombre = query.Nombre;
                        aseguradora.FechaCreacion = query.FechaCreacion.ToString();
                        aseguradora.FechaModificacion = query.FechaModificacion.ToString();
                        aseguradora.Usuario = new ML.Usuario();
                        aseguradora.Usuario.IdUsuario = query.IdUsuario.Value;

                        result.Object = aseguradora;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontró el registro.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result GetAllLINQ()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JGonzalezProgramacionNCapasEntities context = new DL_EF.JGonzalezProgramacionNCapasEntities())
                {
                    var query = (from Aseguradora in context.Aseguradoras
                                 select new
                                 {
                                     Aseguradora.IdAseguradora,
                                     Aseguradora.Nombre,
                                     Aseguradora.FechaCreacion,
                                     Aseguradora.FechaModificacion,
                                     Aseguradora.IdUsuario
                                 });

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var row in query)
                        {
                            ML.Aseguradora aseguradora = new ML.Aseguradora();

                            aseguradora.IdAseguradora = row.IdAseguradora;
                            aseguradora.Nombre = row.Nombre;
                            aseguradora.FechaCreacion = row.FechaCreacion.ToString();
                            aseguradora.FechaModificacion = row.FechaModificacion.ToString();
                            aseguradora.Usuario = new ML.Usuario();
                            aseguradora.Usuario.IdUsuario = row.IdUsuario.Value;

                            result.Objects.Add(aseguradora);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
