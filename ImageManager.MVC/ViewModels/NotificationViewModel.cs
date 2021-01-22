namespace ImageManager.MVC.ViewModels
{
    public class NotificationViewModel
    {
        /// <summary>
        /// Notice id.
        /// </summary>
        public int NotificationId { get; set; }

        /// <summary>
        /// User email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User full name.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Has notification read.
        /// </summary>
        public bool HasRead { get; set; }
    }
}
