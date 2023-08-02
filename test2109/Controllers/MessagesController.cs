using AutoMapper;
using BusinessAccessLayer.IRepositories;
using BusinessAccessLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using test2109.Models.Discussion;

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
        [Authorize("agentpolicy")]
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

        [Authorize("agentpolicy")]
        [HttpPost]
        public IActionResult AddMessage(Message message)
        {
            try
            {
                if(message == null)
                {
                    throw new ArgumentNullException("Objet model est a null");
                }
                if(message.Text == "")
                {
                    throw new InvalidOperationException("Argument text du model message est vide");
                }
                else
                {
                    var detail = _mapper.Map<BusinessAccessLayer.Models.Discussion.Messages>(message);
                    return Ok(_messagesService.AddMessage(detail));
                }
            }
            catch (Exception ex)
            {
                DateTime dateTime = DateTime.Now;
                return BadRequest(ex.Message);
            }
        }

    }
}
