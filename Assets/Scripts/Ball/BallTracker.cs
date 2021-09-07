using UnityEngine;

public class BallTracker : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private Stick stick;
    private Vector3 cameraPosition;
    private Vector3 minBallPosition;
    [SerializeField] private Vector3 directionOffset;
    [SerializeField] private float distance;

    private void Start()
    {
        ball = FindObjectOfType<Ball>();
        stick = FindObjectOfType<Stick>();

        cameraPosition = ball.transform.position;
        minBallPosition = ball.transform.position;

        TrackBall();
    }


    private void Update()
    {
        if (ball.transform.position.y < minBallPosition.y)
        {
            TrackBall();
            minBallPosition = ball.transform.position;
        }
    }

    private void TrackBall()
    {
        Vector3 stickPos = stick.transform.position;
        stickPos.y = ball.transform.position.y;
        cameraPosition = ball.transform.position;
        Vector3 direction = (stickPos - ball.transform.position).normalized + directionOffset;
        cameraPosition -= direction * distance;
        transform.position = cameraPosition;
        transform.LookAt(ball.transform);
    }
}
