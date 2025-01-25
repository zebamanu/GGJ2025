using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Transform playerTransform;
    private NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
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
        }
    }

    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && tiempoInvulnerable <= 0)
        {
            GameManager.Instance.PerderVida();
            tiempoInvulnerable = 2;
        }
    }
}
