using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityEngine.XR.ARFoundation.Samples
{
    public class BackButton : MonoBehaviour
    {
        [SerializeField]
        GameObject m_BackButton;
        public GameObject backButton
        {
            get => m_BackButton;
            set => m_BackButton = value;
        }

        void Start()
        {
            if (Application.CanStreamedLevelBeLoaded("00_Menu"))
            {
                m_BackButton.SetActive(true);
            }
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                BackButtonPressed();
            }
        }

        public void BackButtonPressed()
        {
            if (Application.CanStreamedLevelBeLoaded("00_Menu"))
            {
                SceneManager.LoadScene("00_Menu", LoadSceneMode.Single);
                LoaderUtility.Deinitialize();
            }
        }
    }
}
