using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfouLibrary.BusinessLogic
{
    public class Basic
    {
        public Basic()
        {
            EventManagement = new EventManagement();
            OrganizationsManagement = new OrganizationsManagement();
            SellerManagement = new SellerManagement();
            TicketManagement = new TicketManagement();
            TypesManagement = new TypesManagement();
            UsersManagement = new UsersManagement();
        }

        public EventManagement EventManagement { get; private set; }
        public OrganizationsManagement OrganizationsManagement { get; private set; }
        public SellerManagement SellerManagement { get; private set; }
        public TicketManagement TicketManagement { get; private set; }
        public TypesManagement TypesManagement { get; private set; }
        public UsersManagement UsersManagement { get; private set; }
    }
}
