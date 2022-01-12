using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    private int health;
    public Text healthText;
    public Text ballsText;
    private int balls = 5;
    public AudioClip collect;
    void Start()
    {
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        ShowHealth();
        ShowBalls();
    }

    void OnCollisionEnter(Collision coll) {
        Debug.Log("Collision");

        if (coll.gameObject.tag == "Enemy") {
            health--;
        }

        if (health == 0) {
            SceneManager.LoadScene("GameScene");
        }

        if (coll.gameObject.tag == "Ball") {

            GetComponent<AudioSource>().PlayOneShot(collect, 1);
            balls--;
            Destroy(coll.gameObject);
        }

        if (balls == 0) {
            SceneManager.LoadScene("GameScene");
        }
    }

    public void ShowHealth() {
        string message = health.ToString();
        healthText.text = message;
    }

    public void ShowBalls() {
        string message = balls.ToString();
        ballsText.text = message;
    }
}
