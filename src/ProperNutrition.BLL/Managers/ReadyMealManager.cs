using Microsoft.EntityFrameworkCore;
using ProperNutrition.BLL.Interfaces;
using ProperNutrition.BLL.Models;
using ProperNutrition.Common.Interfaces;
using ProperNutrition.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProperNutrition.BLL.Managers
{
    /// <inheritdoc cref="IReadyMealManager">
    public class ReadyMealManager : IReadyMealManager
    {
        private readonly IRepositoryManager<ReadyMeal> _repositoryReadyMeal;

        public ReadyMealManager(IRepositoryManager<ReadyMeal> repositoryReadyMeal)
        {
            _repositoryReadyMeal = repositoryReadyMeal ?? throw new ArgumentNullException(nameof(repositoryReadyMeal));
        }

        public async Task<ReadyMealDto> GetReadyMealAsync (int id, string userId)
        {
            var readyMeal = await _repositoryReadyMeal
                .GetEntityWithoutTrackingAsync(readyMeal =>
                    readyMeal.Id == id && readyMeal.UserId == userId);

            var readyMealDto = new ReadyMealDto
            {              
                Id = readyMeal.Id,
                Name = readyMeal.Name,
                ChildReacrion = readyMeal.ChildReacrion,
                TeastyMeal = readyMeal.TeastyMeal,
                Comment = readyMeal.Comment,
                ReadyTime = readyMeal.ReadyTime,
                Picture = readyMeal.Picture,
            };
            return readyMealDto;
        }

        public async Task<IEnumerable<ReadyMealDto>> GetReadyMealAsync(string userId)
        {
            var readyMealDto = new List<ReadyMealDto>();
            var readymeals = await _repositoryReadyMeal
                .GetAll()
                .AsNoTracking()
                .Where(readymeal => readymeal.UserId == userId) //Delite becouse all people can use all ingridients
                .ToListAsync();

            if (!readymeals.Any())
            {
                return readyMealDto;
            }

            foreach (var readymeal in readymeals)
            {
                readyMealDto.Add(new ReadyMealDto
                { 
                    Id = readymeal.Id,
                    Name = readymeal.Name,
                    ChildReacrion = readymeal.ChildReacrion,
                    TeastyMeal = readymeal.TeastyMeal,
                    Comment = readymeal.Comment,
                    ReadyTime = readymeal.ReadyTime,
                    Picture = readymeal.Picture,
                });
            }
            return readyMealDto;
        }


        public async Task CreateReadyMealAsync(ReadyMealDto readyMealDto)
        {
            var readymeal = new ReadyMeal
            {
                    Id = readyMealDto.Id,
                    UserId = readyMealDto.UserId,
                    Name = readyMealDto.Name,
                    ChildReacrion = readyMealDto.ChildReacrion,
                    TeastyMeal = readyMealDto.TeastyMeal,
                    Comment = readyMealDto.Comment,
                    ReadyTime = readyMealDto.ReadyTime,
                    Picture = readyMealDto.Picture,
            };
            //Create new model
            await _repositoryReadyMeal.CreateAsync(readymeal);
            //Save new model in DataBase
            await _repositoryReadyMeal.SaveChangesAsync();
        }
    }
}
