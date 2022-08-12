namespace FeatureHub.Application.UseCases.Sum
{
    public class SumUseCase : ISumUseCase
    {
        public int Sum(int value1, int value2) => (value1 + value2);
    }
}
