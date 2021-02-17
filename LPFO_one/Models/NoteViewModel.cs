using LPFO_one.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPFO_one.Models
{
    // модель для создания пользователя 
    public class NoteViewModel
    {
        public Note note { get; set; }
        public Users users { get; set; }
        public Services service { get; set; }
        public Unit unit { get; set; }
        public Spec spec { get; set; }

        public int[] timeSet = { 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 };

    }
}
