using Microsoft.EntityFrameworkCore;
using ProperNutrition.BLL.Interfaces;
using ProperNutrition.BLL.Models;
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

        public Task ChangeIngridientStatusAsync(string UserId, int id)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(string UserId, IngridientDto ingridientDto)
        {
            var ingridient = new Ingridient
            {
                Id = ingridientDto.Id,
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

        public async Task<IEnumerable<IngridientDto>> GetIngridientsByUserIdAsync(string userId)
        {
            var ingridients = await _repositoryIngridient
                .GetAll()
                .AsNoTracking()
                .Where(ingridient => ingridient.UserId == userId) //Delite becouse all people can use all ingridients
                .ToListAsync();

            var ingridientDtos = new List<IngridientDto>();

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
    }
}
