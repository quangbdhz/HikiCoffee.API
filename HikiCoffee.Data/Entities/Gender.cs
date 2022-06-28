namespace HikiCoffee.Data.Entities
{
    public class Gender
    {
        public int Id { get; set; }

        public string NameGender { get; set; }

        public bool IsActive { get; set; }

        public List<AppUser> AppUsers { get; set; }
    }
}
