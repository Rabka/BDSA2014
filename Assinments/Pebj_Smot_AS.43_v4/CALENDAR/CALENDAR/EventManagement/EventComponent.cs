using System;
using CALENDAR.AccountManagement;
using CALENDAR.Storage;

namespace CALENDAR.EventManagement
{
    public interface EventComponent : DBObject
    {
        DateTime DateFrom { get; set; }
        DateTime DateTo { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        IAccount OwnedByAccount { get; }
        IAccount[] SharedWithAccounts { get; }
        INotification[] Notifications { get; set; }
        EventComponent[] GetLeafs();
        void Draw();
        bool IsLeaf();
    }
}
