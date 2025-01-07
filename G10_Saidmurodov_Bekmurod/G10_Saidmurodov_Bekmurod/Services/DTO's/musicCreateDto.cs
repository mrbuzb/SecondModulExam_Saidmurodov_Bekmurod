using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G10_Saidmurodov_Bekmurod.Services.DTO_s;

public class musicCreateDto
{
    public string Name { get; set; }
    public double MB { get; set; }
    public string AuthorName { get; set; }
    public string Description { get; set; }
    public int QuentityLikes { get; set; }
}
