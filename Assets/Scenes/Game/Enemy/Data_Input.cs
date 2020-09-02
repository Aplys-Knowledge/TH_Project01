using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Data_Input : MonoBehaviour
{

    private Enemy_Data[] e_data = new Enemy_Data[512];
    private string[] alldata;
    private string[] path = new string[32];
    private string filePath;

    private PrimitiveStage stage;


    
    
    private Event_Data[] event_data = new Event_Data[128];
    private string[] event_path = new string[32];






    // Start is called before the first frame update
    void Start()
    {
        path[0] = "/Data/test/Test.csv";
        path[1] = "/Data/test/test02.csv";

        event_path[0] = "/Data/test/event91.csv";


        stage = this.gameObject.GetComponent<PrimitiveStage>();


        try
        {
            filePath = Application.dataPath + path[stage.PStage];

            int cnt = 0;



            alldata = File.ReadAllLines(filePath);

            foreach (string text in alldata)
            {
                if (cnt > 0)
                {
                    string[] d = text.Split(',');
                    for (int i = 0; i < 11; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                e_data[(cnt - 1)].position.x = float.Parse(d[i]);
                                break;
                            case 1:
                                e_data[(cnt - 1)].position.y = float.Parse(d[i]);
                                break;
                            case 2:
                                e_data[(cnt - 1)].position.z = float.Parse(d[i]);
                                break;
                            case 3:
                                if (int.Parse(d[i]) == 1)
                                {

                                    e_data[(cnt - 1)].rotation = Quaternion.identity;

                                }


                                break;
                            case 4:
                                e_data[(cnt - 1)].x2 = float.Parse(d[i]);

                                break;
                            case 5:
                                e_data[(cnt - 1)].z2 = float.Parse(d[i]);

                                break;
                            case 6:
                                e_data[(cnt - 1)].knd = int.Parse(d[i]);
                                break;
                            case 7:
                                e_data[(cnt - 1)].behaviour = int.Parse(d[i]);
                                break;
                            case 8:
                                e_data[(cnt - 1)].shot_num = int.Parse(d[i]);
                                break;
                            case 9:
                                e_data[(cnt - 1)].HP = int.Parse(d[i]);
                                break;
                            case 10:
                                e_data[(cnt - 1)].item = int.Parse(d[i]);
                                break;


                        }
                    }
                    e_data[(cnt - 1)].position = new Vector3(e_data[(cnt - 1)].position.x, e_data[(cnt - 1)].position.y, e_data[(cnt - 1)].position.z);
                    e_data[(cnt - 1)].flag = 1;

                }



                cnt++;
            }
        }
        catch
        {

        }
        finally
        {

        }



        try
        {
            filePath = Application.dataPath + event_path[0];

            int cnt = 0;
            alldata = File.ReadAllLines(filePath);

            foreach (string text in alldata)
            {
                if (cnt > 0)
                {
                    string[] d = text.Split(',');
                    for(int i = 0; i < 4; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                event_data[(cnt - 1)].lines = d[i];

                                break;
                            case 1:
                                event_data[(cnt - 1)].chara = int.Parse(d[i]);

                                break;
                            case 2:
                                event_data[(cnt - 1)].picture = int.Parse(d[i]);

                                break;
                            case 3:
                                event_data[(cnt - 1)].motion = int.Parse(d[i]);

                                break;
                        }
                    }
                    event_data[(cnt - 1)].flag = 1;

                }
                cnt++;
            }
        }
        catch
        {

        }
        finally
        {


        }
    }

    public Enemy_Data Get_Enemy_Data(int i)
    {
        return e_data[i];
    }

    public Event_Data[] PEvent_Data
    {
        get { return event_data; }

    }



}
