using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] Puerta puerta;
    

    void OnTriggerEnter(Collider other){
        if (other.tag == "Player")
        {
            puerta.isOpened = true;
            Destroy(gameObject);
        }
    }
}
