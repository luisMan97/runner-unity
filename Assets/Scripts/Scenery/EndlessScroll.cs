using UnityEngine;

public class EndlessScroll : MonoBehaviour
{
    public static class Constants
    {
        public const int platformSize = 90;
        public const float gameSpeed = 5;
    }

    public bool platformRestored;

    int sectionsCount;

    private void Start()
    {
        sectionsCount = GameObject.FindGameObjectsWithTag(TagConstants.section).Length;
    }

    private void Update()
    {
        MoveToBack();
        MoveToForward();
    }

    public int GetSectionsCount()
    {
        return sectionsCount;
    }

    private void MoveToBack()
    {
        transform.Translate(Vector3.back * Constants.gameSpeed * Time.deltaTime);
    }

    private void MoveToForward()
    {
        platformRestored = transform.position.z <= -Constants.platformSize;
        GameManager.Instance.platformRestored = platformRestored;
        if (transform.position.z <= -Constants.platformSize)
            transform.Translate(Vector3.forward * Constants.platformSize * sectionsCount);
    }
}
