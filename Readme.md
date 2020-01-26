# NameMaker
*The NameMaker project is designed to generate random names to use for testing.*

**NAMEMAKER `[/c:runs][/f:format]`**
Where runs is the number names to generate
Where format may consist of the folowing items:

Formatting options:  
`[FirstName]`   First (given) name  
`[LastName]`    Last (family) name  
`[FI]`          First Initial  
`[LI]`          Last Initial  
`[space]`       Space character  
`[comma]`       ,  
`[tab]`         Tab character  
`[dot]`         . character

**Examples:**

This command line produces a thousand random names to the console

NAMEMAKER /c:1000

NAMEMAKER /c:1000 /f:[LastName][comma][space][FirstName]

Produces a thousand random names to the console in the format *lastName, firstName*

Name Lists Copyright Mark Kantrowitz.

## Features
--------

* Generates a name by randomly picking gender then picking a name random from the appropriate gender list.
* 58257 Surnames
* 4987 Female first names
* 2940 Male first names

## Release Notes
-------------
2020-01-26 Version 0.4
Added a dot (.) to formatting
* Tests now in a separate project
* Compiled for .Net 4.5.2


2017-10-12  Version 0.2 
* First Prerelease
* Documentation Update

Version 0.2, 
* Skip Lines beginning with # and blank lines in names files
* Unit tests added
* Formatting of names added with the /f switch

Version 0.1, 5 September 2012
* Command line switch /c:n generates n names in the format `[FirstName][space][LastName]`
* Help added

4 September 2012	First Release.
