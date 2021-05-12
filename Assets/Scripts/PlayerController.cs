using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocity = 0;
    public GameObject focalPoint = null;
    public GameObject powerupIndicator = null;
    public float powerupForce = 0;
    public float powerupDuration = 0;

    private Rigidbody rb;
    private bool hasPowerup = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (powerupIndicator)
        {
            powerupIndicator.transform.position = transform.position;
            powerupIndicator.SetActive(hasPowerup);
        }

        if (gameObject.transform.position.y < -100)
        {
            Destroy(gameObject);
        }
    }

    // Fixed Update is called in fixed intervals (do physics manipulation here!)
    void FixedUpdate()
    {
        float vInput = Input.GetAxis("Vertical");

        if (focalPoint)
        {
            rb.AddForce(focalPoint.transform.forward * velocity * vInput * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // collect powerup
        if (other.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPowerup = true;

            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();

            if (enemyRb)
            {
                Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;
                enemyRb.AddForce(awayFromPlayer * powerupForce, ForceMode.Impulse);
            }
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(powerupDuration);
        hasPowerup = false;
    }
}
