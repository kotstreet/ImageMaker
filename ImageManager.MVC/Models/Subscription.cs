namespace ImageManager.MVC.Models
{
    public class Subscription
    {
        /// <summary>
        /// Subscription id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id of user who will get notification.
        /// </summary>
        public string AdminId { get; set; }

        /// <summary>
        /// Id of user will give notification.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Is that subscription actual.
        /// </summary>
        public bool IsActual { get; set; }
    }
}
