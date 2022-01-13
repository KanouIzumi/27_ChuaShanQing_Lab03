using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BasketMovementScript_Level2 : MonoBehaviour
{
    public float speed;

    private AudioSource audioSource;
    public AudioClip[] AudioClipBGMArr;

    private Rigidbody2D rb;

    public float score;
    public GameObject scoreText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        audioSource = GetComponent<AudioSource>();
        scoreText.GetComponent<Text>().text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");

        transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);


        if (score == 100)
        {
            SceneManager.LoadScene("WinScene");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Healthy"))
        {
            score += 10;
            print("Got Fruit!");
            Destroy(collision.gameObject);
            scoreText.GetComponent<Text>().text = "Score: " + score.ToString();
        }

        else if (collision.gameObject.CompareTag("Unhealthy"))
        {
            print("Bad Stuff");
            Destroy(collision.gameObject);

        }
    }



}
