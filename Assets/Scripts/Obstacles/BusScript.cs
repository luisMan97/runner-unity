using UnityEngine;

public class BusScript : MonoBehaviour
{
    public static class Constants
    {
        public const float speed = 7.5f;
    }

    public EndlessScroll endlessScroll;

    private void Update()
    {
        MoveToBack();
        MoveToForward();
    }

    private void MoveToBack()
    {
        transform.Translate(Vector3.forward * Constants.speed * Time.deltaTime);
    }

    private void MoveToForward()
    {
        if (transform.position.z <= -EndlessScroll.Constants.platformSize)
        {
            transform.Translate(Vector3.back * EndlessScroll.Constants.platformSize * endlessScroll.GetSectionsCount());
            gameObject.SetActive(false);
        }
    }
}
