using UnityEngine;

public class Ncorrect : MonoBehaviour
{
    public Animator animator;

    public void WrongAnimation()
    {
        animator.SetBool("Fail", true);
    }
}
