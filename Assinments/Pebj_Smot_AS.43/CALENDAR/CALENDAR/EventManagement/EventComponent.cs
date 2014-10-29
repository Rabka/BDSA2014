using System;
using CALENDAR.AccountManagement;
using CALENDAR.Synchronization;

namespace CALENDAR.EventManagement
{
    public interface EventComponent : DBObject
    {
        DateTime DateFrom { get; }
        DateTime DateTo { get; }
        string Title { get; }
        string Description { get; }
        Account OwnedByAccount { get; }
        Account[] SharedWithAccounts { get; }
        INotification[] Notifications { get; }
        EventComponent[] GetLeafs();
        void Draw();
        bool IsLeaf();
    }
}
