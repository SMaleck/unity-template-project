using Source.Services.SavegameSystem.Serializable;

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
