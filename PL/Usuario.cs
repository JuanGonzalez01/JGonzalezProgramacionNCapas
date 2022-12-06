using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Usuario
    {
        public static void Add()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("\nNombre:");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Apellido Paterno:");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Apellido Materno:");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Fecha de nacimiento:\tAAAA-MM-DD");
            usuario.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Sexo:\tM) Masculino\tF) Femenino:");
            usuario.Sexo = char.Parse(Console.ReadLine());

            Console.WriteLine("Teléfono:");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Nombre de usuario:");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Contraseña:");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Email:");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Celular:");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("CURP:");
            usuario.CURP = Console.ReadLine();

            Console.WriteLine("ID del rol:");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = byte.Parse(Console.ReadLine());


            //ML.Result result = BL.Usuario.Add(usuario);
            //ML.Result result = BL.Usuario.AddSP(usuario);
            //ML.Result result = BL.Usuario.AddEF(usuario);
            ML.Result result = BL.Usuario.AddLINQ(usuario);

            if (result.Correct)
            {
                Console.WriteLine("\n****** Usuario agregado correctamente *****");
            }
            else
            {
                Console.WriteLine($"\n***** Error al intentar agregar usuario: {result.ErrorMessage}");
            }
        }

        public static void Delete()
        {
            Console.WriteLine("\nIngrese el ID del usuario a eliminar:");
            int idUsuario = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Usuario.Delete(idUsuario);
            //ML.Result result = BL.Usuario.DeleteEF(idUsuario);
            ML.Result result = BL.Usuario.DeleteLINQ(idUsuario);

            if (result.Correct)
            {
                Console.WriteLine("\n****** Usuario eliminado correctamente *****");
            }
            else
            {
                Console.WriteLine($"\n***** Error al intentar eliminar usuario: {result.ErrorMessage}");
            }

        }

        public static void Update()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("\nIngrese el ID del usuario a modificar:");
            usuario.IdUsuario = byte.Parse(Console.ReadLine());

            Console.WriteLine("\nNombre:");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Apellido Paterno:");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Apellido Materno:");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Fecha de nacimiento:\tAAAA-MM-DD");
            usuario.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Sexo:\tM) Masculino\tF) Femenino:");
            usuario.Sexo = char.Parse(Console.ReadLine());

            Console.WriteLine("Teléfono:");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Nombre de usuario:");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Contraseña:");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Email:");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Celular:");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("CURP:");
            usuario.CURP = Console.ReadLine();

            Console.WriteLine("ID del rol:");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = byte.Parse(Console.ReadLine());

            //ML.Result result = BL.Usuario.Update(usuario);
            //ML.Result result = BL.Usuario.UpdateEF(usuario);
            ML.Result result = BL.Usuario.UpdateLINQ(usuario);

            if (result.Correct)
            {
                Console.WriteLine("\n****** Usuario modificado correctamente *****");
            }
            else
            {
                Console.WriteLine($"\n***** Error al intentar modificar usuario: {result.ErrorMessage}");
            }
        }

        public static void GetById()
        {
            Console.WriteLine("\nIngrese el ID del usuario a mostrar:");
            int idUsuario = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Usuario.GetById(idUsuario);
            //ML.Result result = BL.Usuario.GetByIdEF(idUsuario);
            ML.Result result = BL.Usuario.GetByIdLINQ(idUsuario);

            if (result.Correct)
            {
                ML.Usuario usuario = (ML.Usuario)result.Object;

                Console.WriteLine("==========================================================");
                Console.WriteLine($"ID del usuario: \t{usuario.IdUsuario}");
                Console.WriteLine($"Nombre: \t{usuario.Nombre}");
                Console.WriteLine($"Apellido paterno: \t{usuario.ApellidoPaterno}");
                Console.WriteLine($"Apellido materno: \t{usuario.ApellidoMaterno}");
                Console.WriteLine($"Fecha de nacimiento: \t{usuario.FechaNacimiento}");
                Console.WriteLine($"Sexo: \t{usuario.Sexo}");
                Console.WriteLine($"Telefono: \t{usuario.Telefono}");
                Console.WriteLine($"Nombre de usuario: \t{usuario.UserName}");
                Console.WriteLine($"Contraseña: \t{usuario.Password}");
                Console.WriteLine($"Email: \t{usuario.Email}");
                Console.WriteLine($"Celular: \t{usuario.Celular}");
                Console.WriteLine($"CURP: \t{usuario.CURP}");
                Console.WriteLine($"ID del rol: \t{usuario.Rol.IdRol}");
            }
            else
            {
                Console.WriteLine($"\n***** Error al intentar mostrar usuario: {result.ErrorMessage}");
            }
        }

        public static void GetAll()
        {
            //ML.Result result = BL.Usuario.GetAll();
            //ML.Result result = BL.Usuario.GetAllEF();
            ML.Result result = BL.Usuario.GetAllLINQ();

            if (result.Correct)
            {
                foreach (ML.Usuario usuario in result.Objects)
                {
                    Console.WriteLine("==========================================================");
                    Console.WriteLine($"ID del usuario: \t{usuario.IdUsuario}");
                    Console.WriteLine($"Nombre: \t{usuario.Nombre}");
                    Console.WriteLine($"Apellido paterno: \t{usuario.ApellidoPaterno}");
                    Console.WriteLine($"Apellido materno: \t{usuario.ApellidoMaterno}");
                    Console.WriteLine($"Fecha de nacimiento: \t{usuario.FechaNacimiento}");
                    Console.WriteLine($"Sexo: \t{usuario.Sexo}");
                    Console.WriteLine($"Telefono: \t{usuario.Telefono}");
                    Console.WriteLine($"Nombre de usuario: \t{usuario.UserName}");
                    Console.WriteLine($"Contraseña: \t{usuario.Password}");
                    Console.WriteLine($"Email: \t{usuario.Email}");
                    Console.WriteLine($"Celular: \t{usuario.Celular}");
                    Console.WriteLine($"CURP: \t{usuario.CURP}");
                    Console.WriteLine($"ID del rol: \t{usuario.Rol.IdRol}");
                }
            }
            else
            {
                Console.WriteLine($"\n***** Error al intentar mostrar usuarios: {result.ErrorMessage}");
            }
        }
    }
}
