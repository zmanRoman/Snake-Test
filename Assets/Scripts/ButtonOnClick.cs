using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonOnClick : MonoBehaviour
{
    private static ButtonOnClick instance;
    public static ButtonOnClick Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public GameObject reloadPopup;

    public void ActiveGameObject(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }
    public void OnClickReload()
    {
        SceneManager.LoadScene(0);

    }
}
