using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WcfServiceTest.BDD.EF6
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public partial class DbEntities : DbContext
    {
        public DbEntities() : base(nameOrConnectionString: "MonkeyFist") { }

        public DbSet<ObjetTest> ObjetsTest { get; set; }
    }

    [Table("table_test")]
    public class ObjetTest
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("data1")]
        public string Data1 { get; set; }

        [Column("data2")]
        public string Data2 { get; set; }

        [Column("data3")]
        public string Data3 { get; set; }
    }
}