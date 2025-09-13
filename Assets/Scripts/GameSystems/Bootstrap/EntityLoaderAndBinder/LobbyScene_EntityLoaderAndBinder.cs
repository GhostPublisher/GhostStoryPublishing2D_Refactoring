using GameSystems.Entities;
using GameSystems.Repository;

namespace GameSystems.BootStrap
{
    public class LobbyScene_EntityLoaderAndBinder : EntityLoaderAndBinder
    {
        public LobbyScene_EntityLoaderAndBinder(IEntityRepository entityRepository) : base(entityRepository) { }

        public override void LoadEntities_WithScene(SceneEntityRepository SceneEntityRepository)
        {
            foreach (var entity in SceneEntityRepository.GatherAll_IEnumerable())
            {
                this.entityRepository.RegisterEntity(entity.EntityType, entity);
            }
        }

        public override void LoadEntities()
        {

        }

        public override void BindEntities(IGameFlowRepository GameFlowRepository)
        {
            // 두 책임 객체가 존재한다면, 참조를 수행하는 객체
            if (this.entityRepository.TryGetEntity<SceneConvertPanelUIEntity>(out var sceneConvertPanelUIEntity)
                && GameFlowRepository.TryGetGameFlow<GameFlows.LobbyToBattle_SceneConvertGameFlow>(out var sceneConvertGameFlow))
            {
                sceneConvertPanelUIEntity.InitialBinds(sceneConvertGameFlow);
            }


        }
    }
}