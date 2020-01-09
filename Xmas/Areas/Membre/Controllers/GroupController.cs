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
    public class GroupController : Controller
    {
        // GET: Membre/Group
        public ActionResult Index()
        {
            if (!SessionUtils.IsConnected)
            {
                return RedirectToAction("Login", new { controller = "Home", area = "" });
            }

            GroupeRepository Gr = new GroupeRepository(ConfigurationManager.ConnectionStrings["CnstrDev"].ConnectionString);
            int id = SessionUtils.ConnectedUser.Id;
            List<GroupeModel> Gmodel = Gr.GetGroupeMembre(id).Select(g => MapToDBModel.GroupeToGroupeModel(g)).ToList(); ;

            return View(Gmodel);
        }
    }
}