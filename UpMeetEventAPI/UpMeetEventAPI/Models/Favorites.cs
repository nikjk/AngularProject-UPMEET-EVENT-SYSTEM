using System;
using System.Collections.Generic;

namespace UpMeetEventAPI.Models;

public partial class Favorites
{
    public int Userid { get; set; }

    public int? Eventid { get; set; }

    public string Username { get; set; }

    public bool? IsFavorite { get; set; }

    public virtual Event? Event { get; set; }
}
