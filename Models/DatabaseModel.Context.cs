//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Shopping_Site.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ShoppingSiteDatabaseEntities2 : DbContext
    {
        public ShoppingSiteDatabaseEntities2()
            : base("name=ShoppingSiteDatabaseEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<ShoppingProduct> ShoppingProducts { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }
    }
}
