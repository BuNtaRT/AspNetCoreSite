using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LPFO_one.Domain
{
    public class Unit
    {
        [Key]
        public int ID_unit { get; set; }

        public string Name { get; set; }

    }
}
