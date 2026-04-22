using System.ComponentModel.DataAnnotations;

namespace SongRater.Api.Models
{
    public class Vote
    {
        [Key]
        public int Id { get; set; }
        public int SongId { get; set; } // 關聯到哪一首歌
        public string VoterFingerprint { get; set; } = string.Empty; // 防重複投票的觀眾 ID
        public int Score { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}