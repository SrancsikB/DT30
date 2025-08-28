using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubjectGameController : MonoBehaviour
{
    [SerializeField] SubjectTag tag;
    [SerializeField] float startRate = 1;
    [SerializeField] float speedUpRate = 0.1f;
    [SerializeField] TextMeshProUGUI timerTxt;
    [SerializeField] TextMeshProUGUI gameOver;
    [SerializeField] float xOffset = 11;
    [SerializeField] float yOffset = 7;
    float timer = 0;
    float timeToNextTag;
    int tagCounter = 0;
    int dirTypeNotAllowedForNext = -1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
        timeToNextTag = 3;
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
            float xOffset2;
            float yOffset2;

            int rndDir = Random.Range(0, 4);
            while (rndDir == dirTypeNotAllowedForNext)
            {
                rndDir = Random.Range(0, 4);
            }
            dirTypeNotAllowedForNext = rndDir;

            if (rndDir == 0) //Right
            {
                xOffset2 = -1 * xOffset;
                yOffset2 = Random.Range(-1 * yOffset, yOffset);
            }
            else if (rndDir == 1) //down
            {
                yOffset2 = 1 * yOffset;
                xOffset2 = Random.Range(-1 * xOffset, xOffset);
            }
            else if (rndDir == 2) //left
            {
                xOffset2 = 1 * xOffset;
                yOffset2 = Random.Range(-1 * yOffset, yOffset);
            }
            else //up
            {
                yOffset2 = -1 * yOffset;
                xOffset2 = Random.Range(-1 * xOffset, xOffset);
            }


            float rndRot = Random.Range(-180, 180);


            //SubjectTag newTag = Instantiate(tag, new Vector3(rndX, 0, 0), Quaternion.Euler(0, 0, rndRot));
            SubjectTag newTag = Instantiate(tag, new Vector3(xOffset2, yOffset2, -0.01f * tagCounter), Quaternion.Euler(0, 0, 0));
            newTag.speed = startRate;
            if (rndDir == 0) //Right
            {
                newTag.dirX = 1;
            }
            else if (rndDir == 1) //down
            {
                newTag.dirY = -1;
            }
            else if (rndDir == 2) //left
            {
                newTag.dirX = -1;
            }
            else //up
            {
                newTag.dirY = 1;
            }

            //Instantiate(screws[rndScrew], new Vector3(rndX, 12, 0), Quaternion.Euler(0, 0, rndRot));

            tagCounter += 1;
            timeToNextTag = startRate - tagCounter * speedUpRate;
            if (timeToNextTag < 0.5f)
                timeToNextTag = 0.5f;

        }

    }




    public void EndOfGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScene");
    }
}
