using System.Collections.Generic;
using Skunkworks.Constraints.Interfaces;
using Skunkworks.Model.Interfaces;

namespace Skunkworks
{
    public interface IBFDRunner
    {
        IReadOnlyCollection<IShoppingCart> Run(IReadOnlyCollection<IItem> items);
    }
}
