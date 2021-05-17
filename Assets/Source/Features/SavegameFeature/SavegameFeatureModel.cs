using Source.Services.SavegameSystem;
using Source.Services.SavegameSystem.Serialization;
using System.Text;
using Source.Frameworks.SavegameSystem.Runtime.Serializable;
using UtilitiesGeneral.Logging;

namespace Source.Features.SavegameFeature
{
    public class SavegameFeatureModel
    {
        public SavegameFeatureModel(
            Savegame<SavegameContent> savegame,
            ISavegameService savegameService)
        {
            var sb = new StringBuilder()
                .AppendLine("CURRENT SAVEGAME:")
                .AppendLine($"{nameof(savegame.Version)}: {savegame.Version}")
                .AppendLine($"{nameof(savegame.CreatedAtUtc)}: {savegame.CreatedAtUtc}")
                .AppendLine($"{nameof(savegame.UpdatedAtUtc)}: {savegame.UpdatedAtUtc}");

            StaticLogger.Log(sb.ToString());

            savegameService.Save();
        }
    }
}
