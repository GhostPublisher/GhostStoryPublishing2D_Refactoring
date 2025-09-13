using System.Collections;

using GameSystems.PlainServices;
using GameSystems.UnityServices;
using GameSystems.Entities;

using GameSystems.DTO;

using GameSystems.Repository;

using UnityEngine;

namespace GameSystems.GameFlows
{
    public interface ISceneConverter : IGameFlow
    {
        public void InitialBinds(IPlainServiceRepository PlainServiceRepository, IUnityServiceRepository UnityServiceRepository, IEntityRepository EntityRepository);
        public void ConvertToBattleScene(int stageID);
    }

    public class LobbyToBattle_SceneConvertGameFlow : ISceneConverter
    {
        private string NextSceneName = "BattleScene";
        // PlainService
        private IScenePayloadService ScenePayloadService;

        // UnityService
        private ISceneService SceneService;
        private ICoroutineRunner CoroutineRunner;
        private IRectTransformMovementService RectTransformMovementService;

        // Unity Entity
        private SceneConvertPanelUIEntity SceneConvertPanelUIEntity;
        private MessageUIEntity MessageUIEntity;

        public LobbyToBattle_SceneConvertGameFlow() { }

        // 해당 메소드는 임시로 만들어 놓은 것. 새로운 기능이 추가될 때마다 Bind 함수 호출부 까지 변경하는 것을 막아줍니다.
        // 다만, GameFlow가 Repository를 의존하게 되므로, 추후에는 반드시 변경이 필요합니다.
        public void InitialBinds(IPlainServiceRepository PlainServiceRepository, IUnityServiceRepository UnityServiceRepository, IEntityRepository EntityRepository)
        {
            if (PlainServiceRepository.TryGetPlainService<ScenePayloadService>(out var scenePayloadService))
                this.ScenePayloadService = scenePayloadService;

            if (UnityServiceRepository.TryGetUnityService<SceneService>(out var sceneService))
                this.SceneService = sceneService;

            if (UnityServiceRepository.TryGetUnityService<CoroutineRunner>(out var coroutine))
                this.CoroutineRunner = coroutine;

            if (UnityServiceRepository.TryGetUnityService<RectTransformMovementService>(out var rectTransformMovementService))
                this.RectTransformMovementService = rectTransformMovementService;

            if (EntityRepository.TryGetEntity<SceneConvertPanelUIEntity>(out var sceneConvertPanelUIEntity))
                this.SceneConvertPanelUIEntity = sceneConvertPanelUIEntity;

            if (EntityRepository.TryGetEntity<MessageUIEntity>(out var messageUIEntity))
                this.MessageUIEntity = messageUIEntity;
        }

/*        public void InitialBinds(ScenePayloadService scenePayloadService, SceneService sceneService)
        {
            this.ScenePayloadService = scenePayloadService;
            this.SceneService = sceneService;
        }*/

        public void ConvertToBattleScene(int stageID)
        {
            this.CoroutineRunner.Run(this.ConvertOperation(stageID));
        }

        private IEnumerator ConvertOperation(int stageID)
        {
            this.MessageUIEntity.MessageText.text = $"BattleScene - Stage {stageID}으로 넘어갑니다.";
            this.MessageUIEntity.RootRectTransform.gameObject.SetActive(true);

            yield return new WaitForSeconds(1f);

            this.MessageUIEntity.RootRectTransform.gameObject.SetActive(false);

            yield return new WaitForSeconds(0.5f);

            yield return this.CoroutineRunner.Run(
                this.RectTransformMovementService.MoveEaseLinear_ForTransform(
                    this.SceneConvertPanelUIEntity.RootRectTransform,
                    this.SceneConvertPanelUIEntity.SceneConvertPanelUIEntityModel.AnimationPositionEntityModel.ShowPosition,
                    this.SceneConvertPanelUIEntity.SceneConvertPanelUIEntityModel.AnimationPositionEntityModel.HidedPosition,
                    this.SceneConvertPanelUIEntity.SceneConvertPanelUIEntityModel.AnimationPositionEntityModel.AnimationDuration));

            // 다음 Scene에 넘길 Payload 등록.
            LobbyToBattleScenePayload lobbyToBattleScenePayload = new LobbyToBattleScenePayload();
            lobbyToBattleScenePayload.CurrentStageID = stageID;
            this.ScenePayloadService.SetPayload<LobbyToBattleScenePayload>(lobbyToBattleScenePayload);

            this.SceneService.ChangeScene(this.NextSceneName);
        }
    }
}