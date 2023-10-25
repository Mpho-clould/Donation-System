using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


namespace POE_PART1.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AppRolesController1 : Controller
    {
        private readonly RoleManager<IdentityRole>_roleManager;
        public AppRolesController1(RoleManager<IdentityRole> roleManager)
        {
               _roleManager= roleManager;
        }
        //List all the roles created by users
        public IActionResult Index()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole model)
        {
            //Avoid duplicate roles
            if (!_roleManager.RoleExistsAsync(model.Name).GetAwaiter().GetResult()) 
            {
                _roleManager.CreateAsync(new IdentityRole (model.Name)).GetAwaiter().GetResult();    
            }
            return Redirect("Index");
        }
    }
}
