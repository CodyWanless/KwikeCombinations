using Skunkworks.Model.Interfaces;

namespace Skunkworks.Model
{
    public sealed class Item : IItem
    {
        public Item(long id,
            double totalArea)
        {
            this.Identifer = id;
            this.AreaRequired = totalArea;
        }

        public double AreaRequired { get; }

        public long Identifer { get; }
    }
}
