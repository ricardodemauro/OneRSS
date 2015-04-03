using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneRSS.Data.DataSchemas
{
    public abstract class SchemaBase : ViewModelBase
    {
        public abstract string DefaultContent { get; }
        public abstract string DefaultImageUrl { get; }
        public abstract string DefaultSummary { get; }
        public abstract string DefaultTitle { get; }

        public abstract string GetValue(string propertyName);
        //public virtual string GetValues(params string[] propertyNames);
    }
}
