using System.ComponentModel.DataAnnotations.Schema;

namespace ProductDashboard.Models
{
    public class Category
    {

        public  int CategoryId { get; set; }
        public string Name { get; set; }

        public List<Product>? Products { get; set; }

    }

    
}
