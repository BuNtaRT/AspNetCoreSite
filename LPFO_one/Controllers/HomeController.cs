using ClosedXML.Excel;
using LPFO_one.Domain;
using LPFO_one.Domain.Repos;
using LPFO_one.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LPFO_one.Controllers
{
    public class HomeController : Controller
    {
        private readonly NoteRepos noteRepos;

        public HomeController(NoteRepos noteRepos)
        {
            this.noteRepos = noteRepos;
        }



        public IActionResult Index()
        {

            ViewData["date"] = String.Format("{0:yyyy-MM-dd}", DateTime.Now.Date);       // форматируем дату для Datapicker
            LockButton(DateTime.Now);                                                   // медот для блокировки кнопки записи если сегодня выходные  
            return View(noteRepos.GetNoteByNowDay(DateTime.Now));                       // воозвращяем выбранный день
        }


        [HttpPost]
        public IActionResult Index(DateTime DateSlots) {
            ViewData["date"] = String.Format("{0:yyyy-MM-dd}", DateSlots.Date);
            LockButton(DateSlots);
            return View(noteRepos.GetNoteByNowDay(DateSlots));
        }


        [HttpPost]
        public IActionResult GoCreate(DateTime DateSlots) {
            return RedirectToAction("CreateNote", "Create", DateSlots);
        }

        public IActionResult Admin()
        {
            return View();
        }

        // блокировка кнопки если выбран выходной день
        private void LockButton(DateTime date) 
        {

            ViewBag.boolButton = true;

            if (date.Date <= DateTime.Now.Date) {
                ViewBag.boolButton = false;
                ViewData["MessageDay"] = "На данный день запись уже недоступна!";
            }

            if (date.DayOfWeek.ToString() == "Sunday" || date.DayOfWeek.ToString() == "Saturday")
            {
                ViewBag.boolButton = false;
                ViewData["MessageDay"] = "В выходные дни запись закрыта!";
            }
        }

        public IActionResult ExportExcelAll() 
        {
            return Xlsx_Create(noteRepos.GetAllNotes(),"All");

        }

        public IActionResult ExportExcelDay(DateTime DateSlots) 
        {
            return Xlsx_Create(noteRepos.GetNoteByNowDay(DateSlots),"OneDay");

        }

        private IActionResult Xlsx_Create(IEnumerable<Note> model, string name) 
        {
            using (var xml = new XLWorkbook())
            {
                // подготовка таблицы и нейминг первой строки
                var worksheet = xml.Worksheets.Add("Note");
                var current_row = 1;
                worksheet.Cell(current_row, 1).Value = "№";
                worksheet.Cell(current_row, 2).Value = "Имя пользователя";
                worksheet.Cell(current_row, 3).Value = "Отдел";
                worksheet.Cell(current_row, 4).Value = "Должность";
                worksheet.Cell(current_row, 5).Value = "Сервис";
                worksheet.Cell(current_row, 6).Value = "Специалист";
                worksheet.Cell(current_row, 7).Value = "Дата";
                worksheet.Cell(current_row, 8).Value = "Номер телефона";

                //заполнение таблицы
                foreach (var item in model)
                {
                    current_row++;
                    worksheet.Cell(current_row, 1).Value = item.ID_note;
                    worksheet.Cell(current_row, 2).Value = item.Users.Name;
                    worksheet.Cell(current_row, 3).Value = item.Users.Unit.Name;
                    worksheet.Cell(current_row, 4).Value = item.Users.Post;
                    //вытаскиваем имена всех сервисов для данной записи
                    string serv = "";
                    foreach (var temp in item.Services)
                    {
                        serv += temp.Name + "**";
                    }

                    worksheet.Cell(current_row, 5).Value = serv;
                    worksheet.Cell(current_row, 6).Value = item.Spec.Name;
                    worksheet.Cell(current_row, 7).Value = item.Date;
                    worksheet.Cell(current_row, 8).Value = item.Users.Phone_num;
                }
                using (var stream = new MemoryStream())
                {
                    xml.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Note("+ name + ").xlsx");
                }
            }
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
