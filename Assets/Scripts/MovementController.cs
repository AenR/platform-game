using UnityEngine;
using System.Collections;
using System.Threading;
using Unity.VisualScripting;

public class MovementController : MonoBehaviour
{

    [SerializeField] float m_speed = 4.0f;
    [SerializeField] float m_jumpForce = 7.5f;
    [SerializeField] float m_rollForce = 6.0f;
    [SerializeField] bool m_noBlood = false;

    public GameManager gm;
    HealthManager healthManager;
    public GameObject PlayerManagerr;

    public float damageRate = 2.0f;
    private float nextDamage = 0.0f;

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
            gm.durum.text = ("Sonraki bolume gecildi.");
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
    }
}
