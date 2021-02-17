using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPFO_one.Domain.Repos
{
    public class SpecRepos
    {
        private readonly AppDbContext context;

        public SpecRepos(AppDbContext context)
        {
            this.context = context;
        }

        // получение специалиста по id 
        public Spec GetSpec(Spec id)
        {
            return context.Specs.FirstOrDefault(x => x.ID_spec == id.ID_spec);
        }

    }
}
