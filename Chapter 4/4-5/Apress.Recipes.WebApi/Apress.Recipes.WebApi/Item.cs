using System;

namespace Apress.Recipes.WebApi
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime Date
        {
            get
            {
                return DateTime.Now;

            }
           
        }
    }
}