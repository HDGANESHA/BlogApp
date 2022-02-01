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
    public class PostsController : ControllerBase
    {
        public readonly IPostRepository _poRepository;


        public PostsController(IPostRepository postRepository)
        {
            _poRepository = postRepository;
        }

        [HttpGet]
        [Route("GetPostsAll")]
        public async Task<ActionResult<IEnumerable<Post>>> GetPostsAll()
        {
            return await _poRepository.GetAllPost();
        }

        [HttpGet]
        [Route("GetAllPosts")]
        public async Task<IActionResult> GetAllPosts()
        {
            try
            {
                var post = await _poRepository.GetAllPost();
                if (post == null)
                {
                    return NotFound();
                }
                return Ok(post);
            }
            catch (Exception)
            {
                return BadRequest();

            }



        }


        [HttpGet]
        [Route("GetPost")]
        public async Task<IActionResult> GetPost(int? postId)
        {
            if (postId == null) 
            {
                return BadRequest();
            }
            try
            {
                var post = await _poRepository.GetPost(postId);
                if (postId == null)
                {
                    return NotFound();
                }
                return Ok(post);
            }
            catch (Exception) 
            {
                return BadRequest();
            }

        }
        
        




        [HttpPost]
        public async Task<IActionResult> AddPost([FromBody] Post post)
        {
            //check the validation of body
            if (ModelState.IsValid)

            {
                try
                {
                    var postId = await _poRepository.AddPost(post);
                    if (postId > 0)
                    {
                        return Ok(postId);

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
        public async Task<IActionResult> UpdatePost([FromBody] Post post)
        {
            //check the validation of body
            if (ModelState.IsValid)

            {
                try
                {
                    await _poRepository.UpdatePost(post);

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
