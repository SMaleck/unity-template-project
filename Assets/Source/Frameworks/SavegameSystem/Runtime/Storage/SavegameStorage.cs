using System;
using System.Collections.Generic;
using System.Linq;
using Source.Frameworks.SavegameSystem.Runtime.Logging;
using Source.Frameworks.SavegameSystem.Runtime.Serializable;
using Source.Frameworks.SavegameSystem.Runtime.Storage.Dal;
using Source.Frameworks.SavegameSystem.Runtime.Storage.Middlewares;
using Source.Frameworks.SavegameSystem.Runtime.Storage.Middlewares.PostRead;
using Source.Frameworks.SavegameSystem.Runtime.Storage.Middlewares.PreWrite;
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
        private readonly ISavegamePostReadMiddleware[] _postReadMiddlewares;
        private readonly ISavegamePreWriteMiddleware[] _preWriteMiddlewares;
        private readonly ISavegameWriteMiddleware[] _writeMiddlewares;

        public SavegameStorage(
            ISavegameLogger logger,
            ISavegameReader reader,
            ISavegameWriter writer,
            IMigrationProcessor migrationProcessor,
            ISerializationProcessor serializationProcessor,
            List<ISavegameStorageMiddleware> middlewares)
        {
            _logger = logger;
            _reader = reader;
            _writer = writer;
            _migrationProcessor = migrationProcessor;
            _serializationProcessor = serializationProcessor;

            var groupedMiddlewares = middlewares
                .GroupBy(e => e.GetType())
                .ToDictionary(g => g.Key, g => g.ToArray());

            _readMiddlewares = GetMiddleware<ISavegameReadMiddleware>(groupedMiddlewares);
            _postReadMiddlewares = GetMiddleware<ISavegamePostReadMiddleware>(groupedMiddlewares);
            _preWriteMiddlewares = GetMiddleware<ISavegamePreWriteMiddleware>(groupedMiddlewares);
            _writeMiddlewares = GetMiddleware<ISavegameWriteMiddleware>(groupedMiddlewares);
        }

        private T[] GetMiddleware<T>(Dictionary<Type, ISavegameStorageMiddleware[]> middlewares) 
            where T : ISavegameStorageMiddleware
        {
            return middlewares[typeof(T)]
                .Cast<T>()
                .OrderBy(e => e.ExecutionOrder)
                .ToArray();
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
