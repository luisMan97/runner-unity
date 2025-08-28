using UnityEngine;

public class PolicePigPositionChecker : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PolicePigPositionBackChecker"))
        {
            Debug.Log("isVisible c" + GameManager.Instance.policePigIsVisible);
            GameManager.Instance.policePigIsVisible = false;
        }
    }

    /*void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PolicePigPositionBackChecker"))
            GameManager.Instance.policePigIsVisible = true;
    }*/
}
