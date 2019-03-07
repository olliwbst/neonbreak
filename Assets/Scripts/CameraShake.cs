using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    /*function that moves the camera around it's current position randomly to create a
     camerashake. not used because buggy when the player moves because then also the camera 
     moves and the result isn't really nice to look at, also forces the use of a second
     camera because we need one as reference point for the mouseposition-conversion which
     is faulty if the reference-camera shakes around instead of being centered above the player*/
    public IEnumerator Shake(float duration, float intensity)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * intensity;
            float y = Random.Range(-1f, 1f) * intensity;
            
            transform.localPosition = new Vector3(originalPos.x+x,originalPos.y+y,originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
            
            transform.localPosition = originalPos;
        }

    } 
}
