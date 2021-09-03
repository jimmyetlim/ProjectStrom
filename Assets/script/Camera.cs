using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject hero;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - hero.transform.position;
    }
    
    void LateUpdate()
    {
        transform.position = hero.transform.position + offset;
    }
}
