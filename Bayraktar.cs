using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bayraktar : MonoBehaviour
{
    readonly float speed = 1;
    private Rigidbody2D rb;
    List<GameObject> myList = new List<GameObject>();

    GameObject go;

    public float totalScore;
    public Text myText;

    public ParticleSystem DestructionEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        totalScore += Mathf.Ceil(Time.deltaTime);
        myText.text = "Score: " + totalScore;

        float verticalMove = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, verticalMove * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject != null)
        {
            if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Delete")
            {
                Destroy(gameObject);
                myText.text = "You lose. Your total score: " + totalScore + " Click 'Space' to reset";
            }
            if (collision.gameObject.tag == "Coin")
                totalScore += 1000;
        }
    }
}
