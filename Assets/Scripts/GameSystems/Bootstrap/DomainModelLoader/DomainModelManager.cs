using GameSystems.Repository;

namespace GameSystems.BootStrap
{
    public interface IDomainModelManager
    {
        public abstract void LoadDomainModelsWithPayload(IPlainServiceRepository plainServiceRepository);
        public abstract void LoadDomainModels();
    }

    public abstract class DomainModelManager : IDomainModelManager
    {
        protected IDomainModelRepository domainModelRepository;

        public DomainModelManager(IDomainModelRepository DomainModelRepository)
        {
            this.domainModelRepository = DomainModelRepository;
        }

        public abstract void LoadDomainModelsWithPayload(IPlainServiceRepository plainServiceRepository);
        public abstract void LoadDomainModels();

    }    
}