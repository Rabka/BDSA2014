using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.Commands;
using CALENDAR.AccountManagement;
using CALENDAR.Storage;
namespace ComponentTesting.TestStubs.Storage
{
    public class SeasonStub : ISeason
    {
        List<IChangeCommand> changeCommands = new List<IChangeCommand>();
        /// <summary>
        /// Constructor
        /// </summary>
        public SeasonStub()
        {
            OnlineContext = new OnlineContextStub();
        }

        /// <summary>
        /// Adds a changecommand. Changecommands are tied to events and allows for
        /// undoing previous changes to the calendar. Changecommands also makes it easier
        /// for synchronization to tell changes that needs to be done.
        /// </summary>
        /// <param name="command"></param>
        public void AddChangeCommand(IChangeCommand command)
        {
            if (changeCommands.Contains(command))
                throw new Exception("ChangeCommand allready exists!");
            changeCommands.Add(command);
        }
        /// <summary>
        /// Undoes last added changecommand.
        /// </summary>
        public void UndoLastChangeCommand()
        {
            changeCommands[changeCommands.Count - 1].SetOnlineContext(OnlineContext);
            changeCommands[changeCommands.Count - 1].Undo();
            changeCommands.RemoveAt(changeCommands.Count - 1);
        }

        /// <summary>
        /// Undoes all changes.
        /// </summary>
        public void UndoAllChangeCommands()
        {
            changeCommands.ForEach(x => x.SetOnlineContext(OnlineContext));
            changeCommands.ForEach(x => x.Undo());
            changeCommands.Clear();
        }
        public void SyncChangeCommands()
        {
            //Writes changes to the Offline database
            changeCommands.ToList().ForEach(x => x.SetOnlineContext(OnlineContext));
            changeCommands.ToList().ForEach(x => x.Execute());
            //Writes changes between Offline and Online databases to the Online database if Online is available.
            OnlineContext.Sync();
        }
        // Currently loggedin user
        public Account CurrentAccount { get; set; }
        // OnlineContext, in this stub context it is an OnlineContextStub.
        public IOnlineContext OnlineContext { get; private set; }
    }
}
