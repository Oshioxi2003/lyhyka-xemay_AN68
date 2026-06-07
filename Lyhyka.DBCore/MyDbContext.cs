using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyhyka.DBCore
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("MyDbContext") { }

        public DbSet<TestCar> TestCars { get; set; }
        public DbSet<TestVehicle> TestVehicles { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<Calibration> Calibrations { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<ReportCounter> ReportCounters { get; set; }
    }
}
