using G10_Saidmurodov_Bekmurod.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G10_Saidmurodov_Bekmurod.Services.Extension_Methods;

public static  class MusicDtoExtensionMethods
{
    public static void MBToGB(this MusicDto music)
    {
        music.MB *= 1024;
    }
    
    


    public static int GetTotalLikesOfMusics(this List<MusicDto> musics)
    {
        var total = 0;
        foreach (var music in musics)
        {
            total += music.QuentityLikes;
        }

        return total;
    }


}
