
using SalesWebMVC.Models;

namespace SalesWebMVC.Data {
    public class SeedingService {

        private SalesWebMVCContext _context { get; set; }

        public SeedingService(SalesWebMVCContext context) { 
            _context = context;
        }

        public void Seed() {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any()) {
                return; //DB is already seeded
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Electronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            Seller s1 = new Seller(1, "Bob", "bob@mail.com", 1000.0f, new DateTime(1998, 04, 21), d1);
            Seller s2 = new Seller(2, "Maria", "maria@mail.com", 1000.0f, new DateTime(1979, 12, 31), d2);
            Seller s3 = new Seller(3, "Alex", "alex@mail.com", 1000.0f, new DateTime(1988, 01, 22), d3);
            Seller s4 = new Seller(4, "Martha", "martha@mail.com", 1000.0f, new DateTime(1993, 11, 09), d4);
            Seller s5 = new Seller(5, "Donald", "Donald@mail.com", 1000.0f, new DateTime(2000, 6, 4), d1);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2018,09,25), 11000.00f, Models.Enums.SaleStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2018, 09, 26), 12000.00f, Models.Enums.SaleStatus.Billed, s2);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2018, 09, 27), 13000.00f, Models.Enums.SaleStatus.Canceled, s3);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2018, 09, 28), 14000.00f, Models.Enums.SaleStatus.Billed, s4);
            SalesRecord r5 = new SalesRecord(5, new DateTime(2018, 09, 29), 15000.00f, Models.Enums.SaleStatus.Billed, s5);
            SalesRecord r6 = new SalesRecord(6, new DateTime(2018, 09, 30), 16000.00f, Models.Enums.SaleStatus.Pending, s1);
            SalesRecord r7 = new SalesRecord(7, new DateTime(2018, 10, 01), 17000.00f, Models.Enums.SaleStatus.Canceled, s2);
            SalesRecord r8 = new SalesRecord(8, new DateTime(2018, 10, 02), 18000.00f, Models.Enums.SaleStatus.Pending, s3);
            SalesRecord r9 = new SalesRecord(9, new DateTime(2018, 10, 03), 19000.00f, Models.Enums.SaleStatus.Billed, s4);
            SalesRecord r10 = new SalesRecord(10, new DateTime(2018, 10, 04), 20000.00f, Models.Enums.SaleStatus.Billed, s5);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4, s5);
            _context.SalesRecord.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10);

            _context.SaveChanges();

        }
    }
}
