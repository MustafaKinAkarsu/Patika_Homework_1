using Microsoft.AspNetCore.Mvc;
using Patika_HW_1.Models;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
	private static readonly List<Product> Products = new();

	[HttpGet("{id}")]
	public IActionResult Get(int id)
	{
		var product = Products.FirstOrDefault(p => p.Id == id);
		if (product == null)
		{
			return NotFound();
		}
		return Ok(product);
	}

	[HttpPost]
	public IActionResult Post([FromBody] Product product)
	{
		Products.Add(product);
		return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
	}

	[HttpPut("{id}")]
	public IActionResult Put(int id, [FromBody] Product updatedProduct)
	{
		var product = Products.FirstOrDefault(p => p.Id == id);
		if (product == null)
		{
			return NotFound();
		}
		product.Name = updatedProduct.Name;
		product.Price = updatedProduct.Price;
		return NoContent();
	}

	[HttpDelete("{id}")]
	public IActionResult Delete(int id)
	{
		var product = Products.FirstOrDefault(p => p.Id == id);
		if (product == null)
		{
			return NotFound();
		}
		Products.Remove(product);
		return NoContent();
	}


	[HttpGet("list")]
	public IActionResult List([FromQuery] string name)
	{
		var products = Products.Where(p => string.IsNullOrEmpty(name) || p.Name.Contains(name)).ToList();
		return Ok(products);
	}
}