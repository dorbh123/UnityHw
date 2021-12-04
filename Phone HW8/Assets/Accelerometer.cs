using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;
   public bool dragging = false;
    Color activeColor = new Color();
    Rigidbody rd;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.acceleration.x / 10, 0, -Input.acceleration.z / 10);
        if (dragging)
        {
            activeColor = Color.red;
            Debug.Log("rotate");
            if (Input.touchCount==1)
            {
                Touch screenTouch = Input.GetTouch(0);
                if (screenTouch.phase == TouchPhase.Moved)
                {
                    transform.Rotate(0f, screenTouch.deltaPosition.x, 0f);
                }
                if (screenTouch.phase== TouchPhase.Ended)
                {
                    dragging = false;
                }
            }
        }
        else
        {
            activeColor = Color.white;
        }
        GetComponent<MeshRenderer>().material.color = activeColor;
    }
}
