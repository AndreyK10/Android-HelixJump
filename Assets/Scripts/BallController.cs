using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    [SerializeField] private float jumpForce;

    private Rigidbody rb;
    private bool entered = false;

    [SerializeField] private GameObject decal;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlatformSegment platformSegment) && !entered)
        {
            entered = true;
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            StartCoroutine(Waiter());
            Instantiate(decal, new Vector3(transform.position.x, transform.position.y - transform.localScale.y / 2f, transform.position.z), Quaternion.Euler(90f, 0, Random.Range(0, 360f)), collision.gameObject.transform); ;
        }
    }
    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(0.2f);
        entered = false;
    }
}
