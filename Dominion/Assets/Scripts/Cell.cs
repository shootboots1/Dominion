using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public SpriteRenderer spr;
    public AbilityManager abilityManager;
    public GameManager gameManager;

    [Header("Mana Costs")]
    public int duplicateCost;
    public int dismantleCost;
    public int enlargeCost;
    public int rushCost;
    public int cellRushCost;

    [Header("Duplicate")]
    public GameObject cell;

    [Header("Dismantle")]
    public GameObject dismantledCell;
    public int dismantleAmount;
    public GameObject dismantleEffect;

    [Header("Enlarge")]
    public float enlargeAmount;

    [Header("Rush/CellRush")]
    public float rushForce;
    public float cellRushForce;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        spr.color = (new Color32(111, 30, 30, 255));
    }

    void OnMouseExit()
    {
        spr.color = (new Color32(156, 44, 44, 255));
    }

    void OnMouseDown()
    {
        if(abilityManager.currentAbility == CurrentAbility.Duplicate)
        {
            if(gameManager.manaAmount > duplicateCost)
            {
                duplicate();
                gameManager.manaAmount -= duplicateCost;
            }
            
        }
        if (abilityManager.currentAbility == CurrentAbility.Dismantle)
        {
            if(gameManager.manaAmount > dismantleCost)
            {
                StartCoroutine(dismantle());
                gameManager.manaAmount -= dismantleCost;
            }
            
        }
        if (abilityManager.currentAbility == CurrentAbility.Enlarge)
        {
            if (gameManager.manaAmount > enlargeCost)
            {
                enlarge();
                gameManager.manaAmount -= enlargeCost;
            }

        }
        if (abilityManager.currentAbility == CurrentAbility.Rush)
        {
            if(gameManager.manaAmount > rushCost)
            {
                rush();
                gameManager.manaAmount -= rushCost;
            }

        }
        if (abilityManager.currentAbility == CurrentAbility.CellRush)
        {
            if(gameManager.manaAmount > cellRushCost)
            {
                cellRush();
                gameManager.manaAmount -= cellRushCost;
            }

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
        rb.AddForce(Vector2.right * rushForce);
    }

    void cellRush()
    {
        foreach (GameObject cell in gameManager.playerCells)
        {
            cell.GetComponent<Rigidbody2D>().AddForce(Vector2.right * cellRushForce);
        }
    }
}
