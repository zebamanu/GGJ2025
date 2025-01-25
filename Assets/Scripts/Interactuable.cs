using UnityEngine;

public abstract class Interactuable : MonoBehaviour
{
    Transform player;
    protected Player playerController;
    public void Start()
    {
        
        player = GameObject.FindWithTag("Player").transform;
        playerController = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update(){
        if (Vector3.Distance(player.position, transform.position) < 5f)
        {
            playerController.SetCanInteract(true);
            playerController.SetInteractuable(this);
            
        }
        else
        {
            if (playerController.GetInteractuable() == this)
            {
                playerController.SetCanInteract(false);
                playerController.SetInteractuable(null);
            }
        }
    }

    protected abstract void Interact();

    public void EAction(){
        playerController.SetCanInteract(false);
        playerController.SetInteractuable(null);
        Interact();
    }
}
