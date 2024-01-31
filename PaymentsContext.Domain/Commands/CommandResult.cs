using PaymentsContext.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsContext.Domain.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult()
        {
            
        }
        public CommandResult(bool sucess, string message)
        {
            Sucess = sucess;
            Message = message;
        }

        public bool Sucess { get; set; }
        public string Message { get; set; }
    }
}
