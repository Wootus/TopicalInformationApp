using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TopicalInformationApp.Models;

namespace TopicalInformationApp.DAL
{
	//interface for recipe repository 
	public interface IRecipeRepository
	{
		IEnumerable<Recipe> SelectAll( );
		Recipe SelectOne(int id);
		void Insert(Recipe recipe);
		void Update(Recipe recipe);
		void Delete(int id);
	}
}