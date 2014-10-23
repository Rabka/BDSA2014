using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment40_PartIII
{
    public class Report<TData, TError>
    {
        public TData Data { get; set; }
        public TError Error { get; set; }
    }
}
