namespace EFCoreOperatinsApp.Data
{
    public class BookPrice
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public double Amount { get; set; }
        public int CurrencyId { get; set; }
        
        public Book Book { get; set; }
        public Currency CurrencyType { get; set; }
    }
}
