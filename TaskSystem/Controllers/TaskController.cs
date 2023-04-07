using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystem.Models;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {

        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository TaskRepository)
        {
            _taskRepository = TaskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> FindAllTasks()
        {
            List<TaskModel> Tasks = await _taskRepository.FindAllTasks();
            return Ok(Tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> FindById(int id)
        {
            TaskModel Task = await _taskRepository.FindById(id);
            return Ok(Task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> Create([FromBody] TaskModel TaskModel)
        {
            TaskModel Task = await _taskRepository.Create(TaskModel);
            return Ok(Task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskModel>> Update([FromBody] TaskModel TaskModel, int id)
        {
            TaskModel.Id = id;
            TaskModel Task = await _taskRepository.Update(TaskModel, id);
            return Ok(Task);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskModel>> Delete(int id)
        {
            bool deleted = await _taskRepository.Delete(id);
            return Ok(deleted);
        }

    }
}
