using System.ComponentModel.DataAnnotations;

namespace FeatureHub.Api.Controllers
{
    public class SumRequest
    {
        [Required]
        public int Value1 { get; set; }

        [Required]
        public int Value2 { get; set; }
    }
}