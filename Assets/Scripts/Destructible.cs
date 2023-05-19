using UnityEngine;

public class Destructible : MonoBehaviour
{
    public float destroyDelay = 2f; // Yok olma gecikmesi (saniye)

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // �arp��an nesne oyuncu ise, belirli bir s�re sonra objeyi yok etmek i�in Invoke metoduyla DestroyObject metodu �a�r�l�r
            Invoke("DestroyObject", destroyDelay);
        }
    }

    private void DestroyObject()
    {
        // Objeyi yok et
        Destroy(gameObject);
    }
}
