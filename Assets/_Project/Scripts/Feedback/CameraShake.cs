using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;

    [SerializeField] private float duration = 0.2f;
    [SerializeField] private float strength = 0.2f;
    
    private float timer;
    private Vector3 originalPos;
    
    void Update()
    {
        if (timer > 0)
        {
            float t = timer / duration;
            t *= t;
            Vector2 random = Random.insideUnitCircle * strength * t;
            Vector3 offset = new Vector3(random.x,  random.y, 0f);
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
        if (timer <= 0)
            originalPos = cameraTransform.localPosition;
    
        timer = duration;
    }
}
