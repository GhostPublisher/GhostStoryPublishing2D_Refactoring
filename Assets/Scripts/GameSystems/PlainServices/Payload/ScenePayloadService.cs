using GameSystems.DTO;

namespace GameSystems.PlainServices
{
    public interface IScenePayloadService : IPlainService
    {
        public bool TryGetPayload<T>(out T resultPayload) where T : class, DTO.IPayload;
        public void SetPayload<T>(T data) where T : class, DTO.IPayload;
    }

    public class ScenePayloadService : IScenePayloadService
    {
        private DTO.IPayload SceneConvertPayload;

        public ScenePayloadService()
        {
            this.SceneConvertPayload = null;
        }

        public bool TryGetPayload<T>(out T resultPayload) where T : class, DTO.IPayload
        {
            resultPayload = null;
            if (this.SceneConvertPayload == null) return false;

            resultPayload = (T)this.SceneConvertPayload;
            return true;
        }

        public void SetPayload<T>(T data) where T : class, DTO.IPayload
        {
            this.SceneConvertPayload = data;
        }

        public void ClearPayload()
        {
            this.SceneConvertPayload = null;
        }
    }
}
