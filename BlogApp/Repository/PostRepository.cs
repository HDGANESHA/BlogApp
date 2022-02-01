using BlogApp.Models;
using BlogApp.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Repository
{
    public class PostRepository : IPostRepository
    {


        private readonly DemoBlogDBContext _context;

        public PostRepository(DemoBlogDBContext context)
        {
            _context = context;
        }

        public async Task<int> AddPost(Post post)
        {
            if (_context != null)
            {
                await _context.Post.AddAsync(post);
                await _context.SaveChangesAsync();
                return post.PostId;
            }
            return 0;
        }

        public async Task<List<Post>> GetAllPost()
        {
            if (_context != null)
            {
                return await _context.Post.ToListAsync();
            }
            return null;
        }

        public async Task<List<PostViewModel>> GetAllPosts()
        {
            if (_context != null) 
            {
                return await (from p in _context.Post
                              from c in _context.Category
                              where p.CategoryId == c.Id
                              select new PostViewModel
                              {
                                  PostId = p.PostId,
                                  Title = p.Title,
                                  Description = p.Description,
                                  CategoryId = p.CategoryId,
                                  Name = c.Name,
                                  CreatedDate = p.CreatedDate

                              }
                              ).ToListAsync();
            
            }
            return null;
        }

        public async Task<PostViewModel> GetPost(int? postId)
        {
            if (_context != null)
            {
                return await (from p in _context.Post
                              from c in _context.Category
                              where p.PostId == postId
                              select new PostViewModel
                              {
                                  PostId = p.PostId,
                                  Title = p.Title,
                                  Description = p.Description,
                                  CategoryId = p.CategoryId,
                                  Name = c.Name,
                                  CreatedDate = p.CreatedDate

                              }).FirstOrDefaultAsync();

            }
            return null;

        }

        public async Task UpdatePost(Post post)
        {

            if (_context != null)
            {
                _context.Entry(post).State = EntityState.Modified;
                _context.Post.Update(post);

                await _context.SaveChangesAsync();
            }

        }






    }
}
