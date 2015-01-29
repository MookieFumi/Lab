namespace lab.crosscutting
{
    public interface IJsonSerializer
    {
        string SerializeObject(object value);
    }
}