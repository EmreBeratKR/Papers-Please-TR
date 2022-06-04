namespace Inspectables
{
    public interface IInspectableField
    {
        public IComparableField Inspect();
        public bool TryInspect(out IComparableField comparableField);
        public void Cancel();
        public void SolveMismatch();
    }
}