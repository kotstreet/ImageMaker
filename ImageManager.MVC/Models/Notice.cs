namespace ImageManager.MVC.Models
{
    public class Notice
    {
        /// <summary>
        /// Notice id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Subscription id.
        /// </summary>
        public int SubscriptionId { get; set; }

        /// <summary>
        /// Image id.
        /// </summary>
        public int ImageId { get; set; }

        /// <summary>
        /// Has the notice been read.
        /// </summary>
        public bool HasRead { get; set; }
    }
}
