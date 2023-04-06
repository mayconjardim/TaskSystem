﻿using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Models;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly TaskSystemDBContext _dbContext;

        public UserRepository(TaskSystemDBContext taskSystemDBContext)
        {
            _dbContext = taskSystemDBContext;
        }

        public async Task<List<UserModel>> FindAllUsers()
        {
            return await _dbContext.Users.ToListAsync();

        }

        public async Task<UserModel> FindById(int id)
        {
           return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserModel> Create(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();


            return user;
        }

        public async Task<UserModel> Update(UserModel user, int id)
        {

            UserModel userById = await FindById(id);

            if (userById == null)
            {
                throw new Exception($"Usuário id: {id} não foi encontrado!");
            }

            userById.Name = user.Name;
            userById.Email = user.Email;

            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();

            return userById;
        }

        public async Task<bool> Delete(int id)
        {

            UserModel userById = await FindById(id);

            if (userById == null)
            {
                throw new Exception($"Usuário id: {id} não foi encontrado!");
            }

            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();

            return true;

        }

    }
}
