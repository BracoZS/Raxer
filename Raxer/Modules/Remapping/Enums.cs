using System;
using System.Collections.Generic;
using System.Text;

namespace Raxer.Modules.Remapping;

public enum FilterMode
{
    None = 0,  // Sin filtro (todo pasa)
    Whitelist, // Bloquea todo EXCEPTO lo de la lista
    Blacklist  // Bloquea SOLO lo de la lista
}
