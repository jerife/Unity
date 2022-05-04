using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] float period = 2f;
    float movementFactor;
    
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (period < Mathf.Epsilon){return;}
        float cycle = Time.time / period; // continouly growing over time

        const float tau = Mathf.PI * 2; // 2 pi
        movementFactor = Mathf.Abs(Mathf.Sin(tau * cycle));
        

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
