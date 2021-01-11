namespace ImageManager.MVC.Models
{
    public class Notice
    {
        /// <summary>
        /// Notice id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Has the notice been read.
        /// </summary>
        public bool HasRead { get; set; }

        /// <summary>
        /// Subscription id.
        /// </summary>
        public int SubscriptionId { get; set; }

        /// <summary>
        /// Subscription.
        /// </summary>
        public Subscription Subscription { get; set; }

        /// <summary>
        /// Image id for the notice.
        /// </summary>
        public int ImageId { get; set; }

        /// <summary>
        /// Image for the notice.
        /// </summary>
        public Image Image { get; set; }
    }
}
