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
            var model = movies.Select(x => new MovieModel(x));

            return View("List", model);
           
        }

        // GET: Details
        public ActionResult Details ( int id )
        {
            var movie = _database.Get(id);
            if (movie == null)
                return HttpNotFound(); //404

            return View(new MovieModel(movie));
        }

        // GET: Edit
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
            //?? PRG

            //Check for model validity
            if (ModelState.IsValid)
            {
                _database.Update(model.Id, model.ToMovie());
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