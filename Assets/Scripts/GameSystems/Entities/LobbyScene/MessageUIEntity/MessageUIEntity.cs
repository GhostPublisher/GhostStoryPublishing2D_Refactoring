using System;

using UnityEngine;

namespace GameSystems.Entities
{
    public class MessageUIEntity : MonoBehaviour, IEntity
    {
        [SerializeField] private RectTransform RootRectTransform_;
        [SerializeField] private TMPro.TextMeshProUGUI MessageText_;

        public RectTransform RootRectTransform { get => this.RootRectTransform_; }
        public TMPro.TextMeshProUGUI MessageText { get => this.MessageText_; }

        public Type EntityType => typeof(MessageUIEntity);
        // UI의 경우 1개로 고유하기에 EntityID가 사용되지 않습니다.
        public string EntityID => throw new NotImplementedException();
    }
}