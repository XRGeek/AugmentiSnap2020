using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;

public class FaceChanger : MonoBehaviour
{
    public GameObject[] facePrefabs;
    public ARSession arSession;

    private ARFaceManager faceManager;

    private List<ARFace> activeFaces = new List<ARFace>();

    public static int faceIndex;

    

    // Start is called before the first frame update
    void Start()
    {

        faceManager = GetComponent<ARFaceManager>();
        faceManager.facePrefab=facePrefabs[faceIndex];
        arSession.Reset();
    }

    public void SelectFace(int index)
    {
        Debug.Log(index);

        faceIndex = index;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        //foreach (var face in faceManager.trackables)
        //{
        //    activeFaces.Add(face);
        //}
        //Debug.Log("After all tracked face collected");
        //faceManager.facePrefab = facePrefabs[index];
        //Debug.Log("After new prefab");

        //foreach (var face in activeFaces)
        //{
        //    Destroy(face.gameObject);
        //}

        //Debug.Log("After old face destroyed");

        //arSession.Reset();
        //Debug.Log("After session reset");
    }
}
