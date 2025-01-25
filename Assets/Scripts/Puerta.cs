using UnityEngine;

public class Puerta : Interactuable
{
    Animator animator;
    public bool isOpened;
    void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }


    protected override void Interact(){
        if (isOpened)
        {
            animator.SetTrigger("Girar");
            Destroy(this);
        }
        else
        {
            playerController.MostrarTextoLlave();
        }
    }
        
}
