using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellConsumption : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GreenCells"))
        {
            if (transform.localScale.x > collision.transform.localScale.x)
            {
                transform.localScale -= new Vector3(collision.transform.localScale.x/1.5f, collision.transform.localScale.y/1.5f, collision.transform.localScale.z/1.5f);
                Destroy(collision.gameObject);
            }
            else if (transform.localScale.x < collision.transform.localScale.x){
                collision.transform.localScale -= new Vector3(transform.localScale.x / 1.5f, transform.localScale.y / 1.5f, transform.localScale.z / 1.5f);
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionStay2D(Collision2D collision){
        if (collision.gameObject.CompareTag("GreenCells"))
        {
            if (transform.localScale.x > collision.transform.localScale.x)
            {
                transform.localScale -= new Vector3(collision.transform.localScale.x / 1.5f, collision.transform.localScale.y / 1.5f, collision.transform.localScale.z / 1.5f);
                Destroy(collision.gameObject);
            }
            else if (transform.localScale.x < collision.transform.localScale.x){
                collision.transform.localScale -= new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
                Destroy(gameObject);
            }
        }
    }
}
