using UnityEngine;

public class EnableAnimation : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.enabled = true;
    }

    void Update()
    {
        if (animator.enabled)
        {
            animator.speed = ResourceData.Power_multiplier;
        }
    }
}
