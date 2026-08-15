using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private Color[] neonColors = new Color[]
    {
        new Color(1f, 0f, 0.5f),   // Parlak Pembe
        new Color(0f, 1f, 1f),     // Cyan
        new Color(1f, 0.9f, 0f),   // Sarı
        new Color(0.6f, 0f, 1f),   // Mor
        new Color(1f, 0.3f, 0f)    // Turuncu
    };

    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            int randomIndex = Random.Range(0, neonColors.Length);
            sr.color = neonColors[randomIndex];
        }
    }

    void Update()
    {
        // Engeller yukarıdan aşağıya (Vector3.down) doğru aksın
        float dynamicSpeed = 5f;
        if (GameManager.instance != null)
        {
            dynamicSpeed = GameManager.instance.currentObstacleSpeed;
        }

        transform.Translate(Vector3.down * dynamicSpeed * Time.deltaTime);

        // Ekranın altına (-7f) ulaştığında yok olsun
        if (transform.position.y < -7f)
        {
            Destroy(gameObject);
        }
    }
}