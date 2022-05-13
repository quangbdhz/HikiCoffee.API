namespace HikiCoffee.Data.Entities
{
    public class Unit
    {
        public int Id { get; set; }

        public bool IsActive { get; set; }

        public List<UnitTranslation> UnitTranslations { get; set; }
    }
}
