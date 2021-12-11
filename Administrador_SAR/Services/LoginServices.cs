using Administrador_SAR.Models;
using Administrador_SAR.Models.Login;
using System.Threading.Tasks;

namespace Administrador_SAR.Services
{
    public class LoginServices
    {
        public async Task<LoginModelResponse> SigIn(LoginModelRequest model)
        {
            LoginModelResponse repsonse = null;

            //Buscar usuario en base de datos
            return repsonse;
        }
    }
}