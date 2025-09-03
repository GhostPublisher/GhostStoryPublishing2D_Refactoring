using UnityEngine.SceneManagement;

using Foundations.LazyReferenceRegistry;

namespace GameSystems.Modules.Scene
{
    public interface ISceneConverter
    {
        public void OperateSceneConversion(string nextSceneName);
    }

    public class SceneConverter : ISceneConverter, IReferenceLink
    {
        private string EmptySceneName = "EmptyScene";
        private string NextSceneName;

        private bool isConverting = false;

        // Scene 변경 요청시, EmptyScene을 한번 거쳐서 진행.
        public void OperateSceneConversion(string nextSceneName)
        {
            // 작업중일 경우 무시.
            if (this.isConverting) return;

//            UnityEngine.Debug.Log($"current Scene Name : {SceneManager.GetActiveScene().name}");

            this.isConverting = true;
            this.NextSceneName = nextSceneName;
            SceneManager.sceneLoaded += OnSceneLoaded;

            SceneManager.LoadScene(this.EmptySceneName, LoadSceneMode.Single);
        }

        public void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, LoadSceneMode mode)
        {
//            UnityEngine.Debug.Log($"current Scene Name : {SceneManager.GetActiveScene().name}");

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