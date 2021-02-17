using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LPFO_one.Domain
{
    public class Services
    {
        [Key]
        public int ID_service { get; set; }

        public string Name { get; set; }

        public ICollection<Note> Notes { get; set; }

    }
}
