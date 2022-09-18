using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICell : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody2D rb;

    [Header("Duplicate")]
    public GameObject cell;

    [Header("Dismantle")]
    public GameObject dismantleEffect;
    public int dismantleAmount = 5;
    public GameObject dismantledCell;

    [Header("Enlarge")]
    public float enlargeAmount;

    [Header("Rush/Cell Rush")]
    public float rushForce;
    public float cellRushForce;

    [Header("AI Function controller")]
    public int function;
    public float currentTime;
    public float thresholdTime;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        thresholdTime = Random.Range(3.00f, 15.00f);
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        function = Random.Range(1, 10);

    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime >= thresholdTime)
        {
            Debug.Log("do something");

            currentTime = 0;
            if(function < 4 || function == 7 || function == 6)
            {
                Debug.Log("duplicate");
                duplicate();
            }
            if(function < 6 && function > 3)
            {
                Debug.Log("dismantle");
                StartCoroutine(dismantle());
            }
            if(function == 8 || function == 9)
            {
                Debug.Log("enlarge");
                enlarge();
            }
            if(function == 10)
            {
                Debug.Log("Rush");
                rush();
            }
            if(Random.Range(1, 50) == 10)
            {
                Debug.Log("cellRush");

                cellRush();
            }
            thresholdTime = Random.Range(3.00f, 12.00f);
            function = Random.Range(1, 10);
        }
        else
        {
            currentTime += Time.deltaTime;
        }
    }


    void duplicate()
    {
        Instantiate(cell, transform.position, transform.rotation);

    }

    IEnumerator dismantle()
    {
        GameObject dismantleEff = (GameObject)Instantiate(dismantleEffect, transform.position + new Vector3(0, 0, -10f), transform.rotation);
        Destroy(dismantleEff, 1f);
        for (int i = 0; i < dismantleAmount; i++)
        {
            GameObject deadcell = (GameObject)Instantiate(dismantledCell, transform.position + new Vector3(Random.Range(0.01f, 0.1f), Random.Range(0.01f, 0.1f), 0), transform.rotation);
            deadcell.transform.localScale = new Vector3(transform.localScale.x / 2.5f, transform.localScale.y / 2.5f, transform.localScale.z / 2.5f);
            yield return new WaitForSeconds(0.1f);
        }

        Destroy(gameObject);

    }

    void enlarge()
    {

        transform.localScale = new Vector3(transform.localScale.x + enlargeAmount, transform.localScale.y + enlargeAmount, transform.localScale.x);
    }

    void rush()
    {
        rb.AddForce(Vector2.left * rushForce);

    }

    void cellRush()
    {
        foreach (GameObject cell in gameManager.enemyCells)
        {
            cell.GetComponent<Rigidbody2D>().AddForce(Vector2.left * cellRushForce);
        }
    }

}
