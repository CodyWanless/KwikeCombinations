using System.Collections.Generic;
using Skunkworks.Model.Interfaces;
using System.Linq;
using System;

namespace Skunkworks.Model
{
    public sealed class ShoppingCart : IShoppingCart
    {
        private readonly IItem[] items;
        private readonly Lazy<double> totalArea;

        public ShoppingCart(IReadOnlyCollection<IItem> items)
        {
            this.items = items is IItem[] itemArray ? itemArray : items.ToArray();
            this.totalArea = new Lazy<double>(() => this.items.Sum(item => item.AreaRequired));
        }

        public IReadOnlyCollection<IItem> Items => items;

        public double TotalArea => totalArea.Value;
    }
}
