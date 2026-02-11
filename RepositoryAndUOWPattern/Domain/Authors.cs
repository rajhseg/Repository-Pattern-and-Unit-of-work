namespace Domain
{
    public class Authors : TEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string PhotoName { get; set; } = string.Empty;

        public string PhotoContent { get; set; } = string.Empty;
    }
}
