namespace Genetic.Interface
{
    public interface ICrossing
    {
        public (Individual childOne, Individual childTwo) CrossingIndividual(Individual individOne, Individual individTwo);
    }
}
