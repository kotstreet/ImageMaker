using ImageManager.MVC.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageManager.MVC.Models
{
    public class Subscription
    {
        /// <summary>
        /// Subscription id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Is that subscription actual.
        /// </summary>
        public bool IsActual { get; set; }

        /// <summary>
        /// Id of user who will get notification.
        /// </summary>
        public string AdminId { get; set; }

        /// <summary>
        /// User who will get notification
        /// </summary>
        [ForeignKey(DatabaseConstraints.AdminId)]
        public AppUser Admin { get; set; }

        /// <summary>
        /// Id of user who will give notification.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// User who will give notification.
        /// </summary>
        [ForeignKey(DatabaseConstraints.UserId)]
        public AppUser User { get; set; }

        /// <summary>
        /// Notifications for the subscription.
        /// </summary>
        public List<Notice> Notices { get; set; }
    }
}
