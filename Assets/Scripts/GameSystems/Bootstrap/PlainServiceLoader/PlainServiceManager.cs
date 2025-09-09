using System;

using GameSystems.Repository;
using GameSystems.PlainServices;


namespace GameSystems.BootStrap
{
    public interface IPlainServiceManager
    {
        public void LoadPlainServices();
    }

    public class PlainServiceManager : IPlainServiceManager
    {
        private IPlainServiceRepository plainServiceRepository;

        public PlainServiceManager(IPlainServiceRepository plainServiceRepository)
        {
            this.plainServiceRepository = plainServiceRepository;
        }

        public void LoadPlainServices()
        {
            // Plain Service를 등록
            this.plainServiceRepository.RegisterPlainService<ScenePayloadService>(new ScenePayloadService());
            // ~~~
        }
    }
}


