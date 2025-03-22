using UnityEngine;

public class Target : MonoBehaviour
{
    private bool isHit = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(BoxCollider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            isHit = true;
            animator.SetTrigger("Smash"); 
            Debug.Log("Target hit! Animation changed.");
        }
    }
}
