using UnityEngine;

using Foundations.LazyReferenceRegistry;

namespace GameSystems.Modules.Input
{
    public class InputRouterController : MonoBehaviour, IReferenceLink
    {
        private IInputRouterTransitions inputRouterTransitions;

        private IInputRouter currentIInputRouter;

        public InputRouterController()
        {
            this.inputRouterTransitions = new InputRouterTransitions();

        }
        public void TransitInputRouter(InputRouterType inputRouterType)
        {
            if (!this.inputRouterTransitions.TryTransitInputRouter(inputRouterType, out var router))
            {
                Debug.Log($"InputRouterType�� �´� InputRouter�� ����.");
            }

            this.currentIInputRouter = router;
        }

        public void Update()
        {
            this.currentIInputRouter.Update();
        }
    }
}