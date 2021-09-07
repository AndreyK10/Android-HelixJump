using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TowerRotator : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch0 = Input.GetTouch(0);

            if (touch0.phase == TouchPhase.Moved)
            {
                transform.Rotate(0f, touch0.deltaPosition.x * Time.deltaTime * rotateSpeed * -1f, 0f);
            }

        }
    }

}
