using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Webapp3.Entites;
using Webapp3.Models;

namespace Webapp3.Controllers
{
    public class UserController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;



        public UserController(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            List<UserModel> users = _databaseContext.Users.ToList().Select(x => _mapper.Map<UserModel>(x)).ToList(); ;
            
            return View(users);
        }
        public IActionResult Create()
        {
            return View();  
        }
        [HttpPost]
        public IActionResult Create(CreateUserModel model)
        {
            if (ModelState.IsValid)
            {
                if (_databaseContext.Users.Any(x => x.UserName.ToLower() == model.UserName.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.UserName), "Username already exists.");
                    return View(model);
                }
                User user=_mapper.Map<User>(model);
                _databaseContext.Users.Add(user);
                _databaseContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public IActionResult Edit(Guid id)
        {
            User user=_databaseContext.Users.Find(id);  
            EditUserModel model=_mapper.Map<EditUserModel>(user);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Guid id,EditUserModel model)
        {
            if (ModelState.IsValid)
            {
                if (_databaseContext.Users.Any(x => x.UserName.ToLower() == model.UserName.ToLower()&&x.Id != id ))
                {
                    ModelState.AddModelError(nameof(model.UserName), "Username already exists.");
                    return View(model);
                }
                User user = _databaseContext.Users.Find(id); 
                _mapper.Map(model, user);
                _databaseContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
       
        public IActionResult Delete(Guid id)
        {
          
                User user = _databaseContext.Users.Find(id);
            if (user != null)
            {
                _databaseContext.Users.Remove(user);
                _databaseContext.SaveChanges();
            }

                return RedirectToAction(nameof(Index));
            
      
        }
    }
}
