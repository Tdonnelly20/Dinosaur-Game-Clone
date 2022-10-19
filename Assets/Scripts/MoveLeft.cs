using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float Speed;
    //Start position
    public float StartPosition;
    //end position
    public float EndPosition;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x - Speed * Time.deltaTime, transform.position.y);
        if (transform.position.x <= EndPosition)
        {
            if (gameObject.CompareTag("Obstacle"))
            {
                Destroy(gameObject);
            }
            else
            {
                transform.position = new Vector3(StartPosition, transform.position.y);
            }
        }
    }
}
