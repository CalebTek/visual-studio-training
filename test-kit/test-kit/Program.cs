// See https://aka.ms/new-console-template for more information

// test Keyinfo
Console.WriteLine("Press a Key Y/N");
ConsoleKeyInfo key = Console.ReadKey();
Console.WriteLine();
Console.WriteLine(key);
Console.WriteLine(key.KeyChar);
char iskey = (char)key.KeyChar;
char iskey1 = (char)key.Key;
Console.WriteLine(iskey);
Console.WriteLine(iskey1);
int keyint = (int)key.Key;
Console.WriteLine(keyint);
int keyint1 = (int)key.KeyChar;
Console.WriteLine(keyint1);
Console.WriteLine(keyint != 89);
Console.ReadKey();

decimal result;

decimal age = 10.5M;

result = age + 10;
