using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LPFO_one.Domain.Repos
{
    public class NoteRepos
    {
        private readonly AppDbContext context;

        public NoteRepos(AppDbContext context) {
            this.context = context;
        }

        // Iclude что бы включить зависимые/вложенные таблицы
        //все записи
        public IQueryable<Note> GetAllNotes() {
            return context.Notes.Include(x => x.Users).Include(x => x.Services).Include(x => x.Spec).Include(x => x.Users.Unit);
        }

        public bool CheckDate(DateTime check_date)
        {
            if (context.Notes == null)
            {
                return false;
            }

            if (context.Notes.FirstOrDefault(x => x.Date == check_date) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // собственно по ID получение 
        public Note GetNoteById(int id) {
            return context.Notes.Single(x => x.ID_note == id);
        }

        //получение заметок на выбранный день
        public IQueryable<Note> GetNoteByNowDay(DateTime dateTime)
        {                                   //путем сравнивания дат (время не затрагивается)
            return context.Notes.Where(x => x.Date.Date == dateTime.Date).Include(x => x.Users).Include(x => x.Services).Include(x => x.Spec).Include(x => x.Users.Unit);
        }


        // сохранение(ничего больше)
        public void SaveNote(Note note) {
            context.Entry(note).State = EntityState.Added;
            context.SaveChanges();

        }

    }
}
