using System.Collections.Generic;
using System.Linq;

namespace Skunkworks.Model.Interfaces
{
    public sealed class ShoppingCartComparer : EqualityComparer<IShoppingCart>
    {
        private readonly IEqualityComparer<IItem> itemComparer;

        public ShoppingCartComparer()
            : this(new ItemComparer()) { }

        public ShoppingCartComparer(IEqualityComparer<IItem> itemComparer)
        {
            this.itemComparer = itemComparer;
        }

        public override bool Equals(IShoppingCart x, IShoppingCart y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

            var xItemSet = new HashSet<IItem>(x.Items, itemComparer);

            return xItemSet.SetEquals(y.Items);
        }

        public override int GetHashCode(IShoppingCart obj)
        {
            if (obj == null)
            {
                return 3;
            }

            unchecked
            {
                var hash = 5;
                hash = hash * 17 + obj.Items.Sum(i => itemComparer.GetHashCode(i));

                return hash;
            }
        }
    }
}
