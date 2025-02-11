using Microsoft.AspNetCore.Mvc;
using Net_Classe.Models;
using System.Collections.Generic;
using System.Linq;

namespace Net_Classe.Controllers
{
    public class MovieController : Controller
    {
        private static List<Movie> movies = new List<Movie>
        {
            new Movie { Id = 1, Name = "Inception" },
            new Movie { Id = 2, Name = "The Dark Knight" },
            new Movie { Id = 3, Name = "Interstellar" }
        };

        private static List<Customer> customers = new List<Customer>
        {
            new Customer { Id = 1, Name = "Mohamed" },
            new Customer { Id = 2, Name = "Abdou" },
            new Customer { Id = 3, Name = "Wael" },
            new Customer { Id = 4, Name = "Mazen" },
            new Customer { Id = 5, Name = "Ahmed" },
            new Customer { Id = 6, Name = "Sliman" }
        };

        public IActionResult MovieClient()
        {
            var movie = new Movie { Id = 1, Name = "Inception" };

            var viewModel = new MovieCustomerViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            var movie = movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound(); 
            }

            var viewModel = new MovieCustomerViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                var existingMovie = movies.FirstOrDefault(m => m.Id == movie.Id);
                if (existingMovie != null)
                {
                    existingMovie.Name = movie.Name; 
                }

                return RedirectToAction("Index"); 
            }

            return View(movie);
        }

       
      
    }
}
