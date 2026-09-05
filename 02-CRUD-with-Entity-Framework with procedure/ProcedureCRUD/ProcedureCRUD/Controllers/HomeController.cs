using System.Diagnostics;
using Azure;
using System.Net;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcedureCRUD.Models;

namespace ProcedureCRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ProcedureDbContext db=new ProcedureDbContext();
        private string Message=string.Empty;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //show all records
        public IActionResult Index()
        {
            List<ClientMaster> lst=db.ClientMasters.FromSqlRaw($"sp_Client_crud @operation=1").ToList();
            return View(lst);
        }

        // add new record

        public IActionResult AddClient()
        {
            return View();
        }

        [HttpPost]

        public IActionResult AddClient(ClientMaster cm)
        {
            string Sqldt = DateTime.Now.ToString("MM-yyyy-dd HH:mm:ss");
            try
            {
                db.Database.ExecuteSqlRaw($"sp_client_crud @name='{cm.Name}',@gender='{cm.Gender}',@age='{cm.Age}',@mobno='{cm.ContactNo}',@address='{cm.Address}',@addedon='{Sqldt}',@operation=3");
                Message = "Client Record saved Successfully";
            }
            catch (Exception ex)
            {
                Message = "Sorry Unable to add client Record.";
            }
            ViewBag.Result = Message;
            return View();
        }

        //Edit Client
        [HttpGet]

        public IActionResult EditRecord(int cid)
        {
            ClientMaster cm = db.ClientMasters.FromSqlRaw($"sp_client_crud @clientid='{cid}', @operation=2").ToList().First();
            return View(cm);
        }

        [HttpPost]
        public IActionResult EditRecord(ClientMaster cm)
        {
           
            try
            {
                db.Database.ExecuteSqlRaw($"sp_client_crud @name = '{cm.Name}', @gender = '{cm.Gender}', @age = '{cm.Age}', @mobno = '{cm.ContactNo}', @address = '{cm.Address}',@clientid='{cm.ClientId}', @operation = 5");
                Message = "Client Record Updated Successfully";
            }
            catch(Exception ex)
            {
                Message = "Sorry! Unable to update record";
            }
            TempData["msg"] = Message;
            return RedirectToAction("Index");
        }

        public IActionResult DeleteClient(int cid)
        {
            try
            {
                db.Database.ExecuteSqlRaw($"sp_client_crud @clientid='{cid}' ,@operation=4");
                Message = "Client record Deleted Successfully.";

            }
            catch (Exception ex)
            {
                Message = "Unable to Delete  Record.";
            }
            TempData["res"]=Message;
            return RedirectToAction("Index");
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
