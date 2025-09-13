﻿using System.Collections;
using UnityEngine;

namespace GameSystems.UnityServices
{
    public interface IRectTransformMovementService : IUnityService
    {
        public IEnumerator MoveEaseLinear_ForTransform(RectTransform targetObject, Vector3 start, Vector3 target, float moveDuration);
    }

    public class RectTransformMovementService : IRectTransformMovementService
    {
        public RectTransformMovementService()
        {
            // 이곳에서 SO를 읽어오면, Unity에서 제공하는 Custom Animation Curve도 사용할 수 있을 듯.
        }

        public IEnumerator MoveEaseLinear_ForTransform(RectTransform targetObject, Vector3 start, Vector3 target, float moveDuration)
        {
            float elapsed = 0f;

            while (elapsed < moveDuration)
            {
                elapsed += Time.deltaTime;

                // 0 → 1 까지 등속 진행률
                float t = Mathf.Clamp01(elapsed / moveDuration);

                // 등속 이동 (Lerp를 진행률 그대로 사용)
                targetObject.anchoredPosition = Vector3.Lerp(start, target, t);

                yield return null;
            }

            // 마지막에 정확히 목표 지점으로 스냅
            targetObject.anchoredPosition = target;
        }
    }
}