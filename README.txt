DUPLICATE ADVERTISER

Problem: 
Advertiser names get added to database as unique names if they have different prefixes or suffixes added. For example, "FasterBetterPC" can potentially be "The FasterBetterPC" or "The FasterBetterPC Inc". The names are unique, although the company is the same. A list of potential duplicate names needs to be created to avoid having duplicates.

Approach:
There are suffixes that are common in names of businesses. Some examples are "Corp", "Inc", or "Ltd". This solution takes a company name and first, strips it of the prefix or suffix that may already be there, and then appends all possible prefixes and suffixes to create a list of possible duplicate names for that company.

Solution:
There are 4 classes
	- TestVariables.cs - contains the test data and environment variables.
	- OutObject.cs - contains the methods for manipulating the data and create the desired output
	- GetDuplicateName.cs - the engine for the execution of the overall solution
	- Program.cs - Default class for console apps. Being used as a runner.

TestVariables contains the file name and paths for input and output files. Also contains possible suffixes as a List and a string called definite article for the prefix "The"

GetDuplicateName has one method, getDuplicateName(),  that opens the input file, and starts iterating through the list of businesses, sending each business name to the OutObject methods one at a time to be processed. First it sends for stripping the existing prefix and suffix. Then it sends to have all possible suffixes appended, with combinations of having "The" prefix appended as well. Then it sends it to have them written to the output file. GetDuplicateName is a static class with static method because the class does not need to have instance objects.

OutObject.cs has 4 methods:
	- stripCurrentSuffix() takes in the company name and strips off "The", and the current suffix by iterating through the list of potential suffix and searching for it in the string. If it finds that suffix, it will replace it with a blank space. It returns the stripped name back to caller.
	- addDuplicates() takes in the stripped company name, then iterates through the list of possible suffixes and appends them. It adds each appended string into another list. It returns the list created back to the caller.
	- outToFile() takes in the list created in previous method, iterates through it and writes each of the string into the output file.
	- closeOutFile() is called after potential duplicates for all businesses have been added to the output file.


Limitations and Improvements:
Keeping the theme of this assignment in mind, which I understood to be not being focused on clever solution rather the neatness and readability of the code. There are obvious limitations in terms of the solution:
	- It is limited to the given suffixes
	- It doesn't account for "." and "," 
	- There are a lot of records that show up with two "The" prefix. Easy solution to that problem would be to convert the entire business name to lowercase and search for the lowercase prefix and suffix in the business name to strip off.
	- Another improvement that can be made is for the environment variables. Rather than having a class for the variables, they can be placed in the app.config xml file. The benefit of that would be, that those values can be changed with different test data without having to build the solution. 


Go ahead and execute!
	- I have compiled the solution and the executable is in the ..\bin\Debug. It can be executed from command line.
	- I have used relative file paths both input and output files would have to be in the same path as the executable.
	- The solution was created with Visual Studio 2015 in Windows 7 and .Net version 4.6.2.  That probably wouldn't matter for a small application like this, but just in case.



Thank you!