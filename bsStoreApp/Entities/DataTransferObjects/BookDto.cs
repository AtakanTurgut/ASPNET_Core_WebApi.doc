namespace Entities.DataTransferObjects
{
    //[Serializable]   ->   (int Id, String Title, decimal Price)
    public record BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}
