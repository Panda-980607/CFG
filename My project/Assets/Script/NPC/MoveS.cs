using System.Collections;
using UnityEngine;

public class MoveS : MonoBehaviour
{
    public Transform Finish;       
    public float speed = 1f;   
    public Animator animator;
    public float startwalking = 2f;
    public CarGenerater carGenerator;


    void Start()
    {
        //StartCoroutine(MoveToTarget(Finish.position));
    }

    void StopCarGeneration()
    {
        if (carGenerator != null)
        {
            carGenerator.StopCarGeneration();
            Debug.Log("Car generation has been stopped.");
        }
    }


    public IEnumerator MoveToTarget(Vector3 target)
    {

        StopCarGeneration();
        yield return new WaitForSeconds(startwalking);

        animator.SetBool("IsWalking", true);


        // Move the character towards the target (Point B)
        while (Vector3.Distance(transform.position, target) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            yield return null;
        }

        transform.position = target;
        animator.SetBool("IsWalking", false);
    }
}
