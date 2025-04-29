using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class K_Camera : MonoBehaviour
{
    public float cameraSpeed = 5.0f;
    public Vector3 offset;
    public GameObject player;

    public float lockMax;
    public float lockMin;
    Vector3 temp;


    public float shakeAmount = 0.05f;
    public float shakeTime = 0.1f;

    float bloodeSpeed = 1;
    Volume volume;
    Vignette vignette;


    private void Start()
    {
        volume = GetComponent<Volume>();
        if (volume.profile.TryGet(out vignette))
        {
            vignette.intensity.value = 0; // 초기 Vignette 강도 설정
        }
        GameSystemManager.PlayerHPChangeEvent.OnPlayerDamagedEvent += HitBloode;
    }

    public  void CamShake()
    {
        StartCoroutine(Shake(shakeAmount, shakeTime));

    }
    void FixedUpdate()
    {
        Vector3 to = player.transform.position + offset;
        to.y = offset.y;
        transform.position = Vector3.Lerp(transform.position, to, Time.deltaTime * cameraSpeed);
        temp = transform.position;

        if (lockMax > 0)
        {
            if (transform.position.x  > lockMax)
            {
                temp.x = lockMax ;
                transform.position = temp;
            }

            if (transform.position.x < lockMin)
            {
                temp.x = lockMin;
                transform.position = temp;
            }
        }



        vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, 0, bloodeSpeed * Time.deltaTime);
    }


    IEnumerator Shake(float ShakeAmount, float ShakeTime)
    {
        float timer = 0;
        while (timer <= ShakeTime)
        {
            Camera.main.transform.position = Camera.main.transform.position +
               (Vector3)Random.insideUnitCircle.normalized * ShakeAmount;



            timer += Time.deltaTime;
            yield return null;
        }
    }
    void HitBloode(int i) {  vignette.intensity.value = 0.5f; }
}

// GameSystemManager.PlayerHPChangeEvent.OnPlayerDamagedEvent