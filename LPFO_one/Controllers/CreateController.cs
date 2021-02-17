using LPFO_one.Domain;
using LPFO_one.Domain.Repos;
using LPFO_one.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LPFO_one.Controllers
{


    public class CreateController : Controller
    {
        private readonly NoteRepos noteRepos;
        private readonly UserRepos userRepos;
        private readonly SpecRepos specRepos;
        private readonly ServiceRepos servicesRepos;
        private readonly AppDbContext auc;


        public CreateController(NoteRepos noteRepos, UserRepos userRepos, AppDbContext auc, ServiceRepos servicesRepos, SpecRepos specRepos)

        {
            this.noteRepos = noteRepos;
            this.userRepos = userRepos;
            this.specRepos = specRepos;
            this.servicesRepos = servicesRepos;
            this.auc = auc;
        }



        // Данне из бд для формы (для Dropdown)
        public IActionResult CreateNote(DateTime date)
        {


            // вытаскиваем данные для dropdown из бд в ViewBag
            // специалисты
            List<Spec> sp = new List<Spec>();
            List<Spec> spFinal = new List<Spec>();
            sp = (from c in auc.Specs select c).ToList();
            foreach (Spec spec in sp)
            {
                if (spec.Worked)
                {
                    spFinal.Add(spec);
                }
            }
            spFinal.Insert(0, new Spec { ID_spec = 0, Name = "--Выберите специалиста--" });
            ViewBag.specBag = spFinal;

            // потом отделы
            List<Unit> un = new List<Unit>();
            un = (from c in auc.Units select c).ToList();
            un.Insert(0, new Unit { ID_unit = 0, Name = "--Выберите отдел--" });
            ViewBag.unitBag = un;

            //и сервисы/услуги 
            List<Services> se = new List<Services>();
            se = (from c in auc.Services select c).ToList();

            ViewBag.serviceBag = new MultiSelectList(se, "ID_service", "Name");

            // дата из home/index для datapicker
            ViewBag.DateTime = date;

            return View();


        }



        [HttpPost]
        public IActionResult CreateNote(int[] ID_service, NoteViewModel model, int timeSet)
        {
            Users user;
            List<Services> services = new List<Services>();
            DateTime date_set_inModel = new DateTime(model.note.Date.Year, model.note.Date.Month,
                model.note.Date.Day, timeSet, model.note.Date.Minute, model.note.Date.Second);
            if (noteRepos.CheckDate(date_set_inModel)) {
                ViewData["error"] = "Запись на данное время уже существует!";
                return CreateNote(model.note.Date);
            }

            if (ModelState.IsValid)
            {
                // работа с пользователем 
                // проверка на уникальность и заполнение User для дольнейшего добавления в БД
                if (!userRepos.CheckUser(model.users.Phone_num))
                {
                    Users users = new Users();
                    users.Phone_num = model.users.Phone_num;
                    users.Name = model.users.Name;
                    users.Unit = model.unit;
                    users.Post = model.users.Post;

                    user = userRepos.CreateUsers(users);
                    //добавление пользователя 

                    //сбор Note
                    Note note = new Note();

                    note.Users = user;

                    Spec specialist = new Spec();
                    specialist = specRepos.GetSpec(model.spec);     // получаем специалиста и добавляем в поле для записи

                    note.Spec = specialist;



                    note.Date = date_set_inModel;                    // закрепляем дату 


                    // парсим все услуги по ID и добавляем в лист
                    foreach (int ids in ID_service)
                    {
                        Services services1 = servicesRepos.GetServicesById(ids);
                        services.Add(services1);
                    }
                    // для дольнейшего использования его в записи == множество сервисов/услуг на одну запись
                    note.Services = services;
                    noteRepos.SaveNote(note);


                    return View("FinalNote");
                }
                else
                {
                    // если номер существет
                    ViewData["error"] = "Пользователь уже существует, повторная запись запрещена!";
                    return CreateNote(model.note.Date);
                }
            }
            else
            {
                return CreateNote(model.note.Date);
            }

        }

        // финальная страница с уведомлением
        public IActionResult FinalNote()
        {
            return View("FinalNote");
        }



    }
}
