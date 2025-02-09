using GameZone.Attributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GameZone.ViewModels
{
	public class CreateGameFormViewModel
	{
		public string Name { get; set; }

		[Display(Name = "Category")]
		public int CategoryId { get; set; }

		public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();

		[Display(Name = "Supported Devices")]
		public List<int> SelectedDevices { get; set; } = default!;

		public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();


		[AllowedExtensions(FileSettings.AllowedExtensions),FileMaxSize(FileSettings.FileMaxSizeInBytes)]
        public IFormFile Cover { get; set; }
		public string Description { get; set; }

	}
}


