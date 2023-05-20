using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed = 3f;
    public float chaseDistance = 10f;
    public float randomMovementInterval = 3f;

    private Transform player;
    private Rigidbody rb;
    private bool isChasing = false;
    private float randomMovementTimer = 0f;
    private Vector3 randomMovementDirection;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        randomMovementTimer = randomMovementInterval;
        StartCoroutine(WaitMove());
    }
    private IEnumerator WaitMove()
    {
        yield return new WaitForSeconds(3);
        GenerateRandomMovementDirection();


    }

    private void Update()
    {
        // Menghitung jarak antara musuh dan pemain
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Jika musuh melihat pemain, musuh mulai mengejar pemain
        if (distanceToPlayer <= chaseDistance)
        {
            isChasing = true;
        }
        else if (isChasing)
        {
            // Jika musuh sudah tidak melihat pemain, musuh berhenti mengejar dan mulai bergerak secara acak
            isChasing = false;
            GenerateRandomMovementDirection();
        }

        if (isChasing)
        {
            // Menggerakkan musuh menuju pemain
            Vector3 direction = (player.position - transform.position).normalized;
            Vector3 movement = direction * movementSpeed * Time.deltaTime;
            rb.MovePosition(transform.position + movement);
        }
        else
        {
            // Gerakan acak musuh
            randomMovementTimer -= Time.deltaTime;
            if (randomMovementTimer <= 0f)
            {
                GenerateRandomMovementDirection();
                randomMovementTimer = randomMovementInterval;
            }

            Vector3 movement = randomMovementDirection * movementSpeed * Time.deltaTime;
            rb.MovePosition(transform.position + movement);
        }
    }

    private void GenerateRandomMovementDirection()
    {
        randomMovementDirection = new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f)).normalized;
    }

}
