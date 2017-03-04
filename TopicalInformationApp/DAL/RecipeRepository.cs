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

		//Methods
		public IEnumerable<Recipe> SelectAll( )
		{
			return _recipes;
		}

		public Recipe SelectOne(int id)
		{
			Recipe selectedRecipe = _recipes.Where(p => p.Id == id).FirstOrDefault( );

			return selectedRecipe;
		}

		public void Delete(int id)
		{
			throw new NotImplementedException( );
		}

		public void Insert(Recipe recipe)
		{
			throw new NotImplementedException( );
		}



		

		public void Update(Recipe recipe)
		{
			throw new NotImplementedException( );
		}

		public void Dispose( )
		{
			_recipes = null;
		}
	}
}