using System;
using System.Collections.Generic;
using System.Linq;
using Source.Frameworks.SavegameSystem.Runtime.Logging;
using Source.Frameworks.SavegameSystem.Runtime.Serializable;
using Source.Frameworks.SavegameSystem.Runtime.Storage.Dal;
using Source.Frameworks.SavegameSystem.Runtime.Storage.Middlewares.Read;
using Source.Frameworks.SavegameSystem.Runtime.Storage.Middlewares.Write;
using Source.Frameworks.SavegameSystem.Runtime.Storage.Processors;

// ToDo SAVE make all of this async
namespace Source.Frameworks.SavegameSystem.Runtime.Storage
{
    /// <summary>
    /// Represents a single storage target, e.g. local disk, cloud, etc.
    /// </summary>
    public class SavegameStorage : ISavegameStorage
    {
        private readonly ISavegameLogger _logger;
        private readonly ISavegameReader _reader;
        private readonly ISavegameWriter _writer;
        private readonly IMigrationProcessor _migrationProcessor;
        private readonly ISerializationProcessor _serializationProcessor;
        private readonly ISavegameReadMiddleware[] _readMiddlewares;
        private readonly ISavegameWriteMiddleware[] _writeMiddlewares;

        public SavegameStorage(
            ISavegameLogger logger,
            ISavegameReader reader,
            ISavegameWriter writer,
            IMigrationProcessor migrationProcessor,
            ISerializationProcessor serializationProcessor,
            List<ISavegameReadMiddleware> readMiddlewares,
            List<ISavegameWriteMiddleware> writeMiddlewares)
        {
            _logger = logger;
            _reader = reader;
            _migrationProcessor = migrationProcessor;
            _serializationProcessor = serializationProcessor;
            _readMiddlewares = readMiddlewares.OrderBy(e => e.ExecutionOrder).ToArray();
            _writer = writer;
            _writeMiddlewares = writeMiddlewares.OrderBy(e => e.ExecutionOrder).ToArray();
        }

        public bool TryLoad<T>(out ISavegame<T> savegame)
        {
            savegame = null;

            try
            {
                var savegameJson = _reader.Read();
                var migratedSavegame = _migrationProcessor.Process(savegameJson);
                savegame = _serializationProcessor.Deserialize<T>(migratedSavegame);

                return true;
            }
            catch (Exception e)
            {
                _logger.Error("Failed to Load Savegame");
                _logger.Error(e);

                return false;
            }
        }

        public bool TrySave<T>(ISavegame<T> savegame)
        {
            try
            {
                var savegameJson = _serializationProcessor.Serialize<T>(savegame);

                _writer.Write(savegameJson);
            }
            catch (Exception e)
            {
                _logger.Error("Failed to Save Savegame");
                _logger.Error(e);

                return false;
            }

            return true;
        }
    }
}
