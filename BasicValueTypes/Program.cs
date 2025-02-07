// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


// STRINGS
Console.WriteLine();
// Declare
string myString;
string my_string;
string MyString;

// Assign
myString = "Hello, World!";

// Declare and assign
string coolString = "Hello, World!";

// Reassign
coolString = "Goodbye, World!";

// Concatenate
string firstName = "John";
string lastName = "Doe";
string fullName = firstName + " " + lastName;

// Output
Console.WriteLine(fullName);

// Read line
myString = Console.ReadLine();

// Length
Console.WriteLine(myString.Length);

// Individual characters
Console.WriteLine(myString[0]);


// Characters
char myChar = 'a';



// INTEGERS
Console.WriteLine();
// Declare
int myInt;
int my_int;
int MyInt;

// Assign
myInt = 5;

//Declare and assign
int coolInt = 5;

// Reassign
coolInt = 10;

// Do math
int sum = 10 + 5;
int difference = 10 - 5;
int product = 10 * 5;
int quotient = 5 / 10;

// String interpolation
Console.WriteLine($"10 + 5 = {sum}");
Console.WriteLine($"10 - 5 = {difference}");
Console.WriteLine($"10 * 5 = {product}");
Console.WriteLine($"5 / 10 = {quotient}");



// FLOAT & DOUBLE
Console.WriteLine();
// Declare
float myFloat;
float my_float;
float MyFloat;

double myDouble;
double my_double;
double MyDouble;

// Assign
myFloat = 5.5f;
myDouble = 5.5;

// Declare and assign
float coolFloat = 5.5f;
double coolDouble = 5.5;

// Reassign
coolFloat = 10.5f;
coolDouble = 10.5;

// Do math
float sumF = 10.5f + 5.5f;
float differenceF = 10.5f - 5.5f;
float productF = 10.5f * 5.5f;
float quotientF = 5.5f / 10.5f;

Console.WriteLine($"10.5 + 5.5 = {sumF}");
Console.WriteLine($"10.5 - 5.5 = {differenceF}");
Console.WriteLine($"10.5 * 5.5 = {productF}");
Console.WriteLine($"5.5 / 10.5 = {quotientF}");



// BOOLEAN
Console.WriteLine();
//Declare
bool myBool;
bool my_bool;
bool MyBool;

// Assign
myBool = true;
myBool = false;

// Declare and assign
bool coolBool = true;

// Reassign
coolBool = false;

// Boolean logic
bool trueAndFalse = true && false;
bool trueAndTrue = true && true;
bool falseAndFalse = false && false;

bool trueOrFalse = true || false;
bool trueOrTrue = true || true;
bool falseOrFalse = false || false;

bool notTrue = !true;
bool notFalse = !false;

Console.WriteLine($"true && false: {trueAndFalse}");
Console.WriteLine($"true && true: {trueAndTrue}");
Console.WriteLine($"false && false: {falseAndFalse}");
Console.WriteLine($"true || false: {trueOrFalse}");
Console.WriteLine($"true || true: {trueOrTrue}");
Console.WriteLine($"false || false: {falseOrFalse}");
Console.WriteLine($"!true: {notTrue}");
Console.WriteLine($"!false: {notFalse}");



// DATETIME
Console.WriteLine();
// Declare
DateTime myDateTime;
DateOnly myDate;
TimeOnly myTime;

// Assign
myDateTime = DateTime.Now;
myDate = new DateOnly(2025, 2, 6);
myTime = new TimeOnly(16, 22);

// Declare and assign
DateTime myDateTime2 = DateTime.Now;
DateOnly myDate2 = new DateOnly(2025, 2, 6);
TimeOnly myTime2 = new TimeOnly(16, 24);

// Combining
DateTime dateTimeFromCombination = new DateTime(myDate2, myTime2);

Console.WriteLine($"Date Only: {myDate2}");
Console.WriteLine($"Time Only: {myTime2}");
Console.WriteLine($"Date and Time: {dateTimeFromCombination}");



// CASTING/PARSING
Console.WriteLine();
