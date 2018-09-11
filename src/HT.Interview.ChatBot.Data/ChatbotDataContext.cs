using HT.Interview.ChatBot.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model = HT.Interview.ChatBot.Common.Entities;

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
        /// Intent Competence Mapping model
        /// </summary>
        public virtual DbSet<IntentCompetenceMapping> IntentCompetenceMapping { get; set; }

        /// <summary>
        /// Intent Training Phrase model
        /// </summary>
        public virtual DbSet<IntentTrainingPhrase> IntentTrainingPhrase { get; set; }

        /// <summary>
        /// Intent Parameter model
        /// </summary>
        public virtual DbSet<IntentParameter> IntentParameter { get; set; }

        /// <summary>
        /// Intent Suggestion model
        /// </summary>
        public virtual DbSet<IntentSuggestion> IntentSuggestion { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Role entity
        /// </summary>
        public virtual DbSet<Role> Role { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// InterviewTypeCompetenceMapping entity
        /// </summary>
        public virtual DbSet<InterviewTypeCompetenceMapping> InterviewTypeCompetenceMapping { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Gender entity
        /// </summary>
        public virtual DbSet<Gender> Gender { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Employee entity
        /// </summary>
        public virtual DbSet<Employee> Employee { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// CompetenceLevel entity
        /// </summary>
        public virtual DbSet<CompetenceLevel> CompetenceLevel { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Role entity
        /// </summary>
        public virtual DbSet<Competence> Competence { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Candidate entity
        /// </summary>
        public virtual DbSet<Candidate> Candidate { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Attachment entity
        /// </summary>
        public virtual DbSet<Attachment> Attachment { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Menu entity
        /// </summary>
        public virtual DbSet<Menu> Menu { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// InterviewType entity
        /// </summary>
        public virtual DbSet<InterviewType> InterviewType { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// AccessMatrix entity
        /// </summary>
        public virtual DbSet<AccessMatrix> AccessMatrix { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Interview entity
        /// </summary>
        public virtual DbSet<Model.Interview> Interview { get; set; }

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
            modelBuilder.Entity<User>().ToTable("User", "icb").HasKey(t => t.Id);


            EntityTypeBuilder<Intent> intent = modelBuilder.Entity<Intent>().ToTable("Intent", "icb");
            intent.HasKey(i => i.Id);
            intent.Property(i => i.Id).ValueGeneratedOnAdd();
            intent.HasMany(i => i.IntentCompetenceMapping);
            intent.HasMany(i => i.IntentTrainingPhrase);
            intent.HasMany(i => i.IntentParameter);
            intent.HasMany(i => i.IntentSuggestion);

            modelBuilder.Entity<IntentCompetenceMapping>().ToTable("IntentCompetenceMapping", "icb")
                 .HasKey(t => new { t.IntentId, t.CompetenceId, t.CompetenceLevelId });


            modelBuilder.Entity<IntentTrainingPhrase>().ToTable("IntentTrainingPhrase", "icb").HasKey(t => t.Id);
            modelBuilder.Entity<IntentParameter>().ToTable("IntentParameter", "icb").HasKey(t => t.Id);
            modelBuilder.Entity<IntentSuggestion>().ToTable("IntentSuggestion", "icb").HasKey(t => t.Id);


            modelBuilder.Entity<Role>().ToTable("Role", "icb").HasKey(t => t.Id);
            modelBuilder.Entity<InterviewTypeCompetenceMapping>().ToTable("InterviewTypeCompetenceMapping", "icb")
                .HasKey(t => new { t.InterviewTypeId, t.CompetenceId });

            modelBuilder.Entity<Gender>().ToTable("Gender", "icb").HasKey(t => t.Id);
            modelBuilder.Entity<Employee>().ToTable("Employee", "icb").HasKey(t => t.Id);
            modelBuilder.Entity<CompetenceLevel>().ToTable("CompetenceLevel", "icb").HasKey(t => t.Id);
            modelBuilder.Entity<Competence>().ToTable("Competence", "icb").HasKey(t => t.Id);
            modelBuilder.Entity<Candidate>().ToTable("Candidate", "icb").HasKey(t => t.Id);
            modelBuilder.Entity<Attachment>().ToTable("Attachment", "icb").HasKey(t => t.Id);
            modelBuilder.Entity<Menu>().ToTable("Menu", "icb").HasKey(t => t.Id);
            modelBuilder.Entity<InterviewType>().ToTable("InterviewType", "icb").HasKey(t => t.Id);
            modelBuilder.Entity<AccessMatrix>().ToTable("AccessMatrix", "icb").HasKey(t => t.Id);

            EntityTypeBuilder<Model.Interview> interview = modelBuilder.Entity<Model.Interview>().ToTable("Interview", "icb");
            interview.HasKey(t => t.Id);
            interview.Property(i => i.Id).ValueGeneratedOnAdd();

        }
    }
}
