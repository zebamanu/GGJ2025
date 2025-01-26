using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;


public class Menu : MonoBehaviour
{
    [SerializeField] private AudioClip[] mouseAudios;
    [SerializeField] private Image spriteCasa;
    [SerializeField] private Sprite spriteCasaBien;
    [SerializeField] private Sprite spriteCasaMal;

    private AudioSource audioSource;
    void Start(){
        audioSource = GetComponent<AudioSource>();
    }

    public void ClickPlay(){
        SceneManager.LoadScene("Mansion");
    }

    float timer = 0;

    void Update(){
        timer += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            audioSource.clip = mouseAudios[Random.Range(0, mouseAudios.Length)];
            audioSource.Play();
        }
        if (timer >= 3){
            StartCoroutine(ChangeSprite());
            timer = -1.8f;
        }
    }

    IEnumerator ChangeSprite(){
        for (int i = 0; i < 4; i++){
            spriteCasa.sprite = spriteCasaMal;
            yield return new WaitForSeconds(0.2f);
            spriteCasa.sprite = spriteCasaBien;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
