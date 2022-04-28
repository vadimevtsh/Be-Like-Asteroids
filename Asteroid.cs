using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    Vector2 movingPosition;
    float speed;

    void Update()
    {
        speed = Random.Range(0.5f, 1.5f);
        movingPosition.x -= 3;
        transform.position = Vector2.MoveTowards(transform.position, movingPosition, Time.deltaTime * speed);        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject != null)
            if (collision.gameObject.tag == "Delete")
                Destroy(gameObject);
    }


}
