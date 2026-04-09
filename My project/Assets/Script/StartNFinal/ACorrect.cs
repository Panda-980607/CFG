using UnityEngine;

public class ACorrect : MonoBehaviour
{

    public Animator animator;

    public void CorrectAnimation()
    {
        animator.SetBool("Success", true);
    }
}
