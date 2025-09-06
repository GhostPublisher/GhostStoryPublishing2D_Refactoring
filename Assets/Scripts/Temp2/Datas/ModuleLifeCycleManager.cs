/*namespace GameSystems.Datas
{
    public interface IModuleLifeCycleManager
    {
        public IModuleReferenceHandler ModuleReferenceHandler { get; }
        public void LoadMoudles(LifeCycleType lifeCycleType);
        public void UnLoadModules(LifeCycleType lifeCycleType);
    }

    public class ModuleLifeCycleManager : IModuleLifeCycleManager
    {
        private IModuleReferenceHandler moduleReferenceHandler;

        public ModuleLifeCycleManager()
        {
            this.moduleReferenceHandler = new ModuleReferenceHandler();
        }

        public IModuleReferenceHandler ModuleReferenceHandler { get => moduleReferenceHandler; }

        public void LoadMoudles(LifeCycleType lifeCycleType)
        {
            if (this.moduleReferenceHandler == null)
            {
                UnityEngine.Debug.LogError($"ModuleLifeCycleManager의 필드 멤버 명시 안됨.");
                return;
            }

            switch (lifeCycleType)
            {
                case LifeCycleType.LobbyScene:
                    break;
                case LifeCycleType.BattleScene:
                    break;
                default:
                    break;
            }
        }

        public void UnLoadModules(LifeCycleType lifeCycleType)
        {
            if (this.moduleReferenceHandler == null)
            {
                UnityEngine.Debug.LogError($"ModuleLifeCycleManager의 필드 멤버 명시 안됨.");
                return;
            }

            switch (lifeCycleType)
            {
                case LifeCycleType.LobbyScene:
                    break;
                case LifeCycleType.BattleScene:
                    break;
                default:
                    break;
            }
        }
    }
}
*/