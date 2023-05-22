using AutoMapper;
using BusinessAccessLayer.IRepositories;
using BusinessAccessLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace test2109.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IMessagesService _messagesService;

        public MessagesController(IMapper mapper, IMessagesService messagesService)
        {
            _mapper = mapper;
            _messagesService = messagesService;
        }

        [HttpGet("{id}")]
        public IActionResult GetMessages(int id)
        {
            try
            {
                return Ok(_messagesService.GetMessages(id));
            }
            catch (Exception ex)
            {
                DateTime dateTime = DateTime.Now;
                return BadRequest(ex.Message);
            }
            
        }

    }
}
