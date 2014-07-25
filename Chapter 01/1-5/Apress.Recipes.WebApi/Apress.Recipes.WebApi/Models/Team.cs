using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apress.Recipes.WebApi.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime FoundingDate { get; set; }
        public string LeagueName { get; set; }
    }
}