using Source.Framework.Logging;
using Source.Framework.Util.UniRx;
using Source.Services.Savegames.Config;
using Source.Services.Savegames.Models;
using Source.Services.Savegames.Storage;
using System;
using UniRx;

namespace Source.Services.Savegames
{
    public class SavegameService : AbstractDisposable, ISavegameService
    {
        private readonly ISavegameConfig _savegameConfig;
        private readonly ISavegameReader _savegameReader;
        private readonly ISavegameWriter _savegameWriter;

        private readonly SerialDisposable _saveDisposer;
        private readonly TimeSpan _requestSaveTimeout;

        private SavegameData _savegameData;

        public SavegameService(
            ISavegameConfig savegameConfig,
            ISavegameReader savegameReader,
            ISavegameWriter savegameWriter)
        {
            _savegameConfig = savegameConfig;
            _savegameReader = savegameReader;
            _savegameWriter = savegameWriter;

            _saveDisposer = new SerialDisposable().AddTo(Disposer);
            _requestSaveTimeout = TimeSpan.FromSeconds(_savegameConfig.RequestSaveTimeoutSeconds);
        }

        public SavegameData Load()
        {
            _savegameData = _savegameReader.Read();
            _savegameData = _savegameData ?? SavegameDataFactory.CreateSavegameData();

            return _savegameData;
        }

        public void EnqueueSaveRequest()
        {
            Logger.Log($"Savegame dirty, saving in {_requestSaveTimeout.TotalSeconds}s");

            _saveDisposer.Disposable = Observable.Timer(_requestSaveTimeout)
                .Subscribe(_ => Save());
        }

        public void Save()
        {
            _saveDisposer.Disposable?.Dispose();
            _savegameWriter.Write(_savegameData);
        }

        void ISavegameService.Reset()
        {
            _savegameData = SavegameDataFactory.CreateSavegameData();
            Save();
        }
    }
}
