using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Platform
{
    public int left, right, up, down;

}
public class readCsv : MonoBehaviour
{
    public TextAsset csvFile; // Reference of CSV file
   // public Text contentArea ; // Reference of contentArea where records are displayed
    string m_path;
    private char lineSeperater = '\n'; // It defines line seperate character
    private char fieldSeperator = ';'; // It defines field seperate chracter
    float step; // decides how far apart to space the fields
    public GameObject floor, obsticle, movingObsticle, smallObsticle, endLevel;
    float[] coordinates = { 2, 0, -2 };
    Platform platformData;  
    float offset = 20f;
    void Start()
    {
        readData();
    }
    // Read data from CSV file
    private void readData()
    {
       // m_path = Application.persistentDataPath + "/Levels/level01.csv";
        //Debug.Log("path=" + m_path);
        /*if (File.Exists(m_path))
        {
        */
            //csvFile = new TextAsset(System.IO.File.ReadAllText(m_path));
            string[] records = csvFile.text.Split(lineSeperater);
            int lineNumber = 1;
       // foreach line in the file
        foreach (string record in records)
        {
            if (lineNumber == 1) // for the 1st line, get the step(how far apart everthing is
            {
                string[] fields = record.Split(fieldSeperator);
                step = float.Parse( fields[3]);
                offset = float.Parse(fields[4]);
                //Debug.Log("step: " + step);
            }
            else // for the actual level
            {
                string[] fields = record.Split(fieldSeperator);
              //  Debug.Log("fields:" + record);
                int fieldNumber = 1;
                // foreach column in the file
                foreach (string field in fields)
                {
                    // contentArea.text += field + "\t";
                    string[] breakfields = field.Split('|');
                    if(breakfields.Length > 1)
                    {
                        if (breakfields[0] == "m")
                        {
                            // if it is a moving obsticle, create it here
                            createMovingObsticle(new Vector3((-lineNumber * step) + offset, 0.7f, -coordinates[fieldNumber - 1]), -coordinates[int.Parse(breakfields[1])]);
                        }
                        else
                        {
                            foreach (string fieldVal in breakfields)
                            {

                                createMap(fieldVal, lineNumber, fieldNumber);
                            }
                        }
                    }
                    else
                    {
                        createMap(field, lineNumber, fieldNumber);
                    }
                    fieldNumber++;
                }
            }
            //contentArea.text += '\n';
            lineNumber++;
        }
    }
    // Add data to CSV file


    // Get path for given CSV file
    private static string getPath()
    {
        #if UNITY_EDITOR
                return Application.dataPath;
        #elif UNITY_ANDROID
        return Application.persistentDataPath;// +fileName;
        #elif UNITY_IPHONE
        return GetiPhoneDocumentsPath();// +"/"+fileName;
        #else
        return Application.dataPath;// +"/"+ fileName;
        #endif
    }
    // Get the path in iOS device
    void createPlatform()
    {
        debugPlatform();
        GameObject instantiateFloor = Instantiate(floor, this.calculatePlatformPosition(platformData.left, platformData.right, platformData.down, platformData.up), Quaternion.identity);
        instantiateFloor.transform.localScale = this.calculatePlatformScale(platformData.left, platformData.right, platformData.down, platformData.up);
        platformData = null;
        Debug.Log("created platform");
    }
    void createObsticle(Vector3 ObsticlePosition)
    {
        GameObject instantiateObsticle = Instantiate(obsticle, ObsticlePosition, Quaternion.identity);
    }
    void createSmallObsticle(Vector3 ObsticlePosition)
    {
        GameObject instantiateSmallObsticle = Instantiate(smallObsticle, ObsticlePosition, Quaternion.identity);   
        
    }
    void createMovingObsticle(Vector3 ObsticlePosition, float moveby)
    {
        GameObject instantiateMovingObsticle = Instantiate(movingObsticle, ObsticlePosition, Quaternion.identity);
        movingObsticle mo = instantiateMovingObsticle.GetComponent<movingObsticle>();
        mo.moveBy = moveby;


    }
    void createFinishLine(Vector3 finishPositon)
    {
        GameObject instantiateFinish= Instantiate(endLevel, finishPositon, Quaternion.identity);
    }
    // calculate the platfrom scale depending on the up,down, left, right
    Vector3 calculatePlatformScale(int left, int right,int down, int up)
    {
        float widthScale = (right - left + 1) * 2;
        float heightScale = ((down - up) + 1) * step;
        return new Vector3(Mathf.Abs(heightScale), 1, Mathf.Abs(widthScale));
       
    }
    // calculate the platfrom position depending on the up,down, left, right
    Vector3 calculatePlatformPosition(int left, int right, int down, int up)
    {
        //Debug.Log("left: " + left + " Right:" + right);
        //Debug.Log("up: " + up + " Down: " + down);
        float widthPos = (coordinates[right - 1] + coordinates[left -1]) / 2;
        float heightPos = ((down + up) * step) / 2;
        Debug.Log("hightPos: " + heightPos);
        return new Vector3(-heightPos + offset, 0, -widthPos);
    }
    void debugPlatform()
    {
      //  Debug.Log("Left:" + platformData.left + " Right:" + platformData.right + " up:" + platformData.up + " Down:" + platformData.down);
    }

    void createMap(string field, int lineNumber, int fieldNumber )
    {
        switch (field)
        {
            // case for the platforms
            case "p":
                // if its a platform
                // first initialise the object
                if (platformData == null)
                {
                    // if its the first one
                    platformData = new Platform();
                    platformData.up = lineNumber;
                    platformData.left = fieldNumber;
                    debugPlatform();
                }
                // once the object is set, look for the right one
                else if (platformData.left != 0)
                {
                    // if the upper left is already set, check if the next one is in the same line
                    if (platformData.up == lineNumber)
                    {
                        // set the right one
                        platformData.right = fieldNumber;
                        debugPlatform();
                    }
                    // if it is not on the same line, then it is a single column platform, add the down and create it
                    else if (platformData.up != lineNumber && platformData.right == 0)
                    {
                        platformData.right = platformData.left;
                        platformData.down = lineNumber;
                        createPlatform();

                    }
                    // if the down has not yet been set, then get that
                    else if (platformData.down == 0)
                    {
                        // if up, left, and right are set get the down value
                        platformData.down = lineNumber;
                        debugPlatform();
                        // create the platform
                    }
                    // once the final platform has been reached, then create it
                    else
                    {
                        createPlatform();
                    }

                }
                break;
            // end the platform creation
            case "o":
                // create an object
                createObsticle(new Vector3((-lineNumber * step) + offset, 1.4f, -coordinates[fieldNumber - 1]));
                break;
            case "s":
                // create an object
                createSmallObsticle(new Vector3((-lineNumber * step) + offset, 0.8f, -coordinates[fieldNumber - 1]));
                break;
            case "e":
                createFinishLine(new Vector3((-lineNumber * step) + offset, 0.7f, -coordinates[fieldNumber - 1]));
                break;
            default:
                break;
        }
    }
}