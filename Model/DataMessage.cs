namespace CanadaEmployment.Model
{
    public class DataMessage<T>
    {
        public List<T> data { get; set; }
        public Meta meta { get; set; }
    }

    public class Meta
    {
        public int totalRecords { get; set; }
        public int count { get; set; }
    }
}
