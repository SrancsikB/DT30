using UnityEngine;
using TMPro;

public class NumPad : MonoBehaviour
{
    [SerializeField] int numValue;
    [SerializeField] TextMeshProUGUI numTxt;
    [SerializeField] float highLightTime = 0.5f;

    float actHighLightTime;
    bool highLighted;
    SpriteRenderer sr;

    void Start()
    {
        numTxt.text = numValue.ToString();
        sr = GetComponent<SpriteRenderer>();
        highLighted = false;
        actHighLightTime = 0;
        sr.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (highLighted)
        {
            sr.color = Color.yellow;
            actHighLightTime += Time.deltaTime;
            if (actHighLightTime>=highLightTime)
            {
                highLighted = false;
                actHighLightTime = 0;
                sr.color = Color.white;
            }
        }
       
    }


    private void OnMouseDown()
    {
        highLighted = true;


    }
}
