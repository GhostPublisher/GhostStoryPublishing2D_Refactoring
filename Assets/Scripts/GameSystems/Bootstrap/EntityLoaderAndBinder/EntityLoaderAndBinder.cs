using GameSystems.Repository;

namespace GameSystems.BootStrap
{
    public interface IEntityLoaderAndBinder
    {
        public void LoadEntities_WithScene(SceneEntityRepository SceneEntityRepository);
        public void LoadEntities();

        public void BindEntities(IGameFlowRepository GameFlowRepository);
    }

    public abstract class EntityLoaderAndBinder : IEntityLoaderAndBinder
    {
        protected IEntityRepository entityRepository;

        public EntityLoaderAndBinder(IEntityRepository entityRepository)
        {
            this.entityRepository = entityRepository;
        }

        public abstract void LoadEntities_WithScene(SceneEntityRepository SceneEntityRepository);
        public abstract void LoadEntities();

        public abstract void BindEntities(IGameFlowRepository GameFlowRepository);
    }
}