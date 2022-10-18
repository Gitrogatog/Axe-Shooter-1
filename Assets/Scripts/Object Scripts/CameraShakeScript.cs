using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Shake(float dur, float mag){
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0;
        while(elapsed < dur){
            float x = Random.Range(-1, 1) * mag;
            float y = Random.Range(-1, 1) * mag;
            transform.localPosition = new Vector3(x, y, originalPos.z);
            elapsed = Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalPos;
    }
}
