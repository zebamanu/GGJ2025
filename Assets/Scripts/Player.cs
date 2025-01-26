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
    public Animator animator;
    [SerializeField] private Transform spriteTransform;
    [SerializeField] private GameObject interactLogo;
    [SerializeField] private NavMeshSurface navmesh;
    [SerializeField] private TMP_Text globoTexto;

    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        spriteRenderer = spriteTransform.GetComponent<SpriteRenderer>();
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
        yield return new WaitForSeconds(0.25f);
        navmesh.BuildNavMesh();
    }

    public void MostrarTexto(String texto){
        globoTexto.text = texto;
        globoTexto.active = true;
        StartCoroutine(DesaparecerTexto());
    }

    public IEnumerator DesaparecerTexto()
    {
        yield return new WaitForSeconds(3);
        globoTexto.active = false;
    }

    public IEnumerator BlinkCoroutine()
    {
        for (int i = 0; i < 4; i++)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r,spriteRenderer.color.g,spriteRenderer.color.b,0.5f);
            yield return new WaitForSeconds(0.2f);
            spriteRenderer.color = new Color(spriteRenderer.color.r,spriteRenderer.color.g,spriteRenderer.color.b,1f);
            yield return new WaitForSeconds(0.2f);
        }
    }

}
