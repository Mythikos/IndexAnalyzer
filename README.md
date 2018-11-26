# IndexAnalyzer
The program is designed to give the end user the ability to rapidly test index files. It does so by allowing the user to import/export column definitions or define definitions at the time of use. With just the column name, start position, and length of date, it will parse the data into an easier to read format.

## What it can do
1. Define file definitions and have the ability to import and export at time of use, or define them on the fly.
2. Export the results to multiple formats including; xlsx, csv, text tab-delimited, and text pipe-delimited.
3. Define data types per index and report errors when it is unable to parse the column to that data type.
4. Options to ignore header and footer rows.

## Todo
1. Add the ability to define and check for default values.
2. Add the ability to define custom regex expressions to check the cell

## EPPlus
The tool is utilizing the library "EPPlus" to export data to excel. EPPlus is under the LGPL-2.1 license. You can find the binary at: https://www.nuget.org/packages/EPPlus/
