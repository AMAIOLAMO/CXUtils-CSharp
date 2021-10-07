namespace CXUtils.Domain.Types
{
    /// <summary>
    ///     represents a child component of the specified type <typeparamref name="T" />
    /// </summary>
    public abstract class ChildComponent<T> where T : IComponentRoot<T>
    {
        protected ChildComponent( T root ) => Root = root;

        protected ChildComponent() { }
        protected T Root { get; private set; }

        public void Initialize( T root ) => Root = root;
    }
}
