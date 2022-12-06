using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "INSERT INTO Usuario (Nombre,ApellidoPaterno,ApellidoMaterno,FechaNacimiento,Sexo,Telefono,UserName,Password,Email,Celular,CURP,IdRol) VALUES(@Nombre,@ApellidoPaterno,@ApellidoMaterno,CONVERT(DATE, @FechaNacimiento),@Sexo,@Telefono,@UserName,@Password,@Email,@Celular,@CURP,@IdRol)";
                        cmd.Connection = context;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[12];

                        collection[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;

                        collection[1] = new SqlParameter("@ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;

                        collection[2] = new SqlParameter("@ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaterno;

                        collection[3] = new SqlParameter("@FechaNacimiento", System.Data.SqlDbType.VarChar);
                        collection[3].Value = usuario.FechaNacimiento;

                        collection[4] = new SqlParameter("@Sexo", System.Data.SqlDbType.Char);
                        collection[4].Value = usuario.Sexo;

                        collection[5] = new SqlParameter("@Telefono", System.Data.SqlDbType.VarChar);
                        collection[5].Value = usuario.Telefono;

                        collection[6] = new SqlParameter("@UserName", System.Data.SqlDbType.VarChar);
                        collection[6].Value = usuario.UserName;

                        collection[7] = new SqlParameter("@Password", System.Data.SqlDbType.VarChar);
                        collection[7].Value = usuario.Password;

                        collection[8] = new SqlParameter("@Email", System.Data.SqlDbType.VarChar);
                        collection[8].Value = usuario.Email;

                        collection[9] = new SqlParameter("@Celular", System.Data.SqlDbType.VarChar);
                        collection[9].Value = usuario.Celular;

                        collection[10] = new SqlParameter("@CURP", System.Data.SqlDbType.VarChar);
                        collection[10].Value = usuario.CURP;

                        collection[11] = new SqlParameter("@IdRol", System.Data.SqlDbType.TinyInt);
                        collection[11].Value = usuario.Rol.IdRol;

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

        //------------------------- Stored Procedures --------------------------

        public static ML.Result AddSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UsuarioAdd";
                        cmd.Connection = context;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[12];

                        collection[0] = new SqlParameter("@Nombre",System.Data.SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;

                        collection[1] = new SqlParameter("@ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;

                        collection[2] = new SqlParameter("@ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaterno;

                        collection[3] = new SqlParameter("@FechaNacimiento", System.Data.SqlDbType.VarChar);
                        collection[3].Value = usuario.FechaNacimiento;

                        collection[4] = new SqlParameter("@Sexo", System.Data.SqlDbType.Char);
                        collection[4].Value = usuario.Sexo;

                        collection[5] = new SqlParameter("@Telefono", System.Data.SqlDbType.VarChar);
                        collection[5].Value = usuario.Telefono;

                        collection[6] = new SqlParameter("@UserName", System.Data.SqlDbType.VarChar);
                        collection[6].Value = usuario.UserName;

                        collection[7] = new SqlParameter("@Password", System.Data.SqlDbType.VarChar);
                        collection[7].Value = usuario.Password;

                        collection[8] = new SqlParameter("@Email", System.Data.SqlDbType.VarChar);
                        collection[8].Value = usuario.Email;

                        collection[9] = new SqlParameter("@Celular", System.Data.SqlDbType.VarChar);
                        collection[9].Value = usuario.Celular;

                        collection[10] = new SqlParameter("@CURP", System.Data.SqlDbType.VarChar);
                        collection[10].Value = usuario.CURP;

                        collection[11] = new SqlParameter("@IdRol", System.Data.SqlDbType.TinyInt);
                        collection[11].Value = usuario.Rol.IdRol;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();
                        
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            result.Correct=true;
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

        public static ML.Result Delete(int idUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UsuarioDelete";
                        cmd.Connection = context;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter parameter = new SqlParameter("@IdUsuario", System.Data.SqlDbType.TinyInt);
                        parameter.Value = idUsuario;

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
                result.Correct= false;
                result.ErrorMessage= ex.Message;
                result.Ex= ex;
            }
            return result;
        }

        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result= new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UsuarioUpdate";
                        cmd.Connection = context;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[13];

                        collection[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;

                        collection[1] = new SqlParameter("@ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;

                        collection[2] = new SqlParameter("@ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaterno;

                        collection[3] = new SqlParameter("@FechaNacimiento", System.Data.SqlDbType.VarChar);
                        collection[3].Value = usuario.FechaNacimiento;

                        collection[4] = new SqlParameter("@Sexo", System.Data.SqlDbType.Char);
                        collection[4].Value = usuario.Sexo;

                        collection[5] = new SqlParameter("@Telefono", System.Data.SqlDbType.VarChar);
                        collection[5].Value = usuario.Telefono;

                        collection[6] = new SqlParameter("@UserName", System.Data.SqlDbType.VarChar);
                        collection[6].Value = usuario.UserName;

                        collection[7] = new SqlParameter("@Password", System.Data.SqlDbType.VarChar);
                        collection[7].Value = usuario.Password;

                        collection[8] = new SqlParameter("@Email", System.Data.SqlDbType.VarChar);
                        collection[8].Value = usuario.Email;

                        collection[9] = new SqlParameter("@Celular", System.Data.SqlDbType.VarChar);
                        collection[9].Value = usuario.Celular;

                        collection[10] = new SqlParameter("@CURP", System.Data.SqlDbType.VarChar);
                        collection[10].Value = usuario.CURP;

                        collection[11] = new SqlParameter("@IdRol", System.Data.SqlDbType.TinyInt);
                        collection[11].Value = usuario.Rol.IdRol;

                        collection[12] = new SqlParameter("@IdUsuario", System.Data.SqlDbType.TinyInt);
                        collection[12].Value = usuario.IdUsuario;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct=false;
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

        public static ML.Result GetById(int idUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UsuarioGetById";
                        cmd.Connection = context;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter parameter = new SqlParameter("@IdUsuario", System.Data.SqlDbType.TinyInt);
                        parameter.Value = idUsuario;

                        cmd.Parameters.Add(parameter);
                        cmd.Connection.Open();

                        DataTable tablaUsuario = new DataTable();

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(tablaUsuario);

                        if (tablaUsuario.Rows.Count > 0)
                        {
                            DataRow row = tablaUsuario.Rows[0];

                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = byte.Parse(row[0].ToString());
                            usuario.Nombre = row[1].ToString();
                            usuario.ApellidoPaterno = row[2].ToString();
                            usuario.ApellidoMaterno = row[3].ToString();
                            usuario.FechaNacimiento = row[4].ToString();
                            usuario.Sexo = char.Parse(row[5].ToString());
                            usuario.Telefono = row[6].ToString();
                            usuario.UserName = row[7].ToString();
                            usuario.Password = row[8].ToString();
                            usuario.Email = row[9].ToString();
                            usuario.Celular = row[10].ToString();
                            usuario.CURP = row[11].ToString();
                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = byte.Parse(row[12].ToString());

                            result.Object = usuario;
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
                        cmd.CommandText = "UsuarioGetAll";
                        cmd.Connection = context;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection.Open();

                        DataTable tablaUsuario = new DataTable();

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(tablaUsuario);

                        if (tablaUsuario.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in tablaUsuario.Rows)
                            {
                                ML.Usuario usuario = new ML.Usuario();

                                usuario.IdUsuario = byte.Parse(row[0].ToString());
                                usuario.Nombre = row[1].ToString();
                                usuario.ApellidoPaterno = row[2].ToString();
                                usuario.ApellidoMaterno = row[3].ToString();
                                usuario.FechaNacimiento = row[4].ToString();
                                usuario.Sexo = char.Parse(row[5].ToString());
                                usuario.Telefono = row[6].ToString();
                                usuario.UserName = row[7].ToString();
                                usuario.Password = row[8].ToString();
                                usuario.Email = row[9].ToString();
                                usuario.Celular = row[10].ToString();
                                usuario.CURP = row[11].ToString();
                                usuario.Rol = new ML.Rol();
                                usuario.Rol.IdRol = byte.Parse(row[12].ToString());

                                result.Objects.Add(usuario);
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

        public static ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JGonzalezProgramacionNCapasEntities context = new DL_EF.JGonzalezProgramacionNCapasEntities())
                {
                    var query = context.UsuarioAdd(usuario.Nombre, usuario.ApellidoPaterno,usuario.ApellidoMaterno,
                                                    usuario.FechaNacimiento, usuario.Sexo.ToString(), usuario.Telefono,
                                                    usuario.UserName, usuario.Password, usuario.Email, usuario.Celular,
                                                    usuario.CURP, usuario.Rol.IdRol, usuario.Imagen, usuario.Direccion.Calle, usuario.Direccion.NumeroExterior,
                                                    usuario.Direccion.NumeroInterior, usuario.Direccion.Colonia.IdColonia);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct=false;
                        result.ErrorMessage = "No se insertó el registro";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct=false ;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result DeleteEF(int idUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JGonzalezProgramacionNCapasEntities context = new DL_EF.JGonzalezProgramacionNCapasEntities())
                {
                    var query = context.UsuarioDelete((byte)idUsuario);

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

        public static ML.Result UpdateEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JGonzalezProgramacionNCapasEntities context = new DL_EF.JGonzalezProgramacionNCapasEntities())
                {
                    var query = context.UsuarioUpdate(usuario.IdUsuario, usuario.Nombre, usuario.ApellidoPaterno,
                                                    usuario.ApellidoMaterno, usuario.FechaNacimiento, usuario.Sexo.ToString(),
                                                    usuario.Telefono, usuario.UserName, usuario.Password, usuario.Email,
                                                    usuario.Celular, usuario.CURP,usuario.Rol.IdRol,usuario.Imagen, usuario.Direccion.Calle,
                                                    usuario.Direccion.NumeroExterior, usuario.Direccion.NumeroInterior,
                                                    usuario.Direccion.Colonia.IdColonia);
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

        public static ML.Result GetByIdEF(int idUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JGonzalezProgramacionNCapasEntities context = new DL_EF.JGonzalezProgramacionNCapasEntities())
                {
                    var query = context.UsuarioGetById((byte)idUsuario).ToList()[0];

                    if (query != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario = query.IdUsuario;
                        usuario.Nombre = query.Nombre;
                        usuario.ApellidoPaterno = query.ApellidoPaterno;
                        usuario.ApellidoMaterno = query.ApellidoMaterno;
                        usuario.FechaNacimiento = query.FechaNacimiento.ToString("dd-MM-yyyy");
                        usuario.Sexo = char.Parse(query.Sexo);
                        usuario.Telefono = query.Telefono;
                        usuario.UserName = query.UserName;
                        usuario.Password = query.Password;
                        usuario.Email = query.Email;
                        usuario.Celular = query.Celular;
                        usuario.CURP = query.CURP;

                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = query.IdRol;

                        usuario.Imagen = query.Imagen;

                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.IdDireccion = query.IdDireccion;
                        usuario.Direccion.Calle = query.Calle;
                        usuario.Direccion.NumeroExterior = query.NumeroExterior;
                        usuario.Direccion.NumeroInterior = query.NumeroInterior;

                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.IdColonia = query.IdColonia;
                        usuario.Direccion.Colonia.Nombre = query.ColoniaNombre;

                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = query.IdMunicipio;
                        usuario.Direccion.Colonia.Municipio.Nombre = query.MunicipioNombre;

                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = query.IdEstado;
                        usuario.Direccion.Colonia.Municipio.Estado.Nombre = query.EstadoNombre;

                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = query.IdPais;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = query.PaisNombre;

                        result.Object = usuario;
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

        public static ML.Result GetAllEF(ML.Usuario usuarioBusqueda)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JGonzalezProgramacionNCapasEntities context = new DL_EF.JGonzalezProgramacionNCapasEntities())
                {
                    usuarioBusqueda.Nombre = (usuarioBusqueda.Nombre == null) ? "" : usuarioBusqueda.Nombre;
                    usuarioBusqueda.ApellidoPaterno = (usuarioBusqueda.ApellidoPaterno == null) ? "" : usuarioBusqueda.ApellidoPaterno;
                    usuarioBusqueda.Rol = (usuarioBusqueda.Rol == null) ? new ML.Rol() : usuarioBusqueda.Rol;

                    var query = context.UsuarioGetAll(usuarioBusqueda.Nombre, usuarioBusqueda.ApellidoPaterno, usuarioBusqueda.Rol.IdRol).ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var row in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = row.IdUsuario;
                            usuario.Nombre = row.Nombre;
                            usuario.ApellidoPaterno = row.ApellidoPaterno;
                            usuario.ApellidoMaterno = row.ApellidoMaterno;
                            usuario.FechaNacimiento = row.FechaNacimiento.ToString("dd-MM-yyyy");
                            usuario.Sexo = char.Parse(row.Sexo);
                            usuario.Telefono = row.Telefono;
                            usuario.UserName = row.UserName;
                            usuario.Password = row.Password;
                            usuario.Email = row.Email;
                            usuario.Celular = row.Celular;
                            usuario.CURP = row.CURP;

                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = row.IdRol;
                            usuario.Rol.Nombre = row.RolNombre;

                            usuario.Imagen = row.Imagen;

                            usuario.Direccion = new ML.Direccion();
                            usuario.Direccion.IdDireccion = row.IdDireccion;
                            usuario.Direccion.Calle = row.Calle;
                            usuario.Direccion.NumeroExterior = row.NumeroExterior;
                            usuario.Direccion.NumeroInterior = row.NumeroInterior;

                            usuario.Direccion.Colonia = new ML.Colonia();
                            usuario.Direccion.Colonia.IdColonia = row.IdColonia;
                            usuario.Direccion.Colonia.Nombre = row.ColoniaNombre;

                            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuario.Direccion.Colonia.Municipio.IdMunicipio = row.IdMunicipio;
                            usuario.Direccion.Colonia.Municipio.Nombre = row.MunicipioNombre;

                            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            usuario.Direccion.Colonia.Municipio.Estado.IdEstado = row.IdEstado;
                            usuario.Direccion.Colonia.Municipio.Estado.Nombre = row.EstadoNombre;

                            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = row.IdPais;
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = row.PaisNombre;

                            result.Objects.Add(usuario);
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

        public static ML.Result ChangeStatus(byte idUsuario, bool status)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JGonzalezProgramacionNCapasEntities context = new DL_EF.JGonzalezProgramacionNCapasEntities())
                {
                    var query = context.UsuarioChangeStatus(idUsuario, status);

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

        //------------------------- LINQ --------------------------

        public static ML.Result AddLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JGonzalezProgramacionNCapasEntities context = new DL_EF.JGonzalezProgramacionNCapasEntities())
                {
                    DL_EF.Usuario usuarioDL = new DL_EF.Usuario();

                    usuarioDL.IdUsuario = usuario.IdUsuario;
                    usuarioDL.Nombre = usuario.Nombre;
                    usuarioDL.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuarioDL.ApellidoMaterno = usuario.ApellidoMaterno;
                    usuarioDL.FechaNacimiento = DateTime.Parse(usuario.FechaNacimiento);
                    usuarioDL.Sexo = usuario.Sexo.ToString();
                    usuarioDL.Telefono = usuario.Telefono;
                    usuarioDL.UserName = usuario.UserName;
                    usuarioDL.Password = usuario.Password;
                    usuarioDL.Email = usuario.Email;
                    usuarioDL.Celular = usuario.Celular;
                    usuarioDL.CURP = usuario.CURP;
                    usuarioDL.IdRol = usuario.Rol.IdRol;

                    context.Usuarios.Add(usuarioDL);

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

        public static ML.Result DeleteLINQ(int idUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JGonzalezProgramacionNCapasEntities context = new DL_EF.JGonzalezProgramacionNCapasEntities())
                {
                    var query = (from Usuario in context.Usuarios
                                 where Usuario.IdUsuario == idUsuario select Usuario).First();

                    if (query != null)
                    {
                        context.Usuarios.Remove(query);
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

        public static ML.Result UpdateLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JGonzalezProgramacionNCapasEntities context = new DL_EF.JGonzalezProgramacionNCapasEntities())
                {
                    var query = (from Usuario in context.Usuarios
                                 where Usuario.IdUsuario == usuario.IdUsuario
                                 select Usuario).SingleOrDefault();

                    if (query != null)
                    {
                        query.Nombre = usuario.Nombre;
                        query.ApellidoPaterno = usuario.ApellidoPaterno;
                        query.ApellidoMaterno = usuario.ApellidoMaterno;
                        query.FechaNacimiento = DateTime.Parse(usuario.FechaNacimiento);
                        query.Sexo = usuario.Sexo.ToString();
                        query.Telefono = usuario.Telefono;
                        query.UserName = usuario.UserName;
                        query.Password = usuario.Password;
                        query.Email = usuario.Email;
                        query.Celular = usuario.Celular;
                        query.CURP = usuario.CURP;
                        query.IdRol = usuario.Rol.IdRol;

                        context.SaveChanges();
                        result.Correct=true;
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

        public static ML.Result GetByIdLINQ(int idUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JGonzalezProgramacionNCapasEntities context = new DL_EF.JGonzalezProgramacionNCapasEntities())
                {
                    var query = (from Usuario in context.Usuarios
                                 where Usuario.IdUsuario == idUsuario
                                 select new
                                 {
                                     Usuario.IdUsuario,
                                     Usuario.Nombre,
                                     Usuario.ApellidoPaterno,
                                     Usuario.ApellidoMaterno,
                                     Usuario.FechaNacimiento,
                                     Usuario.Sexo,
                                     Usuario.Telefono,
                                     Usuario.UserName,
                                     Usuario.Password,
                                     Usuario.Email,
                                     Usuario.Celular,
                                     Usuario.CURP,
                                     Usuario.IdRol
                                 }).SingleOrDefault();

                    if (query != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario = query.IdUsuario;
                        usuario.Nombre = query.Nombre;
                        usuario.ApellidoPaterno = query.ApellidoPaterno;
                        usuario.ApellidoMaterno = query.ApellidoMaterno;
                        usuario.FechaNacimiento = query.FechaNacimiento.ToShortDateString();
                        usuario.Sexo = char.Parse(query.Sexo);
                        usuario.Telefono = query.Telefono;
                        usuario.UserName = query.UserName;
                        usuario.Password = query.Password;
                        usuario.Email = query.Email;
                        usuario.Celular = query.Celular;
                        usuario.CURP = query.CURP;
                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = query.IdRol;

                        result.Object = usuario;
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
                    var query = (from Usuario in context.Usuarios
                                 select new {
                                     Usuario.IdUsuario,
                                     Usuario.Nombre,
                                     Usuario.ApellidoPaterno,
                                     Usuario.ApellidoMaterno,
                                     Usuario.FechaNacimiento,
                                     Usuario.Sexo,
                                     Usuario.Telefono,
                                     Usuario.UserName,
                                     Usuario.Password,
                                     Usuario.Email,
                                     Usuario.Celular,
                                     Usuario.CURP,
                                     Usuario.IdRol
                                 });

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var row in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = row.IdUsuario;
                            usuario.Nombre = row.Nombre;
                            usuario.ApellidoPaterno = row.ApellidoPaterno;
                            usuario.ApellidoMaterno = row.ApellidoMaterno;
                            usuario.FechaNacimiento = row.FechaNacimiento.ToShortDateString();
                            usuario.Sexo = char.Parse(row.Sexo);
                            usuario.Telefono = row.Telefono;
                            usuario.UserName = row.UserName;
                            usuario.Password = row.Password;
                            usuario.Email = row.Email;
                            usuario.Celular = row.Celular;
                            usuario.CURP = row.CURP;
                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = row.IdRol;

                            result.Objects.Add(usuario);
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
