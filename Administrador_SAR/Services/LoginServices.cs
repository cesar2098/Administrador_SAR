using Administrador_SAR.DBContext;
using Administrador_SAR.Models;
using Administrador_SAR.Models.Login;
using System.Data.Entity;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace Administrador_SAR.Services
{
    public class LoginServices
    {
        private readonly RSDBEntities _context;
        public LoginServices()
        {
            _context = new RSDBEntities();
        }

        public async Task<LoginModelResponse> SigIn(LoginModelRequest model)
        {
            LoginModelResponse repsonse = null;

            //Buscar usuario en base de datos
            var user = await _context.Accounts.FirstOrDefaultAsync(x => x.Email == model.Email && x.IsActive);
            if (user == null)
                return repsonse;
            
            //Validamos contraseñas
            if (BC.Verify(model.Password, user.Password))
            {
                repsonse= new LoginModelResponse();
                repsonse.FirstName = user.FirstName;
                repsonse.RolId = user.Role;
                repsonse.UserId = user.Id;
            }

            return repsonse;
        }
    }
}