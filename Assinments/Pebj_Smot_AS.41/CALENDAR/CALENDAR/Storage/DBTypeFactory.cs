using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CALENDAR.Storage.implementation
{
    class DBTypeFactory
    {
        public Abstraction CreateTestStub(string testStub)
        {
            return new Abstraction(new TestStub(testStub));
        }
        public Abstraction CreateRDBMS(string dbPath)
        {
            return new Abstraction(new RDBMS(dbPath));
        }
        public Abstraction CreateFileStub(string filePath)
        {
            return new Abstraction(new FileStub(filePath));
        }
    }
}
