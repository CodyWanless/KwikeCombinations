using System.Collections.Generic;

namespace Skunkworks.Model.Interfaces
{
    /// <summary>
    /// Representation of a 2D shopping cart.
    /// </summary>
    public interface IShoppingCart
    {
        IReadOnlyCollection<IItem> Items { get; }

        double TotalArea { get; }
    }
}
