using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] string[] anthemLinks;

    public string[] TeacherNames { get; private set; }
    public string[] TeacherEmails { get; private set; }

    public string ChooseRandomLink => anthemLinks[Random.Range(0, anthemLinks.Length)];

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    public void LoadTeacherInputInfo()
    {
        if (TeacherNames == null) TeacherNames = new string[3];
        if (TeacherEmails == null) TeacherEmails = new string[3];

        TeacherNames[0] = PlayerPrefs.GetString("TeacherNameOne");
        TeacherNames[1] = PlayerPrefs.GetString("TeacherNameTwo");
        TeacherNames[2] = PlayerPrefs.GetString("TeacherNameThree");

        TeacherEmails[0] = PlayerPrefs.GetString("TeacherEmailOne");
        TeacherEmails[1] = PlayerPrefs.GetString("TeacherEmailTwo");
        TeacherEmails[2] = PlayerPrefs.GetString("TeacherEmailThree");
    }

    public void SaveTeacherInputInfo(string[] teacherNames, string[] teacherEmails)
    {
        if (teacherNames == null || teacherEmails == null)
            return;

        TeacherNames = teacherNames;
        TeacherEmails = teacherEmails;

        PlayerPrefs.SetString("TeacherNameOne", TeacherNames[0]);
        PlayerPrefs.SetString("TeacherNameTwo", TeacherNames[1]);
        PlayerPrefs.SetString("TeacherNameThree", TeacherNames[2]);

        PlayerPrefs.SetString("TeacherEmailOne", TeacherEmails[0]);
        PlayerPrefs.SetString("TeacherEmailTwo", TeacherEmails[1]);
        PlayerPrefs.SetString("TeacherEmailThree", TeacherEmails[2]);
    }
}
