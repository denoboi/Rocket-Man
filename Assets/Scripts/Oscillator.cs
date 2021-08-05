using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    private Vector3 startingPos;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;
    [SerializeField] float period = 3f;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time/period; //continually growing over time

        const float tau = Mathf.PI * 2; // tau pi'nin 2 kati, yani sabit olarak 6.283
        float rawSinWave = Mathf.Sin(cycles * tau); // -1 ile 1 arasinda gidip geliyor bu wave

        movementFactor = (rawSinWave+1f) / 2f; // 0 ve 1 arasinda gidip gelmesini sagliyoruz

        Vector3 offset = movementVector * movementFactor; //to calculate distance
        transform.position = startingPos + offset;
    }
}
