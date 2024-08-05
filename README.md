# CodeKy_SDM24
## Code Kentucky - Software Development Module July 2024
#### I'll be working along with the class to create a repository for reference and collaboration, as well as to help me maintain perspective so that I can be a better mentor.
<br>

---
### BLOG

#### 240805 - Pet Store Part 3
* Minor updates.  Purposefully added an exception in GetCatfoodOrThrow() in order to demonstrate try/catch  
* Program Improvements to Discuss
* After thinking about it ... removed trailing newlines, and commented out extraneous override.

#### 240626 - Pet Store Part 2
* Added UserInput.cs for user input of a Kitten Food.  

#### 240624 - Pet Store Part 2
* Updated main input logic to a switch statement
* Added the initial ProductLogic.cs
  * Added some Dictionaries to act as indexes
  * Added initial basic fuctions and framework
  * Added initial Get and Search functions, including a Search version with a Lambda Function
* Added `<Enter><Enter>` as another way to exit the program
* Fixed a bug where I forgot to have DogLeash Inherit from Product
* Ran standard code cleanup from the solution manager.

#### 240617 - Pet Store Part 1
* This week's Pet Store homework.  You should reference the commit notes and the assignment notes for more information.  
* Conveniently enough I forgot to update the readme.md, so I get to do an additional commit and push.
* I added so many comments it's actually making it harder to read.  Short and Concise vs Verbose Educational Comments?

#### 240609 - C# Hello World!
* Select "Do Not Use Top Level Statements".  This creates a more explicit program syntax, which is more complete for learning purposes.  You are going to want to learn how to deal with both namespaces and classes, so now is as good a time as any to start using them.
    ```
    namespace Week_240616
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Hello, World!");
            }
        }
    }
    ```
* If you just want to jump straight into code quickly, you can use the top level statements for really simple quick code.  However, 9 out of 10 times once you get past 'simple quick script' you'll end up going back and having to deal with namespaces, classes, etc.  Below is the same code using the simplified top level statements format.
    ```
    Console.WriteLine("Hello, World!");
    ```
* It's quick and fast, but it's not as complete as the first example.  It's a good way to get started, but you'll want to learn the more complete syntax as soon as possible.

#### 240609 - AI
* We'll probably cover this in class one day in the future.  It's not required, It's wrong as often as it's right, but in the end I still find it helpful, and I love letting it write my commit messages. I use git hub copilot the most, but also use the others sometimes as well.  I'm not even sure I'd consider myself competent in AI's use and usefulness, but I do use it.

#### 240609 - Comments, Readme, and Markdown
* Document your work daily in your commits.  Hopefully with better detail than I typically manage.  
* Document your work in your readme every week.  This can help you keep track of what you've done, and it can help you remember what you've learned.  It can also help you to see your progress over time.
  * https://docs.github.com/en/get-started/writing-on-github/getting-started-with-writing-and-formatting-on-github/basic-writing-and-formatting-syntax
  * https://www.markdownguide.org/cheat-sheet/
