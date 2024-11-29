using Entities.TableModels;

namespace Entities.Dtos
{
    public class TeamBoardUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Profession { get; set; }
        public string PhotoUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public string InstagramUrl { get; set; }

        public static TeamBoard ToTeamBoard(TeamBoardUpdateDto dto)
        {
            TeamBoard teamBoard = new TeamBoard()
            {
                Id = dto.Id,
                Name = dto.Name,
                Surname = dto.Surname,
                Profession = dto.Profession,
                PhotoUrl = dto.PhotoUrl,
                FacebookUrl = dto.FacebookUrl,
                LinkedinUrl = dto.LinkedinUrl,
                InstagramUrl = dto.InstagramUrl,
            };
            return teamBoard;
        }
    }
}
