using UnityEngine;

public class BallReset : MonoBehaviour
{
    [SerializeField]
    private GameObject baseball;
    [SerializeField]
    private Rigidbody baseballRigidbody;
    [SerializeField]
    private GameObject resetPoint;
    [SerializeField]
    private int timeUntilReset;

    private int score;
    private int bestScore;

    void Start()
    {
        print("Trigger set up");
    }

    void OnTriggerExit(Collider other)
    {
        print("Something exited the trigger");
        if (other == baseball.GetComponent<Collider>())
        {
            Debug.LogWarning("The ball exited the area");

            Invoke("ResetBall", timeUntilReset);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        print("Something entered the trigger");
    }

    void ResetBall()
    {
        score = (int)Vector3.Distance(baseball.transform.position, resetPoint.transform.position);
        if(score > bestScore)
        {
            bestScore = score;
        }

        Debug.LogError("Last score: " + score + "\nBest score:" + bestScore);

        baseball.transform.position = resetPoint.transform.position;
        baseball.transform.rotation = resetPoint.transform.rotation;
        baseballRigidbody.velocity = Vector3.zero;
        baseballRigidbody.angularVelocity = Vector3.zero;
        Debug.LogWarning("Ball reset");
    }
}
