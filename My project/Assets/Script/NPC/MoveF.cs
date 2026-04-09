using System.Collections;
using UnityEngine;

public class MoveF : MonoBehaviour
{
    public Transform Finish;  
    public float speed = 1f;  
    public Animator animator;  
    public float startWalkingDelay = 2f;  

    private bool isMoving = true; 
    private Vector3 targetPosition;  
    private Vector3 currentDestination;

    private Collider2D objectCollider;

    void Start()
    {
        objectCollider = GetComponent<Collider2D>();
        targetPosition = Finish.position;  
        currentDestination = targetPosition;
        //StartCoroutine(MoveToTarget(Finish.position));
    }

    
    public IEnumerator MoveToTarget(Vector3 target)
    {
        yield return new WaitForSeconds(startWalkingDelay);  
        animator.SetBool("IsWalking", true);  
        currentDestination = target; 
        while (Vector3.Distance(transform.position, currentDestination) > 0.1f && isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentDestination, speed * Time.deltaTime);
            yield return null;
        }

   
        transform.position = currentDestination;
        animator.SetBool("IsWalking", false); 
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Car"))
        {

            isMoving = false;
            animator.SetBool("IsWalking", false);
            Vector3 collisionPoint = other.ClosestPoint(transform.position); // Get the exact collision point
            currentDestination = collisionPoint;
            transform.position = collisionPoint;  // Move the character to that collision point
            transform.rotation = Quaternion.Euler(0, 0, 90);
            StopCoroutine("MoveToTarget");  // Stop the movement coroutine immediately
            objectCollider.enabled = false;
            Debug.Log("Hit " );
        }
    }
}
