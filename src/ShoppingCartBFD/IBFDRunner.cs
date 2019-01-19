using System.Collections.Generic;
using Skunkworks.Model.Interfaces;

namespace ShoppingCartBFD
{
    public interface IBFDRunner
    {
        IReadOnlyCollection<IShoppingCart> Run(IReadOnlyCollection<IItem> items);
    }
}
