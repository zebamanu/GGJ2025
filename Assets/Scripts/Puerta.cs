using UnityEngine;

public class Puerta : Interactuable
{
    Animator animator;
    public bool isOpened;
    [SerializeField] private AudioClip openDoor;
    [SerializeField] private AudioClip closedDoor;
    private AudioSource audioSource;
    void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }


    protected override void Interact(){
        if (isOpened)
        {
            animator.SetTrigger("Girar");
            audioSource.clip = openDoor;
            audioSource.Play();
            Destroy(this);
        }
        else
        {
            audioSource.clip = closedDoor;
            audioSource.Play();
            playerController.MostrarTextoLlave();
        }
    }
        
}
