using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag5 : MonoBehaviour
{
    private float StartPorX;
    private float StartPorY;
    private bool isBeingHeld = false;
    public bool Check5 = false;

    private AudioSource bruh;
    // Update is called once per frame
    void Start()
    {
        bruh = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (isBeingHeld == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - StartPorX, mousePos.y - StartPorY);
            Physics2D.IgnoreLayerCollision(12, 14);
            Physics2D.IgnoreLayerCollision(12, 15);
            Physics2D.IgnoreLayerCollision(12, 16);
            Physics2D.IgnoreLayerCollision(12, 13);
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

        if (collision.gameObject.name == "S5")
        {
            bruh.Play();
            transform.SetParent(collision.collider.transform);
            isBeingHeld = false;
            Check5 = true;
        }

    }
}
