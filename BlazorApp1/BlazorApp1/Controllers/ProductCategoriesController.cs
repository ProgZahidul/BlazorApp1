﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorApp1.Data;
using ProductCat.Models;

namespace BlazorApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly ProductDb _context;

        public ProductCategoriesController(ProductDb context)
        {
            _context = context;
        }

		// GET: api/ProductCategories
		[HttpGet]
		public async Task<ActionResult<IEnumerable<ProductCategory>>> GetProductCategory()
		{
			return await _context.ProductCategory.Include(c => c.Products).ToListAsync();
		}

		// GET: api/ProductCategories/5
		[HttpGet("{id}")]
		public async Task<ActionResult<ProductCategory>> GetProductCategory(int id)
		{
			var productCategory = await _context.ProductCategory.Include(c => c.Products).FirstOrDefaultAsync(c => c.ProductCategoryID == id);

			if (productCategory == null)
			{
				return NotFound();
			}

			return productCategory;
		}

		// PUT: api/ProductCategories/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
        public async Task<IActionResult> PutProductCategory(int id, ProductCategory productCategory)
        {
            if (id != productCategory.ProductCategoryID)
            {
                return BadRequest();
            }

            _context.Entry(productCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProductCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductCategory>> PostProductCategory(ProductCategory productCategory)
        {
            _context.ProductCategory.Add(productCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductCategory", new { id = productCategory.ProductCategoryID }, productCategory);
        }

        // DELETE: api/ProductCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductCategory(int id)
        {
            var productCategory = await _context.ProductCategory.FindAsync(id);
            if (productCategory == null)
            {
                return NotFound();
            }

            _context.ProductCategory.Remove(productCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductCategoryExists(int id)
        {
            return _context.ProductCategory.Any(e => e.ProductCategoryID == id);
        }
    }
}
