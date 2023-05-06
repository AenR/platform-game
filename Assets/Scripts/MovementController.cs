using UnityEngine;
using System.Collections;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class MovementController : MonoBehaviour
{

    public GameManager gm;
    HealthManager healthManager;
    public GameObject PlayerManagerr;

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

    private void Awake()
    {
        healthManager = PlayerManagerr.GetComponent<HealthManager>();
    }


    // Use this for initialization
    void Start()
    {

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
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex) + 1);
        }

        if (collision.gameObject.tag == "acid")
        {
            Time.timeScale = 0;
            gm.durum.text = ("Oldunuz.");
            healthManager.health = 0;
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
                healthManager.health -= 1;
            }
        }

        if (collision.gameObject.tag == "heart")
        {
            if (healthManager.health < 3)
            {
                healthManager.health += 1;
                Destroy(collision.gameObject);
            }
        }

        if(collision.gameObject.tag == "levelupdater")
        {
            PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
            Debug.Log(PlayerPrefs.GetInt("SavedScene"));
        }
    }
}
