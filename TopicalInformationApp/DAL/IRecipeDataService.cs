using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TopicalInformationApp.Models;

namespace TopicalInformationApp.DAL
{
	//Interface for data services to inherit from.  Read and Write only.
	public interface IRecipeDataService
	{
		List<Recipe> Read( );
		void Write(List<Recipe> recipies);
	}
}