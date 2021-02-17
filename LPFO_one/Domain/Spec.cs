using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPFO_one.Domain
{
    public class Spec
    {
        [Key]
        public int ID_spec { get; set; }

        public string Name { get; set; }

        public string Mail { get; set; }

        [Required]
        public bool Worked { get; set; }
    }
}
