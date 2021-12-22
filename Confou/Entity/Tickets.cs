//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Tickets
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tickets()
        {
            this.SellerToTicket = new HashSet<SellerToTicket>();
            this.Buyer = new HashSet<Buyer>();
        }
    
        public int TicketId { get; set; }
        public int EventId { get; set; }
        public int Seat { get; set; }
        public System.Guid TicketCode { get; set; }
        public System.DateTime SoldDate { get; set; }
        public int SoldBy { get; set; }
        public Nullable<int> BillingId { get; set; }
        public int TicketStatus { get; set; }
    
        public virtual BillingInformation BillingInformation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SellerToTicket> SellerToTicket { get; set; }
        public virtual TicketStatuses TicketStatuses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Buyer> Buyer { get; set; }
    }
}
