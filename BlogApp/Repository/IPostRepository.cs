using BlogApp.Models;
using BlogApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Repository
{
   public  interface IPostRepository
    {
        Task<List<Post>> GetAllPost();
        Task<int> AddPost(Post post);
        Task UpdatePost(Post post);

        Task<List<PostViewModel>> GetAllPosts();

        Task<PostViewModel> GetPost(int? postId);


    }
}
