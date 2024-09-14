using azproductapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace azproductapi.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		[HttpGet]
		[Route("ListProduct")]
		public IActionResult GetAllProduct()
		{
			AzproductDbContext db1 = new AzproductDbContext();
			return Ok(db1.Products.ToList());

		}

		[HttpPost]
		[Route("AddProduct")]
		public IActionResult AddProduct(Product product)
		{
			AzproductDbContext db1 = new AzproductDbContext();
			db1.Add(product);
			db1.SaveChanges();
			return Ok(db1.Products.ToList());

		}
	}
}
