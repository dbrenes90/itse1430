using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MovieLibrary.WebHost.Models;

namespace MovieLibrary.WebHost.Controllers
{
    public class MovieController : Controller
    {
        public MovieController()
        {
            //Gets the MovieDatabase connection string from the config file
            var connString = ConfigurationManager.ConnectionStrings["MovieDatabase"].ConnectionString;

            _database = new MovieLibrary.Sql.SqlMovieDatabase(connString);
        }

        //Show all movies
        // GET: Movie
        public ActionResult Index()
        {
            var movies = _database.GetAll();

            //IEnumerable<MovieModel> model = 
            var model = movies.Select(x => new MovieModel(x))
                              .OrderBy(x => x.Name);

            return View("List", model);
           
        }

        // GET: Details/{id}
        public ActionResult Details ( int id )
        {
            var movie = _database.Get(id);
            if (movie == null)
                return HttpNotFound(); //404

            return View(new MovieModel(movie));
        }

        // GET: Edit/{id}
        public ActionResult Edit ( int id )
        {
            var movie = _database.Get(id);
            if (movie == null)
                return HttpNotFound(); //404

           
            return View(new MovieModel(movie));
        }

        // POST: Edit
        [HttpPost]
        public ActionResult Edit ( MovieModel model )
        {
            //??Exception handling

            // Always do PRG for modifications
            //   Post, Redirect, Get

              //Check for model validity
            if (ModelState.IsValid)
                {
                try
                {
                    _database.Update(model.Id, model.ToMovie());

                    //Redirect to details of movie
                    //Using anonymous type 
                    //   new { id = E {, id = E}* }
                    return RedirectToAction(nameof(Details), new { id = model.Id });
                }catch(Exception e)
                {
                    //Never use this - it doesn't work
                    //ModelState.AddModelError("", e);
                    ModelState.AddModelError("", e.Message);
                };
            };
            
            return View(model);
        }

        // GET: Create/{id}
        public ActionResult Create ( ) => View(new MovieModel());        

        // POST: Create 
        [HttpPost]
        public ActionResult Create ( MovieModel model )
        {
            
            // Always do PRG for modifications
            //   Post, Redirect, Get

            //Check for model validity
            if (ModelState.IsValid)
            {
                try
                {
                    var movie = _database.Add(model.ToMovie());

                    //Redirect to details of movie
                    //Using anonymous type 
                    //   new { id = E {, id = E}* }
                    return RedirectToAction(nameof(Details), new { id = movie.Id });
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
            var movie = _database.Get(id);
            if (movie == null)
                return HttpNotFound(); //404


            return View(new MovieModel(movie));
        }

        // POST: Delete
        [HttpPost]
        public ActionResult Delete ( MovieModel model )
        {            
            // Always do PRG for modifications
            //   Post, Redirect, Get

            //Check for model validity
           
                try
                {
                    _database.Delete(model.Id);

                    //Redirect to list
                    return RedirectToAction(nameof(Index));
                } catch (Exception e)
                {
                    //Never use this - it doesn't work
                    //ModelState.AddModelError("", e);
                    ModelState.AddModelError("", e.Message);
                };
            

            return View(model);
        }
        public ActionResult Test ( string name )
        {
            var result = $"Hello {name} it is currently {DateTime.Now}";

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        
        private readonly IMovieDatabase _database;
    }
}