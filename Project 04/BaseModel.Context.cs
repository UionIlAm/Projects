//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project_04
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DemographyBaseEntities : DbContext
    {
        private static DemographyBaseEntities _context { get; set; }

        public DemographyBaseEntities()
            : base("name=DemographyBaseEntities")
        {
        }
    
        public static DemographyBaseEntities GetContext()
        {
            if (_context == null)
                _context = new DemographyBaseEntities();

            return _context;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CauseOfDeath> CauseOfDeath { get; set; }
        public virtual DbSet<CountryInfo> CountryInfo { get; set; }
        public virtual DbSet<DeathPeople> DeathPeople { get; set; }
        public virtual DbSet<GenderType> GenderType { get; set; }
        public virtual DbSet<NewbornPeople> NewbornPeople { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
