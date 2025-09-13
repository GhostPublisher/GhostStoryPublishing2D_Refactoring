using System;
using System.Collections;

using GameSystems.UnityServices;
using GameSystems.Entities;

using GameSystems.Repository;

namespace GameSystems.GameFlows
{
    public interface InitialGameFlow : IGameFlow
    {
        public void LobbyInitialGameFlow();
    }

    public class Lobby_InitialGameFlow : InitialGameFlow
    {
        // UnityService
        private ICoroutineRunner CoroutineRunner;
        private IRectTransformMovementService RectTransformMovementService;

        // Unity Entity
        private SceneConvertPanelUIEntity SceneConvertPanelUIEntity;

        public void InitialBinds(IUnityServiceRepository UnityServiceRepository, IEntityRepository EntityRepository)
        {
            if (UnityServiceRepository.TryGetUnityService<CoroutineRunner>(out var coroutine))
                this.CoroutineRunner = coroutine;

            if (UnityServiceRepository.TryGetUnityService<RectTransformMovementService>(out var rectTransformMovementService))
                this.RectTransformMovementService = rectTransformMovementService;

            if (EntityRepository.TryGetEntity<SceneConvertPanelUIEntity>(out var sceneConvertPanelUIEntity))
                this.SceneConvertPanelUIEntity = sceneConvertPanelUIEntity;
        }

        public void LobbyInitialGameFlow()
        {
            this.CoroutineRunner.Run(this.InitialOperation());
        }

        private IEnumerator InitialOperation()
        {
            yield return this.CoroutineRunner.WaitSeconds(1f);

            this.SceneConvertPanelUIEntity.SceneConvertPanelUIEntityModel.IsButtonBlocked = true;

            yield return this.CoroutineRunner.Run(
                this.RectTransformMovementService.MoveEaseLinear_ForTransform(
                    this.SceneConvertPanelUIEntity.RootRectTransform,
                    this.SceneConvertPanelUIEntity.SceneConvertPanelUIEntityModel.AnimationPositionEntityModel.HidedPosition,
                    this.SceneConvertPanelUIEntity.SceneConvertPanelUIEntityModel.AnimationPositionEntityModel.ShowPosition,
                    this.SceneConvertPanelUIEntity.SceneConvertPanelUIEntityModel.AnimationPositionEntityModel.AnimationDuration));

            this.SceneConvertPanelUIEntity.SceneConvertPanelUIEntityModel.IsButtonBlocked = false;
        }
    }
}