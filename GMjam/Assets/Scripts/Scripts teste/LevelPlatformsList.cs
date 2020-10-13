using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelPlatformsList : MonoBehaviour
{

    public int[] PlatformTypeAmount = new int[3];
    public int[] PlatformTypeAmountBackUp = new int[3];

    public Transform[] PlatformPositions;
    public Text[] platformNumbers;

    public List<GameObject> PlatformTypes = new List<GameObject>();
    public List<GameObject> SelectedPlatforms;
    public List<GameObject> SelectedPlatformsBackup;

    public List<GameObject> PlatformPanels;
    public Transform SelectPlataformsTransform;


    

    

    // Start is called before the first frame update
    void Start()
    {
        SetTextUI();
        
        for (int i = 0; i < PlatformTypeAmount.Length; i++)
        {
            PlatformTypeAmountBackUp[i] = PlatformTypeAmount[i];
        }

            
    }

    // Update is called once per frame
    void Update()
    {
        SetTextUI();
    }

    public void AddPlatform1()
    {
        if (PlatformTypeAmount[0] > 0)
        {
            SelectedPlatforms.Add(PlatformTypes[0]);
            PrintSelectPlatforms();
            PlatformTypeAmount[0]--;
        }
        
    }

    public void AddPlatform2()
    {
        if (PlatformTypeAmount[1] > 0)
        {
            SelectedPlatforms.Add(PlatformTypes[1]);
            PrintSelectPlatforms();
            PlatformTypeAmount[1]--;
        }
    }

    public void AddPlatform3()
    {
        if (PlatformTypeAmount[2] > 0)
        {
            SelectedPlatforms.Add(PlatformTypes[2]);
            PrintSelectPlatforms();
            PlatformTypeAmount[2]--;
        }
    }

    public void AddPlatform4()
    {
        if (PlatformTypeAmount[3] > 0)
        {
            SelectedPlatforms.Add(PlatformTypes[3]);
            PrintSelectPlatforms();
            PlatformTypeAmount[3]--;
        }
    }

    public void UsePlatform()
    {
        SelectedPlatforms.RemoveAt(0);
        DestroyPlatformUI();
        PrintSelectPlatforms();
    }

    public void PrintSelectPlatforms()
    {
        int cont = 0;
        foreach(GameObject platform in SelectedPlatforms)
        {
           if (cont < PlatformPositions.Length)
            {
                switch (platform.name)
                {
                    case "Platform 1":

                        Instantiate(PlatformPanels[0], PlatformPositions[cont].position, PlatformPanels[0].transform.rotation, SelectPlataformsTransform);
                        cont++;
                        break;

                    case "Platform 2":
                        Instantiate(PlatformPanels[1], PlatformPositions[cont].position, PlatformPanels[1].transform.rotation, SelectPlataformsTransform);
                        cont++;
                        break;

                    case "Platform 3":
                        Instantiate(PlatformPanels[2], PlatformPositions[cont].position, PlatformPanels[2].transform.rotation, SelectPlataformsTransform);
                        cont++;
                        break;
                    case "Platform 4":
                        Instantiate(PlatformPanels[3], PlatformPositions[cont].position, PlatformPanels[3].transform.rotation, SelectPlataformsTransform);
                        cont++;
                        break;
                }
            }
          
        }
    }

    public void DestroyPlatformUI()
    {
       
        foreach(GameObject platformUI in GameObject.FindGameObjectsWithTag("PlatFormUI"))
        {
            GameObject.Destroy(platformUI);
        }
    }

    public void SetTextUI()
    {
        int aux = 0;
    

        foreach(Text number in platformNumbers)
        {
            number.text = PlatformTypeAmount[aux].ToString();
            aux++;
        }
        aux = 0;
    }

    public void MakeBackUp()
    {
        SelectedPlatformsBackup = new List<GameObject>(SelectedPlatforms);
    }


    public void UseBackup()
    {

        SelectedPlatforms = new List<GameObject>(SelectedPlatformsBackup);
        DestroyPlatformUI();
        PrintSelectPlatforms();;
    }

    public void ResetPlatformSelection()
    {
        DestroyPlatformUI();
        SelectedPlatforms.Clear();
        for (int i = 0; i < PlatformTypeAmount.Length; i++)
        {
             PlatformTypeAmount[i] = PlatformTypeAmountBackUp[i];
        }

    }
}
