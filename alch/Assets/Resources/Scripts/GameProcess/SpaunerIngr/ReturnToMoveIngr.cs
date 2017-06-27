using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToMoveIngr : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<MoveObject>())
        {
            if(collision.GetComponent<Rigidbody2D>())
            {
                collision.GetComponent<Rigidbody2D>().mass = 0;
                collision.GetComponent<Rigidbody2D>().gravityScale = 0;
                collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

                if(collision.GetComponent<DragEndDrop>())
                    collision.GetComponent<DragEndDrop>().inSequens = true;
            }
            collision.GetComponent<MoveObject>().enabled = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<MoveObject>())
        {
            collision.GetComponent<MoveObject>().enabled = true;
            if (collision.GetComponent<Rigidbody2D>())
            {
                collision.GetComponent<Rigidbody2D>().mass = 0;
                collision.GetComponent<Rigidbody2D>().gravityScale = 0;
                collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                if (collision.GetComponent<DragEndDrop>())
                    collision.GetComponent<DragEndDrop>().inSequens = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<DragEndDrop>())
            collision.GetComponent<DragEndDrop>().inSequens = false;
    }
}
