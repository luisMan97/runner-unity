using UnityEngine;
using System.Collections;

public class PolicePigMovment : MonoBehaviour
{
    public float duration = 2f;


    private void Start()
    {
        StartCoroutine(ChangePositionAfterDelay(false, 3));
    }

    private void Update()
    {
        if (!GameManager.Instance.policePigIsVisible)
            Debug.Log("isVisible " + GameManager.Instance.policePigIsVisible);
        if (GameManager.Instance.showPolicePig && !GameManager.Instance.policePigIsVisible)
        {
            Debug.Log("show");
           
            StartCoroutine(ChangePositionAfterDelay(true));
        }
            
    }

    private IEnumerator ChangePositionAfterDelay(bool show, float delay = 0)
    {
        yield return new WaitForSeconds(delay);
        float newPosition;
        if (show)
        {
            newPosition = transform.position.z + 1f;
            GameManager.Instance.policePigIsVisible = true;
            GameManager.Instance.showPolicePig = false;
        }
        else
        {
            newPosition = transform.position.z - 1f;
            
        }
        float startZ = transform.position.z;
        float endZ = newPosition;
        float elapsed = 0f;

        // Interpolación lineal de la posición en el eje Z
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float newZ = Mathf.Lerp(startZ, endZ, elapsed / duration);
            transform.position = new Vector3(transform.position.x, transform.position.y, newZ);
            yield return null;
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, endZ);

        if (show)
            StartCoroutine(ChangePositionAfterDelay(false, 3));
    }
}
