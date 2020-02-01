using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragging : MonoBehaviour
{
    private float StartPorX;
    private float StartPorY;
    private bool isBeingHeld = false;

    // Update is called once per frame
    void Update()
    {
        if(isBeingHeld == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - StartPorX, mousePos.y - StartPorY);
        }
    }
    public void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            StartPorX = mousePos.x - this.transform.localPosition.x;
            StartPorY = mousePos.y - this.transform.localPosition.y;

            isBeingHeld = true;
        }

    }
    public void OnMouseUp()
    {
        isBeingHeld = false;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "S1")
        {
            transform.SetParent(collision.collider.transform);
            isBeingHeld = false;
        }
       
    }
}
