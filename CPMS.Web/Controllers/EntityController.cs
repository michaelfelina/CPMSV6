using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CPMS.BL;
using CPMS.Rep;

namespace CPMS.Web.Controllers
{
    public class EntityController : Controller
    {
        private readonly EntityRep entityRep = new EntityRep();
        // GET: Entity
        public ActionResult Index()
        {
            List<Entity> entities;
            var result = entityRep.GetAll(out entities);
            return View(entities);
        }

        // GET: Entity/Details/5
        public ActionResult Details(int id)
        {
            Entity entity;
            var result = entityRep.GetInfo_ByID(id, out entity);
            return View(entity);
        }

        // GET: Entity/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Entity/Create
        [HttpPost]
        public ActionResult Create(Entity entity)
        {
            try
            {
                // TODO: Add insert logic here
                entity.IDNo = -1;
                var result = entityRep.Save(entity);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Entity/Edit/5
        public ActionResult Edit(int id)
        {
            Entity entity;
            var result = entityRep.GetInfo_ByID(id, out entity);
            return View(entity);
        }

        // POST: Entity/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Entity entity)
        {
            try
            {
                entity.IDNo = id;
                // TODO: Add update logic here
                var result = entityRep.Save(entity);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Entity/Delete/5
        public ActionResult Delete(int id)
        {
            Entity entity;
            var result = entityRep.GetInfo_ByID(id, out entity);
            return View(entity);
        }

        // POST: Entity/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Entity entity)
        {
            try
            {
                // TODO: Add delete logic here
                var result = entityRep.DeleteInfoByIDNo(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
