using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Transform[] points;

    private float speed = 5f;
    private float minDistance = 0.1f;
    private int i = 1;
    private void Start()
    {
        transform.position = points[0].position;        
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        
        // Rotation
        Vector3 direction = points[i].position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;

        
        if(Vector3.Distance(transform.position, points[i].position) < minDistance && i < points.Length)
        {
            
            gameObject.GetComponent<Renderer>().material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f)); // Color change
            
            if (i == points.Length - 1)
            {
                i = -1;
            }
            i++;
        }        
    } 
}
