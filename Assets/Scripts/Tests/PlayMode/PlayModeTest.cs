using System.Collections;
using UnityEngine.SceneManagement;

namespace Tests.PlayMode
{
    public static class PlayModeTest
    {
        public static IEnumerator StartOfflinePlaymodeTest()
        {
            SceneManager.LoadScene("Main");
            yield return null;
        }
    }
}