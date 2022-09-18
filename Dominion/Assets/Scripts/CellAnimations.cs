using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellAnimations : MonoBehaviour
{
    public Animator anim;

    public float currentTime;
    public float threshold;

    public GameObject eyeWhite;
    // Start is called before the first frame update
    void Start()
    {
        eyeWhite.transform.localScale = new Vector3(7.384487f, 7.384487f, 7.384487f);
        threshold = Random.Range(0.15f, 10.00f);
    }

    // Update is called once per frame
    void Update()
    {
        eyeWhite.transform.localScale = new Vector3(7.384487f, 7.384487f, 7.384487f);

        if (currentTime > threshold)
        {
            currentTime = 0;
            threshold = Random.Range(5.00f, 10.00f);
            anim.SetTrigger("blink");

        }
        currentTime += Time.deltaTime;
    }
}
