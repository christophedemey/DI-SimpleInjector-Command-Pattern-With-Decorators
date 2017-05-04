using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_CommandPattern
{
    public class CustomerController
    {
        private ICommandHandler<MoveCustomerCommand> handler;

        public CustomerController(ICommandHandler<MoveCustomerCommand> handler)
        {
            this.handler = handler;
        }

        public void MoveCustomer(int customerId, string newAddress)
        {
            var command = new MoveCustomerCommand
            {
                CustomerId = customerId,
                NewAddress = newAddress
             };

            this.handler.Handle(command);
        }
    }
}
