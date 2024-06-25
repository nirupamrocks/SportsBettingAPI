namespace SportsBettingAPI.Models
{
    public class PinnacleOdds
    {
        public string GameId { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public double HomeTeamOdds { get; set; }
        public double AwayTeamOdds { get; set; }
    }
}
