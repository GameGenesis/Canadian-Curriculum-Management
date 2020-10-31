using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoginManager : MonoBehaviour
{
    public static LoginManager Instance { get; private set; }

    [SerializeField] TMP_InputField usernameField;

    public string Username { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        DontDestroyOnLoad(this);
    }

    public void Login()
    {
        if (string.IsNullOrEmpty(usernameField.text))
        {
            Debug.Log("No username has been entered!");
            return;
        }

        Username = usernameField.text;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
