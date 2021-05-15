using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Source.Frameworks.SavegameSystem.Serializable;
using Source.Services.SavegameSystem.Serialization;

namespace Source.Services.SavegameSystem
{
    public class SavegameService : ISavegameService
    {
        public SavegameService()
        {

        }

        public ISavegame<SavegameContent> Load()
        {
            return null;
        }

        public void Save()
        {

        }
    }
}
