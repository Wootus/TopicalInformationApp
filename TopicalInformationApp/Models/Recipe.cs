using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopicalInformationApp.Models
{
	public class Recipe
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double PercentABV { get; set; }
		public string GrainAdditions { get; set; }
		public string HopAdditions { get; set; }
	}
}