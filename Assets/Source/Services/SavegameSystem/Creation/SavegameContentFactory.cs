using Source.Services.SavegameSystem.Serialization;

namespace Source.Services.SavegameSystem.Creation
{
    public class SavegameContentFactory : ISavegameContentFactory
    {
        public SavegameContent Create()
        {
            return new SavegameContent()
            {
            };
        }
    }
}
