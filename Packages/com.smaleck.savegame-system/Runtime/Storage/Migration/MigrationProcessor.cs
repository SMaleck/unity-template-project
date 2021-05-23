using System.Collections.Generic;
using System.Linq;

namespace SavegameSystem.Storage.Migration
{
    // ToDo SAVE Implement Migration
    // ToDo SAVE Update Version
    public class MigrationProcessor : IMigrationProcessor
    {
        private readonly IReadOnlyList<ISavegameMigration> _migrations;

        public MigrationProcessor(List<ISavegameMigration> migrations)
        {
            _migrations = migrations.OrderBy(e => e.Version).ToArray();
        }

        public string Process(string savegameJson)
        {
            return savegameJson;
        }
    }
}
