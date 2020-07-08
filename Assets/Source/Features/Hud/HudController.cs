using Source.Framework.Util.UniRx;

namespace Source.Features.Hud
{
    public class HudController : AbstractDisposable
    {
        private readonly HudView _hudView;

        public HudController(HudView hudView)
        {
            _hudView = hudView;
        }
    }
}
