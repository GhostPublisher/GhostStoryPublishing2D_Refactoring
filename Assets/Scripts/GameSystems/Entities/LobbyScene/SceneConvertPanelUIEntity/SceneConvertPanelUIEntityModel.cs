
using UnityEngine;

// Entity는 유니티 GameObject 안의 모든 것을 뜻한다.
// 유니티에 많은 의존이 되어 있으며, 대부분의 컴포넌트들이 UnityEngine에 의존한 상태이다.
// EntityModel을 통해, 전체 제어를 위한 Model을 생성.
// 각 컴포넌트를 ViewModel - View로 간주합니다.

namespace GameSystems.Entities
{
    public class SceneConvertPanelUIEntityModel : MonoBehaviour
    {
        [SerializeField] public AnimationPositionConfigData AnimationPositionEntityModel;

        [SerializeField] public bool IsButtonBlocked;
    }
}