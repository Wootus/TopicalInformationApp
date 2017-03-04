using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace TopicalInformationApp.Models
{
	public class Recipe
	{
		public int Id { get; set; }
		[StringLength(50) ,Required]
		public string Name { get; set; }
		[Required]
		public string Style { get; set; }
		public double PercentABV { get; set; }
		[Range(0, 100)]
		public int IBU { get; set; }
		public string GrainAdditions { get; set; }
		public string HopAdditions { get; set; }
		public string SampleImagePath { get; set; }
	}
}