using UnityEngine;
using UnityEditor;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject inputMenu;
    [SerializeField] TMP_InputField[] teacherNameTexts;
    [SerializeField] TMP_InputField[] teacherEmailTexts;

    private GameManager gameManager;
    private bool inputMenuActive;
    private bool canSaveInputs;

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
        LoadTeacherInfoInput();
    }

    private void Start()
    {
        inputMenu.SetActive(false);
    }

    private void LoadTeacherInfoInput()
    {
        gameManager.LoadTeacherInputInfo();

        for (int i = 0; i < 3; i++)
        {
            teacherNameTexts[i].text = gameManager.TeacherNames[i];
            teacherEmailTexts[i].text = gameManager.TeacherEmails[i];
        }

        canSaveInputs = true;
    }

    public void OnGenerateLink()
    {
        string link = gameManager.ChooseRandomLink;
        Application.OpenURL(link);
        EditorGUIUtility.systemCopyBuffer = link;
    }

    public void OnToggleInputMenu()
    {
        inputMenuActive = !inputMenuActive;
        inputMenu.SetActive(inputMenuActive);
    }

    public void OnTeacherInfoInput()
    {
        if (!canSaveInputs)
            return;

        string[] teacherNames = new string[3];
        string[] teacherEmails = new string[3];

        for (int i = 0; i < 3; i++)
        {
            teacherNames[i] = teacherNameTexts[i].text;
            teacherEmails[i] = teacherEmailTexts[i].text;
        }

        gameManager.SaveTeacherInputInfo(teacherNames, teacherEmails);
    }

    public void OpenInfo()
    {
        Application.OpenURL("https://support.google.com/a/users/answer/9308783?hl=en");
    }
}
