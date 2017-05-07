using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DI_CommandPattern
{
    public class MoveCustomerCommandHandler : ICommandHandler<MoveCustomerCommandModel>
    {
        private readonly UnitOfWork db;

        public MoveCustomerCommandHandler(UnitOfWork db)
        {
            this.db = db;
        }

        public void Handle(MoveCustomerCommandModel command)
        {
            // TODO: Logic here
            //Lets have some fun with the deadlock decorator.
            throw new DbExceptionTest("deadlock");
        }
    }

    public class DbExceptionTest : DbException
    {
        public DbExceptionTest()
        {
        }

        public DbExceptionTest(string message) : base(message)
        {
        }

        protected DbExceptionTest(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DbExceptionTest(string message, int errorCode) : base(message, errorCode)
        {
        }

        protected DbExceptionTest(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}


