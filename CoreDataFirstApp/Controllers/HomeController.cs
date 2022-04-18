using CoreDataFirstApp.DB_context;
using CoreDataFirstApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreDataFirstApp.Controllers
{
    public class HomeController : Controller
    {
        public readonly Db_Class _Db;
        public HomeController(Db_Class db)
        {
            _Db = db;
        }
        [HttpGet]
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(userlogin clobj)
        {
            var res = _Db.userlogins.Where(a => a.username == clobj.username).FirstOrDefault();

            //var res = DbNew.TblUserInfos.FromSqlRaw<TblUserInfo>("UserSelect").t

            if (res == null)
            {

                TempData["Invalid"] = "Email is not found";
            }

            else
            {
                if (res.username == clobj.username && res.password == clobj.password)
                {

                    var claims = new[] { new Claim(ClaimTypes.Name, res.username),
                                        new Claim(ClaimTypes.Email, res.password) };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true
                    };
                    HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity),
                    authProperties);

                    HttpContext.Session.SetString("Sess", res.username);
                    ViewBag.session = HttpContext.Session.GetString("Sess");


                    return RedirectToAction("IndexDashBoard");

                }

                else
                {

                    ViewBag.Inv = "Wrong Email Id or password";

                    return View();
                }


            }


            return View("login");
        }

        [Authorize]
    public IActionResult logout()
        {
            HttpContext.SignOutAsync(
              CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("login");
        }
        [Authorize]
        public IActionResult IndexDashBoard()
        {
            return View();
        }

    [HttpGet]
        [Authorize]
        public IActionResult AddEmployee()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddEmployee(EmpModel objemp)
    {
        //  Db_Class objDb = new Db_Class();

        EmpModel objtbl = new EmpModel();

        objtbl.Sid = objemp.Sid;
        objtbl.Sname = objemp.Sname;
        objtbl.Smail = objemp.Smail;
        objtbl.Smob = objemp.Smob;
        objtbl.City = objemp.City;

        if (objemp.Sid == 0)
        {
            _Db.EmpModels.Add(objtbl);
            _Db.SaveChanges();
        }
        else
        {
            _Db.Entry(objtbl).State = EntityState.Modified;
            _Db.SaveChanges();
        }
        return RedirectToAction("Index");

    }
        [Authorize]

        public IActionResult Delete(int Sid)
    {
        // Db_Class objDb = new Db_Class();
        var resDeleteItem = _Db.EmpModels.Where(m => m.Sid == Sid).First();
        _Db.EmpModels.Remove(resDeleteItem);
        _Db.SaveChanges();
        return RedirectToAction("Index");

    }
        [Authorize]

        public IActionResult Edit(int Sid)
    {
        // Db_Class objDb = new Db_Class();
        var reseditItem = _Db.EmpModels.Where(m => m.Sid == Sid).First();
        EmpModel emp = new EmpModel();

        emp.Sid = reseditItem.Sid;
        emp.Sname = reseditItem.Sname;
        emp.Smail = reseditItem.Smail;
        emp.Smob = reseditItem.Smob;
        emp.City = reseditItem.City;

        //  return View();
        return View("AddEmployee", emp);
    }

        [Authorize]

        public IActionResult Index()
    {
        //HttpContext.Session.SetString("", "");
        List<EmpModel> emplist = new List<EmpModel>();
        // Db_Class objDb = new Db_Class();

        var res = _Db.EmpModels.ToList();
        foreach (var item in res)
        {
            emplist.Add(new EmpModel
            {
                Sid = item.Sid,
                Sname = item.Sname,
                Smail = item.Smail,
                Smob = item.Smob,
                City = item.City
            });

        }

        return View(emplist);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
}
