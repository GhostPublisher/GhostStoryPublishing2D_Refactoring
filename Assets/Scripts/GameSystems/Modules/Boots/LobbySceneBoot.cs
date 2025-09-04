using UnityEngine;

using Foundations.LazyReferenceRegistry;

using GameSystems.Modules.Input;

namespace GameSystems.Modules.Boot
{
    public class LobbySceneBoot : MonoBehaviour
    {
        private void Awake()
        {
            GlobalReferenceRegistry.Instance.GetComponentModule<InputRouterController>().TransitInputRouter(InputRouterType.LobbyScene);
        }
    }
}
