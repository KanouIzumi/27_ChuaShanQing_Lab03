using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BasketMovementScript : MonoBehaviour
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
            SceneManager.LoadScene("GamePlay_Level 2");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Healthy"))
        {
            score += 10;
            print("Got Fruit!");
            audioSource.PlayOneShot(AudioClipBGMArr[0]);
            Destroy(collision.gameObject);
            scoreText.GetComponent<Text>().text = "Score: " + score.ToString();
        }

        else if(collision.gameObject.CompareTag("Unhealthy"))
        {
            audioSource.PlayOneShot(AudioClipBGMArr[1]);
            print("Bad Stuff");
            Destroy(collision.gameObject);
            SceneManager.LoadScene("LoseScene");

        }
    }



}
