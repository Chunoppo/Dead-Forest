using System.Collections;
using UnityEngine;

public class GameClock : MonoBehaviour
{
    public Light sun;

    public float dayTime = 3f;
    public float nightTime = 1.5f;

    private void Start()
    {
        StartCoroutine(StartClock());
    }

    IEnumerator StartClock()
    {
        while (true)
        {
            yield return Day();
            yield return Night();
        }
    }

    IEnumerator Day()
    {
        float t = 0;
        while (t < dayTime)
        {
            t += Time.deltaTime;
            sun.intensity = Mathf.Lerp(0.5f, 1.5f, t / dayTime);
            sun.transform.Rotate(Vector3.right, Time.deltaTime * 360 / dayTime); 
            yield return null;
        }
    }

    IEnumerator Night()
    {
        float t = 0;
        while (t < nightTime)
        {
            t += Time.deltaTime;
            sun.intensity = Mathf.Lerp(1.5f, 0.5f, t / nightTime);
            yield return null;
        }
    }
}
