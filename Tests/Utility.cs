using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSystem.Tests
{
    internal class Utility
    {
        public static Guid ToGuid(int value)
        {
            return new Guid(value, 0, 0, new byte[8]);
        }
    }
}
