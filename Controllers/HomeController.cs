using App.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using App.Models;
using App.Repository;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{


    public class HomeController : Controller
    {

        private readonly IMapper _mapper;

        private readonly IRepository<User> _userRepository;

        public HomeController(IMapper mapper, IRepository<User> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }


        public IActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                //check for the user if the email has instance in the backend database 
                var user = _mapper.Map<User>(viewModel);
                //if the user has found 
                if (_userRepository.FindByEmailAddress(user.EmailAddress))
                {
                    //we found the user
                    var targetUser = _userRepository.GetAll().SingleOrDefault((i => i.EmailAddress == user.EmailAddress));
                    if (targetUser.Password == user.Password)
                    {
                        //gate for entering the system
                        HttpContext.Session.SetString("User",JsonSerializer.Serialize(targetUser));
                        await HttpContext.Session.CommitAsync();
                        return RedirectToRoutePermanent(new {controller="Salaty",action="Index"});
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Wrong Email Or Password");
                        return View(viewModel);
                    }
                }
                else
                {
                    ModelState.AddModelError("Email", "Wrong Email Or Password");
                    return View(viewModel);
                }
            }
            else
            {
                return View(new LoginViewModel());
            }


        }

        public IActionResult Register()
        {
            return View(new RegisterUserViewModel());
        }

        [HttpPost]
        public IActionResult Register(RegisterUserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.Password == viewModel.ConfirmPassword)
                {
                    //map the view Model to the user Model 
                    var user = _mapper.Map<User>(viewModel);
                    //search for the current user in the database 
                    var result = _userRepository.FindByEmailAddress(user.EmailAddress);
                    if (result == false)
                    {
                        //user first time ask for register 
                        //insert the data in the data base 
                        _userRepository.InsertOne(user);
                        //then Navigate the user to the Login Page [index]
                        return RedirectToRoutePermanent(new {controller="Home",action="Index"});
                    }
                    else
                    {
                        ModelState.AddModelError("EmailAddress", "Email Already Exist");
                        return View(new RegisterUserViewModel());
                    }

                    //redirect to the Profile View
                }
                else
                {
                    ModelState.AddModelError("Password", "Wrong Password Confirmation");
                    return View(new RegisterUserViewModel());
                    //model is not valid 
                }
            }
            else
            {
                //do something to tell him that no thing running well
                return View(new RegisterUserViewModel());
            }

        }


        public IActionResult Logout(){
            HttpContext.Session.Remove("User");
            return RedirectToRoutePermanent(new {controller="Home",action="Index"});
        }

    }





}