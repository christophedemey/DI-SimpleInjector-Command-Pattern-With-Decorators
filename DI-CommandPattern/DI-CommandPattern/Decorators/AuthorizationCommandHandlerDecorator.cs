using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DI_CommandPattern
{
    public class AuthorizationCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand>
    {
        private readonly ICommandHandler<TCommand> decorated;

        public AuthorizationCommandHandlerDecorator(ICommandHandler<TCommand> decorated)
        {
            this.decorated = decorated;
        }

        public void Handle(TCommand command)
        {
            //Perform authentication... but how ?
            Console.WriteLine("Performing authorization.");
            this.decorated.Handle(command);
        }
    }
}
