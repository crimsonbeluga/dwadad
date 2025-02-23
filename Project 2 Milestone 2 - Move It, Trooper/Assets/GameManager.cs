using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int deathTargetCount = 0;
    public int DeathTargetCount => deathTargetCount;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterDeathTarget()
    {
        deathTargetCount++;
        Debug.Log("DeathTarget added. Total count: " + deathTargetCount);
    }

    public void UnregisterDeathTarget()
    {
        deathTargetCount = Mathf.Max(0, deathTargetCount - 1);
        Debug.Log("DeathTarget removed. Total count: " + deathTargetCount);

        // Check if all DeathTargets are destroyed
        if (deathTargetCount == 0)
        {
            WinGame();
        }
    }

    public void WinGame()
    {
        Debug.Log("You Win!");
    }

    public void LoseGame()
    {
        Debug.Log("You Lose!");
    }
}
