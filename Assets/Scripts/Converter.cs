using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Converter : MonoBehaviour
{

    [SerializeField] private InputField roman;
    [SerializeField] private InputField arabic;
    [SerializeField] private Text outputField;
    [SerializeField] private GameObject helpImage;

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
        if ((num > 7) || ((num ==7)&& (ar!= "1000000")))
        {
            outputField.text = "Number out of rage";
            return "";
        }

      

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
                outputField.text = result;
                roman.text = result;
                return result;

            }

            else
            {
                outputField.text = "Wrong number";
                return "";
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
                default: outputField.text = "Wrong number"; break;



            }



        }


        foreach (string i in resArray)
        {
            result += i;
        }


        outputField.text = result;
        roman.text = result;

        return result;


    }




    private string convertRomanToArabic(string rom)
    {

        int num = rom.Length;
     
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
            
            outputField.text = "Wrong number!";
            result = "";
            return result;
        }

        else
            if ((num == 1) && (rom == "m"))
        {
            result = "1000000";
            outputField.text = result;
            arabic.text = result;
            return result;
        }

        else
        {


            int lastElement = 1000001;
            do
            {
                int tempres = 0;
                int temp1 = numbers[rom[i]];
                if (temp1 >= lastElement)
                {
                    outputField.text = "Wrong number";
                    return "";
                }
                



                lastElement = temp1;
                
                if (i + 1 != num)
                {
                    int temp2 = numbers[rom[i + 1]];
                    if ((temp2 > temp1) && ((temp2 / temp1 == 10) || (temp2 / temp1 == 5)))
                    {
                        


                        tempres = temp2 - temp1;
                       
                        res += tempres;
                      
                        i++;
                        lastElement = temp1;
                        


                    } // 

                    else if ((temp2 > temp1) && ((temp2 / temp1 != 10) && (temp2 / temp1 != 5)))
                    {
                        outputField.text = "Wrong number";
                        return "";

                    }


                    else
                           if ((temp2 < temp1) && ((temp1 / temp2 == 5) || (temp1 / temp2 == 10)))
                    {
                        tempres = temp1 + temp2;

                        lastElement = temp2;
                       
                        if ((i + 2 != num) && (numbers[rom[i + 2]] == numbers[rom[i]]))
                        {
                            tempres += numbers[rom[i + 2]] - numbers[rom[i + 1]] * 2;
                            lastElement = numbers[rom[i + 1]];
                            i++;
                        }
                        else
                        if ((i + 2 != num) && (numbers[rom[i + 2]] == numbers[rom[i + 1]]))
                        {
                            tempres += numbers[rom[i + 2]];
                            lastElement = numbers[rom[i + 2]];
                            
                            if ((i + 3 != num) && (numbers[rom[i + 3]] == numbers[rom[i + 1]]))
                            {
                                tempres += numbers[rom[i + 3]];
                                lastElement = numbers[rom[i + 3]];
                                


                                if ((i + 4 != num) && (numbers[rom[i + 4]] == numbers[rom[i + 1]]))
                                {
                                    outputField.text = "Wrong number";
                                    return "";
                                   
                                }
                               
                                i++;

                            }
                            i++;

                        }
                        i++;


                        res += tempres;

                    }//

                    else if ((temp2 < temp1) && (temp1 / temp2 > 10))
                    {
                        res += temp1;
                        lastElement = temp2;
                        
                    }

                    else
                   if ((temp2 == temp1))
                    {

                        if (temp1.ToString()[0] == '5')
                        {
                            outputField.text = "Wrong number";
                            return "";
                           

                        }




                        tempres = temp1 + temp2;
                        lastElement = temp1;
                       
                        if ((i + 2 != num) && (numbers[rom[i + 2]] == numbers[rom[i + 1]]))
                        {
                            tempres += numbers[rom[i + 2]];
                            if ((i + 3 != num) && (numbers[rom[i + 3]] == numbers[rom[i + 1]]))
                            {
                                outputField.text = "Wrong number";
                                return "";
                                

                            }

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



              
            } while (i != num);






        }


        result = res.ToString();
        outputField.text = result;
        arabic.text = result;
        return result;

    }



    public void help()
    {
        helpImage.SetActive(true);

    }
    public void back()
    {
        helpImage.SetActive(false);

    }


    public void quit()
    {
        Application.Quit();

    }

   

}
