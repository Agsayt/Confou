//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConfouLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class Logging
    {
        public System.Guid LogId { get; set; }
        public Action Action { get; set; }
        public string TargetTable { get; set; }
        public string Description { get; set; }
        public System.Guid Author { get; set; }
        public string AuthorIP { get; set; }
        public System.DateTime ActionDate { get; set; }
    
        public virtual ActionType ActionType { get; set; }
    }
}
