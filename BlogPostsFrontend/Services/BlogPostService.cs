using BlogPostsFrontend.Constants;
using BlogPostsFrontend.Models.BlogPosts;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlogPostsFrontend.Services
{
    public class BlogPostService
    {
        HttpService _httpService;
        public BlogPostService(HttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<BlogPostHttpResult> CreateAsync(BlogPost blogPost)
        {
            var result = await _httpService.PostAsync($"{Endpoints.BlogPosts}", blogPost);

            BlogPostHttpResult blogHttpResult = new BlogPostHttpResult()
            {
                Success = result.Success,
                Message = result.Data,
            };

            if (blogHttpResult.Success)
                blogHttpResult.BlogPost = JsonConvert.DeserializeObject<BlogPost>(result.Data);

            return blogHttpResult;
        }

        public async Task<BlogPostHttpResult> ListAsync()
        {
            var result = await _httpService.GetAsync($"{Endpoints.BlogPosts}/List?Paginate=false");

            BlogPostHttpResult blogHttpResult = new BlogPostHttpResult()
            {
                Success = result.Success,
                Message = result.Data,
            };

            if (blogHttpResult.Success)
                blogHttpResult.BlogPosts = JsonConvert.DeserializeObject<List<BlogPost>>(result.Data);

            return blogHttpResult;
        }

        public async Task<BlogPostHttpResult> ListForUserAsync(int userId)
        {
            var result = await _httpService.GetAsync($"{Endpoints.Users}/{userId}{Endpoints.BlogPosts}/List?Paginate=false");

            BlogPostHttpResult blogHttpResult = new BlogPostHttpResult()
            {
                Success = result.Success,
                Message = result.Data,
            };

            if (blogHttpResult.Success)
                blogHttpResult.BlogPosts = JsonConvert.DeserializeObject<List<BlogPost>>(result.Data);

            return blogHttpResult;
        }

        public async Task<BlogPostHttpResult> ImportBlogPostsAsync(int userId)
        {
            var result = await _httpService.GetAsync($"{Endpoints.Users}/{userId}{Endpoints.BlogPosts}/Import?Paginate=false");

            BlogPostHttpResult blogHttpResult = new BlogPostHttpResult()
            {
                Success = result.Success,
                Message = result.Data,
            };

            if (blogHttpResult.Success)
                blogHttpResult.BlogPosts = JsonConvert.DeserializeObject<List<BlogPost>>(result.Data);

            return blogHttpResult;
        }

        public async Task<BlogPostHttpResult> GetAsync(int blogId)
        {
            var result = await _httpService.GetAsync($"{Endpoints.BlogPosts}/{blogId}");

            BlogPostHttpResult blogHttpResult = new BlogPostHttpResult()
            {
                Success = result.Success,
                Message = result.Data,
            };

            if (blogHttpResult.Success)
                blogHttpResult.BlogPost = JsonConvert.DeserializeObject<BlogPost>(result.Data);

            return blogHttpResult;
        }
    }

    public class BlogPostHttpResult
    {
        public bool Success { get; set; }
        public BlogPost BlogPost { get; set; }
        public List<BlogPost> BlogPosts { get; set; }
        public string Message { get; set; }
    }
}

