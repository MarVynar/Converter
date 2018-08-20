using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Converter : MonoBehaviour
{

    [SerializeField] private Text roman;
    [SerializeField] private Text arabic;
    [SerializeField] private Text outputField;

    private int arabicnumber;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    public
        void getInfo()
    {
        string romanString = roman.text;

        string arabicString = arabic.text.ToString();

      
        if ((arabicString != "" && romanString != "") || (arabicString == "" && romanString == ""))
        {
            Debug.Log("Wrong" + arabicString + "|" + romanString);
            outputField.text = "Error! One field should be filled, other should be empty!";
        }



        else if (arabicString != "" && romanString == "")
        {

            convertArabicToRoman(arabicString);
        }

        else if (romanString != "" && arabicString == "")
        {

            convertRomanToArabic(romanString);
        }



    }

    private string convertArabicToRoman(string ar)
    {
        int num = ar.Length;
        string result = "";
        string one = "";
        string five = "";
        string ten = "";
        string[] resArray = new string[num];

        for (int i = num - 1; i >= 0; i--)
        {

            if (i == num - 1)
            {
                one = "I";
                five = "V";
                ten = "X";
            }
            else                                                                    //10
                if (i == num - 2)
            {
                one = "X";
                five = "L";
                ten = "C";
            }

            else if (i == num - 3)                               //100
            {
                one = "C";
                five = "D";
                ten = "M";
            }


            else if (i == num - 4)                          //1000
            {
                one = "M";
                five = "v";
                ten = "x";
            }


            else if (i == num - 5)                          //10000
            {
                one = "x";
                five = "l";
                ten = "c";
            }
            else if (i == num - 6)                                   //100000
            {
                one = "c";
                five = "d";
                ten = "m";

            }

            else if (ar == "1000000")                                      //1000000
            {
                result = "m";
                Debug.Log(result);
                return result;

            }

            else
            {
                Debug.Log("wrong number");
            }

            switch (ar[i])
            {
                case '1': resArray[i] = one; break;
                case '2': resArray[i] = one + one; break;
                case '3': resArray[i] = one + one + one; break;
                case '4': resArray[i] = one + five; break;
                case '5': resArray[i] = five; break;
                case '6': resArray[i] = five + one; break;
                case '7': resArray[i] = five + one + one; break;
                case '8': resArray[i] = five + one + one + one; break;
                case '9': resArray[i] = one + ten; break;
                case '0': resArray[i] = ""; break;
                default: Debug.Log("Wrong Number"); break;



            }



        }


        foreach (string i in resArray)
        {
            result += i;
        }

        Debug.Log(result);
        outputField.text = result;
    

        return result;


    }




    private string convertRomanToArabic(string rom)
    {
     
        int num = rom.Length;
        Debug.Log(num);
        string result = "";
        int res = 0;

        int i = 0;


        Dictionary<char, int> numbers = new Dictionary<char, int>();
        numbers.Add('I', 1);
        numbers.Add('V', 5);
        numbers.Add('X', 10);
        numbers.Add('L', 50);
        numbers.Add('C', 100);
        numbers.Add('D', 500);
        numbers.Add('M', 1000);
        numbers.Add('v', 5000);
        numbers.Add('x', 10000);
        numbers.Add('l', 50000);
        numbers.Add('c', 100000);
        numbers.Add('d', 500000);
        numbers.Add('m', 1000000);



        if ((num > 1) && (rom[0] == 'm'))
        {
            Debug.Log("Out of rage");
            outputField.text = "Wrong number!";
            result = "";
            return result;
        }

        else
            if ((num == 1) && (rom == "m"))
        {
            result = "1000000";
            outputField.text = result;
            return result;
        }

        else
        {
  
            int previousPeriod = 1000000;
            int lastElement = 0;
            do
            {
                int tempres = 0;
                int temp1 = numbers[rom[i]];

                Debug.Log("Period _"+ previousPeriod);
                if (temp1 > previousPeriod)
                {
                    outputField.text = "Wrong number";
                    break;
                } 
                
  
                if (i + 1 != num)
                {
                    int temp2 = numbers[rom[i + 1]];
                    if ((temp2 > temp1) && ((temp2 / temp1 == 10) || (temp2 / temp1 == 5)))
                    {
                      
                        if (temp1 > previousPeriod)
                        {
                            outputField.text = "Wrong number";
                            break;
                        }
                        
                        tempres = temp2 - temp1;
                          Debug.Log(temp1 + " " + temp2 + " " + tempres+ "Yoyo");
                        res += tempres;
                        Debug.Log(temp1 + " " + temp2 + " " + tempres + " " + res + "Yo");
                        i++;
                        lastElement = temp1;



                    } // 
                    else
                           if ((temp2 < temp1) && ((temp1 / temp2 == 5) || (temp1 / temp2 == 10)))
                            {
                                    tempres = temp1 + temp2;
                                    


                                    if ((i + 2 != num) && (numbers[rom[i + 2]] == numbers[rom[i + 1]]))
                                    {
                                    tempres += numbers[rom[i + 2]];

                                    if ((i + 3 != num) && (numbers[rom[i + 3]] == numbers[rom[i + 1]]))
                                    {
                                        tempres += numbers[rom[i + 3]];

                                        i++;

                                        Debug.Log(temp1 + " " + temp2 + " " + tempres + " " + res+ "babubo");
                                    }
                                    i++;
                               
                                }
                                i++;
                               

                                res += tempres;
                       
                    }//

                            else if ( (temp2<temp1) && (temp1/ temp2>10))
                                {
                                    res += temp1;
                                    lastElement = temp2;
                                }

                    else
                           if ((temp2 == temp1))
                    {
        
                        tempres = temp1 + temp2;
                        lastElement = temp1;

                        if ((i + 2 != num) && (numbers[rom[i + 2]] == numbers[rom[i + 1]]))
                        {
                            tempres += numbers[rom[i + 2]];
   
                            i++;
                        }

                        res += tempres;
                        i++;
                    }

                }

                else
                {
                    
                    res += temp1;
                    lastElement = temp1;
                 
                }



                i++;
                float dec = Mathf.Pow (10f, previousPeriod.ToString().Length- lastElement.ToString().Length -1) ;
                previousPeriod /=  (int) dec;

                
                 Debug.Log("Iteration " +tempres +res);
            } while (i != num);






        }


        result = res.ToString();
        Debug.Log(result);
        outputField.text = result;
        return result;

    }


}
