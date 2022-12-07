using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Operaciones" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Operaciones.svc o Operaciones.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Operaciones : IOperaciones
    {
        public int Suma (int numero1, int numero2)
        {
            return numero1 + numero2;
        }

        public int Resta(int numero1, int numero2)
        {
            return numero1 - numero2;
        }

        public int Multiplicacion(int numero1, int numero2)
        {
            return numero1 * numero2;
        }

        public decimal Division(int numero1, int numero2)
        {
            return numero1 / numero2;
        }

        public string Saludar(string nombre)
        {
            return $"Hola {nombre}, toma agua ^^";
        }
    }
}
