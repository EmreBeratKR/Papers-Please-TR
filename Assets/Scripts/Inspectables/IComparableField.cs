using Helpers;

namespace Inspectables
{
    public interface IComparableField
    {
        public ComparisonResult Compare(object other);
        public void SolveMismatch();
    }
}