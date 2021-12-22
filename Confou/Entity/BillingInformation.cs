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
    
    public partial class BillingInformation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BillingInformation()
        {
            this.Tickets = new HashSet<Tickets>();
        }
    
        public int BillingId { get; set; }
        public int TicketId { get; set; }
        public bool TransactionResult { get; set; }
        public string Email { get; set; }
        public System.DateTime TransactionDate { get; set; }
        public int SellerId { get; set; }
        public string BuyerEmail { get; set; }
    
        public virtual Buyer Buyer { get; set; }
        public virtual Seller Seller { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tickets> Tickets { get; set; }
    }
}
