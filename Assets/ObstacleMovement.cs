using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private float screenBottom = -6.5f;
    private SpriteRenderer spriteRenderer;

    // Neon renk paleti
    private Color[] neonColors = new Color[]
    {
        new Color(1f, 0.05f, 0.5f),   // Neon Pembe / Macenta
        new Color(0f, 1f, 1f),        // Neon Camgöbeği (Cyan)
        new Color(0.2f, 1f, 0.2f),    // Neon Yeşil
        new Color(1f, 0.6f, 0f),      // Neon Turuncu
        new Color(0.7f, 0f, 1f),      // Neon Mor
        new Color(1f, 1f, 0f)         // Neon Sarı
    };

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            // Doğduğu anda rastgele bir neon renk ata
            spriteRenderer.color = neonColors[Random.Range(0, neonColors.Length)];
        }
    }

    void Update()
    {
        float speed = (GameManager.instance != null) ? GameManager.instance.currentObstacleSpeed : 5f;
        transform.position += Vector3.down * speed * Time.deltaTime;

        // Ekranın altına ulaştığında yok et
        if (transform.position.y < screenBottom)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.GameOver();
            }
        }
    }
}