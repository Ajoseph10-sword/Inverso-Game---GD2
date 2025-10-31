using UnityEngine;
using UnityEngine.SceneManagement;

public class hoodbending : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    public void GetBumped()
    {
        SceneManager.LoadScene("Game Over");
    }

}
