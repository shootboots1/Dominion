using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] playerCells;
    public GameObject[] enemyCells;
    public float currentTime;
    public float timeThreshold = 3;

    public float manaAmount;
    public int maxMana;
    public TextMeshProUGUI manaText;

    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.minValue = 0;
        slider.maxValue = maxMana;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = manaAmount;
        if(currentTime > timeThreshold)
        {
            playerCells = GameObject.FindGameObjectsWithTag("RedCells");
            enemyCells = GameObject.FindGameObjectsWithTag("GreenCells");
            currentTime = 0;
        }
        else
        {
            currentTime += Time.deltaTime;
        }
        if(manaAmount < maxMana)
        {
            manaAmount += Time.deltaTime / 1.4f;
        }
        manaText.text = manaAmount.ToString("0");
    }
}
