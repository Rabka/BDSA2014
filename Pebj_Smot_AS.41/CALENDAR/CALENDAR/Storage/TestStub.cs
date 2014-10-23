using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CALENDAR.Storage.implementation
{
    class TestStub : DBTypeImplementor
    {
        public TestStub(string something)
        {

        }
        public void Add(DBRow row)
        {

        }
        public void Remove(DBRow row)
        {
        }
        public void Update(DBRow row)
        {

        }
        public void Get(int itemIndex)
        {

        }
        public int ItemCount()
        {
            return 0;
        }
    }
}
