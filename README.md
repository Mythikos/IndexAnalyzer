# IndexAnalyzer
The program is designed to give the end user the ability to rapidly test index files. It does so by allowing the user to import/export column definitions or define definitions at the time of use. With just the column name, start position, and length of date, it will parse the data into an easier to read format. The Index Analyzer has the ability to export analyzed results to excel, tab delimited and CSV formats. 

# Todo
1. Add the ability to flag rows are potential issues. 
2. Add the ability to define and check for default values.
3. Add the ability to analyze datatypes and convert columns to its respective data types, returning inconsistent findings. 
4. Cleanup the transition between the main form and the analysis form.

# EPPlus
The tool is utilizing the library "EPPlus" to export data to excel. EPPlus is under the LGPL-2.1 license. You can find the binary at: https://www.nuget.org/packages/EPPlus/
