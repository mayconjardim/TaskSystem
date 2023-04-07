using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Models;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem.Repositories
{
    public class TaskRepository : ITaskRepository
    {

        private readonly TaskSystemDBContext _dbContext;

        public TaskRepository(TaskSystemDBContext taskSystemDBContext)
        {
            _dbContext = taskSystemDBContext;
        }

        public async Task<List<TaskModel>> FindAllTasks()
        {
            return await _dbContext.Tasks.ToListAsync();

        }

        public async Task<TaskModel> FindById(int id)
        {
           return await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TaskModel> Create(TaskModel task)
        {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();


            return task;
        }

        public async Task<TaskModel> Update(TaskModel task, int id)
        {

            TaskModel taskById = await FindById(id);

            if (taskById == null)
            {
                throw new Exception($"Usuário id: {id} não foi encontrado!");
            }

            taskById.Name = task.Name;
            taskById.Description = task.Description;
            taskById.Status = task.Status;

            _dbContext.Tasks.Update(taskById);
            await _dbContext.SaveChangesAsync();

            return taskById;
        }

        public async Task<bool> Delete(int id)
        {

            TaskModel taskById = await FindById(id);

            if (taskById == null)
            {
                throw new Exception($"Tarefa id: {id} não foi encontrada!");
            }

            _dbContext.Tasks.Remove(taskById);
            await _dbContext.SaveChangesAsync();

            return true;

        }

    }
}
