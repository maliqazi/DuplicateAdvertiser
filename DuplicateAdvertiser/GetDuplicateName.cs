using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/************************************/
// 
// This is the main execution module
// This class reads following variables from TestVariables.cs
//  -  File name and path of Input file
//  -  Definite article "The" to append as prefix for potential duplicates
//  -  Potential suffixes - LLC, corp, Ltd, Inc, company, Limited
//           More suffixes can be added to this list
// This call accesses methods in the outObject.cs to output results to file
//
/*************************************/

namespace DuplicateAdvertiser
{
    public static class GetDuplicateName
    {
        public static void getDuplicateName()
        {
            string line = "";
            string strippedName = "";

            try
            {
                OutObject outobject = new OutObject();
                System.IO.StreamReader file = new System.IO.StreamReader(TestVariables.infilename);

                while ((line = file.ReadLine()) != null)
                {
                    List<string> duplicateList = new List<string>();

                    // Strip the company name of "The" and suffix
                    strippedName = outobject.stripCurrentSuffix(line);

                    // Append "The" and all suffixes to produce potential duplicate names
                    duplicateList = outobject.addDuplicates(strippedName);

                    // Write all potential duplicate names to output file
                    outobject.outToFile(duplicateList, line);

                }
                outobject.closeOutFile();
                file.Close();
            }
            catch (FileNotFoundException fne)
            {
                Console.WriteLine("Check file path. File should be stored in bin\\Debug folder" + fne);
            }
            catch (IOException ioe)
            {
                Console.WriteLine("Could not read from file" + ioe);
            }
 
            return;
        }
    }
}
