using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xmas.Areas.Membre.Models;
using Xmas.DAL.Repositories;
using Xmas.Tools;
using Xmas.Tools.Mappers;

namespace Xmas.Areas.Membre.Controllers
{
    public class CadeauController : Controller
    {
        // GET: Membre/Cadeau
        public ActionResult Index()
        {

            if (!SessionUtils.IsConnected)
            {
                return RedirectToAction("Login", new { controller = "Home", area = "" });
            }

            CadeauRepository Cd = new CadeauRepository(ConfigurationManager.ConnectionStrings["CnstrDev"].ConnectionString);
            int id = SessionUtils.ConnectedUser.Id;
            List<CadeauModel> Cmodel = Cd.GetGiftsMember(id).Select(c => MapToDBModel.CadeauToCadeauModel(c)).ToList(); 

            return View(Cmodel);
      
        }
    }
}