using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;
using Swashbuckle.AspNetCore;
using Swashbuckle.AspNetCore.Annotations;
using System.Reflection.Metadata.Ecma335;
using WebApplication4.Controllers;

namespace WebApplication4.Models
{
    public class Model
    {
        int i;
        string[] wordsArray = { "", "", "մեկ", "երկու", "երեք", "չորս", "հինգ", "վեց", "յոթ", "ութ", "ինը", "տաս", "տասնմեկ", "տասներկու", "տասներեք", "տասնչորս", "տասնհինգ", "տասնվեց", "տասնյոթ", "տասնութ", "տասնինը" };
        string[] words2Array = { "", "", "քսան", "երեսուն", "քառասուն", "հիսուն", "վաթսուն", "յոթանասուն", "ութսուն", "իննսուն", "հարյուր" };
        string[] words3Array = { "", "հարյուր", "հազար", "միլիոն ", "միլիարդ " };
        public string SetNumber(long number)
        {
            i += 1;
            string resultik = "";
            if (number == 0 && i == 1)
                return ("զրո");
            if (number < 0) {
                resultik += ("բացասական ");
                number *= -1;
            }
            if (number >= 1000000000)
            {
                if (number / 1000000000 == 1)
                {
                    resultik += words3Array[4];
                    number %= 1000000000;
                    resultik += (SetNumber(number / 1000000000)) + " ";
                }
                else
                {
                    resultik += (SetNumber(number / 1000000000)) + " ";
                    resultik += words3Array[4];
                    number %= 1000000000;
                }
            }
            if (number >= 1000000)
            {
                if (number / 1000000 == 1)
                {
                    resultik += words3Array[3];
                    number %= 1000000;
                    resultik += (SetNumber(number / 1000000)) + " ";
                }
                else
                {
                    resultik += (SetNumber(number / 1000000)) + " ";
                    resultik += words3Array[3];
                    number %= 1000000;
                }
            }
            if (number >= 1000) {
                if (number / 1000 == 1)
                {
                    resultik += words3Array[2];
                    number %= 1000;
                    resultik += (SetNumber(number / 1000)) + " ";
                }
                else
                {
                    resultik += (SetNumber(number / 1000)) + " ";
                    resultik += words3Array[2];
                    number %= 1000;
                    resultik += " ";
                }
            }
            if (number >= 100) {
                if (number / 100 == 1)
                {
                    resultik += words3Array[1];
                    number %= 100;
                    resultik += (SetNumber(number / 100)) + " ";
                }
                else
                {
                    resultik += (SetNumber(number / 100)) + " ";
                    resultik += words3Array[1];
                    number %= 100;
                    resultik += " ";
                }
            } 
            if (number > 0) {
                if (number < 20)
                    resultik += wordsArray[number+1];
                else
                {
                    resultik += words2Array[number / 10] + wordsArray[1+number % 10];
                    number %= 10;
                }

            }
            return resultik;
        }
    }
}