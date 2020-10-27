# CustomerReaderExcercise
Task on Customer Reader Exercise
Following are the changes done on the task
1) Modified complete Architecture, utilized (Program,BL,DL and Modal)
	segregated the complete applicaiton as tiers, which gives the application a plug and play facility, just in case if 	in future an UI is needed just we can consume the BL and DL layer for the UI layer
	also, if incase we need to add new functionality we can just modify the BL layer and other layers are need not be 	modified.

2) Followed C# coding standards as 
	- Followed Pascal cases for Class Names and Method Names.
	- Followed Camel cases for local variables and method arguments.
	- Avoided underscores for using Identifier.
	- Use of System data types and prefered using the predefined data types.
	- For better code indentation and readability followed alignment accross all files developed in the application.
	- Declared the variables as close as possible to their use.
	- Seperated the methods, different sections of program by one space.

3) Added Full Name Property.

4) Added Lower Casing for email field as it required to be all caps using System.Globalization.

5) Added Title Casing for making the fields First Name, Last Name, Full Name, Street Address and City as first    letter capitalization using System.Globalization.

6) Added Upper Casing for the field State as it required to be all caps using System.Globalization.

7) Modified fn and ln as understandable firstName and lastName in Customer Class.

8) Added required comments for each method.

9) Removed unused using statements (unused Name spaces).

10) Added Unit Testing project using NUnit framework available in .Net.


