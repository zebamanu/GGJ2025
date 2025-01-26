using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    [SerializeField] Image[] vidas;
    [SerializeField] Sprite vidaPerdida;
    private int vidasRestantes = 3;

    private void Awake(){
        if (Instance == null){
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PerderVida(){
        vidasRestantes--;
        
        vidas[vidasRestantes].sprite = vidaPerdida;
        
        if (vidasRestantes <= 0){
            Debug.Log("Game Over");
        }
    }
    

}
