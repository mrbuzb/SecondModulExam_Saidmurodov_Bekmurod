using G10_Saidmurodov_Bekmurod.Services.DTO_s;

namespace G10_Saidmurodov_Bekmurod.Services;

public interface IMusicService
{
     Guid AddMusic(musicCreateDto music);
     void DeleteMusic(Guid id);
     void UpdateMusic(MusicDto music);
     MusicDto GetMudsicById(Guid id);
     List<MusicDto> GetAllMusics();
     List<MusicDto> GetAllMusicByAuthorName(string name);
     MusicDto GetMostLikedMusic();
     MusicDto GetMusicByName(string name);
     List<MusicDto> GetAllMusicAboveSize(double minSize);
     List<MusicDto> GetAllMusicBeloveSize(double minSize);
     List<MusicDto> GetTopMostLikedMusic(int count);
     List<MusicDto> GetMusicByDescriptionKeyword(string keyword);
     List<MusicDto> GetMusicWithLikesInRange(int minLikes, int maxLikes);
     List<string> GetAllUniqueAuthors();
    double GetTotalMusicSizeByAuthor(string authorName);
}