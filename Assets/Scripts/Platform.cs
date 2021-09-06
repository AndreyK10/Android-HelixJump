using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float bounceForce;
    [SerializeField] private float bounceRadius;

    public void Break()
    {
        PlatformSegment[] segments = GetComponentsInChildren<PlatformSegment>();
        foreach (PlatformSegment segment in segments)
        {
            segment.Bounce(bounceForce, transform.position, bounceRadius);
        }
    }


}
