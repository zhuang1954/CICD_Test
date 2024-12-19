public class Record
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public static class RecordManager
{
    private static List<Record> _records = new();
    private static int _nextId = 1;

    public static List<Record> GetAll()
    {
        return _records;
    }

    public static Record GetById(int id)
    {
        return _records.FirstOrDefault(r => r.Id == id);
    }

    public static void Create(string name)
    {
        _records.Add(new Record { Id = _nextId++, Name = name });
    }

    public static void Update(int id, string name)
    {
        var record = _records.FirstOrDefault(r => r.Id == id);
        if (record != null) record.Name = name;
    }

    public static void Delete(int id)
    {
        var record = _records.FirstOrDefault(r => r.Id == id);
        if (record != null) _records.Remove(record);
    }
}
