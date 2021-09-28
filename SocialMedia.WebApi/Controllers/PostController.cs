using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Exceptions;
using SocialMedia.Core.Interfaces.Services;
using SocialMedia.WebApi.Models;

namespace SocialMedia.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IServicePost _servicePost;
        private readonly IMapper _mapper;
        public PostController(IServicePost servicePost, IMapper mapper)
        {
            _servicePost = servicePost;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PostViewModel), StatusCodes.Status200OK)]
        public  ActionResult<IEnumerable<PostViewModel>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<PostViewModel>>( _servicePost.GetPosts()));                      
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(PostViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PostViewModel> Get(int id)
        {            
            var postViewModel = _mapper.Map<PostViewModel>(_servicePost.GetPost(id));            

            if(postViewModel == null) return NotFound();            
            
            return Ok(postViewModel);
        }

        [HttpGet("{id:int}/Comments")]
        [ProducesResponseType(typeof(CommentViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<CommentViewModel>> GetComments(int id)
        {            
            var commentViewModel = _mapper.Map<IEnumerable<CommentViewModel>>(_servicePost.GetComments(id));            

            if(commentViewModel == null) return NotFound();            
            
            return Ok(commentViewModel);
        }

        [HttpGet("GetPostsByUser/{id:int}")]
        [ProducesResponseType(typeof(PostViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<PostViewModel>> GetByUser(int id)
        {            
            var post = _mapper.Map<IEnumerable<PostViewModel>>(_servicePost.GetPostsByUser(id));            

            if(post == null) return NotFound();            
            
            return Ok(post);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PostViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PostViewModel> Post([FromBody] PostViewModel postViewModel)
        {
            try{
                if(!ModelState.IsValid) return BadRequest();

                var post = _mapper.Map<Post>(postViewModel);

                _servicePost.InsertPost(post);

                return CreatedAtAction("Get", new { id = post.Id }, postViewModel);
            }
            catch(BusinessException ex)
            {
                return BadRequest(new {ErrorMessage = ex.Message});
            }

        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(PostViewModel), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PostViewModel> Put(int id, [FromBody] PostViewModel postViewModel)
        {   
            try
            {
                if(!ModelState.IsValid) return BadRequest();

                if(id != postViewModel.Id) return BadRequest();

                var post = _mapper.Map<Post>(postViewModel);

                _servicePost.UpdatePost(post);

                return NoContent();
            }
            catch(BusinessException ex)
            {
                return BadRequest(new {ErrorMessage = ex.Message});
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(typeof(PostViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PostViewModel> Delete(int id)
        {   
            try
            {
                var postViewModel = _mapper.Map<PostViewModel>(_servicePost.GetPost(id));

                if(postViewModel == null) return NotFound();

                _servicePost.DeletePost(id);
                return Ok(postViewModel);
            }
            catch(BusinessException ex)
            {
                return BadRequest(new {ErrorMessage = ex.Message});
            }

            
        }
    }
}