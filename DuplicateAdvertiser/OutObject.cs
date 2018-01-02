using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


/************************************/
// 
// This is the class object to create potential duplicates and write them to output file
// This class takes the following input   
//  -  File name and path of Input file
//  -  Name of company to be evaluated
//
/*************************************/

namespace DuplicateAdvertiser
{
    public class OutObject
    {

        System.IO.StreamWriter outputFile = new System.IO.StreamWriter(TestVariables.outfilename);

        // This method strips off "The" and original suffix of the company
        public string stripCurrentSuffix(string companyName)
        {
            string strippedCompanyName = companyName;

            foreach (string sfx in TestVariables.suffixes)
            {
                if (companyName.Contains(sfx))
                {
                    strippedCompanyName = companyName.Replace(sfx, "");
                }
            }

            if (strippedCompanyName.Contains(TestVariables.definiteArticle))
            {
                strippedCompanyName = strippedCompanyName.Replace(TestVariables.definiteArticle, "");
            }

            return strippedCompanyName;
        }

        // This method reads in the stripped company name and appends prefix and suffix for potential duplicates
        public List<string> addDuplicates(string companyName)
        {
            List<string> Duplicates = new List<string>();
            foreach (string sfx in TestVariables.suffixes)
            {
                Duplicates.Add(companyName + " " + sfx);
                Duplicates.Add(TestVariables.definiteArticle + " " + companyName + " " + sfx);
            }

            return Duplicates;
        }


        // This method writes potential duplicates for company to the output file
        public void outToFile (List<string> duplicateList, string companyName)
        {
            try
            {
                outputFile.WriteLine(companyName);
                foreach (string duplicate in duplicateList)
                {
                    outputFile.WriteLine("\t" + duplicate);

                }
                outputFile.WriteLine("");

            }
            catch (DirectoryNotFoundException dnf)
            {
                Console.WriteLine("Target path not available. Ensure \\bin\\Debug exists." + dnf);
            }
            catch (IOException ioe)
            {
                Console.WriteLine("Could not read from file" + ioe);
            }

        }

        public void closeOutFile()
        {
            outputFile.Close();
        }
    }
}
