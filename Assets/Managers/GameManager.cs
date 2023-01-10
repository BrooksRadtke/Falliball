using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool isGameOver = false;

    public float restartDelay;
    public GameObject gameOverMenu;

    private void Update()
    {
        LoadGameScene();
    }

    public void GameOver()
    {
        if(isGameOver == false)
        {
            isGameOver = true;
            gameOverMenu.SetActive(true);

            // Stop player from earning score on Death
            FindObjectOfType<Player>().speed = 0f;
            FindObjectOfType<Player>().maxSpeed = 0f;
            //FindObjectOfType<Player>().gravityScale = 0f;
            //FindObjectOfType<Player>().GetComponent<Rigidbody>().constraints(RigidbodyConstraints.FreezeAll);

            Debug.Log("gameOver!");
            //Invoke("Restart", restartDelay);
        }

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.X))
        {
            Restart();
        }
    }

    void Restart()
    {
        gameOverMenu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void LoadGameScene()
    {
        if(SceneManager.GetActiveScene().name != "TestScene")
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene("TestScene");
            }
        }
    }
}
