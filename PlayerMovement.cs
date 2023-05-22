using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : UniversalMovement 
{
    private Rigidbody playerRb;
    public bool hasPowerup;
    //private float powerupStrength = 200.0f;
    public GameObject PowerupIndicator;
    Animator animator;
    public bool gameOver = false;


    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (vertical != 0)
            animator.SetFloat("velocity", vertical);
        else
            animator.SetFloat("velocity", 0);
        Move(new Vector3(horizontal,0, vertical));

        PowerupIndicator.transform.position = transform.position + new Vector3(0, 0.5f, 0);

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("PowerUp"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            PowerupIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
            speed = 25;
        }
        
    }
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        PowerupIndicator.gameObject.SetActive(false);
        speed = 15;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            if (gameOver == false)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
        }
    }

}
        //private void OnCollisionEnter(Collision collision)
        //{
        //    if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        //    {
        //        Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
        //        Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
        //        Debug.Log("Player collided with " + collision.gameObject + " with powerup set to " + hasPowerup);
        //        enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        //    }
        //}

    
