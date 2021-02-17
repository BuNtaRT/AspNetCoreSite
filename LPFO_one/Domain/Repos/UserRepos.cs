using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPFO_one.Domain.Repos
{
    public class UserRepos
    {
        private readonly AppDbContext context;

        public UserRepos(AppDbContext context)
        {
            this.context = context;
        }

        // проверка пользователя по номеру телефона
        public bool CheckUser(string num) {

            if (context.Users == null)
            {
                return false;
            }

            if (context.Users.FirstOrDefault(x => x.Phone_num == num) != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        // создание нового пользователя
        // для исключения повторной записи 
        public Users CreateUsers(Users user)
        {
            context.Entry(user).State = EntityState.Added;
            context.SaveChanges();
            return user;
        }
    }
}
