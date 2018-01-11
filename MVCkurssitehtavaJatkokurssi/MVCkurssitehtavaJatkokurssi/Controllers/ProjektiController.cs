using MVCkurssitehtavaJatkokurssi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCkurssitehtavaJatkokurssi.Controllers
{
    public class ProjektiController : Controller
    {
        public ActionResult Index2()
        {
            AsiakastietokantaEntities entities = new AsiakastietokantaEntities();
            List<Projektit> model = entities.Projektit.ToList();
            entities.Dispose();

            return View(model);
        }
        public ActionResult Index()
        {
            return View();
        }
        
        // GET: Projekti
        public JsonResult GetList()
        {
            AsiakastietokantaEntities entities = new AsiakastietokantaEntities();
            //List<Projektit> model = entities.Projektit.ToList();

            var model = (from p in entities.Projektit
                         select new
                         {
                             ProjektiID = p.ProjektiID,
                             Projektinimi = p.Projektinimi,
                             
                         }).ToList();

            string json = JsonConvert.SerializeObject(model);
            entities.Dispose();

            return Json(json, JsonRequestBehavior.AllowGet);

        }
    }
}