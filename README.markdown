# SQL to CSV tool for MSSQL
### When SQL Server Management Studio (SSMS) is not enough

<a href='https://pledgie.com/campaigns/29418'><img alt='Click here to lend your support to: Beer and coffee money and make a donation at pledgie.com !' src='https://pledgie.com/campaigns/29418.png?skin_name=chrome' border='0' ></a>

This is a simple program that fulfils specific requirements

  - You need a CSV created from a SQL query

Very simple to use. Just start it up and enter in the connection string, query and the output file name for the CSV.

![SQLtoCSV Screenshot](http://i.imgur.com/hbZxbZt.png)

### Tech / 3rd Party Stuff
* [CSV Helper](https://www.nuget.org/packages/CsvHelper/) -  An awesome CSV handling library


## Why I built this / Issues with exporting from SMSS
**The issue is the delimitation**. If a data cell contains a comma and line break, then the export tool kind of ignores it by default. 

There [is a setting inside of SSMS](http://stackoverflow.com/a/19639406/59532) that supposedly fixes this, but it still has issues. The line breaks can still leave broken unusable CSV records.

### Todo's

- Command line version
- Support MySQL and other abitrary SQL solutions
- Save state / Remember settings

### Versions
* v1 - Initial release with basic functionality of querying against a database, which is saved to a file. Simples.
