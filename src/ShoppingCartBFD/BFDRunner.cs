using System.Collections.Generic;
using System.Linq;
using Skunkworks.Constraints;
using Skunkworks.Constraints.Interfaces;
using Skunkworks.Model;
using Skunkworks.Model.Interfaces;

namespace Skunkworks
{
    public sealed class BFDRunner : IBFDRunner
    {
        private readonly IShoppingCartValidator shoppingCartValidator;

        public BFDRunner(IShoppingCartValidator shoppingCartValidator)
        {
            this.shoppingCartValidator = shoppingCartValidator;
        }

        public BFDRunner()
            : this(new ShoppingCartValidator()) { } // happy bastard injection Saturday!

        public IReadOnlyCollection<IShoppingCart> Run(IReadOnlyCollection<IItem> items)
        {
            if (items.Count == 0)
            {
                return new IShoppingCart[0];
            }

            var orderItems = new LinkedList<IItem>(items.OrderByDescending(item => item.AreaRequired));
            var result = new List<IShoppingCart>();

            var currentItems = new List<IItem>
            {
                orderItems.First.Value
            };
            orderItems.RemoveFirst();

            do
            {
                var iterItem = orderItems.First;
                while (iterItem != null)
                {
                    var test = new List<IItem>(currentItems)
                    {
                        iterItem.Value
                    };
                    if (shoppingCartValidator.IsValid(test))
                    {
                        currentItems.Add(iterItem.Value);
                        // meh, was hoping we could just re-assign some pointers. Oh well
                        var next = iterItem.Next;
                        orderItems.Remove(iterItem);

                        iterItem = next;
                    }
                    else
                    {
                        iterItem = iterItem.Next;
                    }
                }

                result.Add(new ShoppingCart(currentItems));

                if (orderItems.First != null)
                {
                    currentItems = new List<IItem>
                    {
                        orderItems.First.Value
                    };
                    orderItems.RemoveFirst();
                }
            } while (orderItems.Any());

            return result;
        }
    }
}
