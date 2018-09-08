using HT.Interview.ChatBot.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace HT.Interview.ChatBot.Data
{
    /// <inheritdoc />
    /// <summary>
    /// ChatBot Data Context
    /// </summary>
    public class ChatBotDataContext : DbContext, IChatBotDataContext
    {
        private readonly string _connectionString;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public ChatBotDataContext(string connectionString)
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
        /// Role entity
        /// </summary>
        public virtual DbSet<Role> Role { get; set; }

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
            modelBuilder.Entity<User>().ToTable("User", "icb").Property(t => t.Id);
            modelBuilder.Entity<Role>().ToTable("Role", "icb").Property(t => t.Id);
        }
    }
}
