using TMPro;
using UnityEngine;

public class SubjectTag : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tagTxt;
    public float speed;
    public int dirX = 0;
    public int dirY = 0;
    [SerializeField] ParticleSystem ps;

    bool valid = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int rndValue = Random.Range(0, 2);
        if (rndValue == 0)
        {
            valid = true;
        }

        if (valid)
        {
            rndValue = Random.Range(711001, 715589);
        }
        else
        {
            rndValue = Random.Range(100000, 709999);
        }

        tagTxt.text = rndValue.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(transform.position.x + Time.deltaTime * dirX, transform.position.y + Time.deltaTime * dirY, transform.position.z);
        transform.position = newPos;
    }


    private void OnMouseDown()
    {
        if (valid)
        {
            ps.Play();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            Destroy(this.gameObject, 4);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            Time.timeScale = 0;
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.GetComponent<SpriteRenderer>().enabled == true)
        {
            if (valid)
            {
                GetComponent<SpriteRenderer>().color = Color.red;
                Time.timeScale = 0;
            }
            else
            {
                Destroy(this.gameObject);
            }

        }

    }


}
