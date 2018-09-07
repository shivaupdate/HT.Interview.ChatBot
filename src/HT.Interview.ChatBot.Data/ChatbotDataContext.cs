using HT.Interview.ChatBot.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

        /// <summary>
        /// Intent model
        /// </summary>
        public virtual DbSet<Intent> Intent { get; set; }

        /// <summary>
        /// Intent Suggestion model
        /// </summary>
        public virtual DbSet<IntentSuggestion> IntentSuggestion { get; set; }

        /// <summary>
        /// Intent Training Phrase model
        /// </summary>
        public virtual DbSet<IntentTrainingPhrase> IntentTrainingPhrase { get; set; }

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

            EntityTypeBuilder<Intent> intent = modelBuilder.Entity<Intent>().ToTable("Intent", "icb");
            intent.Property(i => i.Id);
            intent.HasMany(i => i.IntentTrainingPhrase);
            intent.HasMany(i => i.IntentSuggestion);

            modelBuilder.Entity<IntentSuggestion>().ToTable("IntentSuggestion", "icb").Property(t => t.Id);
            modelBuilder.Entity<IntentTrainingPhrase>().ToTable("IntentTrainingPhrase", "icb").Property(t => t.Id);
        }
    }
}
