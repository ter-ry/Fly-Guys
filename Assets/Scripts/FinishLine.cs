using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private bool hasPlayerFinished = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayerFinished)
        {
            hasPlayerFinished = true;
            // Add any other code to stop the game or show messages here
        }
    }

    public bool FinishLineReached()
    {
        return hasPlayerFinished;
    }
}
