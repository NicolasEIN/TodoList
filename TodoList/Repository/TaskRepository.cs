using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.IRepository;
using TodoList.Models;

namespace TodoList.Repository
{
    public class TaskRepository : IRepository<TaskModel>
    {
        private readonly TaskContext _taskContext;

        public TaskRepository(TaskContext taskContext)
        {
            _taskContext = taskContext;
        }
        public async Task<TaskModel> Delete(int id)
        {
            TaskModel taskId = await GetByIdAsync(id);
            if (taskId == null)
            {
                throw new Exception("O Usuário não pode ser encontrado");
            }
            _taskContext.tasks.Remove(taskId);
            await _taskContext.SaveChangesAsync();

            return taskId;
        }

        public async Task<List<TaskModel>> GetAllAsync()
        {
            return await _taskContext.tasks.Include(x=> x.User).ToListAsync();
        }

        public async Task<TaskModel> GetByIdAsync(int id)
        {
            TaskModel _name = await _taskContext.tasks.Include(x=> x.User).FirstOrDefaultAsync(x => x.Id == id);
            if (_name == null)
            {
                throw new Exception($"O Usuário de nome: {id} não pode ser encontrado");
            }

            return _name;
        }

        public async Task<TaskModel> Insert(TaskModel entity)
        {
            await _taskContext.tasks.AddAsync(entity);
            await _taskContext.SaveChangesAsync();
            return entity;
        }


        public async Task<TaskModel> Update(TaskModel entity, int id)
        {
            TaskModel taskId = await GetByIdAsync(id);
            if (taskId == null)
            {
                throw new Exception("A tarefa não pode ser encontrada");
            }
            taskId.Name = entity.Name;
            taskId.Description = entity.Description;
            taskId.Status = entity.Status;
            taskId.UserId = entity.UserId;

            _taskContext.tasks.Update(taskId);
            await _taskContext.SaveChangesAsync();

            return taskId;
        }
    }
}
