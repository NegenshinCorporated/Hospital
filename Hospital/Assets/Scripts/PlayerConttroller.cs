using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerConttroller : MonoBehaviour
{
    private float speed = 10f;
    private float force = 8f;
    private float horizontal;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool onIsland;
    public Transform islandCheck;
    public LayerMask whatIsIsland;
    public float radiusIslandCheck;
    private Animator animator;
    private bool isFlipped;
    public GameObject sceneManager;
    private ScreenManager screenManager;
    public GameObject killBox;

    // Start is called before the first frame update
    void Start()
    {
        //screenManager = sceneManager.GetComponent<ScreenManager>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        onIsland = Physics2D.OverlapCircle(islandCheck.position, radiusIslandCheck, whatIsIsland);

        horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * speed * Time.deltaTime * horizontal);
        sr.flipX = horizontal < 0;
        if (horizontal < 0)
        {
            sr.flipX = true;
            isFlipped = true;
        }
        else if (horizontal > 0)
        {
            sr.flipX = false;
            isFlipped = false;
        }
        else 
        {
            if (isFlipped)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.W) && onIsland)
        {
            rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
        if (horizontal != 0 && onIsland)
        {
            animator.SetFloat("Run", 1);
        }
        else
        {
            animator.SetFloat("Run", -1);
        }
        if (!onIsland)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("KillBox"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
