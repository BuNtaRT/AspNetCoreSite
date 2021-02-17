using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPFO_one.Domain.Repos
{
    public class ServiceRepos
    {
        private readonly AppDbContext context;

        public ServiceRepos(AppDbContext context)
        {
            this.context = context;
        }

        // просто получение сервиса по ID
        public Services GetServicesById(int id)
        {
            return context.Services.FirstOrDefault(x => x.ID_service == id);
        }
    }
}