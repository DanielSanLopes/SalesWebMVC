using Microsoft.EntityFrameworkCore.Storage;
using System.Collections;
using System.Linq;

namespace SalesWebMVC.Models {
    public class Department {

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department() { }
        public Department(int id, string name) {
            Id = id;
            Name = name;
        }

        public void AddSeller(Seller seller) {
            Sellers.Add(seller);
        }

        public void RemoveSeller(Seller seller) {
            Sellers.Remove(seller); 
        }

        public float TotalSales(DateTime initial, DateTime final) {
            float totalSales = 0;
            totalSales = Sellers.Sum(value => value.TotalSales(initial, final));
            return totalSales;
                         
        }
    }
}
