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
    
    public partial class Organizations
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Organizations()
        {
            this.Events = new HashSet<Events>();
        }
    
        public int OrganizationID { get; set; }
        public int AssigneeId { get; set; }
        public string OrganizationName { get; set; }
        public decimal OrganizationINN { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int CreateAuthor { get; set; }
        public decimal Fee { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Events> Events { get; set; }
        public virtual Users Users { get; set; }
    }
}
