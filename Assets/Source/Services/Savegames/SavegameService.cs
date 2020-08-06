using Source.Framework.Logging;
using Source.Framework.Util.UniRx;
using Source.Services.Savegames.Config;
using Source.Services.Savegames.Models;
using Source.Services.Savegames.Storage;
using System;
using UniRx;

namespace Source.Services.Savegames
{
    public class SavegameService : AbstractDisposable, ISavegameService, ISavegamePersistenceService
    {
        private readonly SavegamesConfig _savegamesConfig;
        private readonly ISavegameReader _savegameReader;
        private readonly ISavegameWriter _savegameWriter;

        private readonly SerialDisposable _savegameDisposer;
        private readonly SerialDisposable _saveDisposer;
        private readonly TimeSpan _requestSaveTimeout;

        private SavegameData _savegameData;
        private Savegame _savegame;

        Savegame ISavegameService.Savegame => GetSavegame();

        private ISavegamePersistenceService SavegamePersistenceService => this;

        public SavegameService(
            SavegamesConfig savegamesConfig,
            ISavegameReader savegameReader,
            ISavegameWriter savegameWriter)
        {
            _savegamesConfig = savegamesConfig;
            _savegameReader = savegameReader;
            _savegameWriter = savegameWriter;

            _savegameDisposer = new SerialDisposable().AddTo(Disposer);
            _saveDisposer = new SerialDisposable().AddTo(Disposer);
            _requestSaveTimeout = TimeSpan.FromSeconds(_savegamesConfig.RequestSaveTimeoutSeconds);
        }

        private Savegame GetSavegame()
        {
            if (_savegame == null)
            {
                SavegamePersistenceService.Load();
            }

            return _savegame;
        }

        void ISavegamePersistenceService.Load()
        {
            _savegameData = _savegameReader.Read();
            _savegameData = _savegameData ?? SavegameDataFactory.CreateSavegameData();

            SetupSavegame();
        }

        void ISavegamePersistenceService.EnqueueSaveRequest()
        {
            Logger.Log($"Savegame dirty, saving in {_requestSaveTimeout.TotalSeconds}s");

            _saveDisposer.Disposable = Observable.Timer(_requestSaveTimeout)
                .Subscribe(_ => SavegamePersistenceService.Save());
        }

        void ISavegamePersistenceService.Save()
        {
            _saveDisposer.Disposable?.Dispose();
            _savegameWriter.Write(_savegameData);
        }

        void ISavegameService.Reset()
        {
            _savegameData = SavegameDataFactory.CreateSavegameData();
            SetupSavegame();

            SavegamePersistenceService.Save();
        }

        private void SetupSavegame()
        {
            _savegameDisposer.Disposable?.Dispose();

            _savegame = new Savegame(_savegameData);
            _savegameDisposer.Disposable = _savegame;
        }
    }
}
