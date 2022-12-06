using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();            
        }

        public static void Menu()
        {
            do
            {
                Console.WriteLine("========== ABC en ADO.NET =========\nDel siguiente menú selecciona la tabla deseada:\n1) Usuario\n2) Aseguradora");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        MenuUsuario();
                        break;
                    case 2:
                        MenuAseguradora();
                        break;
                }
                Console.WriteLine("\n¿Deseas seleccionar otra tabla?\n1) Si\n2) No");
            } while (int.Parse(Console.ReadLine()) == 1);
        }

        public static void MenuUsuario()
        {
            do
            {
                Console.WriteLine("++++++++++ USUARIO ++++++++++\nDel siguiente menú selecciona la opción deseada:\n1) Alta (Añadir)\n2) Baja(Eliminar)\n3) Cambio(Actualizar)\n4) Obtener registro\n5) Obtener todo");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                   case 1:
                        Usuario.Add();
                        break;
                    case 2:
                        Usuario.Delete();
                        break;
                    case 3:
                        Usuario.Update();
                        break;
                    case 4:
                        Usuario.GetById();
                        break;
                    case 5:
                        Usuario.GetAll();
                        break;
                }
                Console.WriteLine("\n¿Deseas hacer otra acción?\n1) Si\n2) No");
            } while (int.Parse(Console.ReadLine()) == 1);
        }

        public static void MenuAseguradora()
        {
            do
            {
                Console.WriteLine("++++++++++ ASEGURADORA ++++++++++\nDel siguiente menú selecciona la opción deseada:\n1) Alta (Añadir)\n2) Baja(Eliminar)\n3) Cambio(Actualizar)\n4) Obtener registro\n5) Obtener todo");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Aseguradora.Add();
                        break;
                    case 2:
                        Aseguradora.Delete();
                        break;
                    case 3:
                        Aseguradora.Update();
                        break;
                    case 4:
                        Aseguradora.GetById();
                        break;
                    case 5:
                        Aseguradora.GetAll();
                        break;
                }
                Console.WriteLine("\n¿Deseas hacer otra acción?\n1) Si\n2) No");
            } while (int.Parse(Console.ReadLine()) == 1);
        }
    }
}
