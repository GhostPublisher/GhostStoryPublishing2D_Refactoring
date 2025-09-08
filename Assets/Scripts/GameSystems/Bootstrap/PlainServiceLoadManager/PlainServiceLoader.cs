using System;

using GameSystems.Repository;
using GameSystems.PlainServices;


namespace GameSystems.BootStrap
{
    public interface IPlainServiceLoader
    {
        public void LoadPlainServices(IPlainServiceRepository plainServiceRepository);
    }

    public class PlainServiceLoader : IPlainServiceLoader
    {
        public void LoadPlainServices(IPlainServiceRepository plainServiceRepository)
        {
            // Plain Service를 등록
            plainServiceRepository.RegisterPlainService<ScenePayloadService>(new ScenePayloadService());
            // ~~~
        }
    }
}


