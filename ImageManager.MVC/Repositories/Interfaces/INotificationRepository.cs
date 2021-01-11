using ImageManager.MVC.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ImageManager.MVC.Repositories.Interfaces
{
    public interface INotificationRepository
    {
        /// <summary>
        /// Get notice by id.
        /// </summary>
        /// <param name="noticeId">The notice id.</param>
        /// <returns>Notice.</returns>
        Task<Notice> GetByIdAsync(int noticeId);

        /// <summary>
        /// Get all notices from database.
        /// </summary>
        /// <returns>All notices.</returns>
        IQueryable<Notice> GetAll();

        /// <summary>
        /// Delete notice by id.
        /// </summary>
        /// <param name="noticeId">The notice id.</param>
        Task DeleteAsync(int noticeId);

        /// <summary>
        /// Create new notice.
        /// </summary>
        /// <param name="notice">The notice for create.</param>
        /// <returns>Created notice.</returns>
        Task<Notice> CreateAsync(Notice notice);

        /// <summary>
        /// Update notice.
        /// </summary>
        /// <param name="notice">The notice for update.</param>
        /// <returns>Updated notice.</returns>
        Task<Notice> UpdateAsync(Notice notice);
    }
}
