using System.Collections;
using UnityEngine; // TextMeshPro kullanıyorsan burayı değiştirebilirsin
using TMPro;
public class SubtitleController : MonoBehaviour
{
    public TMP_Text subtitleText;// TextMeshPro kullanıyorsan TMP_Text yap
    [TextArea(2, 5)]
    public string[] subtitles;
    public float[] delays; // her altyazının gösterilme süresi

    void Start()
    {
        subtitleText.text = "";
        StartCoroutine(PlaySubtitles());
    }

    IEnumerator PlaySubtitles()
    {
        for (int i = 0; i < subtitles.Length; i++)
        {
            subtitleText.text = subtitles[i];
            yield return new WaitForSeconds(delays[i]);
        }

        subtitleText.text = ""; // Son altyazıdan sonra temizle
    }
}