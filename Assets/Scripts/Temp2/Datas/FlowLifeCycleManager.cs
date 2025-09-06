/*namespace GameSystems.Datas
{
    public interface IFlowLifeCycleManager
    {
        public IFlowReferencHandler FlowReferencHandler { get; }
        public void LoadFlows(LifeCycleType lifeCycleType, IModuleReferenceHandler moduleReferenceHandler);
        public void UnLoadFlows(LifeCycleType lifeCycleType);
    }

    public class FlowLifeCycleManager : IFlowLifeCycleManager
    {
        private IFlowReferencHandler flowReferencHandler;

        public FlowLifeCycleManager()
        {
            this.flowReferencHandler = new FlowReferencHandler();
        }

        public IFlowReferencHandler FlowReferencHandler { get => flowReferencHandler; }

        public void LoadFlows(LifeCycleType lifeCycleType, IModuleReferenceHandler moduleReferenceHandler)
        {
            if (this.flowReferencHandler == null)
            {
                UnityEngine.Debug.LogError($"FlowLifeCycleManager 필드 멤버 명시 안됨.");
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

        public void UnLoadFlows(LifeCycleType lifeCycleType)
        {
            if (this.flowReferencHandler == null)
            {
                UnityEngine.Debug.LogError($"FlowLifeCycleManager 필드 멤버 명시 안됨.");
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