using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MemoryGameController : MonoBehaviour
{
    [SerializeField] MemoryTag tag;
    [SerializeField] ParticleSystem ps;
    [SerializeField] float startRate = 1;
    [SerializeField] float speedUpRate = 0.1f;
    [SerializeField] TextMeshProUGUI timerTxt;
    [SerializeField] TextMeshProUGUI gameOver;
    [SerializeField] TextMeshProUGUI[] codesTxt;
    [SerializeField] TextMeshProUGUI typingTxt;
    [SerializeField] Transform startPos;
    [SerializeField] Sprite[] sprites;

    float timer = 0;
    float timeToNextTag;
    int tagCounter = 0;
    int[] codes = { 0, 0, 0, 0 };
    string typedStr = "";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
        timeToNextTag = 3;
        codes[0] = Random.Range(1000, 10000);
        codesTxt[0].text = codes[0].ToString();
        codes[1] = Random.Range(1000, 10000);
        codesTxt[1].text = codes[1].ToString();
        codes[2] = Random.Range(1000, 10000);
        codesTxt[2].text = codes[2].ToString();
        codes[3] = Random.Range(1000, 10000);
        codesTxt[3].text = codes[3].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
            gameOver.gameObject.SetActive(true);
        else
            gameOver.gameObject.SetActive(false);

        timer += Time.deltaTime;
        timerTxt.text = timer.ToString("0.0") + " sec";

        timeToNextTag -= Time.deltaTime;
        if (timeToNextTag < 0)
        {



            MemoryTag newTag = Instantiate(tag, startPos.position, Quaternion.Euler(0, 0, 0));

            newTag.memoryType = (MemoryTag.MemoryType)Random.RandomRange(0, 4);
            switch (newTag.memoryType)
            {
                case MemoryTag.MemoryType.Alarm:
                    newTag.memoryCode = codes[0];
                    newTag.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[0];
                    break;
                case MemoryTag.MemoryType.Card:
                    newTag.memoryCode = codes[1];
                    newTag.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[1];
                    break;
                case MemoryTag.MemoryType.Petrol:
                    newTag.memoryCode = codes[2];
                    newTag.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[2];
                    break;
                case MemoryTag.MemoryType.Mobile:
                    newTag.memoryCode = codes[3];
                    newTag.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[3];
                    break;
                default:
                    break;
            }

            tagCounter += 1;
            timeToNextTag = startRate - tagCounter * speedUpRate;
            if (timeToNextTag < 0.5f)
                timeToNextTag = 0.5f;



        }


        if (typedStr.Length > 0 && Input.GetKeyDown(KeyCode.Backspace))
        {
            typedStr = typedStr.Substring(0, typedStr.Length - 1);
        }
        else if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            MemoryTag[] memoryTags = FindObjectsByType<MemoryTag>(FindObjectsSortMode.InstanceID);
            for (int i = memoryTags.Length - 1; i >= 0; i--)
            {
                if (memoryTags[i].memoryCode.ToString() == typedStr)
                {
                    ParticleSystem newPS= Instantiate(ps, memoryTags[i].gameObject.transform.position, Quaternion.Euler(0, 0, 0));
                    newPS.startColor = memoryTags[i].GetComponent<SpriteRenderer>().color;
                    Destroy(memoryTags[i].gameObject);
                    newPS.Play();
                    Destroy(newPS.gameObject,2);
                    break;
                }
            }
            typedStr = "";
        }

        else
        {
            int n;
            bool isNumeric = int.TryParse(Input.inputString, out n);
            if (isNumeric)
            {
                typedStr = typedStr + n.ToString();
            }

        }

        typingTxt.text = typedStr;

    }




    public void EndOfGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScene");
    }
}
