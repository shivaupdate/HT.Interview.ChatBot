using HT.Interview.ChatBot.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace HT.Interview.ChatBot.Data
{
    /// <inheritdoc />
    /// <summary>
    /// Master Data Context
    /// </summary>
    public class ChatbotDataContext : DbContext, IChatbotDataContext
    {
        private readonly string _connectionString;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public ChatbotDataContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <inheritdoc />
        /// <summary>
        /// User entity
        /// </summary>
        public virtual DbSet<User> User { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// On configuring
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_connectionString);
        }

        /// <inheritdoc />
        /// <summary>
        /// On model creating
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User", "dbo").Property(t => t.Id);
        }
    }
}
