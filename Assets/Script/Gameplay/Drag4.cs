﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag4 : MonoBehaviour
{
    private float StartPorX;
    private float StartPorY;
    private bool isBeingHeld = false;

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
            Physics2D.IgnoreLayerCollision(11, 14);
            Physics2D.IgnoreLayerCollision(11, 15);
            Physics2D.IgnoreLayerCollision(11, 13);
            Physics2D.IgnoreLayerCollision(11, 17);
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

        if (collision.gameObject.name == "S4")
        {
            bruh.Play();
            transform.SetParent(collision.collider.transform);
            isBeingHeld = false;
        }

    }
}
