// See https://aka.ms/new-console-template for more information
using System.Collections;

var texts = new string[2] {"this" , "that"};

var collection = new MyCollection<string>(texts);

foreach (var item in collection.items)
{
    Console.WriteLine(item);
}


public class MyCollection<T> : IEnumerable<T>
{
    public T[] items;

    public MyCollection(T[] items)
    {
        this.items = items;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new MyCollectionEnumerator<T>(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class MyCollectionEnumerator<T> : IEnumerator<T>
{
    private MyCollection<T> collection;
    private int currentIndex = -1;
    public MyCollectionEnumerator(MyCollection<T> collection)
    {
        this.collection = collection;
    }
    public T Current { get
        {
            if (currentIndex == -1 || currentIndex >= collection.items.Length)
                throw new InvalidOperationException();
            return collection.items[currentIndex];
        } }

    object IEnumerator.Current => Current;

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public bool MoveNext()
    {
        currentIndex++;
        return currentIndex < collection.items.Length;
    }

    public void Reset()
    {
        currentIndex = -1;
    }
}