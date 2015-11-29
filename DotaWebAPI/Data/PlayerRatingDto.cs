namespace Data
{
    public class PlayerRatingDto:BaseDto
    {
        public PlayerRating Rating { get; set; }
    }

    public class PlayerRating
    {
        public int PlayerId { get; set; }
        public int Rating { get; set; }
        public int MatchCount { get; set; } 
    }
}
