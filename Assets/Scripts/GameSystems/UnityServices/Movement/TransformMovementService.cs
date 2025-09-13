using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystems.UnityServices
{
    public interface IObjectMovementService : IUnityService
    {
        public IEnumerator MoveEaseLinear_ForTransform(Transform targetObject, Vector3 start, Vector3 target, float moveDuration);
    }

    public class TransformMovementService : IObjectMovementService
    {
        public TransformMovementService()
        {
            // �̰����� SO�� �о����, Unity���� �����ϴ� Custom Animation Curve�� ����� �� ���� ��.
        }

        public IEnumerator MoveEaseLinear_ForTransform(Transform targetObject, Vector3 start, Vector3 target, float moveDuration)
        {
            float elapsed = 0f;

            while (elapsed < moveDuration)
            {
                elapsed += Time.deltaTime;

                // 0 �� 1 ���� ��� �����
                float t = Mathf.Clamp01(elapsed / moveDuration);

                // ��� �̵� (Lerp�� ����� �״�� ���)
                targetObject.position = Vector3.Lerp(start, target, t);

                yield return null;
            }

            // �������� ��Ȯ�� ��ǥ �������� ����
            targetObject.position = target;
        }
    }
}