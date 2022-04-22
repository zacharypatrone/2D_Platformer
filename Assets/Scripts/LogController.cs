using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LogController : MonoBehaviour
{

    public float yRotateSpeed = .25f;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, yRotateSpeed, 0);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController.numCoins++;
            Destroy(gameObject); 
        }
    }

    
}
