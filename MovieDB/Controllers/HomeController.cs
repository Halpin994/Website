using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MovieDB.Models;

namespace MovieDB.Controllers
{
    public class HomeController : Controller
    {
        private MoviesDBEntities _db = new MoviesDBEntities();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        // GET: /Home/Details/5 

        public ActionResult Details(int id)

        {

            return View();

        }

        //public ActionResult MovieDB()
        //{

        //    return View(_db.Movies.ToList());

        //}

        public ActionResult Projects()
        {

            return View();

        }

        //

        // GET: /Home/Create 

        public ActionResult Create()

        {

            return View();

        }  

        //

        // POST: /Home/Create 

        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult Create([Bind(Exclude="Id")] Movie movieToCreate)

        {

                 if (!ModelState.IsValid)
                    return View(); 

                //_db.AddToMovieSet(movieToCreate);
                _db.Movies.Add(movieToCreate);
                _db.SaveChanges(); 

                return RedirectToAction("Index");

        } 

        //

        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {

            var movieToEdit = (from m in _db.Movies

                               where m.Id == id

                               select m).First();

            return View(movieToEdit);

        }

        //

        // POST: /Home/Edit/5 

        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult Edit(Movie movieToEdit)
        {

            var originalMovie = (from m in _db.Movies

                                 where m.Id == movieToEdit.Id

                                 select m).First();

            if (!ModelState.IsValid)

                return View(originalMovie);

                _db.Entry(originalMovie).CurrentValues.SetValues(movieToEdit);
                _db.SaveChanges();

                return RedirectToAction("Index");

        }

        public ActionResult Delete(int id)
        {
            var movieToDelete = _db.Movies.First(movie => movie.Id == id);
     
            //var movieToDelete = (from m in _db.Movies

            //                   where m.Id == id

            //                   select m).First();

            return View(movieToDelete);

        }

        //

        // POST: /Home/Edit/5 

        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult Delete(Movie movieToDelete)
        {

            var originalMovie = (from m in _db.Movies

                                 where m.Id == movieToDelete.Id

                                 select m).First();

            if (!ModelState.IsValid)
                return View(originalMovie);

            _db.Movies.Remove(originalMovie);
            _db.SaveChanges();

            return RedirectToAction("Index");

        } 

    }
}