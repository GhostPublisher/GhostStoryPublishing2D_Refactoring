using System;
using System.Collections.Generic;

using UnityEngine;

// Entity는 유니티 GameObject 안의 모든 것을 뜻한다.
// 유니티에 많은 의존이 되어 있으며, 대부분의 컴포넌트들이 UnityEngine에 의존한 상태이다.
// EntityModel을 통해, 전체 제어를 위한 Model을 생성.
// 각 컴포넌트를 ViewModel - View로 간주합니다.

namespace GameSystems.Entities
{
    public class SceneConvertPanelUIEntity : MonoBehaviour, IEntity
    {
        // 일종의 ViewModel
        [SerializeField] private SceneConvertPanelUIEntityModel SceneConvertPanelUIEntityModel_;
        
        [SerializeField] private RectTransform RootRectTransform_;
        [SerializeField] private List<ButtonView> ButtonViews;

        public RectTransform RootRectTransform { get => RootRectTransform_; }
        public SceneConvertPanelUIEntityModel SceneConvertPanelUIEntityModel { get => SceneConvertPanelUIEntityModel_; }

        public Type EntityType => typeof(SceneConvertPanelUIEntity);
        // UI의 경우 1개로 고유하기에 EntityID가 사용되지 않습니다.
        public string EntityID => throw new NotImplementedException();


        public void InitialBinds(GameFlows.LobbyToBattle_SceneConvertGameFlow sceneConvertGameFlow)
        {
            foreach(var buttonView in this.ButtonViews)
            {
                buttonView.IntialBind(sceneConvertGameFlow);
            }
        }
    }
}