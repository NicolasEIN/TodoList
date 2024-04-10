using Microsoft.AspNetCore.Mvc;
using TodoList.IRepository;
using TodoList.Models;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IRepository<TaskModel> _taskRepository;

        public TaskController(IRepository<TaskModel> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> GetAllTasks()
        {
            List<TaskModel> tasks = await _taskRepository.GetAllAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> GetId(int id)
        {
            TaskModel taskid = await _taskRepository.GetByIdAsync(id);
            return Ok(taskid);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> AddTask([FromBody] TaskModel taskinsert)
        {
            TaskModel tasks = await _taskRepository.Insert(taskinsert);
            return Ok(tasks);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TaskModel>> AlterTask([FromBody] TaskModel taskAlteration, int id)
        {
            taskAlteration.Id = id; 
            TaskModel tasks = await _taskRepository.Update(taskAlteration, id);
            return Ok(tasks);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskModel>> DeleteTask(int id)
        {
            TaskModel tasks = await _taskRepository.Delete(id);
            return Ok(tasks);
        }
    }
}
