using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_CommandPattern
{
    public class CustomerController
    {
        private ICommandHandler<MoveCustomerCommandModel> handler;

        public CustomerController(ICommandHandler<MoveCustomerCommandModel> handler)
        {
            this.handler = handler;
        }

        public void MoveCustomer(int customerId, string newAddress)
        {
            var command = new MoveCustomerCommandModel
            {
                CustomerId = customerId,
                NewAddress = newAddress
             };

            this.handler.Handle(command);
        }
    }
}
