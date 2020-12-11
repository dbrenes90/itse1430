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
            var characters = _database.GetAll();

            var model = characters.Select(x => new CharacterModel(x))
                                    .OrderBy(x => x.Name);
            return View("List", model);
        }

        // GET: Edit/{id}
        public ActionResult Details ( int id )
        {
            var character = _database.Get(id);
            if (character == null)
                return HttpNotFound(); //404

            return View(new CharacterModel(character));
        }

        //GET: Create/{id}
        public ActionResult Create () => View(new CharacterModel());

        // POST: Create 
        [HttpPost]
        public ActionResult Create ( CharacterModel model )
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    var character = _database.Add(model.ToCharacter());
                                       
                    return RedirectToAction(nameof(Details), new { id = character.Id });
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
            var character = _database.Get(id);
            if (character == null)
                return HttpNotFound(); //404


            return View(new CharacterModel(character));
        }

        // POST: Edit
        [HttpPost]
        public ActionResult Edit ( CharacterModel model )
        {
            //??Exception handling

            // Always do PRG for modifications
            //   Post, Redirect, Get

            //Check for model validity
            if (ModelState.IsValid)
            {
                try
                {
                    _database.Update(model.Id, model.ToCharacter());

                    //Redirect to details of movie
                    //Using anonymous type 
                    //   new { id = E {, id = E}* }
                    return RedirectToAction(nameof(Details), new { id = model.Id });
                } catch (Exception e)
                {
                    //Never use this - it doesn't work
                    //ModelState.AddModelError("", e);
                    ModelState.AddModelError("", e.Message);
                };
            };

            return View(model);
        }
        // GET: Delete/{id}
        public ActionResult Delete ( int id )
        {
            var character = _database.Get(id);
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
                _database.Delete(model.Id);
               
                return RedirectToAction(nameof(Index));
            } catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            };


            return View(model);
        }

        private readonly static ICharacterDatabase _database = new CharacterCreator.Memory.MemoryCharacterDatabase();
    }
}