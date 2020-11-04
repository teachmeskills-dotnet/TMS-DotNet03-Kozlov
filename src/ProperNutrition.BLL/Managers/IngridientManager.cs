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
    /// <inheritdoc cref="IIngridientManager">
    public class IngridientManager : IIngridientManager
    {
        private readonly IRepository<Ingridient> _repositoryIngridient;

        public IngridientManager(IRepository<Ingridient> repositoryIngridient)
        {
            _repositoryIngridient = repositoryIngridient ?? throw new ArgumentNullException(nameof(repositoryIngridient));
        }

        public async Task<IEnumerable<IngridientDto>> GetIngridientsByUserIdAsync(string userId)
        {
            var ingridients = await _repositoryIngridient
                .GetAll()
                .AsNoTracking()
                .Where(ingridient => ingridient.UserId == userId)
                .ToListAsync();

            var ingridientDtos = new List<IngridientDto>();

            foreach (var ingridient in ingridients)
            {
                ingridientDtos.Add(new IngridientDto
                {
                    Id = ingridient.Id,
                    NameIngridient = ingridient.NameIngridient,
                    Category = ingridient.Category,
                    //VegetarionorMeat = ingridient.VegetarionorMeat,
                    Description = ingridient.Description,
                    Colories = ingridient.Colories,
                    IsRecomended = ingridient.IsRecomended,
                    Reaction = ingridient.Reaction,
                    IngridientDate = ingridient.IngridientDate
                });
            }

            return ingridientDtos;

        }
    }
}
