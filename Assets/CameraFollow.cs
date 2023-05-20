using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
     [SerializeField] Transform target; // Referensi ke Transform pemain
    public Vector3 offset = new Vector3(0f, 0f, 0f); // Jarak kamera terhadap pemain

    private void LateUpdate()
    {
        if (target != null)
        {
            // Mengatur posisi kamera ke posisi pemain ditambah offset
            transform.position = target.position + offset;
        }
    }
}
