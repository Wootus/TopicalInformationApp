using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace TopicalInformationApp.Models
{
	public class Recipe
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Style { get; set; }
		public double PercentABV { get; set; }
		public int IBU { get; set; }
		public string GrainAdditions { get; set; }
		public string HopAdditions { get; set; }
		public string SampleImagePath { get; set; }
	}
}