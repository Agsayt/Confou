﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Confou.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ConfouEntities : DbContext
    {
        public ConfouEntities()
            : base("name=ConfouEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BillingInformation> BillingInformation { get; set; }
        public virtual DbSet<Buyer> Buyer { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<EventStatuses> EventStatuses { get; set; }
        public virtual DbSet<Logging> Logging { get; set; }
        public virtual DbSet<Organizations> Organizations { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Seller> Seller { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tickets> Tickets { get; set; }
        public virtual DbSet<TicketStatuses> TicketStatuses { get; set; }
        public virtual DbSet<TicketType> TicketType { get; set; }
        public virtual DbSet<TicketTypeStatuses> TicketTypeStatuses { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<SellerToTicket> SellerToTicket { get; set; }
        public virtual DbSet<ActionType> ActionType { get; set; }
        public virtual DbSet<DisactivatedAccounts> DisactivatedAccounts { get; set; }
        public virtual DbSet<DisactivatedTypes> DisactivatedTypes { get; set; }
    }
}
