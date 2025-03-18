using dataEntrySampleProj.Models;
using Microsoft.AspNetCore.Mvc;

namespace dataEntrySampleProj.Controllers
{
	public class TrackingController : Controller
	{
		private readonly AppDbContext _context;

		public TrackingController(AppDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult dataEntry()
		{
			return View(); // This will render the dataEntry.cshtml view
		}


		[HttpPost]
		public JsonResult SaveTrackingNumber(string trackingNumber)
		{
			if (!string.IsNullOrEmpty(trackingNumber))
			{
				// Check if the tracking number exists in the TrackingNumbers table
				var existsInList = _context.TrackingNumbers.Any(t => t.TNumber == trackingNumber);

				if (!existsInList)
				{
					return Json(new { status = "notFound", message = "Tracking number does not exist in the predefined list." });
				}

				// If it exists, save it to the TrackingNumbers table
				var trackingData = new DataEntry
				{
					Number = trackingNumber,
					SubmittedAt = DateTime.Now
				};
				_context.DataEntries.Add(trackingData);
				_context.SaveChanges();

				return Json(new { status = "success", message = "Tracking number saved successfully." });
			}

			return Json(new { status = "error", message = "Invalid tracking number." });
		}



		[HttpGet]
		public JsonResult GetTrackingNumbers()
		{
			var trackingNumbers = _context.DataEntries
				.OrderByDescending(t => t.SubmittedAt)
				.ToList();
			return Json(trackingNumbers);
		}
	}

}
