namespace HikiCoffee.Data.Entities
{
    public class Language
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string NameLanguage { get; set; }

        public bool IsDefault { get; set; }

        public List<UnitTranslation> UnitTranslations { get; set; }

        public List<CategoryTranslation> CategoryTranslations { get; set; }

        public List<ProductTranslation> ProductTranslations { get; set; }
    }
}
