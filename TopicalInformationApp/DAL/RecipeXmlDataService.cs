using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using TopicalInformationApp.Models;

namespace TopicalInformationApp.DAL
{
	public class RecipeXmlDataService : IRecipeDataService, IDisposable
	{
		//Method to read contents of an xml file and convert to recipe object format
		public List<Recipe> Read( )
		{
			//defnition of a model for the xml serializer to use
			Recipes RecipiesModel;

			//Prep a FireStream object
			string xmlFilePath = HttpContext.Current.Application[ "dataFilePath" ].ToString( );
			StreamReader sReader = new StreamReader(xmlFilePath);

			//Prep a XML Deserialization object
			XmlSerializer deserializer = new XmlSerializer(typeof(Recipes));

			//using statement to connect the stream reader and deserializer to read the xml file
			using(sReader)
			{
				//Deserializer gets the dataset into object form
				object xmlObject = deserializer.Deserialize(sReader);

				//A cast to turn the generic object form into a recipe object
				RecipiesModel = (Recipes)xmlObject;
			}

			return RecipiesModel.recipes;
		}

		//Method to write the database to an xml file
		public void Write(List<Recipe> recipies)
		{
			//Declaration and instatiationof a stream writer object that points to correct dataset location
			string xmlFilePath = HttpContext.Current.Application[ "dataFilePath" ].ToString( );
			StreamWriter sWriter = new StreamWriter(xmlFilePath, false);

			//Serializer object to prepare objects for storage
			XmlSerializer serializer = new XmlSerializer(typeof(List<Recipe>), new XmlRootAttribute("Recipes"));

			//using statement that uses the serializer and sWriter object to create and write the new xml database
			using(sWriter)
			{
				serializer.Serialize(sWriter, recipies);
			}
		}

		public void Dispose( )
		{

		}
	}
}