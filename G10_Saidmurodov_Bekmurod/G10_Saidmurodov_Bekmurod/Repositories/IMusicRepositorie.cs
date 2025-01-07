using G10_Saidmurodov_Bekmurod.DataAccess.Entities;

namespace G10_Saidmurodov_Bekmurod.Repositories;

public interface IMusicRepositorie
{
    
    public List<Music> GetAllMusics();
    public Guid AddMusic(Music music);
    public Music GetMusicById(Guid id);
    public void DeleteMusic(Guid id);
    public void UpdateMusic(Music music);
}