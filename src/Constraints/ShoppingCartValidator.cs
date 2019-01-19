using System.Collections.Generic;
using System.Linq;
using Skunkworks.Constraints.Interfaces;
using Skunkworks.Model.Interfaces;

namespace Skunkworks.Constraints
{
    public sealed class ShoppingCartValidator : IShoppingCartValidator
    {
        private const double maxArea = 30d;

        public bool IsValid(IShoppingCart cartToTest)
        {
            return cartToTest.TotalArea < maxArea;
        }

        public bool IsValid(IReadOnlyCollection<IItem> items)
        {
            return items.Sum(i => i.AreaRequired) < maxArea;
        }
    }
}
