using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ComposeRoot();

            try
            {
                var command = container.GetInstance<ICommandHandler<MoveCustomerCommand>>();

                // Inject the handler into the controller’s constructor.
                var controller = new CustomerController(command);
                controller.MoveCustomer(5, "woop");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to insert : {ex.Message}.");
            }

            Console.ReadLine();
        }

        private static Container ComposeRoot()
        {
            var container = new Container();

            // Go look in all assemblies and register all implementations
            // of ICommandHandler<T> by their closed interface:
            container.Register(typeof(ICommandHandler<>),
                AppDomain.CurrentDomain.GetAssemblies());

            // Decorate each returned ICommandHandler<T> object with
            // a TransactionCommandHandlerDecorator<T>.
            container.RegisterDecorator(typeof(ICommandHandler<>),
                typeof(TransactionCommandHandlerDecorator<>));

            // Decorate each returned ICommandHandler<T> object with
            // a DeadlockRetryCommandHandlerDecorator<T>.
            container.RegisterDecorator(typeof(ICommandHandler<>),
                typeof(DeadlockRetryCommandHandlerDecorator<>));

            // Decorates all handlers with an authorization decorator.
            container.RegisterDecorator(typeof(ICommandHandler<>),
                typeof(AuthorizationCommandHandlerDecorator<>));

            return container;
        }
    }
}
