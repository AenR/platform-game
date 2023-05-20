using UnityEngine;
using System.Collections;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    
    public GameManager gm;

    HealthManager healthManager;

    public float damageRate = 2.0f;
    private float nextDamage = 0.0f;

    //Movement
    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;

    public GameObject pauseMenu;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    int savedScene;

    private void Awake()
    {
        
    }


    // Use this for initialization
    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; // Oyun zamanýný durdurur
    }

    void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; // Oyun zamanýný geri baþlatýr
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "coin")
        {
            gm.coin += 1;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "door")
        {
            savedScene = (SceneManager.GetActiveScene().buildIndex) + 1;
            PlayerPrefs.SetInt("SavedScene", savedScene);
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex) + 1);
        }

        if (collision.gameObject.tag == "acid")
        {
            Time.timeScale = 0;
            gm.durum.text = ("Oldunuz.");
        
        }

        if (collision.gameObject.tag == "key")
        {
            gm.key++;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "keydoor")
        {
            if (gm.key > 0)
            {
                gm.key--;
                gm.durum.text = ("Kapi acildi.");
            }
        }

        if (collision.gameObject.tag == "enemy")
        {
            if (Time.time > nextDamage)
            {
                nextDamage = Time.time + damageRate;
                healthManager.TakeDamage(25); //25 can eksilt
            }
        }

        if (collision.gameObject.tag == "heart" && healthManager.healthAmount<100) //kalbin ustune geldiginde can 100den kucukse
        {
            healthManager.Heal(25); //25 can ver
            Destroy(collision.gameObject); //kalbi yok et
        }

       
    }
}
