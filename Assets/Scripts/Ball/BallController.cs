using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Ball))]
public class BallController : MonoBehaviour
{
    [SerializeField] private float jumpForce;

    private Rigidbody rb;
    private bool collided = false;

    [SerializeField] private GameObject decal;
    private Ball ball;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ball = GetComponent<Ball>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlatformSegment platformSegment) && !collided)
        {
            collided = true;
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            StartCoroutine(WaitBeforeColliding());
            Instantiate(decal, new Vector3(transform.position.x, transform.position.y - transform.localScale.y / 2f, transform.position.z), Quaternion.Euler(90f, 0, Random.Range(0, 360f)), collision.gameObject.transform);
        }
        if (collision.gameObject.TryGetComponent(out GameOverPlatform goPlatform))
        {
            GameplayController.instance.GameOver(ball);
        }
        if (collision.gameObject.TryGetComponent(out FinishSegment finishSegment))
        {
            GameplayController.instance.FinishGame(ball);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlatformSegment platformSegment))
        {
            other.GetComponentInParent<Platform>().Break();
            GameplayController.instance.DecreaseCounter();
            other.gameObject.SetActive(false);
        }
        
    }
    private IEnumerator WaitBeforeColliding()
    {
        yield return new WaitForSeconds(0.2f);
        collided = false;
    }
}
