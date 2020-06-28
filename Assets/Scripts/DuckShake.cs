using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckShake : MonoBehaviour
{
    public static DuckShake instance;

    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform duckTransform;

    // How long the object should shake for.
    public float shakeDuration = 0.1f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    public static bool shaketrue = false;

    Vector3 originalPos;

    void Awake()
    {
        instance = this;
        if (duckTransform == null)
        {
            duckTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = duckTransform.localPosition;
    }

    void Update()
    {
        if (shaketrue)
        {
            if (shakeDuration > 0)
            {
                duckTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

                shakeDuration -= Time.deltaTime * decreaseFactor;
            }
            else
            {
                shakeDuration = 1f;
                duckTransform.localPosition = originalPos;
                shaketrue = false;
            }
        }
    }

    public static void Shake()
    {
        shaketrue = true;
    }
}
