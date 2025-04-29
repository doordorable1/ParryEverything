using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeAmount = 3.0f;
    public float shakeTime = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Shake(shakeAmount, shakeTime));

    }
    IEnumerator Shake(float ShakeAmount, float ShakeTime)
    {
        float timer = 0;
        while (timer <= ShakeTime)
        {
            Camera.main.transform.position =
                Random.insideUnitCircle * ShakeAmount ;



            timer += Time.deltaTime;
            yield return null;
        }
        Camera.main.transform.position = new Vector3(0f, 0f, 0f);
    }
}
