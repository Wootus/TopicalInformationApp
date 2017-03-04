using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TopicalInformationApp.Models;

namespace TopicalInformationApp.DAL
{
	public class RecipeRepository : IRecipeRepository, IDisposable
	{
		//internal variable declaration
		private List<Recipe> _recipes;

		//Default constructor
		public RecipeRepository( )
		{
			//When instatiated will create xml dataservice object
			RecipeXmlDataService recipeXMLDataService = new RecipeXmlDataService( );

			//with a using statement the xmldataservice is used to get a list of objects that is stored internaly
			using(recipeXMLDataService)
			{
				_recipes = recipeXMLDataService.Read( ) as List<Recipe>;
			}
		}

		//Method to select all recipes from persistance
		public IEnumerable<Recipe> SelectAll( )
		{
			return _recipes;
		}

		//Method to select one recipe based on ID from persistance
		public Recipe SelectOne(int id)
		{
			Recipe selectedRecipe = _recipes.Where(p => p.Id == id).FirstOrDefault( );

			return selectedRecipe;
		}

		//method to add a recipe to percistance
		public void Insert(Recipe recipe)
		{
			_recipes.Add(recipe);

			Save( );
		}

		public void Update(Recipe recipe)
		{
			//temp var of the original recipe
			var oldRecipe = _recipes.Where(b => b.Id == recipe.Id).FirstOrDefault( );

			if(oldRecipe != null)
			{
				_recipes.Remove(oldRecipe);
				_recipes.Add(recipe);
			}

			Save( );
		}

		//Method to remove a recipe from persistance
		public void Delete(int id)
		{
			//temp var of recipe to be removed
			var recipe = _recipes.Where(b => b.Id == id).FirstOrDefault( );

			if(recipe != null)
			{
				_recipes.Remove(recipe);
			}

			Save( );
		}

		//Method called when saving to persistance
		public void Save( )
		{
			RecipeXmlDataService recipeXmlDataService = new RecipeXmlDataService( );

			using(recipeXmlDataService)
			{
				recipeXmlDataService.Write(_recipes);
			}
		}
		public void Dispose( )
		{
			_recipes = null;
		}
	}
}