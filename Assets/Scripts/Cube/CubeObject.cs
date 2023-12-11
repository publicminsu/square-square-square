using System.Collections;
using UnityEngine;

public class CubeObject : MonoBehaviour
{
    private Rigidbody cubeRigidbody;

    private void Awake()
    {
        cubeRigidbody = GetComponent<Rigidbody>();
    }

    public IEnumerator Drop(int height, int totalHeight)
    {
        float duration = (cubeRigidbody.transform.localPosition.y - height) / totalHeight;
        float progress = 0f;

        WaitForFixedUpdate waitForFixedUpdate = new();
        while (progress < duration)
        {
            progress += Time.deltaTime;

            Vector3 localTargetPosition = new(
                cubeRigidbody.transform.localPosition.x,
                Mathf.Lerp(transform.position.y, height, progress / duration),
                cubeRigidbody.transform.localPosition.z);
            Vector3 worldTargetPosition = cubeRigidbody.transform.TransformDirection(localTargetPosition);

            cubeRigidbody.MovePosition(worldTargetPosition);

            yield return waitForFixedUpdate;
        }
    }
}
