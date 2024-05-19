using UnityEngine;

public class DecisionAnswer : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("Scene loaded");
            return;
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("Finish");
            return;
        }
    }
}
