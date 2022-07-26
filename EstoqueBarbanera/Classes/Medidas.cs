﻿using System;

namespace Estoque
{
    internal class Medidas
    {
        internal static string Start(string x)
        {
            switch (x)
            {
                case "1/32": x = "0,79"; break;
                case "1/16": x = "1,58"; break;
                case "3/32": x = "2,38"; break;
                case "1/8": x = "3,18"; break;
                case "5/32": x = "3,97"; break;
                case "3/16": x = "4,76"; break;
                case "7/32": x = "5,56"; break;
                case "1/4": x = "6,35"; break;
                case "9/32": x = "7,14"; break;
                case "5/16": x = "7,98"; break;
                case "11/32": x = "8,73"; break;
                case "3/8": x = "9,53"; break;
                case "13/32": x = "10,32"; break;
                case "7/16": x = "11,11"; break;
                case "15/32": x = "11,91"; break;
                case "1/2": x = "12,70"; break;
                case "17/32": x = "13,49"; break;
                case "9/16": x = "14,29"; break;
                case "19/32": x = "15,08"; break;
                case "5/8": x = "15,87"; break;
                case "21/32": x = "16,67"; break;
                case "11/16": x = "17,46"; break;
                case "23/32": x = "18,26"; break;
                case "3/4": x = "19,05"; break;
                case "25/32": x = "19,84"; break;
                case "13/16": x = "20,64"; break;
                case "27/32": x = "21,43"; break;
                case "7/8": x = "22,22"; break;
                case "29/32": x = "23,02"; break;
                case "15/16": x = "23,81"; break;
                case "31/32": x = "24,61"; break;
                case "1'": x = "25,40"; break;
                case "1.1/32": x = "26,19"; break;
                case "1.1/16": x = "26,99"; break;
                case "1.3/32": x = "27,78"; break;
                case "1.1/8": x = "28,57"; break;
                case "1.5/32": x = "29,37"; break;
                case "1.3/16": x = "30,16"; break;
                case "1.7/32": x = "30,95"; break;
                case "1.1/4": x = "31,75"; break;
                case "1.9/32": x = "32,54"; break;
                case "1.5/16": x = "33,34"; break;
                case "1.11/32": x = "34,13"; break;
                case "1.3/8": x = "34,92"; break;
                case "1.13/32": x = "35,72"; break;
                case "1.7/16": x = "36,51"; break;
                case "1.15/32": x = "37,30"; break;
                case "1.1/2": x = "38,1"; break;
                case "1.17/32": x = "38,89"; break;
                case "1.9/16": x = "39,69"; break;
                case "1.19/32": x = "40,48"; break;
                case "1.5/8": x = "41,27"; break;
                case "1.21/32": x = "42,07"; break;
                case "1.11/16": x = "42,86"; break;
                case "1.23/32": x = "43,65"; break;
                case "1.3/4": x = "44,45"; break;
                case "1.25/32": x = "45,24"; break;
                case "1.13/16": x = "46,04"; break;
                case "1.27/32": x = "46,83"; break;
                case "1.7/8": x = "47,62"; break;
                case "1.29/32": x = "48,42"; break;
                case "1.15/16": x = "49,21"; break;
                case "1.31/32": x = "50"; break;
                case "2'": x = "50,8"; break;
                case "2.1/16": x = "52,39"; break;
                case "2.1/8": x = "53,97"; break;
                case "2.3/16": x = "55,56"; break;
                case "2.1/4": x = "57,15"; break;
                case "2.5/16": x = "58,74"; break;
                case "2.3/8": x = "60,32"; break;
                case "2.7/16": x = "61,91"; break;
                case "2.1/2": x = "63,5"; break;
                case "2.9/16": x = "65,09"; break;
                case "2.5/8": x = "66,67"; break;
                case "2.11/16": x = "68,26"; break;
                case "2.3/4": x = "69,85"; break;
                case "2.13/16": x = "71,44"; break;
                case "2.7/8": x = "73,02"; break;
                case "2.15/16": x = "74,61"; break;
                case "3'": x = "76,2"; break;
                case "3.1/8": x = "79,38"; break;
                case "3.1/4": x = "82,55"; break;
                case "3.3/8": x = "85,73"; break;
                case "3.1/2": x = "88,9"; break;
                case "3.5/8": x = "92,08"; break;
                case "3.3/4": x = "95,25"; break;
                case "3.7/8": x = "98,43"; break;
                case "4'": x = "101,6"; break;
                case "4.1/4": x = "107,95"; break;
                case "4.1/2": x = "114,3"; break;
                case "4.3/4": x = "120,65"; break;
                case "5'": x = "127"; break;
                case "5.1/4": x = "133,35"; break;
                case "5.1/2": x = "139,7"; break;
                case "5.3/4": x = "146,05"; break;
                case "6'": x = "152,4"; break;
                case "6.1/4": x = "158,75"; break;
                case "6.1/2": x = "165,1"; break;
                case "6.3/4": x = "171,45"; break;
                case "7'": x = "177,8"; break;
                case "7.1/4": x = "184,15"; break;
                case "7.1/2": x = "190,5"; break;
                case "7.3/4": x = "196,85"; break;
                case "8'": x = "203,2"; break;
                case "8.1/4": x = "209,55"; break;
                case "8.1/2": x = "215,9"; break;
                case "8.3/4": x = "222,25"; break;
                case "9'": x = "228,6"; break;
                case "9.1/4": x = "234,95"; break;
                case "9.1/2": x = "241,3"; break;
                case "9.3/4": x = "247,65"; break;
                case "10'": x = "254"; break;
                case "10.1/4": x = "260,35"; break;
                case "10.1/2": x = "266,7"; break;
                case "10.3/4": x = "273,05"; break;
                case "11'": x = "279,4"; break;
                case "11.1/4": x = "285,75"; break;
                case "11.1/2": x = "292,1"; break;
                case "11.3/4": x = "298,45"; break;
                case "12'": x = "304,8"; break;
                case "12.1/4": x = "311,15"; break;
                case "12.1/2": x = "317,5"; break;
                case "12.3/4": x = "323,85"; break;
                case "13'": x = "330,2"; break;
                case "13.1/4": x = "336,55"; break;
                case "13.1/2": x = "342,9"; break;
                case "13.3/4": x = "349,25"; break;
                case "14'": x = "355,6"; break;
                case "14.1/4": x = "361,95"; break;
                case "14.1/2": x = "368,3"; break;
                case "14.3/4": x = "374,65"; break;
                case "15'": x = "381"; break;
                case "15.1/4": x = "387,35"; break;
                case "15.1/2": x = "393,7"; break;
                case "15.3/4": x = "400,05"; break;
                case "16'": x = "406,4"; break;
                case "16.1/4": x = "412,75"; break;
                case "16.1/2": x = "419,1"; break;
                case "16.3/4": x = "425,45"; break;
                case "17'": x = "431,8"; break;
                case "17.1/4": x = "438,15"; break;
                case "17.1/2": x = "444,5"; break;
                case "17.3/4": x = "450,85"; break;
                case "18'": x = "457,2"; break;
                case "18.1/4": x = "463,55"; break;
                case "18.1/2": x = "469,9"; break;
                case "18.3/4": x = "476,25"; break;
                case "19'": x = "482,6"; break;
                case "19.1/4": x = "488,95"; break;
                case "19.1/2": x = "495,3"; break;
                case "19.3/4": x = "501,65"; break;
                case "20'": x = "508"; break;
                case "20.1/4": x = "514,35"; break;
                case "20.1/2": x = "520,7"; break;
                case "20.3/4": x = "527,05"; break;
                case "21'": x = "533,4"; break;
                case "21.1/4": x = "539,75"; break;
                case "21.1/2": x = "546,1"; break;
                case "21.3/4": x = "552,45"; break;
                case "22'": x = "558,8"; break;
                case "22.1/4": x = "565,15"; break;
                case "22.1/2": x = "571,5"; break;
                case "22.3/4": x = "577,85"; break;
                case "23'": x = "584,2"; break;
            }
            return x;
        }
    }
}