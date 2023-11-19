using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bankingMvcTestApp.Models;
using System.Configuration;
using Npgsql;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;

namespace bankingMvcTestApp.Controllers
{
    public class LoginController : Controller
    {

         // requires using Microsoft.Extensions.Configuration;
         private readonly IConfiguration Configuration;

         public LoginController(IConfiguration configuration) {
            Configuration = configuration;
         }


        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginClass lc)
        {

            //string strConnString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            string strConnString = Configuration["myconnection"];
            NpgsqlConnection conn = new NpgsqlConnection(strConnString);
            NpgsqlDataReader dr;
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from test.public.userlogin where accountnumber='" + lc.accountnumber + "' and accountpassword='" + lc.accountpassword + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                //HttpContext.Current.Session["accountnumber"] = lc.accountnumber.ToString();
                HttpContext.Session.SetString("accountnumber",lc.accountnumber.ToString());
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                ViewData["message"] = "User login data verification failed!";
            }
            conn.Close();
            return View();
        }
    }
}