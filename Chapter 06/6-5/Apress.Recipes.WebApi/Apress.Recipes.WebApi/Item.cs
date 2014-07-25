namespace Apress.Recipes.WebApi
{
    public class Item
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Country { get; set; }
    }

    public class SuperItem : Item
    {
        public double Price { get; set; }
    }
}