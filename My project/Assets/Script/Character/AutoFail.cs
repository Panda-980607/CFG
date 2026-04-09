using System.Collections;
using UnityEngine;

public class AutoFail : MonoBehaviour
{

    public Transform pointA;
    public Transform pointB;
    public float speed = 1f;
    public float stopTimeAtA = 2f;
    public Animator Animator;
    public SpriteRenderer spriteRenderer;

    private int moveStage = 0;// 0 at rest 1 to A, 2 to B, 3 = stop


    public GameObject spinnerA;
    public GameObject spinnerB;


    private bool spinnerAVisible = false;
    private bool spinnerBVisible = false;


    public GameObject objectAtA;
    public GameObject objectAtB;
    // Start is called before the first frame update
    void Start()
    {

        //StartCoroutine(MoveSequence());
        spinnerA.SetActive(false);
        spinnerB.SetActive(false);
    }

    public IEnumerator MoveSequence()
    {
        // Move to Point A
        Animator.SetBool("IsWalking", true);
        yield return StartCoroutine(MoveToTarget(pointA.position));
        moveStage = 1;

        // Trigger at Point A
        TriggerAtPointA();

        // Pause at A
        Animator.SetBool("IsWalking", false);
        yield return new WaitForSeconds(stopTimeAtA);
        moveStage = 2;

        // Move to Point B
        FlipCharacter();
        Animator.SetBool("IsWalking", true);
        yield return StartCoroutine(MoveToTarget(pointB.position));
        moveStage = 3;

        // Trigger at Point B
        TriggerAtPointB();

        Animator.SetBool("IsWalking", false);
        
    }

    IEnumerator MoveToTarget(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            yield return null;
        }
    }

    void FlipCharacter()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }

    void TriggerAtPointA()
    {
        //Spinner A
        if (spinnerA != null && !spinnerAVisible)
        {
            spinnerA.SetActive(true);
            spinnerAVisible = true;
            // Wait for 2 seconds to show spinner
            StartCoroutine(HideSpinnerAfterDelay(spinnerA, 2f));
        }

        // Remove object at Point A if exists
        if (objectAtA != null)
        {
            objectAtA.SetActive(false);
        }
    }

    void TriggerAtPointB()
    {
        //Spinner B
        if (spinnerB != null && !spinnerBVisible)
        {
            spinnerB.SetActive(true);
            spinnerBVisible = true;
            // Wait for 2 seconds to show spinner
            StartCoroutine(HideSpinnerAfterDelay(spinnerB, 2f));
        }


        if (objectAtB != null)
        {
            Animator.SetBool("Fail", true);
            objectAtB.SetActive(true);
        }
    }

    IEnumerator HideSpinnerAfterDelay(GameObject spinner, float delay)
    {
        yield return new WaitForSeconds(delay);
        spinner.SetActive(false); // Deactivate Spinner after delay
    }
}
