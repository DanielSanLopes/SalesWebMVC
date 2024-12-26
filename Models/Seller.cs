using System.Data;

namespace SalesWebMVC.Models {
    public class Seller {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public float BaseSalary { get; set; }
        public DateTime BirthDate { get; set; }
        public Department Department { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller() { }

        public Seller(int id, string name, string email, float baseSalary, DateTime birthDate, Department department) {
            Id = id;
            Name = name;
            Email = email;
            BaseSalary = baseSalary;
            BirthDate = birthDate;
            Department = department;
        }

        public void AddSales(SalesRecord sr) { 
            Sales.Add(sr);
        }
        
        public void RemoveSales(SalesRecord sr) { 
            Sales.Remove(sr);
        }

        public float TotalSales(DateTime initial, DateTime final) {
            float total = 0;
            total = Sales.Where(value => value.Date >= initial && value.Date <= final).Sum(value => value.Amount);
            return total;
        }
    }
}
