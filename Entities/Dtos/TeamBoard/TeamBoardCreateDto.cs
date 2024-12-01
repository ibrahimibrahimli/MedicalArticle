using Entities.TableModels;

namespace Entities.Dtos
{
    public class TeamBoardCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Profession { get; set; }
        public string PhotoUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public string InstagramUrl { get; set; }
        public bool IsHomePage { get; set; }

        public static TeamBoard ToTeamBoard(TeamBoardCreateDto dto)
        {
            TeamBoard teamBoard = new TeamBoard()
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Profession = dto.Profession,
                PhotoUrl = dto.PhotoUrl,
                FacebookUrl = dto.FacebookUrl,
                LinkedinUrl = dto.LinkedinUrl,
                InstagramUrl = dto.InstagramUrl,
                IsHomePage = dto.IsHomePage,
            };
            return teamBoard;
        }
    }
}
