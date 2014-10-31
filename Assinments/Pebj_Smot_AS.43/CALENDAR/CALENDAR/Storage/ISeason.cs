using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.Commands;
using CALENDAR.EventManagement;
using CALENDAR.AccountManagement;
using CALENDAR.Storage;
namespace CALENDAR.Storage
{
    public interface ISeason
    {
        void AddChangeCommand(IChangeCommand command);
        void UndoLastChangeCommand();
        void UndoAllChangeCommands();
        void SyncChangeCommands();
        Account CurrentAccount {get;set;}
        IOnlineContext OnlineContext { get;   }
    }
}
