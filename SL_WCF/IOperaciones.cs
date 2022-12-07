using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IOperaciones" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IOperaciones
    {
        [OperationContract]
        int Suma(int numero1, int numero2);

        [OperationContract]
        int Resta(int numero1, int numero2);

        [OperationContract]
        int Multiplicacion(int numero1, int numero2);

        [OperationContract]
        decimal Division(int numero1, int numero2);

        [OperationContract]
        string Saludar(string nombre);
    }
}
