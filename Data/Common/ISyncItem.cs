using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneRSS.Data.Common
{
    public interface ISyncItem<T>
    {
        void Sync(T other);
        bool NeedSync(T other);
    }
}
