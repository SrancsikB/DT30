using UnityEngine;

public class Screw : MonoBehaviour
{
    public enum ScrewTpye
    {
        M4x20, M4x40, M5x30, M5x50, M6x40, M6x60, Floor
    }

    [SerializeField] ScrewTpye screwTpye;

    bool moveEnable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void OnMouseDown()
    {
        if (Time.timeScale > 0)
        {
            moveEnable = true;
        }
    }

    private void OnMouseUp()
    {
        moveEnable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveEnable)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            transform.position = new Vector3(ray.origin.x, ray.origin.y, 0);
            transform.rotation = Quaternion.Euler(Vector3.zero);
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (moveEnable == false)
        {
            ScrewBox screwBox = collision.GetComponent<ScrewBox>();
            if (screwBox != null)
            {
                if (screwBox.screwType == screwTpye)
                {
                    Destroy(this.gameObject);
                }
                else
                {
                    GetComponent<SpriteRenderer>().color = Color.red;
                    Time.timeScale = 0;
                }
            }
            
        }
    }


}
