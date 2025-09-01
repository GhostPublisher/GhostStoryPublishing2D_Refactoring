using UnityEngine.SceneManagement;

using Foundations.ReferencesHandler;

namespace GameSystems.Infrastructures.SceneConverterModule
{
    public class SceneConverter : ISceneConverter
    {
        private string EmptySceneName = "EmptyScene";
        private string NextSceneName;

        private bool isConverting = false;

        public SceneConverter()
        {
            var GlobalHandlerManager = LazyReferenceHandlerManager_Global.Instance;
            GlobalHandlerManager.GetDynamicHandler<SceneConverterHandler>().ISceneConverter = this;
        }

        // Scene 변경 요청시, EmptyScene을 한번 거쳐서 진행.
        public void OperateSceneConversion(string nextSceneName)
        {
            // 작업중일 경우 무시.
            if (this.isConverting) return;

            this.isConverting = true;
            this.NextSceneName = nextSceneName;
            SceneManager.sceneLoaded += OnSceneLoaded;

            SceneManager.LoadScene(this.EmptySceneName, LoadSceneMode.Single);
        }

        public void OnSceneLoaded(Scene scene, LoadSceneMode mode)  
        {
            // Empty Scene에 도착 후, 바로 NextScene 로드.
            if (scene.name.Equals(this.EmptySceneName))
            {
                SceneManager.LoadScene(this.NextSceneName, LoadSceneMode.Single);
            }
            // 목적 Scene에 도착하였을 경우, Scene 변경 중지. 및 관련 값 설정.
            else if (scene.name.Equals(this.NextSceneName))
            {
                SceneManager.sceneLoaded -= OnSceneLoaded;
                this.NextSceneName = null;
                this.isConverting = false;
                return;
            }
        }
    }
}