using Application.Exceptions;
using Application.Interfaces;
using Application.ViewModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    /// <summary>
    /// Программа маленькая, решила не выводить интерфейс отдельно
    /// </summary>
    public interface INutritionsReportService
    {
        Task<NutritionsReportViewModel> GetNutritionsReportAsync();
    }

    public class NutritionsReportService : INutritionsReportService
    {
        private readonly INutritionsReportRepository _nutritionsReportRepository;
        private readonly ISupplementVitaminRepository _supplementVitaminRepository;

        public NutritionsReportService(INutritionsReportRepository nutritionsReportRepository,
                                        ISupplementVitaminRepository supplementVitaminRepository)
        {
            _nutritionsReportRepository = nutritionsReportRepository;
            _supplementVitaminRepository = supplementVitaminRepository;
        }

        public async Task<NutritionsReportViewModel> GetNutritionsReportAsync()
        {
            var report = await _nutritionsReportRepository.GetNutritionsReportAsync().ConfigureAwait(false) ?? throw new NutritionsReportNotFoundException();
            var belowVitaminsNutritions = report.NutritionsReportAttributes.Where(x => x.Vitamin.Value > x.Value).ToList();
            var supps = await _supplementVitaminRepository.GetDietarySupplementByVitaminListAsync(belowVitaminsNutritions.Select(x => x.VitaminId).ToList());

            var result = new NutritionsReportViewModel()
            {
                Id = report.Id,
                CountInNorm = report.NutritionsReportAttributes.Count() - belowVitaminsNutritions.Count(),
                CountBelow = belowVitaminsNutritions.Count(),
                VitaminAttributes = report.NutritionsReportAttributes.Select(x => new VitaminAttributeViewModel()
                {
                    Value = x.Value,
                    VitaminTitle = x.Vitamin.Title,
                    NormValue = x.Vitamin.Value,
                    ValueDif = x.Vitamin.Value - x.Value < 0 ? 0 : Math.Round(x.Vitamin.Value - x.Value, 2),
                }).ToList(),
                DietarySupplements = supps,
                VitaminBalances = belowVitaminsNutritions.Select(x => new VitaminBalanceViewModel()
                {
                    VitaminTitle = x.Vitamin.Title,
                    Value = x.Value,
                    SuppsValue = supps.SelectMany(x => x.VitaminBalances).ToDictionary(vb => vb.Key, vb => vb.Value)[x.Vitamin.Title]
                })
            };

            return result;
        }
    }
}
