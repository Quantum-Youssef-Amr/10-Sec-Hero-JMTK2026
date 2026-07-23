using UnityEngine;

public class LevelStart : MonoBehaviour
{
    public void StartLevel()
    {
        EventBus.Instance.OnStartTimer?.Invoke();
        EventBus.Instance.OnStartLevelSpawner.Invoke();
    }
}
