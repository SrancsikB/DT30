using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectController : MonoBehaviour
{
    public void StartScrew()
    {
        SceneManager.LoadScene("ScrewScene");
    }

    public void StartSubject()
    {
        SceneManager.LoadScene("SubjectScene");
    }

    public void StartMemory()
    {
        SceneManager.LoadScene("MemoryScene");
    }
}
