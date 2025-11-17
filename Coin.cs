using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreValue = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            gameManager.AddScore(scoreValue);
            Destroy(this.gameObject);
        }
    }
}
