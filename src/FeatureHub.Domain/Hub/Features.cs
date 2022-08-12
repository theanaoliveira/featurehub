namespace FeatureHub.Domain.Hub
{
    public class Features
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public bool Active { get; private set; }

        public Features(string name, bool active)
        {
            Id = Guid.NewGuid();
            Name = name;
            Active = active;
        }

        public void SetActive(bool active) => Active = active;
    }
}
