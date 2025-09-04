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

        // Scene ���� ��û��, EmptyScene�� �ѹ� ���ļ� ����.
        public void OperateSceneConversion(string nextSceneName)
        {
            // �۾����� ��� ����.
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