using System;

using UnityEngine;

namespace GameSystems.Entities
{
    [Serializable]
    public class AnimationPositionConfigData
    {
        public Vector2 HidedPosition;
        public Vector2 ShowPosition;
        public float AnimationDuration;
    }
}