using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public float bottomY = -6f;

    void Update()
    {
        if (transform.position.y < bottomY)
        {
            if (CompareTag("Fruit"))
            {
                GameManager.instance.LoseLife();
            }

            Destroy(gameObject);
        }
    }
}