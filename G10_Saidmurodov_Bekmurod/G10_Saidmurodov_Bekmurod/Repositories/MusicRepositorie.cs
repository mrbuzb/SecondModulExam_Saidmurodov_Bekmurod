using G10_Saidmurodov_Bekmurod.DataAccess.Entities;
using System.Text.Json;

namespace G10_Saidmurodov_Bekmurod.Repositories;

public class MusicRepositorie : IMusicRepositorie
{

    private List<Music> _musics;
    private string _path;

    public MusicRepositorie()
    {
        _musics = new List<Music>();
        _path = "../../../DataAccess/Data/Music.json";

        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }
        _musics = GetAllMusics();
    }

    private void SaveInformation()
    {
        var musicsJson = JsonSerializer.Serialize(_musics);
        File.WriteAllText(_path, musicsJson);
    }
    
    public List<Music> GetAllMusics()
    {
        var musicsJson = File.ReadAllText(_path);
        return JsonSerializer.Deserialize<List<Music>>(musicsJson);
    }

    public Guid AddMusic(Music music)
    {
        _musics.Add(music);
        SaveInformation();
        return music.Id;
    }

    public Music GetMusicById(Guid id)
    {
        foreach (var music in _musics)
        {
            if (music.Id.Equals(id))
            {
                return music;
            }
        }
        throw new Exception("Music Not Found");
    }

    public void DeleteMusic(Guid id)
    {
        var musicByID = GetMusicById(id);
        _musics.Remove(musicByID);
        SaveInformation();
    }

    public void UpdateMusic(Music music)
    {
        var musicById = GetMusicById(music.Id);
        _musics[_musics.IndexOf(musicById)] = music;
        SaveInformation();
    }

    

}
