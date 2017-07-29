using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuScroller : EventTrigger
{

    float oldPos = 0;
    float current;
    public override void OnBeginDrag(PointerEventData data)
    {
        Debug.Log("begin drag");
        oldPos = data.position.x;
    }
    public override void OnDrag(PointerEventData data)
    {
        Debug.Log("drag");
        
 
            current = data.position.x - oldPos;
        if (current > 200)
            current = 200;
        if (current < -200)
            current = -200;
   

            this.transform.GetChild(0).transform.GetChild(0).transform.position = new Vector2(this.transform.GetChild(0).transform.GetChild(0).transform.position.x + current, this.transform.GetChild(0).transform.GetChild(1).transform.position.y);
            this.transform.GetChild(0).transform.GetChild(1).transform.position = new Vector2(this.transform.GetChild(0).transform.GetChild(1).transform.position.x + current, this.transform.GetChild(0).transform.GetChild(2).transform.position.y);
            this.transform.GetChild(0).transform.GetChild(2).transform.position = new Vector2(this.transform.GetChild(0).transform.GetChild(2).transform.position.x + current, this.transform.GetChild(0).transform.GetChild(3).transform.position.y);
            this.transform.GetChild(0).transform.GetChild(3).transform.position = new Vector2(this.transform.GetChild(0).transform.GetChild(3).transform.position.x + current, this.transform.GetChild(0).transform.GetChild(4).transform.position.y);
            this.transform.GetChild(0).transform.GetChild(4).transform.position = new Vector2(this.transform.GetChild(0).transform.GetChild(4).transform.position.x + current, this.transform.GetChild(0).transform.GetChild(5).transform.position.y);
            this.transform.GetChild(0).transform.GetChild(5).transform.position = new Vector2(this.transform.GetChild(0).transform.GetChild(5).transform.position.x + current, this.transform.GetChild(0).transform.GetChild(6).transform.position.y);
            this.transform.GetChild(0).transform.GetChild(6).transform.position = new Vector2(this.transform.GetChild(0).transform.GetChild(6).transform.position.x + current, this.transform.GetChild(0).transform.GetChild(7).transform.position.y);

            oldPos = data.position.x;       
    }
    public override void OnEndDrag(PointerEventData data)
    {
        oldPos = 0;
        Debug.Log("OnEndDrag called.");
    }


}
