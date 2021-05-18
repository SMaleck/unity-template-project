using Source.Frameworks.SavegameSystem.Runtime.Logging;
using Source.Frameworks.SavegameSystem.Runtime.Serializable;
using Source.Frameworks.SavegameSystem.Runtime.Storage.Dal;
using Source.Frameworks.SavegameSystem.Runtime.Storage.Middlewares;
using Source.Frameworks.SavegameSystem.Runtime.Storage.Middlewares.PostRead;
using Source.Frameworks.SavegameSystem.Runtime.Storage.Middlewares.PreWrite;
using Source.Frameworks.SavegameSystem.Runtime.Storage.Middlewares.Read;
using Source.Frameworks.SavegameSystem.Runtime.Storage.Middlewares.Write;
using Source.Frameworks.SavegameSystem.Runtime.Storage.Processors;
using System;
using System.Collections.Generic;
using System.Linq;

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

            _readMiddlewares = FilterMiddleware<ISavegameReadMiddleware>(middlewares);
            _postReadMiddlewares = FilterMiddleware<ISavegamePostReadMiddleware>(middlewares);
            _preWriteMiddlewares = FilterMiddleware<ISavegamePreWriteMiddleware>(middlewares);
            _writeMiddlewares = FilterMiddleware<ISavegameWriteMiddleware>(middlewares);
        }

        private T[] FilterMiddleware<T>(IReadOnlyList<ISavegameStorageMiddleware> middlewares)
            where T : ISavegameStorageMiddleware
        {
            return middlewares
                .OfType<T>()
                .OrderBy(e => e.ExecutionOrder)
                .ToArray();
        }

        public bool TryLoad<T>(out ISavegame<T> savegame)
        {
            savegame = null;

            try
            {
                var savegameJson = _reader.Read();
                savegameJson = ExecuteReadMiddlewares(savegameJson);

                var migratedSavegame = _migrationProcessor.Process(savegameJson);
                savegame = _serializationProcessor.Deserialize<T>(migratedSavegame);

                savegame = ExecutePostReadMiddlewares(savegame);

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
                savegame = ExecutePreWriteMiddlewares(savegame);
                var savegameJson = _serializationProcessor.Serialize<T>(savegame);
                savegameJson = ExecuteWriteMiddlewares(savegameJson);

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

        private string ExecuteReadMiddlewares(string savegame)
        {
            foreach (var mw in _readMiddlewares)
            {
                savegame = mw.Process(savegame);
            }

            return savegame;
        }

        private ISavegame<T> ExecutePostReadMiddlewares<T>(ISavegame<T> savegame)
        {
            foreach (var mw in _postReadMiddlewares)
            {
                savegame = mw.Process(savegame);
            }

            return savegame;
        }

        private ISavegame<T> ExecutePreWriteMiddlewares<T>(ISavegame<T> savegame)
        {
            foreach (var mw in _preWriteMiddlewares)
            {
                savegame = mw.Process(savegame);
            }

            return savegame;
        }

        private string ExecuteWriteMiddlewares(string savegame)
        {
            foreach (var mw in _writeMiddlewares)
            {
                savegame = mw.Process(savegame);
            }

            return savegame;
        }
    }
}
