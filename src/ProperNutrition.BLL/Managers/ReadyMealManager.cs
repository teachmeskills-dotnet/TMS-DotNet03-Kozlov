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
        private readonly IRepository<ReadyMeal> _repositoryReadyMeal;

        public ReadyMealManager(IRepository<ReadyMeal> repositoryReadyMeal)
        {
            _repositoryReadyMeal = repositoryReadyMeal ?? throw new ArgumentNullException(nameof(repositoryReadyMeal));
        }

        public async Task<IEnumerable<ReadyMealDto>> GetReadyMealByIdAsync(string name)
        {
             var readymeals = await _repositoryReadyMeal
                .GetAll()
                .AsNoTracking()
                .ToListAsync();

            var readymealDtos = new List<ReadyMealDto>();

            foreach (var readymeal in readymeals)
            {
                readymealDtos.Add(new ReadyMealDto
                { 
                    Id = readymeal.Id,
                    Name = readymeal.Name,
                    ChildReacrion = readymeal.ChildReacrion,
                    TeastyMeal = readymeal.TeastyMeal,
                    Comment = readymeal.Comment,
                    ReadyTime = readymeal.ReadyTime,
                    //Photo = readymeal.Photo,
                });
            }
            return readymealDtos;
        }
    }
}
