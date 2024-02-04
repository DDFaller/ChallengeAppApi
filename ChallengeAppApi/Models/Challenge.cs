using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Mono.TextTemplating;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChallengeAppApi.Models
{
    [Table("Challenges")]
    public class ChallengeEntity
    {
        public ChallengeEntity(string name, int? difficultyLevel, string? description, int? duration, DateTime? startedAt, string? githubLink)
        {
            Name = name;
            DifficultyLevel = difficultyLevel;
            Description = description;
            Duration = duration;
            StartedAt = startedAt;
            GithubLink = githubLink;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? DifficultyLevel { get; set; }
        public string? Description { get; set; }
        public int? Duration { get; set; }
        public DateTime? StartedAt { get; set; }
        public string? GithubLink { get; set; }
    }

    public class ChallengeModel
    {
        [Required(ErrorMessage = "Please provide a challenge name")]
        public string Name { get; set; }
        public int? DifficultyLevel { get; set; }
        public string? Description { get; set; }
        public int? Duration { get; set; }
        public DateTime? StartedAt { get; set; }
        public string? GithubLink { get; set; }
    }
}