using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TopicalInformationApp.DAL;
using TopicalInformationApp.Models;

namespace TopicalInformationApp.Controllers
{
    public class RecipeUserController : Controller
    {
        [HttpGet]
        public ActionResult Index(string sort)
        {
			//repository instatiation
			RecipeRepository recipeRepository = new RecipeRepository( );
			//temp recipe list object
			IEnumerable<Recipe> recipes;


			//Using the repository a list if recipe objects is gotten
			using(recipeRepository)
			{
				recipes = recipeRepository.SelectAll( ) as IList<Recipe>;
			}

			//creates a list of beer styles to send to the view
			ViewBag.Styles = ListOfStyles( );

			//sort by name unless otherwise specified
			switch(sort)
			{
				case "Name":
					recipes = recipes.OrderBy(recipe => recipe.Name);
					break;
				case "IBU":
					recipes = recipes.OrderBy(recipe => recipe.IBU);
					break;
				case "Style":
					recipes = recipes.OrderBy(recipe => recipe.Style);
					break;
				default:
					recipes = recipes.OrderBy(recipe => recipe.Name);
					break;
			}

            return View(recipes);
        }

		[HttpPost]
		public ActionResult Index(string searchCriteria, string styleFilter)
		{
			//repository instatiation
			RecipeRepository recipeRepository = new RecipeRepository( );
			//temp recipe list object
			IEnumerable<Recipe> recipes;


			//Using the repository a list if recipe objects is gotten
			using(recipeRepository)
			{
				recipes = recipeRepository.SelectAll( ) as IList<Recipe>;
			}

			//creates a list of beer styles to send to the view
			ViewBag.Styles = ListOfStyles( );

			//If a search of grain additions is posted
			if(searchCriteria != null)
			{
				recipes = recipes.Where(recipe => recipe.Name.ToUpper( ).Contains(searchCriteria.ToUpper( )));
			}

			//if the style filter is selected
			if(styleFilter != "" || styleFilter == null)
			{
				recipes = recipes.Where(recipe => recipe.Style == styleFilter);
			}

			return View(recipes);
		}

		//Method to get all unique beer types
		[NonAction]
		private IEnumerable<string> ListOfStyles( )
		{
			//repository instatiation
			RecipeRepository recipeRepository = new RecipeRepository( );
			//temp recipe list object
			IEnumerable<Recipe> recipes;


			//Using the repository a list if recipe objects is gotten
			using(recipeRepository)
			{
				recipes = recipeRepository.SelectAll( ) as IList<Recipe>;
			}

			//gets a distinct list of beer styles in the database
			var styles = recipes.Select(recipe => recipe.Style).Distinct( ).OrderBy(x => x);

			return styles;
		}

		public ActionResult Details(int id)
		{
			//repository instatiation
			RecipeRepository recipeRepository = new RecipeRepository( );
			//temp recipe
			Recipe recipe;


			//Using the repository a list if recipe objects is gotten
			using(recipeRepository)
			{
				recipe = recipeRepository.SelectOne(id) as Recipe;
			}

			return View(recipe);
		}


    }
}