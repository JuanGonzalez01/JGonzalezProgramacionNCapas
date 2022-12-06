using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Aseguradora
    {
        public static void Add()
        {
            ML.Aseguradora aseguradora = new ML.Aseguradora();

            Console.WriteLine("\nNombre:");
            aseguradora.Nombre = Console.ReadLine();

            Console.WriteLine("ID del usuario:");
            aseguradora.Usuario = new ML.Usuario();
            aseguradora.Usuario.IdUsuario = byte.Parse(Console.ReadLine());

            //ML.Result result = BL.Aseguradora.Add(aseguradora);
            //ML.Result result = BL.Aseguradora.AddEF(aseguradora);
            ML.Result result = BL.Aseguradora.AddLINQ(aseguradora);

            if (result.Correct)
            {
                Console.WriteLine("\n****** Aseguradora agregada correctamente *****");
            }
            else
            {
                Console.WriteLine($"\n***** Error al intentar agregar aseguradora: {result.Ex.Message}");
            }
        }

        public static void Delete()
        {
            Console.WriteLine("\nIngrese el ID de la aseguradora a eliminar:");
            int idAseguradora = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Aseguradora.Delete(idAseguradora);
            //ML.Result result = BL.Aseguradora.DeleteEF(idAseguradora);
            ML.Result result = BL.Aseguradora.DeleteLINQ(idAseguradora);

            if (result.Correct)
            {
                Console.WriteLine("\n****** Aseguradora eliminada correctamente *****");
            }
            else
            {
                Console.WriteLine($"\n***** Error al intentar eliminar aseguradora: {result.ErrorMessage}");
            }

        }

        public static void Update()
        {
            ML.Aseguradora aseguradora = new ML.Aseguradora();

            Console.WriteLine("\nIngrese el ID de la aseguradora a modificar:");
            aseguradora.IdAseguradora = int.Parse(Console.ReadLine());

            Console.WriteLine("\nNombre:");
            aseguradora.Nombre = Console.ReadLine();

            Console.WriteLine("ID del usuario:");
            aseguradora.Usuario = new ML.Usuario();
            aseguradora.Usuario.IdUsuario = byte.Parse(Console.ReadLine());

            //ML.Result result = BL.Aseguradora.Update(aseguradora);
            //ML.Result result = BL.Aseguradora.UpdateEF(aseguradora);
            ML.Result result = BL.Aseguradora.UpdateLINQ(aseguradora);

            if (result.Correct)
            {
                Console.WriteLine("\n****** Aseguradora modificada correctamente *****");
            }
            else
            {
                Console.WriteLine($"\n***** Error al intentar modificar aseguradora: {result.ErrorMessage}");
            }
        }

        public static void GetById()
        {
            Console.WriteLine("\nIngrese el ID de la aseguradora a mostrar:");
            int idAseguradora = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Aseguradora.GetById(idAseguradora);
            //ML.Result result = BL.Aseguradora.GetByIdEF(idAseguradora);
            ML.Result result = BL.Aseguradora.GetByIdLINQ(idAseguradora);

            if (result.Correct)
            {
                ML.Aseguradora aseguradora = (ML.Aseguradora)result.Object;

                Console.WriteLine("==========================================================");
                Console.WriteLine($"ID de la aseguradora: \t{aseguradora.IdAseguradora}");
                Console.WriteLine($"Nombre: \t{aseguradora.Nombre}");
                Console.WriteLine($"Fecha de creación: \t{aseguradora.FechaCreacion}");
                Console.WriteLine($"Fecha de modificación: \t{aseguradora.FechaModificacion}");
                Console.WriteLine($"ID del usuario: \t{aseguradora.Usuario.IdUsuario}");
            }
            else
            {
                Console.WriteLine($"\n***** Error al intentar mostrar aseguradora: {result.ErrorMessage}");
            }
        }

        public static void GetAll()
        {
            //ML.Result result = BL.Aseguradora.GetAll();
            //ML.Result result = BL.Aseguradora.GetAllEF();
            ML.Result result = BL.Aseguradora.GetAllLINQ();

            if (result.Correct)
            {
                foreach (ML.Aseguradora aseguradora in result.Objects)
                {
                    Console.WriteLine("==========================================================");
                    Console.WriteLine($"ID de la aseguradora: \t{aseguradora.IdAseguradora}");
                    Console.WriteLine($"Nombre: \t{aseguradora.Nombre}");
                    Console.WriteLine($"Fecha de creación: \t{aseguradora.FechaCreacion}");
                    Console.WriteLine($"Fecha de modificación: \t{aseguradora.FechaModificacion}");
                    Console.WriteLine($"ID del usuario: \t{aseguradora.Usuario.IdUsuario}");
                }
            }
            else
            {
                Console.WriteLine($"\n***** Error al intentar mostrar aseguradoras: {result.ErrorMessage}");
            }
        }
    }
}
