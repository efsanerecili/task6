namespace Core
{
    public class CustomList<T>

    {
        private T[] _items;
        private int _capacity;
        private int _count;

        public int Capacity => _capacity;
        public int Count => _count;

        public CustomList()
        {
            _capacity = 4;
            _items = new T[_capacity];
            _count = 0;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
                    throw new ArgumentOutOfRangeException(nameof(index));
                return _items[index];
            }
            set
            {
                if (index < 0 || index >= _count)
                    throw new ArgumentOutOfRangeException(nameof(index));
                _items[index] = value;
            }
        }

        public void Add(T item)
        {
            if (_count == _capacity)
            {
                _capacity *= 2;
                Array.Resize(ref _items, _capacity);
            }
            _items[_count++] = item;
        }

        public T Find(Predicate<T> match)
        {
            foreach (T item in _items)
            {
                if (match(item))
                    return item;
            }
            return default(T);
        }

        public List<T> FindAll(Predicate<T> match)
        {
            List<T> foundItems = new List<T>();
            foreach (T item in _items)
            {
                if (match(item))
                    foundItems.Add(item);
            }
            return foundItems;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(_items[i], item))
                {
                    RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public int RemoveAll(Predicate<T> match)
        {
            int removedCount = 0;
            for (int i = 0; i < _count; i++)
            {
                if (match(_items[i]))
                {
                    RemoveAt(i);
                    removedCount++;
                    i--; // Bir önceki indekse dön
                }
            }
            return removedCount;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException(nameof(index));
            for (int i = index; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }
            _count--;
        }

        public void ForEach(Action<T> action)
        {
            foreach (var item in _items)
            {
                action(item);
            }
        }
    }





}
