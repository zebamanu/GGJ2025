using UnityEngine;

public class Silla : Interactuable
{
    Animator animator;
    
    void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }


    protected override void Interact(){
        animator.SetTrigger("Girar");
        playerController.animator.SetTrigger("Throw");
        Destroy(this);
    }
}
