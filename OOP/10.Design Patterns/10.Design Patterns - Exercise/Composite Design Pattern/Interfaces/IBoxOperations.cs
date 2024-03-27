using Composite_Design_Pattern.Models;

namespace Composite_Design_Pattern.Interfaces
{
    public interface IBoxOperations
    {
        void Add(GiftBase gift);
        void Remove(GiftBase gift);
    }
}
