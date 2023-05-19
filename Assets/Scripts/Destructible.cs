using UnityEngine;

public class Destructible : MonoBehaviour
{
    public float destroyDelay = 2f; // Yok olma gecikmesi (saniye)

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Çarpýþan nesne oyuncu ise, belirli bir süre sonra objeyi yok etmek için Invoke metoduyla DestroyObject metodu çaðrýlýr
            Invoke("DestroyObject", destroyDelay);
        }
    }

    private void DestroyObject()
    {
        // Objeyi yok et
        Destroy(gameObject);
    }
}
