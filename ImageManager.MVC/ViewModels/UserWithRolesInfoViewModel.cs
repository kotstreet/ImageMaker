namespace ImageManager.MVC.ViewModels
{
    public class UserWithRolesInfoViewModel
    {
        /// <summary>
        /// User id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// User email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User fullname.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Is user has admin role.
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Is user has user role.
        /// </summary>
        public bool IsUser { get; set; }

        /// <summary>
        /// Is user active on site.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Is admin has subscription for a user.
        /// </summary>
        public bool HasSubscription { get; set; }
    }
}
