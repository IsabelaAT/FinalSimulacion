using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguidor : MonoBehaviour
{
    [SerializeField]
    private float maxAngle = 160;
    [SerializeField]
    private float minAngle = 20;
    [SerializeField]
    private float initialSpeed = 3;

    private bool launched = false;
    private Mover mover;

    void Start()
    {
        mover = GetComponent<Mover>();
    }

    void Update()
    {
        if (launched == true)
        {
            return;
        }

        // Calculate the launch dir
        MyVector mousepos = MousePosition();
        MyVector transformpos = new MyVector(transform.position);
        MyVector dif = mousepos - transformpos;

        // Set the rotation based on mouse
        float radian = Mathf.Atan2(dif.y, dif.x);
        float angle = radian * Mathf.Rad2Deg;
        if (angle < minAngle) { angle = minAngle; }
        else if (angle > maxAngle) { angle = maxAngle; }
        transform.localRotation = Quaternion.Euler(0f, 0f, angle);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            MyVector velocity = dif.Normalizar() * initialSpeed;
            mover.Launch(velocity);
            launched = true;
        }
    }

    private MyVector MousePosition()
    {
        Camera camara = Camera.main;
        Vector2 screenpos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camara.nearClipPlane);
        Vector2 worldpos = Camera.main.ScreenToWorldPoint(screenpos);
        MyVector mundopos = new MyVector(worldpos);

        return (mundopos);
    }
}
