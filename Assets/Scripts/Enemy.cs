using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Transform playerTransform;
    private NavMeshAgent agent;
    private CapsuleCollider capsuleCollider;
    private Animator animator;
    public GameObject explosion;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        animator = GetComponent<Animator>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    private float tiempoInvulnerable = 0;

    // Update is called once per frame
    void Update()
    {
        if (tiempoInvulnerable > 0)
        {
            tiempoInvulnerable -= Time.deltaTime;
        }
        else
        {
            agent.SetDestination(playerTransform.position);
            capsuleCollider.enabled = true;
        }
    }

    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && tiempoInvulnerable <= 0)
        {
            GameManager.Instance.PerderVida();
            StartCoroutine(playerTransform.GetComponent<Player>().BlinkCoroutine());
            tiempoInvulnerable = 2;
            capsuleCollider.enabled = false;
            //I want the explosion to be instantiated in the contact point of the collision
            animator.SetTrigger("Laugh");
            GameObject exp = Instantiate(explosion, collision.GetContact(0).point, Quaternion.identity);
        }
    }
}
