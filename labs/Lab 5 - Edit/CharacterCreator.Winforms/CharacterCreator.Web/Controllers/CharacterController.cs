/*
 * Daniel Brenes
 * Lab 5 ITSE 1430
 * Character Creator
 * Character Class
 * 12/11/2020
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CharacterCreator.Web.Models;

namespace CharacterCreator.Web.Controllers
{
    public class CharacterController : Controller
    {
        public CharacterController ()
        {         
                         
        }

        // GET: Character
        public ActionResult Index()
        {
            var characters = s_database.GetAll();

            var model = characters.Select(x => new CharacterModel(x))
                                    .OrderBy(x => x.Name);
            return View("List", model);
        }

        // GET: Edit/{id}
        public ActionResult Details ( int id )
        {
            var character = s_database.Get(id);
            if (character == null)
                return HttpNotFound(); //404

            return View(new CharacterModel(character));
        }

        //GET: Create
        public ActionResult Create () => View(new CharacterModel());

        // POST: Create 
        [HttpPost]
        public ActionResult Create ( CharacterModel model )
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    var character = s_database.Add(model.ToCharacter());

                    return RedirectToAction(nameof(Details), new { id = character.Id }) ;
                } catch (Exception e)
                {                    
                    ModelState.AddModelError("", e.Message);
                };
            };

            return View(model);
        }

        // GET: Edit/{id}
        public ActionResult Edit ( int id )
        {
            var character = s_database.Get(id);
            if (character == null)
                return HttpNotFound(); //404


            return View(new CharacterModel(character));
        }

        // POST: Edit
        [HttpPost]
        public ActionResult Edit ( CharacterModel model )
        {            
            if (ModelState.IsValid)
            {
                try
                {
                    s_database.Update(model.Id, model.ToCharacter());
                    
                    return RedirectToAction(nameof(Details), new { id = model.Id });
                } catch (Exception e)
                {                    
                    ModelState.AddModelError("", e.Message);
                };
            };

            return View(model);
        }
        // GET: Delete/{id}
        public ActionResult Delete ( int id )
        {
            var character = s_database.Get(id);
            if (character == null)
                return HttpNotFound(); //404


            return View(new CharacterModel(character));
        }

        // POST: Delete
        [HttpPost]
        public ActionResult Delete ( CharacterModel model )
        {            
            try
            {
                s_database.Delete(model.Id);
               
                return RedirectToAction(nameof(Index));
            } catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            };

            return View(model);
        }

        private readonly static ICharacterDatabase s_database = new CharacterCreator.Memory.MemoryCharacterDatabase();
    }
}