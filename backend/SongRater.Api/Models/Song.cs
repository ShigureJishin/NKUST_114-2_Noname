using System.ComponentModel.DataAnnotations;

namespace SongRater.Api.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Artist { get; set; } = string.Empty;
        public double FinalScore { get; set; } // 最終平均分
        public int VoteCount { get; set; }     // 總投票人數
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}