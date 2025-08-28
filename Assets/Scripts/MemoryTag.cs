using UnityEngine;

public class MemoryTag : MonoBehaviour
{
    public enum MemoryType
    {
        Alarm, Card, Petrol, Mobile
    }

    public MemoryType memoryType;
    public int memoryCode;
    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            switch (memoryType)
            {
                case MemoryType.Alarm:
                    sr.color = Color.red;
                    break;
                case MemoryType.Card:
                    sr.color = Color.green;
                    break;
                case MemoryType.Petrol:
                    sr.color = Color.blue;
                    break;
                case MemoryType.Mobile:
                    sr.color = Color.yellow;
                    break;
                default:
                    break;
            }
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        ScrewBox screwBox = collision.GetComponent<ScrewBox>();
        if (screwBox != null)
        {

            sr.color = Color.gray;
            Time.timeScale = 0;

        }

    }
}
