namespace Inspectables
{
    public interface IInspectableField
    {
        public IComparableField Inspect();
        public void Cancel();
    }
}