using GalaSoft.MvvmLight;
using System;

namespace OneRSS.Data.DataSchemas
{
    /// <summary>
    /// Implementation of the MenuSchema class.
    /// </summary>
    public class MenuSchema : SchemaBase, IEquatable<MenuSchema>
    {
        private string _name;
        private string _title;
        private string _type;
        private string _target;
        private string _icon;

        public string Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }

        public string Title
        {
            get { return _title; }
            set { Set(ref _title, value); }
        }

        public string Type
        {
            get { return _type; }
            set { Set(ref _type, value); }
        }

        public string Target
        {
            get { return _target; }
            set { Set(ref _target, value); }
        }

        public string Icon
        {
            get { return _icon; }
            set { Set(ref _icon, value); }
        }

        public override string DefaultTitle
        {
            get { return Title; }
        }

        public override string DefaultSummary
        {
            get { return null; }
        }

        public override string DefaultImageUrl
        {
            get { return Icon; }
        }

        public override string DefaultContent
        {
            get { return null; }
        }

        override public string GetValue(string fieldName)
        {
            if (!String.IsNullOrEmpty(fieldName))
            {
                switch (fieldName.ToLowerInvariant())
                {
                    case "name":
                        return String.Format("{0}", Name);
                    case "title":
                        return String.Format("{0}", Title);
                    case "type":
                        return String.Format("{0}", Type);
                    case "target":
                        return String.Format("{0}", Target);
                    case "icon":
                        return String.Format("{0}", Icon);
                    case "defaulttitle":
                        return String.Format("{0}", DefaultTitle);
                    case "defaultsummary":
                        return String.Format("{0}", DefaultSummary);
                    case "defaultimageurl":
                        return String.Format("{0}", DefaultImageUrl);
                    default:
                        break;
                }
            }
            return String.Empty;
        }

        public bool Equals(MenuSchema other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(null, other)) return false;

            return this.Target == other.Target;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as MenuSchema);
        }

        public override int GetHashCode()
        {
            return this.Target.GetHashCode();
        }
    }
}
