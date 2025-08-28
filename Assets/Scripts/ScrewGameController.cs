using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScrewGameController : MonoBehaviour
{

    [SerializeField] Screw[] screws;
    [SerializeField] float startRate = 3;
    [SerializeField] float speedUpRate = 0.1f;
    [SerializeField] TextMeshProUGUI timerTxt;
    [SerializeField] TextMeshProUGUI gameOver;
    float timer = 0;
    float timeToNextScrew;
    int screwCounter = 0;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
        timeToNextScrew = 3;
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
        timeToNextScrew -= Time.deltaTime;
        if (timeToNextScrew < 0)
        {
            float rndX = Random.Range(-3, 3);
            float rndRot = Random.Range(-180, 180);
            int rndScrew = Random.Range(0, 6);


            Instantiate(screws[rndScrew], new Vector3(rndX, 12, 0), Quaternion.Euler(0, 0, rndRot));

            screwCounter += 1;
            timeToNextScrew = startRate - screwCounter * speedUpRate;
            if (timeToNextScrew < 0.5f)
                timeToNextScrew = 0.5f;

        }

    }

    public void EndOfGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScene");
    }
}
