namespace ShopOnline.Api.Entities
{
    public class Cart
    {
        /// <summary>
        /// Has Relation One to Many to CartItem
        /// </summary>
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
