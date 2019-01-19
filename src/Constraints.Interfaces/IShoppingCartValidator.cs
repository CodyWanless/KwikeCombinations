using System.Collections.Generic;
using Skunkworks.Model.Interfaces;

namespace Skunkworks.Constraints.Interfaces
{
    public interface IShoppingCartValidator
    {
        bool IsValid(IShoppingCart cartToTest);

        bool IsValid(IReadOnlyCollection<IItem> items);
    }
}
