using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*************************************/
// This class contains test data and environment variables
/************************************/

namespace DuplicateAdvertiser
{
    public static class TestVariables
    {
        public static List<string> suffixes = new List<string> { "LLC", "corp", "Ltd", "Inc", "company", "Limited" };
        public static string definiteArticle = "The";
        public static string infilename = @"advertisers.txt";
        public static string outfilename = @"DuplicateAdvertisers.txt";
    }
}
