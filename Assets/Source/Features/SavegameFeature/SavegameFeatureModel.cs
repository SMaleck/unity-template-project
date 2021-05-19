using Newtonsoft.Json;
using SavegameSystem.Serializable;
using Source.Services.SavegameSystem;
using Source.Services.SavegameSystem.Serializable;
using System.Text;
using UtilitiesGeneral.Logging;

namespace Source.Features.SavegameFeature
{
    public class SavegameFeatureModel
    {
        public SavegameFeatureModel(
            Savegame<SavegameContent> savegame,
            ISavegameService savegameService)
        {
            var savegameJson = JsonConvert.SerializeObject(savegame, Formatting.Indented);

            var sb = new StringBuilder()
                .AppendLine("CURRENT SAVEGAME:")
                .AppendLine($"{savegameJson}");

            StaticLogger.Log(sb.ToString());

            savegameService.Save();
        }
    }
}
