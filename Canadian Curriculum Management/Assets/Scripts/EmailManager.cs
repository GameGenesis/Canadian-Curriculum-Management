using UnityEngine;

public class EmailManager : MonoBehaviour
{
    public static void OpenEmailClient(int contactNumber)
    {
        string recepientEmail = GameManager.Instance.TeacherEmails[contactNumber];
        string recepientName = GameManager.Instance.TeacherNames[contactNumber];

        if (string.IsNullOrEmpty(recepientEmail) || string.IsNullOrEmpty(recepientName))
        {
            Debug.LogError("Recepient email or name is missing!");
            return;
        }

        string subject = "Feedback";
        string body = $"Dear {recepientName},%0D%0A%0D%0A*Your Body Text Here*%0D%0A%0D%0ABest Regards,%0D%0A{LoginManager.Instance.Username}";
        OpenLink($"mailto:{recepientEmail}?subject={subject}&body={body}");
    }

    public static void OpenLink(string link)
    {
        bool googleSearch = link.Contains("google.com/search");
        string linkNoSpaces = link.Replace(" ", googleSearch ? "+" : "%20");
        Application.OpenURL(linkNoSpaces);
    }
}
