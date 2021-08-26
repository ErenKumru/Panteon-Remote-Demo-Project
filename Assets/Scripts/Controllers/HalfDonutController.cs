using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfDonutController : MonoBehaviour
{
    [SerializeField] private Vector3 leftPoint;
    [SerializeField] private Vector3 rightPoint;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float minTimeInterval;
    [SerializeField] private float maxTimeInterval;
    [SerializeField] private bool isReversed;
    private Vector3 direction;

    private Rigidbody rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        direction = isReversed ? Vector3.right : Vector3.left;
        ActivateHalfDonut();
    }

    //Starts Mutually Recursive Coroutine Couple
    private void ActivateHalfDonut()
    {
        StartCoroutine(ShootHalfDonut());
    }

    //MoveLeft and MoveRight coroutines are Mutually Recursive Coroutines

    private IEnumerator ShootHalfDonut()
    {
        yield return new WaitForSeconds(Random.Range(minTimeInterval, maxTimeInterval));

        while (transform.localPosition.x > leftPoint.x)
        {
            Vector3 newPosition = transform.position;
            newPosition += moveSpeed * Time.deltaTime * direction;
            rigidBody.MovePosition(newPosition);

            yield return new WaitForEndOfFrame();
        }

        yield return StartCoroutine(PullHalfDonut());
    }

    private IEnumerator PullHalfDonut()
    {
        yield return new WaitForSeconds(Random.Range(minTimeInterval, maxTimeInterval));

        while (transform.localPosition.x < rightPoint.x)
        {
            Vector3 newPosition = transform.position;
            newPosition += moveSpeed * Time.deltaTime * -direction;
            rigidBody.MovePosition(newPosition);

            yield return new WaitForEndOfFrame();
        }

        yield return StartCoroutine(ShootHalfDonut());
    }
}
