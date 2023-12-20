using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application;
using AutoMapper;
using Application.Commands;
using WebApi.Models;
using System.Threading.Tasks;
namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class FragmentController : BaseController
    {
        private readonly IMapper _mapper;
        public FragmentController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<GetFragmentsListVm>> GetAll()
        {
            var query = new GetFragmentByUserIdListQuery()
            {
                UserId = User_Id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FragmentDetailsVm>> Get(Guid id)
        {
            var query = new GetFragmentDetailsQuery()
            {
                Id = id,
                User_Id = User_Id
            };
            var vm = Mediator.Send(query);
            return Ok(vm);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateFragmentDto createFragmentDto)
        {
            var command = _mapper.Map<CreateFragmentCommand>(createFragmentDto);
            command.User_Id = User_Id;
            var FragmentId = await Mediator.Send(command);
            return Ok(FragmentId);
        }
        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateFragmentDto updateFragmentDto)
        {
            var command = _mapper.Map<UpdateFragmentCommand>(updateFragmentDto);
            command.User_Id = User_Id;
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var command = new DeleteFragmentCommand()
            {
                Id = id,
                User_Id = User_Id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }

}
