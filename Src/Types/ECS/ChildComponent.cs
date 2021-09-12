namespace CXUtils.Types
{
    /// <summary>
    ///     represents a child component of the specified type <typeparamref name="T" />
    /// </summary>
    public abstract class ChildComponent<T>
    {
        public readonly T root;

        protected ChildComponent( T root ) => this.root = root;
    }
}
