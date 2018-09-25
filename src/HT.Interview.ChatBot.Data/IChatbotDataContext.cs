using HT.Framework.Contracts;
using HT.Interview.ChatBot.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Model = HT.Interview.ChatBot.Common.Entities;

namespace HT.Interview.ChatBot.Data
{
    /// <summary>
    /// IChatbotDataContext
    /// </summary>
    public interface IChatBotDataContext : IDbContext
    {
        /// <summary>
        /// User model
        /// </summary>
        DbSet<User> User { get; set; }

        /// <summary>
        /// User model
        /// </summary>
        DbSet<UserDetail> UserDetail { get; set; }

        /// <summary>
        /// Intent model
        /// </summary>
        DbSet<Intent> Intent { get; set; }
         
        /// <summary>
        /// Intent Training Phrase model
        /// </summary>
        DbSet<IntentTrainingPhrase> IntentTrainingPhrase { get; set; }

        /// <summary>
        /// Intent Parameter model
        /// </summary>
        DbSet<IntentParameter> IntentParameter { get; set; }

        /// <summary>
        /// Intent Suggestion model
        /// </summary>
        DbSet<IntentSuggestion> IntentSuggestion { get; set; }

        /// <summary>
        /// Role model
        /// </summary>
        DbSet<Role> Role { get; set; }

        /// <summary>
        /// Role Claim Detail model
        /// </summary>
        DbSet<RoleClaimDetail> RoleClaimDetail { get; set; }

        /// <summary>
        /// Menu model
        /// </summary>
        DbSet<Menu> Menu { get; set; }

        /// <summary>
        /// JobProfileCompetenceMapping model
        /// </summary>
        DbSet<JobProfileCompetenceMapping> JobProfileCompetenceMapping { get; set; }

        /// <summary>
        /// JobProfile model
        /// </summary>
        DbSet<JobProfile> JobProfile { get; set; }

        /// <summary>
        /// Gender model
        /// </summary>
        DbSet<Gender> Gender { get; set; }
          
        /// <summary>
        /// Competence model
        /// </summary>
        DbSet<Competence> Competence { get; set; }
          
        /// <summary>
        /// AccessMatrix model
        /// </summary>
        DbSet<AccessMatrix> AccessMatrix { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Interview entity
        /// </summary>
        DbSet<Model.Interview> Interview { get; set; } 
    }
}
