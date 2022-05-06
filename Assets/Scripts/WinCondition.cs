using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    [SerializeField] ParticleSystem[] winParticleEffect = null;
    [SerializeField] GameObject[] target;
    int count = 0;
    [SerializeField] GameObject winText;


    private void Awake()
    {
        winText.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {

        foreach (GameObject i in target)
        {
            if (i.activeInHierarchy)
            {
                count++;
            }
        }
        if (count == 0)
        {
            winText.SetActive(true);
            StartCoroutine(LoadNextScene());
        }

    }

    IEnumerator LoadNextScene()
    {
        foreach (ParticleSystem i in winParticleEffect)
            i.Play(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
