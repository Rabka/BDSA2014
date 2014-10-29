using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.Commands;
using CALENDAR.EventManagement;
using CALENDAR.AccountManagement;
using CALENDAR.Synchronization;
namespace CALENDAR.Storage
{
    interface ISeason
    {
        void AddChangeCommand(IChangeCommand command);
        void UndoLastChangeCommand();
        void UndoAllChangeCommands();
        void SyncChangeCommands();
        Account currentAccount {get;set;}
        OnlineContext OnlineContext { get;   }
    }
}
