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
    /// <inheritdoc cref="IIngridientManager">
    public class IngridientManager : IIngridientManager
    {
        private readonly IRepositoryManager<Ingridient> _repositoryIngridient;

        public IngridientManager(IRepositoryManager<Ingridient> repositoryIngridient)
        {
            _repositoryIngridient = repositoryIngridient ?? throw new ArgumentNullException(nameof(repositoryIngridient));
        }

        public async Task CreateAsync(IngridientDto ingridientDto)
        {
            if (ingridientDto is null)
            {
                throw new ArgumentNullException(nameof(ingridientDto));
            }

            var ingridient = new Ingridient
            {
                Id = ingridientDto.Id,
                UserId = ingridientDto.UserId,
                Name = ingridientDto.Name,
                Category = ingridientDto.Category,
                IsVeggie = ingridientDto.IsVeggie,
                Description = ingridientDto.Description,
                Colories = ingridientDto.Colories,
                IsRecomended = ingridientDto.IsRecomended,
                ReactionType = ingridientDto.ReactionType,
                Date = ingridientDto.Date
            };
            //Create new model
            await _repositoryIngridient.CreateAsync(ingridient);
            //Save new model in DataBase
            await _repositoryIngridient.SaveChangesAsync();
        }

        public async Task<IngridientDto> GetIngridientAsync(int id, string userId)
        {
            var ingridient = await _repositoryIngridient
                .GetEntityWithoutTrackingAsync(ingridient =>
                    ingridient.Id == id && ingridient.UserId == userId);

            if (ingridient is null)
            {
                throw new ArgumentNullException(nameof(ingridient));
            }

            var ingridientDto = new IngridientDto
            {
                Id = ingridient.Id,
                UserId = ingridient.UserId,
                Name = ingridient.Name,
                Category = ingridient.Category,
                IsVeggie = ingridient.IsVeggie,
                Description = ingridient.Description,
                Colories = ingridient.Colories,
                IsRecomended = ingridient.IsRecomended,
                ReactionType = ingridient.ReactionType,
                Date = ingridient.Date
            };
            return ingridientDto;
        }

        public async Task<IEnumerable<IngridientDto>> GetIngridientsAsync(string userId)
        {
            var ingridientDtos = new List<IngridientDto>();
            var ingridients = await _repositoryIngridient
                .GetAll()
                .AsNoTracking()
                .Where(ingridient => ingridient.UserId == userId) //Delite becouse all people can use all ingridients
                .ToListAsync();

            if (!ingridients.Any())
            {
                return ingridientDtos;
            }

            foreach (var ingridient in ingridients)
            {
                ingridientDtos.Add(new IngridientDto
                {
                    Id = ingridient.Id,
                    Name = ingridient.Name,
                    Category = ingridient.Category,
                    IsVeggie = ingridient.IsVeggie,
                    Description = ingridient.Description,
                    Colories = ingridient.Colories,
                    IsRecomended = ingridient.IsRecomended,
                    ReactionType = ingridient.ReactionType,
                    Date = ingridient.Date
                });
            }

            return ingridientDtos;
        }

        public async Task ChangeIngridientStatusAsync(string userId, int id)
        {
            var ingridient = await _repositoryIngridient
                .GetEntityAsync(ingridient =>
                    ingridient.Id == id && ingridient.UserId == userId);

            if (ingridient is null)
            {
                throw new KeyNotFoundException(ErrorResource.IngridientNotFound);
            }

            _repositoryIngridient.Update(ingridient);
            await _repositoryIngridient.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id, string userId)
        {
            var ingridient = await _repositoryIngridient
                .GetEntityAsync(ingridient =>
                    ingridient.Id == id && ingridient.UserId == userId);

            if (ingridient is null)
            {
                throw new KeyNotFoundException(ErrorResource.IngridientNotFound);
            }

            _repositoryIngridient.Delete(ingridient);
            await _repositoryIngridient.SaveChangesAsync();
        }

        public async Task UpdateAsync(IngridientDto ingridientDto)
        {
            ingridientDto = ingridientDto ?? throw new ArgumentNullException(nameof(ingridientDto));

            var ingridient = await _repositoryIngridient
                .GetEntityAsync(ingridient =>
                    ingridient.Id == ingridientDto.Id && ingridient.UserId == ingridientDto.UserId);

            if (ingridient is null)
            {
                throw new KeyNotFoundException(ErrorResource.IngridientNotFound);
            }

            static bool CheckAndUpdate(Ingridient ingridient, IngridientDto newIngridient)
            {
                var toUpdate = false;

                if (ingridient.Name != newIngridient.Name)
                {
                    ingridient.Name = newIngridient.Name;
                    toUpdate = true;
                }

                if (ingridient.Category != newIngridient.Category)
                {
                    ingridient.Category = newIngridient.Category;
                    toUpdate = true;
                }

                if (ingridient.Colories != newIngridient.Colories)
                {
                    ingridient.Colories = newIngridient.Colories;
                    toUpdate = true;
                }

                if (ingridient.Description != newIngridient.Description)
                {
                    ingridient.Description = newIngridient.Description;
                    toUpdate = true;
                }

                if (ingridient.ReactionType != newIngridient.ReactionType)
                {
                    ingridient.ReactionType = newIngridient.ReactionType;
                    toUpdate = true;
                }

                return toUpdate;
            }

            if (CheckAndUpdate(ingridient, ingridientDto))
            {
                await _repositoryIngridient.SaveChangesAsync();
            }
        }
    }
}
