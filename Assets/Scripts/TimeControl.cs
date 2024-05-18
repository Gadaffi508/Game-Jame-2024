using System.Collections;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    public float normalTimeScale = 1f;
    public float fastTimeScale = 2f;
    public float slowTimeScale = 0.5f;

    public Camera mainCamera;
    public float normalFOV = 60f;
    public float fastFOV = 80f;

    public float abilityDuration = 10f;
    public float cooldownDuration = 30f;

    private bool canUseAbility = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canUseAbility)
        {
            StartCoroutine(UseAbility(fastTimeScale, fastFOV));
            Debug.Log("1");
        }
        else if (Input.GetKeyDown(KeyCode.L) && canUseAbility)
        {
            StartCoroutine(UseAbility(slowTimeScale, normalFOV));
            Debug.Log("2");
        }
     
    }

    private IEnumerator UseAbility(float timeScale, float fov)
    {
        canUseAbility = false;
        Time.timeScale = timeScale;
        mainCamera.fieldOfView = fov;

        yield return new WaitForSecondsRealtime(abilityDuration);

        SetNormalTime();

        yield return new WaitForSecondsRealtime(cooldownDuration - abilityDuration);

        canUseAbility = true;
    }

    private void SetNormalTime()
    {
        Time.timeScale = normalTimeScale;
        mainCamera.fieldOfView = normalFOV;
    }
}