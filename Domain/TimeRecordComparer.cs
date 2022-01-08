using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Avo.SoftDev.Domain
{
    public class TimeRecordComparer : IEqualityComparer<TimeRecord>
    {
        public bool Equals([AllowNull] TimeRecord x, [AllowNull] TimeRecord y)
        {
            if (x == null && y == null)
                return true;
            else if (x == null || y == null)
                return false;
            else if (x.Date == y.Date && 
                     x.Hours == y.Hours && 
                     x.Name == y.Name && 
                     x.Message == y.Message)
                return true;
            else 
                return false;
        }

        public int GetHashCode([DisallowNull] TimeRecord obj)
        {
            int hCode = obj.Date.Day ^ obj.Hours ^ obj.Name.Length ^ obj.Message.Length;
            return hCode;
        }
    }
}
