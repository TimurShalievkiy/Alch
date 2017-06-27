using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragEndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public bool inSequens = true;



    public void OnBeginDrag(PointerEventData eventData)
    {
        this.GetComponent<Rigidbody2D>().mass = 0;
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        this.GetComponent<MoveObject>().enabled = false;

        inSequens = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
   
        if (inSequens)
        {
            this.GetComponent<MoveObject>().enabled = true;

            this.GetComponent<Rigidbody2D>().mass = 0;
            this.GetComponent<Rigidbody2D>().gravityScale = 0;
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        else
        {
            this.GetComponent<MoveObject>().enabled = false;

            this.GetComponent<Rigidbody2D>().mass = 10;
            this.GetComponent<Rigidbody2D>().gravityScale = 10;
        }
    }
}
