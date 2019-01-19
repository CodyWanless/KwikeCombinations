using System.Collections.Generic;

namespace Skunkworks.Model.Interfaces
{
    public sealed class ItemComparer : EqualityComparer<IItem>
    {
        public override bool Equals(IItem x, IItem y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

            return x.Identifer == y.Identifer;
        }

        public override int GetHashCode(IItem obj)
        {
            if (obj == null)
            {
                return 3;
            }

            unchecked
            {
                var hash = 3;
                hash = hash * 17 + obj.Identifer.GetHashCode();

                return hash;
            }
        }
    }
}
