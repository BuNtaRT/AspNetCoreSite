using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPFO_one.Domain
{
    public class Note
    {
        [Key]
        public int ID_note { get; set; }

        

        [Display(Name = "Пользователь")]
        public Users Users { get; set; }

        //public Users ID_user { get; set; }
        //public int ID_user { get; set; }




        [Display(Name = "Специалист")]
        public Spec Spec { get; set; }

        //public Spec ID_spec { get; set; }

        //public int ID_spec { get; set; }


        public ICollection<Services> Services { get; set; }

        [Required]
        [Display(Name = "Дата")]
        public DateTime Date { get; set; }

    }
}
