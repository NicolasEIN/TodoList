using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.IRepository;
using TodoList.Models;

namespace TodoList.Repository
{
    public class UserRepository : IRepository<UserModel>
    {
        private readonly TaskContext _taskContext;

        public UserRepository(TaskContext taskContext)
        {
            _taskContext = taskContext;
        }
        public async Task<UserModel> Delete(int id)
        {
            UserModel userId = await GetByIdAsync(id);
            if (userId == null)
            {
                throw new Exception("O Usuário não pode ser encontrado");
            }
            _taskContext.users.Remove(userId);
            await _taskContext.SaveChangesAsync();

            return userId;
        }

        public async Task<List<UserModel>> GetAllAsync()
        {
            return await _taskContext.users.ToListAsync();
        }

        public async Task<UserModel> GetByIdAsync(int id)
        {
            UserModel _name = await _taskContext.users.FirstOrDefaultAsync(x => x.Id == id);
            if (_name == null)
            {
                throw new Exception($"O Usuário de nome: {id} não pode ser encontrado");
            }

            return _name;
        }

        public async Task<UserModel> Insert(UserModel entity)
        {
            await _taskContext.users.AddAsync(entity);
            await _taskContext.SaveChangesAsync();
            return entity;
        }


        public async Task<UserModel> Update(UserModel entity, int id)
        {
            UserModel userId = await GetByIdAsync(id);
            if (userId == null)
            {
                throw new Exception("O Usuário não pode ser encontrado");
            }
            userId.Name = entity.Name;
            userId.Email = entity.Email;

            _taskContext.users.Update(userId);
            await _taskContext.SaveChangesAsync();

            return userId;
        }
    }
}
