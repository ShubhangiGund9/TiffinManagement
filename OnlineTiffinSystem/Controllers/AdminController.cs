using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Model.Models;
//using OnlineTiffinSystem.Models;

namespace OnlineTiffinSystem.Controllers
{
    public class AdminController : Controller
    {
        RoleManager<IdentityRole> rolemanager;
        UserManager<IdentityUser> userManager;

        public AdminController(RoleManager<IdentityRole> rolemanager, UserManager<IdentityUser> userManager)
        {
            this.rolemanager = rolemanager;
            this.userManager = userManager;
        }

        public async Task< IActionResult> Index()
        {
            List<IdentityRole> roles = await rolemanager.Roles.ToListAsync();
            ViewData["Roles"]=roles;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Index(RoleModel rm)
        {
            if(ModelState.IsValid)
            {
                bool roleexist = await rolemanager.RoleExistsAsync(rm?.RoleName);
                if(roleexist)
                {
                    ModelState.AddModelError(string.Empty, "Role already Exist");
                }
                else
                {
                    var role = new IdentityRole()
                    {
                        Name = rm.RoleName,

                    };
                    var result = await rolemanager.CreateAsync(role);
                    if(result.Succeeded)
                    {
                        ViewBag.msg = "Role is Added";
                        ModelState.Clear();

                    }
                    else
                    {
                        foreach(var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }

            List<IdentityRole> roles = await rolemanager.Roles.ToListAsync();
            ViewData["roles"] = roles;
            return View();

        }

        public async Task<IActionResult> EditRole(string roleid)
        {
            IdentityRole role = await rolemanager.FindByIdAsync(roleid);
            var model = new EditRoleModel()
            {
                id = role.Id,
                RoleName = role.Name,
                User = new List<string>()
            };
            foreach(var user in userManager.Users.ToList())
            {
                if(await userManager.IsInRoleAsync(user,role.Name))
                {
                    model.User.Add(user.UserName);
                }
            }
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRole(EditRoleModel model)
        {
            Console.WriteLine("POST METHOD HIT");

            if (ModelState.IsValid)
            {
                var role = await rolemanager.FindByIdAsync(model.id);

                if (role == null)
                {
                    ViewBag.msg = "Role not found";
                    return View(model);
                }

                role.Name = model.RoleName;

                var result = await rolemanager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    ViewBag.msg = "Role updated successfully";
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            model.User = new List<string>();

            var existingRole = await rolemanager.FindByIdAsync(model.id);

            if (existingRole != null)
            {
                foreach (var user in userManager.Users.ToList())
                {
                    if (await userManager.IsInRoleAsync(user, existingRole.Name))
                    {
                        model.User.Add(user.UserName);
                    }
                }
            }

            return View(model);
        }

        public async Task<IActionResult> EditUserInRole(string roleid)
        {
            ViewBag.RoleId = roleid;
            var role = await rolemanager.FindByIdAsync(roleid);
            ViewBag.RoleName = role.Name;
            var model = new List<UserRoleViewModel>();
            foreach(var user in userManager.Users.ToList())
             {
                var umodel = new UserRoleViewModel()
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                };
                if(await userManager.IsInRoleAsync(user,role.Name))
                {
                    umodel.IsSelected = true;
                }
                else
                {
                    umodel.IsSelected = false;
                }
                model.Add(umodel);

            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUserInRole(List<UserRoleViewModel> umodel,string roleid)
        {
            var role = await rolemanager.FindByIdAsync(roleid);
            for(int i=0;i<umodel.Count;i++)
            {
                var user = await userManager.FindByIdAsync(umodel[i].UserId);
                IdentityResult? result;
                if (umodel[i].IsSelected && !( await userManager.IsInRoleAsync(user,role.Name)))
                    {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!umodel[i].IsSelected && (await userManager.IsInRoleAsync(user,role.Name)))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if(result.Succeeded)
                {
                    if(i<(umodel.Count-1))
                    {
                        continue;
                    }
                    else
                    {
                        return RedirectToAction("EditRole", new {roleid=roleid});
                    }
                }


            }
            return View();

        }

        
             

               
               




    }
}
