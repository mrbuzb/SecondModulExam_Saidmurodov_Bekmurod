using G10_Saidmurodov_Bekmurod.DataAccess.Entities;
using G10_Saidmurodov_Bekmurod.Repositories;
using G10_Saidmurodov_Bekmurod.Services.DTO_s;

namespace G10_Saidmurodov_Bekmurod.Services;

public class MusicService : IMusicService
{
    private IMusicRepositorie _musicRepo;
    public MusicService()
    {
        _musicRepo = new MusicRepositorie();
    }

    private void MusicInvalidation(musicCreateDto music)
    {
        if (music.Name.Length == 0 || music.Name.Length > 50)
        {
            throw new Exception("Invalid Name");
        }
        if (music.AuthorName.Length == 0 || music.AuthorName.Length > 50)
        {
            throw new Exception("Invalid Author Name");
        }
        if (music.Description.Length > 1000)
        {
            throw new Exception("Long Description");
        }
        if(music.QuentityLikes <0 ||music.MB < 0)
        {
            throw new Exception("Invalid Music");
        }
    }


    public Guid AddMusic(musicCreateDto music)
    {
        MusicInvalidation(music);
        var baseMusic = ConvertMusic(music);
        baseMusic.Id = Guid.NewGuid();
        _musicRepo.AddMusic(baseMusic);
        return baseMusic.Id;
    }

    public void DeleteMusic(Guid id)
    {
        _musicRepo.DeleteMusic(id);
    }

    public void UpdateMusic(MusicDto music)
    {
        _musicRepo.UpdateMusic(ConvertMusic(music));
    }

    public MusicDto GetMudsicById(Guid id)
    {
        return ConvertMusic(_musicRepo.GetMusicById(id));
    }
    public List<MusicDto> GetAllMusics()
    {
        var allMusics = _musicRepo.GetAllMusics();
        var musicsList = new List<MusicDto>();
        foreach (var music in allMusics)
        {
            musicsList.Add(ConvertMusic(music));
        }
        return musicsList;
    }

    public List<MusicDto> GetAllMusicByAuthorName(string name)
    {
        var musicsOfSameAuthor = new List<MusicDto>();

        foreach (var music in GetAllMusics())
        {
            if (music.AuthorName == name)
            {
                musicsOfSameAuthor.Add(music);
            }
        }

        return musicsOfSameAuthor;
    }

    public MusicDto GetMostLikedMusic()
    {
        var mostLikedMusic = new MusicDto();
        foreach (var music in GetAllMusics())
        {
            if(music.QuentityLikes > mostLikedMusic.QuentityLikes)
            {
                mostLikedMusic = music;
            }
        }

        return mostLikedMusic;
    }

    public MusicDto GetMusicByName(string name)
    {
        foreach (var music in GetAllMusics())
        {
            if(music.Name == name)
            {
                return music;
            }
        }
        throw new Exception("Music Not Found");
    }

    public List<MusicDto> GetAllMusicAboveSize(double minSize)
    {
        var list = new List<MusicDto>();
        foreach(var music in GetAllMusics())
        {
            if(music.MB > minSize)
            {
                list.Add(music);
            }
        }

        return list;
    }
    public List<MusicDto> GetAllMusicBeloveSize(double minSize)
    {
        var list = new List<MusicDto>();
        foreach(var music in GetAllMusics())
        {
            if(music.MB < minSize)
            {
                list.Add(music);
            }
        }

        return list;
    }
    
    public List<MusicDto>GetTopMostLikedMusic(int count)
    {
        var list = new List<MusicDto>();
        var mostLikes = 0d;
        foreach (var music in GetAllMusics())
        {
            if(music.MB > mostLikes)
            {
                mostLikes = music.MB;
            }
        }

        foreach (var music in GetAllMusics())
        {
            if (music.MB == mostLikes)
            {
                list.Add(music);
            }
            if(list.Count == count)
            {
                return list;
            }
        }
        return list;
    }

    public List<MusicDto> GetMusicByDescriptionKeyword(string keyword)
    {
        var list = new List<MusicDto>();
        foreach (var music in GetAllMusics())
        {
            if (music.Description.Contains(keyword))
            {
                list.Add(music);
            }
        }

        return list;
    }

    public List<MusicDto>GetMusicWithLikesInRange(int minLikes,int maxLikes)
    {
        var list = new List<MusicDto>();    
        foreach (var music in GetAllMusics())
        {
            if(music.QuentityLikes >=minLikes&&music.QuentityLikes <= maxLikes)
            {
                list.Add(music);
            }
        }

        return list;
    }

    public List<string> GetAllUniqueAuthors()
    {
        var list = new List<string>();
        foreach (var music in GetAllMusics())
        {
            foreach(var letter in music.AuthorName)
            {
                if (!char.IsLetter(letter))
                {
                    if(letter !=' ')
                    {
                        list.Add(music.AuthorName);
                        break;
                    }
                }
            }
        }

        return list;
    }

    public double GetTotalMusicSizeByAuthor(string authorName)
    {
        var total = 0d;
        foreach (var music in GetAllMusics())
        {
            if(music.AuthorName == authorName)
            {
                total += music.MB;
            }
        }

        return total;
    }
    

    private Music ConvertMusic(MusicDto music)
    {
        return new Music
        {
            Id = music.Id,
            Name = music.Name,
            MB = music.MB,
            AuthorName = music.AuthorName,
            Description = music.Description,
            QuentityLikes = music.QuentityLikes,
        };
    }
    private MusicDto ConvertMusic(Music music)
    {
        return new MusicDto
        {
            Id = music.Id,
            Name = music.Name,
            MB = music.MB,
            AuthorName = music.AuthorName,
            Description = music.Description,
            QuentityLikes = music.QuentityLikes,
        };
    }



    private Music ConvertMusic(musicCreateDto music)
    {
        return new Music
        {
            Name = music.Name,
            MB = music.MB,
            AuthorName = music.AuthorName,
            Description = music.Description,
            QuentityLikes = music.QuentityLikes,
        };
    }

}
