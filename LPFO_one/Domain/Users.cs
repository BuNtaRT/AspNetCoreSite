using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LPFO_one.Domain
{
    public class Users
    {
        [Key]
        public int ID_user { get; set; }

        [Required]
        [Display(Name = "Номер Телефона")]
        public string Phone_num { get; set; }

        [Required]
        [Display(Name = "Ф.И.О")]
        public string Name { get; set; }

        [Display(Name = "Подразделение")]

        public Unit Unit { get; set; }

        //public List<Unit> ID_unit { get; set; }
        //public int ID_unit { get; set; }

        [Required]
        [Display(Name = "Должность")]
        public string Post { get; set; }
    }
}
