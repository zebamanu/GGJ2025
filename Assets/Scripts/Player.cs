using UnityEngine;
using NavMeshPlus.Components;
using System;
using System.Collections;
public class Player : MonoBehaviour
{
    public float velocity = 5;
    private bool canInteract = false;
    private Interactuable interactuable;
    private Rigidbody rb;
    private Animator animator;
    [SerializeField] private Transform spriteTransform;
    [SerializeField] private GameObject interactLogo;
    [SerializeField] private NavMeshSurface navmesh;
    [SerializeField] private GameObject textoLlave;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    public void SetCanInteract(bool value)
    {
        canInteract = value;
        interactLogo.SetActive(value);
    }

    public void SetInteractuable(Interactuable interactuable)
    {
        this.interactuable = interactuable;
    }

    public Interactuable GetInteractuable()
    {
        return interactuable;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, vertical, 0 );
        rb.linearVelocity = new Vector2(horizontal * velocity, vertical * velocity);
        animator.SetFloat("Velocidad", direction.magnitude / Mathf.Sqrt(2));
        //I want spriteTransform to rotate towards the direction the player is moving
        spriteTransform.rotation = Quaternion.LookRotation(Vector3.forward, direction);

        //Fix this so the player can interact with the object pressing E key
        if (canInteract && (Input.GetKey("e")||Input.GetKeyDown("e")))
        {
            interactuable.EAction();
            StartCoroutine(RebuildNavMesh());
            
        }
    }

    public IEnumerator RebuildNavMesh()
    {
        yield return new WaitForSeconds(0.3f);
        navmesh.BuildNavMesh();
    }

    public void MostrarTextoLlave()
    {
        StartCoroutine(DesaparecerTextoLlave());
        textoLlave.SetActive(true);
    }

    public IEnumerator DesaparecerTextoLlave()
    {
        yield return new WaitForSeconds(3);
        textoLlave.SetActive(false);
    }

}
