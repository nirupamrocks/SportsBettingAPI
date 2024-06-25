using HtmlAgilityPack;
using SportsBettingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SportsBettingAPI.Services
{
    public class MLBStatsService
    {
        private const string BaseballReferenceUrl = "https://www.baseball-reference.com/";

        public async Task<MLBTeamStats> GetMLBTeamStatsAsync(string team)
        {
            var teamStats = new MLBTeamStats();

            // Construct URL for the team's stats page on Baseball Reference
            string teamStatsUrl = $"{BaseballReferenceUrl}/teams/{team.ToLower()}/2024.shtml"; // Example URL for 2024 season

            // Fetch HTML content from the URL
            var htmlWeb = new HtmlWeb();
            var htmlDocument = await htmlWeb.LoadFromWebAsync(teamStatsUrl);

            // Parse HTML to extract stats
            var battingAverageNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@id='div_team_batting']//td[contains(@data-stat, 'batting_avg')]");
            if (battingAverageNode != null)
            {
                teamStats.BattingAverage = double.Parse(battingAverageNode.InnerText.Trim());
            }

            // Add more parsing logic for other stats like ERA, etc.

            return teamStats;
        }
    }
}
