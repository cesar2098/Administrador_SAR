using Administrador_SAR.DBContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Administrador_SAR.Services
{
    public class CountriesServices
    {
        private RSDBEntities db = new RSDBEntities();

        public async Task<List<Countries>> GetCountries()
        {
            return await db.Countries.ToListAsync();
        }

        //Obtiene pais por id
        public async Task<Countries> GetCountrie(int id)
        {
            //si no encuntra resultados, retorna null
           return await db.Countries.FirstOrDefaultAsync(x => x.CountryId == id);
        }
    }
}