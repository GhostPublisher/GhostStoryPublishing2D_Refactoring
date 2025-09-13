using GameSystems.Entities;
using GameSystems.Repository;

namespace GameSystems.BootStrap
{
    public class BattleScene_EntityLoaderAndBinder : EntityLoaderAndBinder
    {
        public BattleScene_EntityLoaderAndBinder(IEntityRepository entityRepository) : base(entityRepository) { }

        public override void LoadEntities_WithScene(SceneEntityRepository SceneEntityRepository)
        {
            foreach (var entity in SceneEntityRepository.GatherAll_IEnumerable())
            {
                this.entityRepository.RegisterEntity(entity.EntityType, entity);
            }
        }
        public override void LoadEntities()
        {
            throw new System.NotImplementedException();
        }
        public override void BindEntities(IGameFlowRepository GameFlowRepository)
        {
            throw new System.NotImplementedException();
        }
    }
}