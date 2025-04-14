using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTestMover : MonoBehaviour
{
    public bool testMode = true;
    public float moveSpeed = 5f;

    void Update()
    {
        if (!testMode) return;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float y = 0;

        if (Input.GetKey(KeyCode.E)) y = 1;
        if (Input.GetKey(KeyCode.Q)) y = -1;

        Vector3 move = new Vector3(h, y, v) * moveSpeed * Time.deltaTime;
        transform.position += move;

        // Optional: rotate with arrow keys
        float rot = Input.GetAxis("Mouse X") * 50f * Time.deltaTime;
        transform.Rotate(0, rot, 0);
    }
}
