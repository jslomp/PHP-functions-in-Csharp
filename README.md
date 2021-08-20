# PHP-functions-in-Csharp


Author: Jacob Slomp

Website: www.slomp.ca

Free to use



This is under active development, and nowere near to be done. many functions has to be added.



Use php functions in csharp to make it easier to go from PHP to c#.


Add to your code:
```
Using PHPFunctions;
```


Use it as following:
```
string result = php.file_get_contents("filename.txt");
```
or
```
string result = php.file_get_contents("http://www.slomp.ca");
```


 Because php works always with scalable arrays we use List<string> instead of string[]
  
 so explode() will return a list
 end( input will be list )

  Usage:
 
 ```
 List<string> myArray = php.explode(" ","this is a text");
 
 Console.WriteLine( php.end(myArray) ); // will return text
 
 Console.WriteLine( php.implode("-",myArray) ); // will return this-is-a-text
 ``` 
  
  
 just like PHP

 
print_r equivalent in c#
print_r(); is a very powerfull function that prints out arrays.
I haven't made every single type yet, but will add more as we go.

Usage: php.print_r( Dictionairy<string,string> | List<string> | string[] .... )
There are more types, just look in the code. 
