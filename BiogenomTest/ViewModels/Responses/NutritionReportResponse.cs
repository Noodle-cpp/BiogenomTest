using Application.ViewModels;

namespace Api.ViewModels.Responses
{
    public class NutritionReportResponse
    {
        public Guid Id { get; set; }
        public int CountInNorm { get; set; }
        public int CountBelow { get; set; }
        public IEnumerable<VitaminAttributeResponse> VitaminAttributeViewModels { get; set; }
        public IEnumerable<DietarySupplementResponse> DietarySupplements { get; set; }
        public IEnumerable<VitaminBalanceResponse> VitaminBalances { get; set; }
    }
}
