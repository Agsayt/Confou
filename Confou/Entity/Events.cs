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
    
    public partial class Events
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Events()
        {
            this.Tickets = new HashSet<Tickets>();
            this.TicketType = new HashSet<TicketType>();
        }
    
        public int EventId { get; set; }
        public int OrgarnizatorID { get; set; }
        public string EventName { get; set; }
        public string HallName { get; set; }
        public string EventAddress { get; set; }
        public string EventDescription { get; set; }
        public System.DateTime EventDate { get; set; }
        public int EventStatus { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int AgeRestriction { get; set; }
    
        public virtual AgeRestrictionTypes AgeRestrictionTypes { get; set; }
        public virtual EventStatuses EventStatuses { get; set; }
        public virtual Organizations Organizations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tickets> Tickets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TicketType> TicketType { get; set; }
    }
}
