using UnityEngine;

public class Target : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isRunning", true); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            animator.SetTrigger("Smash");         
            animator.SetBool("isRunning", false); 
            Debug.Log("Target hit! Playing Smash animation.");

            
            Invoke("ReturnToRun", 1.0f); 
        }
    }

    void ReturnToRun()
    {
        animator.SetBool("isRunning", true);
    }
}
