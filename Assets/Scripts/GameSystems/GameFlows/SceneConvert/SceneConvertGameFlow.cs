using GameSystems.PlainServices;
using GameSystems.UnityServices;

using GameSystems.DTO;

namespace GameSystems.GameFlows
{
    public interface ISceneConverter : IGameFlow
    {
        public void ConvertToBattleScene(string stageID);
        public void ConvertToBattleScene(int stageID);
    }

    public class SceneConvertGameFlow : ISceneConverter
    {
        // PlainService
        private IScenePayloadService ScenePayloadService;
        private IStringParser StringParser;

        // UnityService
        private ISceneService SceneService;

        public SceneConvertGameFlow(Repository.IPlainServiceRepository PlainServiceRepository, Repository.IUnityServiceRepository UnityServiceRepository)
        {
            if (PlainServiceRepository.TryGetPlainService<ScenePayloadService>(out var service01))
                this.ScenePayloadService = service01;

            if (PlainServiceRepository.TryGetPlainService<StringParser>(out var service02))
                this.StringParser = service02;

            if (UnityServiceRepository.TryGetUnityService<SceneService>(out var service03))
                this.SceneService = service03;
        }

        // 이게 맞는거 같은데, 좀 더 해보다가 repository를 제거할 방법 생각해 볼듯.
        public SceneConvertGameFlow(ISceneService sceneService, IScenePayloadService scenePayloadService,
            IStringParser stringParser)
        {
            this.SceneService = sceneService;
            this.ScenePayloadService = scenePayloadService;
            this.StringParser = stringParser;
        }

        public void ConvertToBattleScene(string stageID)
        {
            string nextSceneName = "BattleScene";
            if (!this.StringParser.TryExtractInt(stageID, out var id)) return;

            // 다음 Scene에 넘길 Payload 등록.
            LobbyToBattleScenePayload lobbyToBattleScenePayload = new LobbyToBattleScenePayload();
            lobbyToBattleScenePayload.CurrentStageID = id;
            this.ScenePayloadService.SetPayload<LobbyToBattleScenePayload>(lobbyToBattleScenePayload);

            this.SceneService.ChangeScene(nextSceneName);
        }

        public void ConvertToBattleScene(int stageID)
        {
            string nextSceneName = "BattleScene";

            // 다음 Scene에 넘길 Payload 등록.
            LobbyToBattleScenePayload lobbyToBattleScenePayload = new LobbyToBattleScenePayload();
            lobbyToBattleScenePayload.CurrentStageID = stageID;
            this.ScenePayloadService.SetPayload<LobbyToBattleScenePayload>(lobbyToBattleScenePayload);

            this.SceneService.ChangeScene(nextSceneName);
        }
    }
}
