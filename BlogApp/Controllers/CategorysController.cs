using BlogApp.Models;
using BlogApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController : ControllerBase
    {
        public readonly ICategoryRepository _categoryRepository;


        public CategorysController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategorysAll()
        {
            return await _categoryRepository.GetAllCategory();
        }

        [HttpGet]
        [Route("GetCategories")]
        public async Task<ActionResult> GetCategories()
        {
            try
            {
                var categories = await _categoryRepository.GetCategories();
                if (categories == null)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception) 
            {
                return BadRequest();
            }
        }



        [HttpPost]
        public async Task<IActionResult> AddPost([FromBody] Category category)
        {
            //check the validation of body
            if (ModelState.IsValid)

            {
                try
                {
                    var Id = await _categoryRepository.AddCategory(category);
                    if (Id > 0)
                    {
                        return Ok(Id);

                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }


            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] Category category)
        {
            //check the validation of body
            if (ModelState.IsValid)

            {
                try
                {
                    await _categoryRepository.UpdateCategory(category);

                    return Ok();

                }
                catch (Exception)
                {
                    return BadRequest();
                }


            }
            return BadRequest();
        }
    }
}
