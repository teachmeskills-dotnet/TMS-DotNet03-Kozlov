using Microsoft.EntityFrameworkCore;
using ProperNutrition.BLL.Interfaces;
using ProperNutrition.BLL.Models;
using ProperNutrition.Common.Resources;
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

        public async Task CreateAsync(ReadyMealDto readyMealDto)
        {
            if (readyMealDto is null)
            {
                throw new ArgumentNullException(nameof(readyMealDto));
            }

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
            await _repositoryReadyMeal.CreateAsync(readymeal);
            await _repositoryReadyMeal.SaveChangesAsync();
        }

        public async Task<ReadyMealDto> GetReadyMealAsync(int id, string userId)
        {
            var readymeal = await _repositoryReadyMeal
                .GetEntityWithoutTrackingAsync(readymeal =>
                    readymeal.Id == id && readymeal.UserId == userId);

            if (readymeal is null)
            {
                throw new ArgumentNullException(nameof(readymeal));
            }

            var readyMealDto = new ReadyMealDto
            {
                Id = readymeal.Id,
                UserId = readymeal.UserId,
                Name = readymeal.Name,
                ChildReacrion = readymeal.ChildReacrion,
                TeastyMeal = readymeal.TeastyMeal,
                Comment = readymeal.Comment,
                ReadyTime = readymeal.ReadyTime,
                Picture = readymeal.Picture,
            };
            return readyMealDto;
        }

        public async Task<IEnumerable<ReadyMealDto>> GetReadyMealsAsync(string userId)
        {
            var readyMealDtos = new List<ReadyMealDto>();
            var readymeals = await _repositoryReadyMeal
                .GetAll()
                .AsNoTracking()
                .Where(readymeal => readymeal.UserId == userId)
                .ToListAsync();

            if (!readymeals.Any())
            {
                return readyMealDtos;
            }

            foreach (var readymeal in readymeals)
            {
                readyMealDtos.Add(new ReadyMealDto
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
            return readyMealDtos;
        }

        public async Task ChangeReadyMealStatusAsync(string userId, int id)
        {
            var readymeal = await _repositoryReadyMeal
                .GetEntityAsync(readymeal =>
                    readymeal.Id == id && readymeal.UserId == userId);

            if (readymeal is null)
            {
                throw new KeyNotFoundException(ErrorResource.ReadyMealNotFound);
            }

            _repositoryReadyMeal.Update(readymeal);
            await _repositoryReadyMeal.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id, string userId)
        {
            var readymeal = await _repositoryReadyMeal
                .GetEntityAsync(readymeal =>
                    readymeal.Id == id && readymeal.UserId == userId);

            if (readymeal is null)
            {
                throw new KeyNotFoundException(ErrorResource.ReadyMealNotFound);
            }

            _repositoryReadyMeal.Delete(readymeal);
            await _repositoryReadyMeal.SaveChangesAsync();
        }

        public async Task UpdateAsync(ReadyMealDto readyMealDto)
        {
            readyMealDto = readyMealDto ?? throw new ArgumentNullException(nameof(readyMealDto));

            var readymeal = await _repositoryReadyMeal
                .GetEntityAsync(readymeal =>
                    readymeal.Id == readyMealDto.Id && readymeal.UserId == readyMealDto.UserId);

            if (readymeal is null)
            {
                throw new KeyNotFoundException(ErrorResource.IngridientNotFound);
            }

            static bool CheckAndUpdate(ReadyMeal readymeal, ReadyMealDto newReadyMeal)
            {
                var toUpdate = false;

                if (readymeal.Name != newReadyMeal.Name)
                {
                    readymeal.Name = newReadyMeal.Name;
                    toUpdate = true;
                }

                if (readymeal.ChildReacrion != newReadyMeal.ChildReacrion)
                {
                    readymeal.ChildReacrion = newReadyMeal.ChildReacrion;
                    toUpdate = true;
                }

                if (readymeal.TeastyMeal != newReadyMeal.TeastyMeal)
                {
                    readymeal.TeastyMeal = newReadyMeal.TeastyMeal;
                    toUpdate = true;
                }

                if (readymeal.Comment != newReadyMeal.Comment)
                {
                    readymeal.Comment = newReadyMeal.Comment;
                    toUpdate = true;
                }

                if (readymeal.ReadyTime != newReadyMeal.ReadyTime)
                {
                    readymeal.ReadyTime = newReadyMeal.ReadyTime;
                    toUpdate = true;
                }

                return toUpdate;
            }

            if (CheckAndUpdate(readymeal, readyMealDto))
            {
                await _repositoryReadyMeal.SaveChangesAsync();
            }
        }
    }
}