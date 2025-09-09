using UnityEngine;

using GameSystems.Repository;
using GameSystems.Domain.Models;

namespace GameSystems.InputController
{
    public interface IInputController
    {
        public void InitialBinds(IPlainServiceRepository plainServiceRepository, IUnityServiceRepository unityServiceRepository,
            IDomainModelRepository domainModelRepository, IGameFlowRepository gameFlowRepository);
    }

    public abstract class InputController : MonoBehaviour, IInputController
    {
        // 각 서비스 레포지토리
        protected IPlainServiceRepository PlainServiceRepository;
        protected IUnityServiceRepository UnityServiceRepository;

        // GameFlow 레포지토리
        protected IGameFlowRepository GameFlowRepository;

        // DomainModelRepository의 InputState Model 을 참조하기 위함.
        protected InputStateModel InputStateModel;

        public void InitialBinds(IPlainServiceRepository plainServiceRepository,
            IUnityServiceRepository unityServiceRepository,
            IDomainModelRepository domainModelRepository,
            IGameFlowRepository gameFlowRepository)
        {
            this.PlainServiceRepository = plainServiceRepository;
            this.UnityServiceRepository = unityServiceRepository;
            this.GameFlowRepository = gameFlowRepository;

            if(domainModelRepository.TryGetDomainModel<InputStateModel>(out var data))
                this.InputStateModel = data;
        }
    }
}