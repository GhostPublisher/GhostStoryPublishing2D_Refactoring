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

        // Scene ���� ��û��, EmptyScene�� �ѹ� ���ļ� ����.
        public void OperateSceneConversion(string nextSceneName)
        {
            // �۾����� ��� ����.
            if (this.isConverting) return;

            this.isConverting = true;
            this.NextSceneName = nextSceneName;
            SceneManager.sceneLoaded += OnSceneLoaded;

            SceneManager.LoadScene(this.EmptySceneName, LoadSceneMode.Single);
        }

        public void OnSceneLoaded(Scene scene, LoadSceneMode mode)  
        {
            // Empty Scene�� ���� ��, �ٷ� NextScene �ε�.
            if (scene.name.Equals(this.EmptySceneName))
            {
                SceneManager.LoadScene(this.NextSceneName, LoadSceneMode.Single);
            }
            // ���� Scene�� �����Ͽ��� ���, Scene ���� ����. �� ���� �� ����.
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