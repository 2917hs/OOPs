public class GenericCollection<T> where T : struct
{
    private List<T> list = new List<T>();

    public GenericCollection()
    {
    }

    public List<T> GetList()
    {
        return list;
    }

    public void Add(T item)
    {
        list.Add(item);
    }

    public void PrintItem(Action<T> action)
    {
        foreach (var item in list)
        {
            action(item);
        }
    }

    public void PrintItemBy1(Func<T, int> func)
    {
        foreach (var item in list)
        {
            System.Console.WriteLine(func(item));
        }
    }

    public IEnumerable<T> PrintItemUsingIEnumerable(IEnumerable<T> numbers)
    {
        foreach (var item in numbers)
        {
            yield return item;
        }
    }
}