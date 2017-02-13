using UnityEngine;
using UnityEngine.Video;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class Form : MonoBehaviour {
    [DllImport("user32.dll")]
    private static extern void OpenFileDialog();

    [SerializeField]
    private VideoPlayer videoPlayer;

    void Start () {
        OpenFileAndPlay();
	}

    public void OpenFileAndPlay()
    {
        string filePath = OpenFile();

        if (filePath == "")
        {
            return;
        }

        string filename = System.IO.Path.GetFileName(filePath);
        videoPlayer.url = "file://" + filePath;
        videoPlayer.Play();
    }

    private string OpenFile()
    {
        OpenFileDialog dialog = new OpenFileDialog();
        DialogResult result = dialog.ShowDialog();

        return dialog.FileName;
    }
}
