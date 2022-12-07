using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Aseguradora" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Aseguradora.svc o Aseguradora.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Aseguradora : IAseguradora
    {
        public SL_WCF.Result GetAll()
        {
            ML.Result result = BL.Aseguradora.GetAllEF();
            return new SL_WCF.Result { Correct=result.Correct, ErrorMessage=result.ErrorMessage, Ex=result.Ex, Object=result.Object, Objects=result.Objects};
        }

        public SL_WCF.Result GetById(int idAseguradora)
        {
            ML.Result result = BL.Aseguradora.GetByIdEF(idAseguradora);
            return new SL_WCF.Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex, Object = result.Object, Objects = result.Objects };
        }

        public SL_WCF.Result Update(ML.Aseguradora aseguradora)
        {
            ML.Result result = BL.Aseguradora.UpdateEF(aseguradora);
            return new SL_WCF.Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex, Object = result.Object, Objects = result.Objects };
        }

        public SL_WCF.Result Add(ML.Aseguradora aseguradora)
        {
            ML.Result result = BL.Aseguradora.AddEF(aseguradora);
            return new SL_WCF.Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex, Object = result.Object, Objects = result.Objects };
        }

        public SL_WCF.Result Delete(int idAseguradora)
        {
            ML.Result result = BL.Aseguradora.DeleteEF(idAseguradora);
            return new SL_WCF.Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex, Object = result.Object, Objects = result.Objects };
        }
    }
}
