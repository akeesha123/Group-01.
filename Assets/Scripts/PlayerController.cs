using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 8f;
    public float xLimit = 8f;

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");

        transform.Translate(
            Vector3.right * move * speed * Time.deltaTime
        );

        float clampedX = Mathf.Clamp(
            transform.position.x,
            -xLimit,
            xLimit
        );

        transform.position = new Vector3(
            clampedX,
            transform.position.y,
            0f
        );
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fruit"))
        {
            GameManager.instance.AddScore(1);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Bomb"))
        {
            GameManager.instance.LoseLife();
            Destroy(other.gameObject);
        }
    }
}