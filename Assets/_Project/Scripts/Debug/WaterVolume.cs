using UnityEngine;

namespace _Project.Scripts.Gameplay.Player
{
    

[RequireComponent(typeof(Collider))]
public class WaterVolume : MonoBehaviour
{
    
    public float SurfaceY => transform.position.y + GetComponent<Collider>().bounds.extents.y;

    private void OnTriggerEnter(Collider other)
    {
        PlayerRoot root = other.GetComponentInParent<PlayerRoot>();
        if (root != null)
        {
            root.Water.EnterWater(SurfaceY);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerRoot root = other.GetComponentInParent<PlayerRoot>();
        if (root != null)
        {
            root.Water.ExitWater();
        }
    }

   
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0f, 0.5f, 1f, 0.25f);
        Gizmos.DrawCube(transform.position, GetComponent<Collider>().bounds.size);
        Gizmos.color = new Color(0f, 0.8f, 1f, 0.8f);
        Vector3 surfaceLine = new Vector3(transform.position.x, SurfaceY, transform.position.z);
        Gizmos.DrawLine(surfaceLine - Vector3.right * 2f, surfaceLine + Vector3.right * 2f);
        Gizmos.DrawLine(surfaceLine - Vector3.forward * 2f, surfaceLine + Vector3.forward * 2f);
    }
}
}