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
    
    public partial class SellerToTicket
    {
        public int SellerId { get; set; }
        public int TicketId { get; set; }
    
        public virtual Seller Seller { get; set; }
        public virtual Tickets Tickets { get; set; }
    }
}
