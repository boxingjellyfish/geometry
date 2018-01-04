using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour
{
    public Transform squarePrefab;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                Application.Quit();
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void StartButtonClick()
    {
        SceneManager.LoadScene("TestScene");
    }

    public void ExitButtonClick()
    {
        Application.Quit();
    }

    public void AddRectangleClick()
    {
        var newSquare = Instantiate(squarePrefab, new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0), Quaternion.identity);
        newSquare.name = "GreenSquare";
        newSquare.transform.parent = GameObject.Find("_Dynamic").transform;

        GameObject shape = new GameObject("LineRenderer");
        shape.transform.parent = GameObject.Find("_Dynamic").transform;
        shape.transform.position = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);

        shape.AddComponent<CircularMotionScript>();

        Color c1 = Color.yellow;
        Color c2 = Color.red;

        LineRenderer lineRenderer = shape.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.widthMultiplier = 0.1f;
        lineRenderer.positionCount = 4;
        lineRenderer.useWorldSpace = false;
        lineRenderer.loop = true;
        lineRenderer.SetPosition(0, new Vector3(0, 0, 0));
        lineRenderer.SetPosition(1, new Vector3(0, 4, 0));
        lineRenderer.SetPosition(2, new Vector3(4, 4, 0));
        lineRenderer.SetPosition(3, new Vector3(4, 0, 0));

        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
            );
        lineRenderer.colorGradient = gradient;
    }
}
