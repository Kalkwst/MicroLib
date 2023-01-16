using System.Collections;

namespace Collections.Collection;

/// <summary>
/// Decorates another <see cref="ICollection{T}"/> to provide additional behavior.
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class AbstractCollectionDecorator<T> : ICollection<T>
{
    // The collection being decorated.
    private ICollection<T> _collection;

    protected AbstractCollectionDecorator(ICollection<T> collection)
    {
        _collection = collection ?? throw new ArgumentNullException(nameof(collection));
    }

    protected ICollection<T> Decorated()
    {
        return _collection;
    }

    public virtual IEnumerator<T> GetEnumerator() => Decorated().GetEnumerator();
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    ///<inheritdoc cref="ICollection{T}.Add"/>
    public virtual void Add(T item)
    {
        Decorated().Add(item);
    }

    ///<inheritdoc cref="ICollection{T}.Clear"/>
    public virtual void Clear()
    {
        Decorated().Clear();
    }

    ///<inheritdoc cref="ICollection{T}.Contains"/>
    public virtual bool Contains(T item)
    {
        return Decorated().Contains(item);
    }

    ///<inheritdoc cref="ICollection{T}.CopyTo"/>
    public virtual void CopyTo(T[] array, int arrayIndex)
    {
        Decorated().CopyTo(array, arrayIndex);
    }

    ///<inheritdoc cref="ICollection{T}.Remove"/>
    public virtual bool Remove(T item)
    {
        return Decorated().Remove(item);
    }

    ///<inheritdoc cref="ICollection{T}.Count"/>
    public virtual int Count => Decorated().Count;

    ///<inheritdoc cref="ICollection{T}.IsReadOnly"/>
    public virtual bool IsReadOnly => Decorated().IsReadOnly;

    
}