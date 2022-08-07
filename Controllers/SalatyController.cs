using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using App.Models;
using AutoMapper;
using App.ViewModel;
using App.Repository;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{

    public class SalatyController : Controller
    {

        private readonly IMapper _mapper;

        private readonly IRepository<Salah> _salahRepository;

        public SalatyController(IMapper mapper, IRepository<Salah> salaRepository)
        {
            _mapper = mapper;

            _salahRepository = salaRepository;
        }

        public IActionResult Index()
        {

            //check for the session if the user is there then hook on him and convert him to user 
            var jsonUser = HttpContext.Session.GetString("User");
            //convert the user to SalatyUserViewModel
            if (jsonUser != null)
            {
                var user = JsonSerializer.Deserialize<User>(jsonUser);
                user.Salahs = _salahRepository.GetAll().Include("Tasbeeh").Where(s => s.UserId == user.Id).ToList();
                //conver to SalatyProfileUser
                var salatyProfileViewModel = _mapper.Map<SalatyProfileViewModel>(user);

                return View(salatyProfileViewModel);
            }
            else
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

        }


        public IActionResult Add()
        {
            return View(new SalahAddViewModel());
        }

        [HttpPost]
        public IActionResult Add(SalahAddViewModel viewModel)
        {

            var jsonUser = HttpContext.Session.GetString("User");

            if (jsonUser != null)
            {
                var user = JsonSerializer.Deserialize<User>(jsonUser);
                //convert the viewmodel to salah 
                var salah = _mapper.Map<Salah>(viewModel);
                //complete the salah object and prepare for db insertion                     
                //if all are ok navigate back to the Index
                salah.UserId = user.Id;
                               
                _salahRepository.InsertOne(salah);


                return RedirectToRoute(new { controller = "Salaty", action = "Index" });

            }
            else
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            }

        }


        public IActionResult Delete(int id)
        {
            //check for the session if the user is there then hook on him and convert him to user 
            var jsonUser = HttpContext.Session.GetString("User");
            //convert the user to SalatyUserViewModel
            if (jsonUser != null)
            {
                var user = JsonSerializer.Deserialize<User>(jsonUser);

                _salahRepository.DeleteOne(id); //deleting                

                return RedirectToRoute(new { controller = "Salaty", action = "Index" });
            }
            else
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
        }

    }



}