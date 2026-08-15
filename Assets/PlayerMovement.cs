using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Hareket Ayarları")]
    public float smoothSpeed = 12f; // Süzülme hızı
    public float minX = -2.1f;
    public float maxX = 2.1f;

    private float targetX;

    void Start()
    {
        targetX = transform.position.x;
    }

    void Update()
    {
        // 1. Dokunmatik veya Fare ile Hedef Belirleme
        if (Input.GetMouseButton(0))
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetX = Mathf.Clamp(worldPos.x, minX, maxX);
        }

        // 2. Klavye ile Test Desteği
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal != 0)
        {
            targetX += horizontal * 10f * Time.deltaTime;
            targetX = Mathf.Clamp(targetX, minX, maxX);
        }

        // 3. Süzülerek (Lerp) Hedefe Doğru Akış
        float newX = Mathf.Lerp(transform.position.x, targetX, smoothSpeed * Time.deltaTime);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}