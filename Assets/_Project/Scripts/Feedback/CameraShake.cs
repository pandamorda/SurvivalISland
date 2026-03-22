using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;

    [SerializeField] private float duration = 0.2f;
    [SerializeField] private float strength = 0.5f;
    
    private float timer;
    private Vector3 originalPos;
    
    void Update()
    {
        if (timer > 0)
        {
            float t = timer / duration;
            t *= t;
            Vector2 random = Random.insideUnitCircle * strength * t;
            Vector3 offset = new Vector3(random.x, 0f, random.y);
            cameraTransform.localPosition = originalPos + offset;
            timer -= Time.deltaTime;
        }
        else
        {
            cameraTransform.localPosition = originalPos;
        }
    }

    public void PlayShake()
    {
        originalPos = cameraTransform.localPosition;
        timer = duration;
    }
}
