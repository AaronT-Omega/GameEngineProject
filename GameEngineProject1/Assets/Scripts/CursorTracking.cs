using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTracking : MonoBehaviour
{

    private Camera cam;


    private void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y, Camera.main.nearClipPlane + 0.1f)); // Adjust Z for perspective camera

        Vector3 direction = mouseWorldPos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Adjust for sprite orientation and rotates player to face the mouse
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90);

    }
}
