using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace QuizApplication
{
    // QuizSystem class provides the interface for the user and its main connection
    public class QuizSystem
    {
        // public attributes to be shared by all methods and classes across the system (this is different to the UML AHHH)
        // initialize new lists with the matching class names as object reference
        public List<Admin> admins = new List<Admin>();
        public List<Student> students = new List<Student>();
        public List<Category> categories = new List<Category>();
        public List<Quiz> quizzes = new List<Quiz>();
        // Main method that holds the calls of the other methods and this where the code is executed. Basically creates the whole interface ready for interaction
        static void Main(string[] args)
        {
            // initialize a new instance of the quizSystem class, allowing the attributes to be used 
            QuizSystem quizSystem = new QuizSystem();
            // populate the lists of quizSystem using the appropriate methods and passing the corresponding list in the parameter
            // note: everytime a method is called or attribute, you have to reference the object it belongs to, only in the Main tho!
            quizSystem.CreateAdmins(quizSystem.admins);
            quizSystem.CreateStudents(quizSystem.students);
            quizSystem.CreateCategories(quizSystem.categories);
            quizSystem.CreateQuizzes(quizSystem.quizzes);
            // saving all the quiz questions in the system once created to an excel file using the SaveQuiztoCSV
            quizSystem.SaveQuiztoCSV(quizSystem.quizzes, "quizzes.csv");

            // for clean aesthetic look we clean the console, keeping things neat for the user
            Console.Clear();
            // loading the student and admins list, so that the user can find their login credentials
            quizSystem.LoadAdmins(quizSystem.admins);
            quizSystem.LoadStudents(quizSystem.students);
            Console.WriteLine("Please scroll upwards and find your login credentials :D");
            // the Main Menu method is called to provide the interface for the user and they can choose which option they would like
            // with this one line code below, the user is able to do everything needed because other methods are called within it.
            quizSystem.MainMenu(quizSystem.admins, quizSystem.students, quizSystem.categories, quizSystem.quizzes); // passes all the lists as parameters for future use
            // added so that the console does not close directly, just incase text needs to be read one last time, no abruptness
            Console.ReadLine();


        }
        // default constructor
        public QuizSystem() { }
        // method to populate the admins list, the required list is passed as a parameter
        public void CreateAdmins(List<Admin> admins)
        {
            // try-catch block for error n exception handling and output appropriate message
            try
            {
                // we are appending the list using the method Add() within the System.Linq
                // for each call of method Add(), you create a new instance of the admin class and pass the needed parameters for the custom constructor
                // parameters: Username, Password, Email
                admins.Add(new Admin("Fatima", "mEs#1245", "f.benmesmia@ulster.ac.uk"));
                admins.Add(new Admin("James", "coN#2345", "jp.connolly@ulster.ac.uk"));
                admins.Add(new Admin("Sophie", "smIt#3456", "s.mardine@ulster.ac.uk"));
                admins.Add(new Admin("Liam", "owEn#4567", "l.owens@ulster.ac.uk"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error faced while creating admins :( " + ex.Message);
            }
        }
        //method to populate the students list, the required list is passed as a parameter
        public void CreateStudents(List<Student> students)
        {
            // try-catch block for error n exception handling and output appropriate message
            try
            {
                // once again, we append the list using the method Add() within System.Linq
                //for each call of method Add(), you create a new instance of the student class and pass the needed parameters for the custom constructor
                //parameters: Username, Password, Email
                students.Add(new Student("Leanne", "meow2006", "Alhussein-L@ulster.ac.uk"));
                students.Add(new Student("Ilhem", "iLeR2005", "Cherif-I@ulster.ac.uk"));
                students.Add(new Student("Izzah", "iZzaH2005", "Imtiaz-I@ulster.ac.uk"));
                students.Add(new Student("Rend", "pInk2006", "Alshekhlee-R@ulster.ac.uk"));
                students.Add(new Student("Guest", "CuQC@2025", "City-G@ulster.ac.uk"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error faced while creating students :( " + ex.Message);

            }
        }
        // method to loop through the admins list and output each each element details in the list, obviously the required list is passed as a parameter
        public void LoadAdmins(List<Admin> admins)
        {
            // try-catch block for error n exception handling and output appropriate message
            try
            {
                // output to the console what the type of user the list contains
                Console.WriteLine("ADMINS");
                // using foreach loop you go through each element of the list
                foreach (Admin admin in admins)
                {
                    // for every element, containing an admin object, you call the LoadUser() method within User Class
                    //LoadUser() is inherited by Admin Class from the User class
                    admin.LoadUser(); // details printed to the console
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to load Admins due to an error --> " + ex.Message);


            }
        }
        // method to populate the categories list, the required list is passed as a parameter
        public void CreateCategories(List<Category> categories)
        {
            // try-catch block for error n exception handling and output appropriate message
            try
            {
                // Appending the list using the Add() method in the System.Linq
                // each line below, you call the Add method for the categories list, and creating a new instance of the Category class, using the custom constructor and passing the needed parameters
                // parameters: Category Name, Category Description
                categories.Add(new Category("Programming Concepts", "Concepts of object-oriented programming and coding principles"));
                categories.Add(new Category("Data Structures", "Arrays, lists, stacks, queues, trees, and their applications"));
                categories.Add(new Category("Software Design", "Design patterns, architecture principles, and system modelling"));
                categories.Add(new Category("Web Development", "HTML, CSS, JavaScript, and client-server interactions"));
                categories.Add(new Category("Database Systems", "SQL queries, relational models, normalization, and transactions"));
                categories.Add(new Category("Cybersecurity Basics", "Encryption, authentication, and common security threats"));
                categories.Add(new Category("Computer Networks", "Protocols, IP addressing, routing, and network layers"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error faced while creating categories :( " + ex.Message);
            }
        }
        // method to populate the quizzes list, the required list is passed as a parameter
        public void CreateQuizzes(List<Quiz> quizzes)
        {
            // try-catch block for error n exception handling and output appropriate message
            try
            {
                // this is bit complicated AHH
                // process repeats for every quiz population
                // FIRSLTY, initialize a local list of questions for each quiz
                List<Question> qQuestions1 = new List<Question>();// new list of type question of questions
                // SECONDLY, lets populate the questions list since its empty
                // we use the Add() to append the questions list
                // for every call, you pass a new instance of question class, using the custom constructor and passing needed parameters
                // Parameters for question: Question Text, List of strings holding the options, correct answer and difficulty level
                // Note: FOR the options, you initialize the new list within the parameter bracket, this saves spacing and time without having to make a local list of options for every question in every quiz
                qQuestions1.Add(new Question("What does OOP stand for?", new List<string> { "Object-Oriented Programming", "Operational Output Processing", "OpenOrder Protocol", "OverloadedOperator Procedure" }, "Object-Oriented Programming", "Easy"));
                qQuestions1.Add(new Question("Which of the following is NOT a core principle of OOP? ", new List<string> { "Encapsulation", "Polymorphism", "Abstraction", "Compilation" }, "Compilation", "Easy"));
                qQuestions1.Add(new Question("What is encapsulation in object-oriented programming?", new List<string> { "Binding data and methods", "Inheritance", "Overloading", "Creating objects" }, "Binding data and methods", "Medium"));
                qQuestions1.Add(new Question("Which keyword is used in C# to inherit a class?", new List<string> { "extends", "inherits", ":", "base" }, ":", "Medium"));
                qQuestions1.Add(new Question("What is the purpose of a constructor in a class?", new List<string> { "To destroy objects", "To initialize objects", "To inherit methods", "To override properties" }, "To initialize objects", "Easy"));
                qQuestions1.Add(new Question("Which concept allows multiple methods with the same name but different parameters?", new List<string> { "Inheritance", "Polymorphism", "Overloading", "Encapsulation" }, "Overloading", "Medium"));
                qQuestions1.Add(new Question("What is the base class for all classes in C#?", new List<string> { "System.Object", "BaseClass", "RootClass", "MainClass" }, "System.Object", "Hard"));
                qQuestions1.Add(new Question("What is the difference between a class and an object?", new List<string> { "Class is an instance and object is a blueprint", "Class is a blueprint and object is an instance", "They are the same", "Object inherits class" }, "Class is a blueprint and object is an instance", "Medium"));
                qQuestions1.Add(new Question("Which access modifier makes a member accessible only within its own class? ", new List<string> { "public", "private", "protected", "internal" }, "private", "Easy"));
                qQuestions1.Add(new Question("What is polymorphism in OOP?", new List<string> { "Ability to hide data", "Ability to inherit methods", "Ability to take many forms", "Ability to override constructors" }, "Ability to take many forms", "Medium"));
                // the questions list now contains the questions related for the quiz
                // NOW WE APPEND the quizzes list of the system
                // passing a new instance of the Quiz class and using the custom constructor we passed the parameters needed
                // parameters: Quiz Title, Quiz Description, Category, the questions list (the local variable we just made)
                // Note: for category we pass the whole object, with correct index to match which element , the quiz belongs to!
                quizzes.Add(new Quiz("OOP fundamentals", "Covers basics of object-oriented programming", categories[0], qQuestions1));

                // Like i mentioned THE WHOLE PROCESS REPEATS and you make how many quizzes you would like to start with :D
                List<Question> qQuestions2 = new List<Question>();
                qQuestions2.Add(new Question("Which data structure uses LIFO (Last In First Out) principle?", new List<string> { "Queue", "Stack", "Array", "Linked List" }, "Stack", "Easy"));
                qQuestions2.Add(new Question("What is the time complexity of accessing an element in an array?", new List<string> { "O(1)", "O(n)", "O(log n)", "O(n^2)" }, "O(1)", "Easy"));
                qQuestions2.Add(new Question("Which data structure is best suited for implementing a FIFO (First In First Out) system?", new List<string> { "Stack", "Queue", "Tree", "Graph" }, "Queue", "Easy"));
                qQuestions2.Add(new Question("What is a linked list?", new List<string> { "A collection of nodes", "A type of array", "A stack implementation", "A queue implementation" }, "A collection of nodes", "Medium"));
                qQuestions2.Add(new Question("Which data structure is used for hierarchical data representation?", new List<string> { "Array", "Linked List", "Tree", "Graph" }, "Tree", "Hard"));
                qQuestions2.Add(new Question("What is the main difference between a stack and a queue?", new List<string> { "Stack is FIFO and Queue is LIFO", "Stack is LIFO and Queue is FIFO", "Both are FIFO", "Both are LIFO" }, "Stack is LIFO and Queue is FIFO", "Easy"));
                qQuestions2.Add(new Question("What is the time complexity of searching for an element in a balanced binary search tree?", new List<string> { "O(1)", "O(n)", "O(log n)", "O(n log n)" }, "O(log n)", "Hard"));
                qQuestions2.Add(new Question("Which data structure allows dynamic resizing?", new List<string> { "Array", "Linked List", "Stack", "Queue" }, "Linked List", "Medium"));
                qQuestions2.Add(new Question("What is a data structure?", new List<string> { "A programming language", "A collection of algorithms", "A way to store and organize data", "A type of computer hardware" }, "A way to store and organize data", "Easy"));
                qQuestions2.Add(new Question("Which data structure is used to implement recursion?", new List<string> { "Queue", "Stack", "Array", "Linked List" }, "Stack", "Hard"));
                quizzes.Add(new Quiz("Data Structures I", "Focuses on arrays, lists, stacks, queues, trees, and their applications.", categories[1], qQuestions2));

                List<Question> qQuestions3 = new List<Question>();
                qQuestions3.Add(new Question("Which is the first step in the software development life cycle?", new List<string> { "Analysis", "Design", "Problem/Opportunity Identification", "Development and Documentation" }, "Problem/Opportunity Identification", "Medium"));
                qQuestions3.Add(new Question("A step by step instruction used to solve a problem is known as", new List<string> { "Sequential structure", "A list", "A plan", "An Algorithm" }, "An Algorithm", "Easy"));
                qQuestions3.Add(new Question("Debugging is", new List<string> { "creating program code", "finding and correcting errors in the program code", "identifying the task to be computerized", "creating the algorithm" }, "finding and correcting errors in the program code", "Medium"));
                qQuestions3.Add(new Question("The importance of software design can be summarized in a single word which is: ", new List<string> { "Efficiency", "Accuracy", "Simplicity", "Quality" }, "Quality", "Medium"));
                qQuestions3.Add(new Question("Cohesion is a qualitative indication of the degree to which a module", new List<string> { "can be written more compactly", "focuses on just one thing", "is able to complete its function in a timely manner", "is connected to other modules" }, "focuses on just one thing", "Hard"));
                qQuestions3.Add(new Question("Which of the property of software modularity is incorrect with respect to benefits software modularity?", new List<string> { "Modules are robust", "Module can use other modules", "Modules can be separately compiled and stored in a library", "Modules are mostly dependent" }, "Modules are mostly dependent", "Medium"));
                qQuestions3.Add(new Question("________ is a measure of the degree of interdependence between modules", new List<string> { "Cohesion", "Coupling", "None of the mentioned", "All of the mentioned" }, "Coupling", "Hard"));
                qQuestions3.Add(new Question("Which of the following is NOT a design pattern?", new List<string> { "Singleton", "Factory", "Observer", "Algorithm" }, "Algorithm", "Medium"));
                qQuestions3.Add(new Question("A software engineer must design the modules with the goal of high cohesion and low coupling.", new List<string> { "True", "False" }, "True", "Easy"));
                qQuestions3.Add(new Question("Which UML diagram is primarily used to represent the static structure of a system?", new List<string> { "Use Case Diagram", "Class Diagram", "Sequence Diagram", "Activity Diagram" }, "Class Diagram", "Hard"));
                quizzes.Add(new Quiz("Software Design I", "Includes design patterns, architecture principles, and system modelling.", categories[2], qQuestions3));

                List<Question> qQuestions4 = new List<Question>();
                qQuestions4.Add(new Question("Which language is primarily used for structuring web content?", new List<string> { "CSS", "JavaScript", "HTML", "Python" }, "HTML", "Easy"));
                qQuestions4.Add(new Question("What does CSS stand for?", new List<string> { "Cascading Style Sheets", "Computer Style Sheets", "Creative Style System", "Colorful Style Sheets" }, "Cascading Style Sheets", "Easy"));
                qQuestions4.Add(new Question("Which of the following is a JavaScript framework?", new List<string> { "Django", "React", "Laravel", "Ruby on Rails" }, "React", "Hard"));
                qQuestions4.Add(new Question("What is the purpose of the <div> tag in HTML?", new List<string> { "To create a hyperlink", "To define a division or section", "To insert an image", "To create a list" }, "To define a division or section", "Medium"));
                qQuestions4.Add(new Question("Which HTTP method is used to retrieve data from a server?", new List<string> { "POST", "GET", "PUT", "DELETE" }, "GET", "Medium"));
                qQuestions4.Add(new Question("In JavaScript which symbol is used to denote a comment?", new List<string> { "//", "/* */", "#", "<!-- -->" }, "//", "Easy"));
                qQuestions4.Add(new Question("What is the purpose of the box model in CSS?", new List<string> { "To define the layout of HTML elements", "To create animations", "To handle user input", "To manage server requests" }, "To define the layout of HTML elements", "Hard"));
                qQuestions4.Add(new Question("Which HTML element is used to embed JavaScript code?", new List<string> { "<js>", "<script>", "<javascript>", "<code>" }, "<script>", "Easy"));
                qQuestions4.Add(new Question("What does AJAX stand for?", new List<string> { "Asynchronous JavaScript and XML", "Advanced Java and XHTML", "Asynchronous JSON and XML", "Advanced JavaScript and XHTML" }, "Asynchronous JavaScript and XML", "Hard"));
                qQuestions4.Add(new Question("Which CSS property is used to change the text color of an element?", new List<string> { "font-color", "text-color", "color", "font-style" }, "color", "Easy"));
                quizzes.Add(new Quiz("Web Development", " HTML, CSS, JavaScript, and client-server interactions.", categories[3], qQuestions4));

                List<Question> qQuestions5 = new List<Question>();
                qQuestions5.Add(new Question("What does SQL stand for?", new List<string> { "Structured Query Language", "Simple Query Language", "Sequential Query Language", "Standard Query Language" }, "Structured Query Language", "Easy"));
                qQuestions5.Add(new Question("Which SQL command is used to retrieve data from a database?", new List<string> { "SELECT", "INSERT", "UPDATE", "DELETE" }, "SELECT", "Easy"));
                qQuestions5.Add(new Question("What is normalization in database design?", new List<string> { "Process of organizing data to reduce redundancy", "Process of backing up data", "Process of encrypting data", "Process of indexing data" }, "Process of organizing data to reduce redundancy", "Medium"));
                qQuestions5.Add(new Question("Which SQL clause is used to filter records?", new List<string> { "WHERE", "HAVING", "GROUP BY", "ORDER BY" }, "WHERE", "Easy"));
                qQuestions5.Add(new Question("What is a primary key in a database?", new List<string> { "A field that uniquely identifies each record", "A field that can have duplicate values", "A field used for indexing", "A field used for foreign key relationships" }, "A field that uniquely identifies each record", "Medium"));
                qQuestions5.Add(new Question("Which SQL command is used to add new records to a table?", new List<string> { "INSERT INTO", "UPDATE", "DELETE", "SELECT" }, "INSERT INTO", "Easy"));
                qQuestions5.Add(new Question("What is a foreign key?", new List<string> { "A key used to encrypt data", "A field that uniquely identifies each record", "A field that links to the primary key of another table", "A field used for indexing" }, "A field that links to the primary key of another table", "Medium"));
                qQuestions5.Add(new Question("Which SQL function is used to count the number of records in a table?", new List<string> { "SUM()", "COUNT()", "AVG()", "MAX()" }, "COUNT()", "Easy"));
                qQuestions5.Add(new Question("What is a transaction in database systems?", new List<string> { "A sequence of operations performed as a single logical unit of work", "A backup of the database", "A method of encrypting data", "A way to index data" }, "A sequence of operations performed as a single logical unit of work", "Hard"));
                qQuestions5.Add(new Question("Which SQL clause is used to sort the result set?", new List<string> { "WHERE", "ORDER BY", "GROUP BY", "HAVING" }, "ORDER BY", "Easy"));
                quizzes.Add(new Quiz("Database Systems", "SQL queries, relational models, normalization, and transactions.", categories[4], qQuestions5));

                List<Question> qQuestions6 = new List<Question>();
                qQuestions6.Add(new Question("What is the primary purpose of encryption in cybersecurity?", new List<string> { "To speed up data transmission", "To protect data confidentiality", "To compress data", "To format data" }, "To protect data confidentiality", "Easy"));
                qQuestions6.Add(new Question("Which of the following is a common type of cyber attack?", new List<string> { "Phishing", "Caching", "Compiling", "Indexing" }, "Phishing", "Easy"));
                qQuestions6.Add(new Question("What does the term 'firewall' refer to in cybersecurity?", new List<string> { "A physical barrier to prevent unauthorized access", "A software or hardware system that monitors and controls incoming and outgoing network traffic", "A type of encryption algorithm", "A method of data compression" }, "A software or hardware system that monitors and controls incoming and outgoing network traffic", "Medium"));
                qQuestions6.Add(new Question("What is two-factor authentication (2FA)?", new List<string> { "Using two passwords for login", "Using a password and a second form of verification", "Using two usernames for login", "Using biometric data only" }, "Using a password and a second form of verification", "Medium"));
                qQuestions6.Add(new Question("Which of the following is NOT a strong password practice?", new List<string> { "Using a mix of letters and numbers and symbols", "Using common words or phrases", "Changing passwords regularly", "Using long passwords" }, "Using common words or phrases", "Easy"));
                qQuestions6.Add(new Question("What is a VPN (Virtual Private Network)?", new List<string> { "A tool for speeding up internet connection", "A service that encrypts internet traffic and masks IP addresses", "A type of firewall", "A method of data compression" }, "A service that encrypts internet traffic and masks IP addresses", "Medium"));
                qQuestions6.Add(new Question("What is the main goal of ethical hacking?", new List<string> { "To exploit vulnerabilities for personal gain", "To identify and fix security weaknesses", "To create malware", "To bypass firewalls" }, "To identify and fix security weaknesses", "Hard"));
                qQuestions6.Add(new Question("What is Pharming?", new List<string> { "A type of malware", "A cyber attack that redirects users to fake websites", "A method of data encryption", "A firewall technique" }, "A cyber attack that redirects users to fake websites", "Medium"));
                qQuestions6.Add(new Question("What is Phishing?", new List<string> { "A method of data encryption", "A cyber attack that tricks users into revealing personal information", "A type of firewall", "A tool for speeding up internet connection" }, "A cyber attack that tricks users into revealing personal information", "Easy"));
                qQuestions6.Add(new Question("Which of the following is a common method used to protect against malware?", new List<string> { "Using strong passwords", "Installing antivirus software", "Using a VPN", "Enabling two-factor authentication" }, "Installing antivirus software", "Easy"));
                quizzes.Add(new Quiz("Cybersecurity Basics", "Encryption, authentication, and common security threats.", categories[5], qQuestions6));

                List<Question> qQuestions7 = new List<Question>();
                qQuestions7.Add(new Question("What does IP stand for in networking?", new List<string> { "Internet Protocol", "Internal Process", "Internet Program", "Internal Protocol" }, "Internet Protocol", "Easy"));
                qQuestions7.Add(new Question("Which device is used to connect multiple networks together?", new List<string> { "Switch", "Router", "Hub", "Modem" }, "Router", "Easy"));
                qQuestions7.Add(new Question("What is the purpose of a subnet mask?", new List<string> { "To identify the network and host portions of an IP address", "To encrypt data", "To route traffic", "To assign IP addresses" }, "To identify the network and host portions of an IP address", "Hard"));
                qQuestions7.Add(new Question("Which protocol is used for secure communication over the internet?", new List<string> { "HTTP", "FTP", "HTTPS", "SMTP" }, "HTTPS", "Medium"));
                qQuestions7.Add(new Question("What is the function of DNS (Domain Name System)?", new List<string> { "To translate domain names to IP addresses", "To encrypt data", "To route traffic", "To assign IP addresses" }, "To translate domain names to IP addresses", "Medium"));
                qQuestions7.Add(new Question("Which layer of the OSI model is responsible for data transmission between devices?", new List<string> { "Network Layer", "Data Link Layer", "Physical Layer", "Transport Layer" }, "Physical Layer", "Hard"));
                qQuestions7.Add(new Question("What is a MAC address?", new List<string> { "A unique identifier assigned to network interfaces for communications", "An IP address", "A type of firewall", "A routing protocol" }, "A unique identifier assigned to network interfaces for communications", "Medium"));
                qQuestions7.Add(new Question("What does TLS stand for?", new List<string> { "Transport Link Security", "Transport Layer Security", "Time Layer Secure", "Transport Layer Safety" }, "Transport Layer Security", "Easy"));
                qQuestions7.Add(new Question("What does TCP stand for?", new List<string> { "Transport Control Protocol", "Time Crunch Protocol", "Time Control Protocol", "Transport Collect Protocol" }, "Transport Control Protocol", "Easy"));
                qQuestions7.Add(new Question("What is a computer network?", new List<string> { "A device used to display information on a computer screen", "A collection of interconnected computers and devices that can communicate and share resources", "A type of software used to create documents and presentations", "The physical casing that protects a computer's internal components" }, "A collection of interconnected computers and devices that can communicate and share resources", "Easy"));
                quizzes.Add(new Quiz("Computer Networks", "Protocols, IP addressing, routing, and network layers.", categories[6], qQuestions7));

                List<Question> qQuestions8 = new List<Question>();
                qQuestions8.Add(new Question("Who invented OOP?", new List<string> { "Andrea Ferro", "Adele Goldberg", "Alan Kay", "Dennis Ritchie" }, "Alan Kay", "Hard"));
                qQuestions8.Add(new Question("Which of the following is an example of polymorphism in OOP?", new List<string> { "Method Overloading", "Data Hiding", "Class Inheritance", "Object Instantiation" }, "Method Overloading", "Medium"));
                qQuestions8.Add(new Question("In OOP what is the term for a class that cannot be instantiated?", new List<string> { "Abstract Class", "Concrete Class", "Interface", "Static Class" }, "Abstract Class", "Hard"));
                qQuestions8.Add(new Question("What is the main advantage of using interfaces in OOP?", new List<string> { "Code Reusability", "Multiple Inheritance", "Data Encapsulation", "Polymorphism" }, "Multiple Inheritance", "Hard"));
                qQuestions8.Add(new Question("Which of the following is NOT a type of inheritance in OOP?", new List<string> { "Single Inheritance", "Multiple Inheritance", "Hierarchical Inheritance", "Sequential Inheritance" }, "Sequential Inheritance", "Hard"));
                qQuestions8.Add(new Question("What is method overriding in OOP?", new List<string> { "Defining a method in a subclass with the same name and signature as in the superclass", "Defining multiple methods with the same name but different parameters", "Hiding data within a class", "Creating objects from a class" }, "Defining a method in a subclass with the same name and signature as in the superclass", "Medium"));
                qQuestions8.Add(new Question("Which OOP principle emphasizes the bundling of data and methods that operate on that data within a single unit?", new List<string> { "Encapsulation", "Abstraction", "Inheritance", "Polymorphism" }, "Encapsulation", "Easy"));
                qQuestions8.Add(new Question("In OOP what is the term for a class that serves as a blueprint for creating objects?", new List<string> { "Object", "Method", "Class", "Interface" }, "Class", "Easy"));
                qQuestions8.Add(new Question("What is the difference between composition and inheritance in OOP?", new List<string> { "Composition is a 'has-a' relationship while inheritance is an 'is-a' relationship", "Composition allows code reuse while inheritance does not", "Inheritance is more flexible than composition", "There is no difference" }, "Composition is a 'has-a' relationship while inheritance is an 'is-a' relationship", "Hard"));
                qQuestions8.Add(new Question("Which of the following is a benefit of using OOP?", new List<string> { "Improved code organization and maintainability", "Faster execution speed", "Reduced memory usage", "Simplified syntax" }, "Improved code organization and maintainability", "Easy"));
                quizzes.Add(new Quiz("Advanced OOP", "In-depth exploration of advanced object-oriented programming concepts.", categories[0], qQuestions8));

                List<Question> qQuestions9 = new List<Question>();
                qQuestions9.Add(new Question("What is a balanced binary search tree?", new List<string> { "A tree where each node has at most two children", "A tree where the left and right subtrees of every node differ in height by at most one", "A tree that allows duplicate values", "A tree that is always complete" }, "A tree where the left and right subtrees of every node differ in height by at most one", "Hard"));
                qQuestions9.Add(new Question("Which of the following points is/are not true about Linked List data structure when it is compared with an array?", new List<string> { "Random access is not allowed in a typical implementation of Linked Lists", "Access of elements in linked list takes less time than compared to arrays", "Arrays have better cache locality that can make them better in terms of performance", "It is easy to insert and delete elements in Linked List" }, "Access of elements in linked list takes less time than compared to arrays", "Medium"));
                qQuestions9.Add(new Question("Which of the following application makes use of a circular linked list?", new List<string> { "Recursive function calls", "Undo operation in a text editor", "Implementing Hash Tables", "Allocating CPU to resources" }, "Allocating CPU to resources", "Hard"));
                qQuestions9.Add(new Question("Which of the following is not the type of queue?", new List<string> { "Priority queue", "Circular queue", "Single ended queue", "Ordinary queue" }, "Single ended queue", "Medium"));
                qQuestions9.Add(new Question("Which is the most appropriate data structure for reversing a word?", new List<string> { "Array", "Stack", "Queue", "Linked List" }, "Stack", "Easy"));
                qQuestions9.Add(new Question("What is the average time complexity for searching an element in a hash table?", new List<string> { "O(1)", "O(n)", "O(log n)", "O(n log n)" }, "O(1)", "Hard"));
                qQuestions9.Add(new Question("In which data structure are elements added and removed from the same end?", new List<string> { "Queue", "Stack", "Linked List", "Array" }, "Stack", "Easy"));
                qQuestions9.Add(new Question("Which of the following is not a self-balancing binary search tree?", new List<string> { "AVL Tree", "Red-Black Tree", "B-Tree", "Binary Heap" }, "Binary Heap", "Hard"));
                qQuestions9.Add(new Question("What is the advantage of a hash table as a data structure?", new List<string> { "Fast access to elements based on keys", "Ordered storage of elements", "Hierarchical data representation", "Dynamic resizing" }, "Fast access to elements based on keys", "Medium"));
                qQuestions9.Add(new Question("Which of the following is also known as Rope data structure?", new List<string> { "Linked List", "Array", "String", "Cord" }, "Cord", "Hard"));
                quizzes.Add(new Quiz("Data Structures II", "Challenging questions on existing data structures and their properties", categories[1], qQuestions9));

                List<Question> qQuestions10 = new List<Question>();
                qQuestions10.Add(new Question("What is the Singleton design pattern used for?", new List<string> { "To create multiple instances of a class", "To ensure a class has only one instance and provide a global point of access to it", "To define a family of algorithms", "To separate the construction of a complex object from its representation" }, "To ensure a class has only one instance and provide a global point of access to it", "Easy"));
                qQuestions10.Add(new Question("Which design pattern is used to separate the construction of a complex object from its representation?", new List<string> { "Builder Pattern", "Factory Pattern", "Observer Pattern", "Decorator Pattern" }, "Builder Pattern", "Medium"));
                qQuestions10.Add(new Question("What is the main purpose of the Observer design pattern?", new List<string> { "To define a one-to-many dependency between objects", "To create objects without specifying the exact class", "To encapsulate a request as an object", "To provide a surrogate for another object" }, "To define a one-to-many dependency between objects", "Medium"));
                qQuestions10.Add(new Question("Which design pattern provides a way to access the elements of an aggregate object sequentially without exposing its underlying representation?", new List<string> { "Iterator Pattern", "Composite Pattern", "Facade Pattern", "Proxy Pattern" }, "Iterator Pattern", "Hard"));
                qQuestions10.Add(new Question("What is the main advantage of using the Factory design pattern?", new List<string> { "It allows for easy object creation without specifying the exact class", "It improves performance", "It simplifies code syntax", "It enhances security" }, "It allows for easy object creation without specifying the exact class", "Medium"));
                qQuestions10.Add(new Question("Which design pattern is used to provide a simplified interface to a complex subsystem?", new List<string> { "Facade Pattern", "Adapter Pattern", "Bridge Pattern", "Decorator Pattern" }, "Facade Pattern", "Hard"));
                qQuestions10.Add(new Question("Which of the following is the worst type of module cohesion?", new List<string> { "Logical Cohesion", "Temporal Cohesion", "Functional Cohesion", "Coincidental Cohesion" }, "Coincidental Cohesion", "Hard"));
                qQuestions10.Add(new Question(" In the Analysis phase the development of the ____________ occurs which is a clear statement of the goals and objectives of the project.", new List<string> { "documentation", "program specification", "system design", "flowchart" }, "program specification", "Medium"));
                qQuestions10.Add(new Question("Actual programming of software code is done during the ____________ step in the SDLC.", new List<string> { "Testing and Integration", "Design", "Development and Documentation", "Analysis" }, "Development and Documentation", "Easy"));
                qQuestions10.Add(new Question("Which design pattern allows behavior to be added to an individual object either statically or dynamically without affecting the behavior of other objects from the same class?", new List<string> { "Decorator Pattern", "Strategy Pattern", "Command Pattern", "Mediator Pattern" }, "Decorator Pattern", "Hard"));
                quizzes.Add(new Quiz("Software Design II ", "Harder questions related to designing a good software and includes all design patterns", categories[2], qQuestions10));

                List<Question> qQuestions11 = new List<Question>();
                qQuestions11.Add(new Question("Which HTML5 element is used to define the main content of a document?", new List<string> { "<header>", "<main>", "<section>", "<article>" }, "<main>", "Easy"));
                qQuestions11.Add(new Question("What is the purpose of the 'defer' attribute in a <script> tag?", new List<string> { "To load the script asynchronously", "To delay the execution of the script until after the document has been parsed", "To block the rendering of the page until the script is loaded", "To prioritize the script loading" }, "To delay the execution of the script until after the document has been parsed", "Medium"));
                qQuestions11.Add(new Question("Which CSS property is used to create a flex container?", new List<string> { "display: block;", "display: inline;", "display: flex;", "display: grid;" }, "display: flex;", "Hard"));
                qQuestions11.Add(new Question("In JavaScript which method is used to add an event listener to an element?", new List<string> { "addEventListener()", "attachEvent()", "onEvent()", "bindEvent()" }, "addEventListener()", "Medium"));
                qQuestions11.Add(new Question("What is the purpose of the 'this' keyword in JavaScript?", new List<string> { "To refer to the current function", "To refer to the global object", "To refer to the object that is executing the current function", "To refer to the parent object" }, "To refer to the object that is executing the current function", "Hard"));
                qQuestions11.Add(new Question("Which HTTP status code indicates a successful request?", new List<string> { "200", "404", "500", "301" }, "200", "Easy"));
                qQuestions11.Add(new Question("What is the purpose of the 'async' attribute in a <script> tag?", new List<string> { "To load the script asynchronously", "To delay the execution of the script until after the document has been parsed", "To block the rendering of the page until the script is loaded", "To prioritize the script loading" }, "To load the script asynchronously", "Medium"));
                qQuestions11.Add(new Question("Which CSS property is used to create a grid container?", new List<string> { "display: block;", "display: inline;", "display: flex;", "display: grid;" }, "display: grid;", "Hard"));
                qQuestions11.Add(new Question("In JavaScript which method is used to remove an event listener from an element?", new List<string> { "removeEventListener()", "detachEvent()", "offEvent()", "unbindEvent()" }, "removeEventListener()", "Medium"));
                qQuestions11.Add(new Question("What is the purpose of the 'bind()' method in JavaScript?", new List<string> { "To create a new function with a specific 'this' value", "To call a function with a specific 'this' value", "To apply a function with a specific 'this' value", "To create a closure" }, "To create a new function with a specific 'this' value", "Hard"));
                quizzes.Add(new Quiz("Further Web Development", "Comprehensive quiz covering more aspects of JavaScript.", categories[3], qQuestions11));

                List<Question> qQuestions12 = new List<Question>();
                qQuestions12.Add(new Question("Who designs and implement database structures?", new List<string> { "Programmer", "Architect", "Technical writers", "Database administrators" }, "Database administrators", "Easy"));
                qQuestions12.Add(new Question("What is DBMS?", new List<string> { "DBMS is a collection of queries", "DBMS is a high-level language", "DBMS is a programming language", "DBMS stores and modifies and retrieves data" }, "DBMS stores and modifies and retrieves data", "Easy"));
                qQuestions12.Add(new Question("Which of the following is a type of DBMS?", new List<string> { "Hierarchical DBMS", "Network DBMS", "Relational DBMS", "All of the mentioned" }, "All of the mentioned", "Medium"));
                qQuestions12.Add(new Question("Which of the following is not a function of DBMS?", new List<string> { "Data storage management", "Data transformation", "Data security", "Data retrieval" }, "Data transformation", "Easy"));
                qQuestions12.Add(new Question("Which of the following is a NoSQL database?", new List<string> { "MySQL", "PostgreSQL", "MongoDB", "SQLite" }, "MongoDB", "Hard"));
                qQuestions12.Add(new Question("Which of the following is not an example of DBMS?", new List<string> { "MySQL", "Microsoft Access", "Google", "IBM DB2" }, "Google", "Easy"));
                qQuestions12.Add(new Question("Which of the following is not a feature of DBMS?", new List<string> { "Minimum Duplication and Redundancy of Data", "High Level of Security", "Single-user Access only", "Support ACID property" }, "Single-user Access only", "Medium"));
                qQuestions12.Add(new Question("What does ACID stand for in database systems?", new List<string> { "Atomicity Consistency Isolation Durability", "Accuracy Consistency Integrity Durability", "Atomicity Clarity Isolation Durability", "Accuracy Clarity Integrity Durability" }, "Atomicity Consistency Isolation Durability", "Hard"));
                qQuestions12.Add(new Question("Which of the following is known as a set of entities of the same type that share same properties or attributes?", new List<string> { "Relation set", "Tuples", "Entity Relation Model", "Entity set" }, "Entity set", "Medium"));
                qQuestions12.Add(new Question("In a relational database what is a 'tuple'?", new List<string> { "A column in a table", "A row in a table", "A relationship between tables", "A type of index" }, "A row in a table", "Easy"));
                quizzes.Add(new Quiz("Database Management System", "General quiz covering aspects of DBMS", categories[4], qQuestions12));

                List<Question> qQuestions13 = new List<Question>();
                qQuestions13.Add(new Question("You receive an email from your “college admin” asking you to update your student credentials via a link. What should you do first?", new List<string> { "Click the link and log in immediately DUh", "Forward the email to classmates", "Reply with your password for verification", "Verify the sender's email domain and contact the admin office directly" }, "Verify the sender's email domain and contact the admin office directly", "Easy"));
                qQuestions13.Add(new Question("Your laptop shows a pop-up saying “Your computer is infected! click to clean now!” What’s the right step?", new List<string> { "Click to fix it", "Restart your system immediately", "Run your verified antivirus instead", "Ignore and continue browsing" }, "Run your verified antivirus instead", "Medium"));
                qQuestions13.Add(new Question("During an online internship your supervisor asks you to install unfamiliar monitoring software. What should you do?", new List<string> { "Install immediately", "Download from a random site", "Disable antivirus before installation", "Ask for written verification from your organization" }, "Ask for written verification from your organization", "Easy"));
                qQuestions13.Add(new Question("You notice unusual activity on your bank account after using public Wi-Fi. What’s your immediate action?", new List<string> { "Ignore it", "Change your online banking password and notify the bank", "Continue using public Wi-Fi for banking", "Share your account details with a friend for safety" }, "Change your online banking password and notify the bank", "Medium"));
                qQuestions13.Add(new Question("What does DoS attack stand for?", new List<string> { "Denial of Security", "Denial of Safety", "Denial of Simplicity", "Denial of Service" }, "Denial of Service", "Easy"));
                qQuestions13.Add(new Question("What does EDR stand for?", new List<string> { "Endlevel and Development Response", "Endpoint Detection and Response", "End Detect and Respond", "Extract Diffuse and Relay" }, "Endpoint Detection and Response", "Medium"));
                qQuestions13.Add(new Question("What is a black hat hacker?", new List<string> { "A hacker who uses their skills for ethical purposes", "A hacker who exploits vulnerabilities for malicious purposes", "A hacker who works for government agencies", "A hacker who focuses on network security" }, "A hacker who exploits vulnerabilities for malicious purposes", "Hard"));
                qQuestions13.Add(new Question("What is a zero-day vulnerability?", new List<string> { "A type of virus", "A flaw unknown to developers but exploited by hackers", "An old attack", "A security patch" }, "A flaw unknown to developers but exploited by hackers", "Hard"));
                qQuestions13.Add(new Question("Which of protocol encrypts data at the network level?", new List<string> { "IPV6", "IPFec", "IPSev", "IPSec" }, "IPSec", "Hard"));
                qQuestions13.Add(new Question("Which attack type employs a fake server with a relay address?", new List<string> { "Man-in-the-Center (MITC)", "Man-in-the-Middle (MITM)", "Man-in-the-Top (MITP)", "Man-in-the-West (MITW)" }, "Man-in-the-Middle (MITM)", "Hard"));
                quizzes.Add(new Quiz("Cybersecurity Advanced", "Detailed quiz on cybersecurity topics and some scenarios to handle.", categories[5], qQuestions13));

                List<Question> qQuestions14 = new List<Question>();
                qQuestions14.Add(new Question("How is a single channel shared by multiple signals in a computer network?", new List<string> { "multiplexing", "phase modulation", "analog modulation", "digital modulation" }, "multiplexing", "Medium"));
                qQuestions14.Add(new Question("What is the term for an endpoint of an inter-process communication flow across a computer network?", new List<string> { "port", "machine", "socket", "pipe" }, "socket", "Medium"));
                qQuestions14.Add(new Question("When discussing IDS/IPS what is a signature?", new List<string> { "It refers to 'normal' baseline network behavior", "It is used to authorize the users on a network", "An electronic signature used to authenticate the identity of a user on the network", "Attack-definition file" }, "An electronic signature used to authenticate the identity of a user on the network", "Medium"));
                qQuestions14.Add(new Question("Which of the following are Gigabit Ethernets?", new List<string> { "1000 BASE-LX", "1000 BASE-CX", "1000 BASE-SX", "All of the mentioned" }, "All of the mentioned", "Hard"));
                qQuestions14.Add(new Question("What does each packet contain in a virtual circuit network?", new List<string> { "only source address", "only destination address", "full source and destination address", "a short VC number" }, "a short VC number", "Hard"));
                qQuestions14.Add(new Question("What was the name of the first network?", new List<string> { "ASAPNET", "ARPANET", "CNNET", "NSFNET" }, "ARPANET", "Hard"));
                qQuestions14.Add(new Question("Which of the following is not a routing protocol?", new List<string> { "BGP", "RIP", "OSPF", "FTP" }, "FTP", "Medium"));
                qQuestions14.Add(new Question("Which of the following allows you to connect and login to a remote computer?", new List<string> { "SMTP", "HTTP", "FTP", "Telnet" }, "Telnet", "Easy"));
                qQuestions14.Add(new Question("TCP/IP model does not have ______ layer but OSI model have this layer.", new List<string> { "session layer", "transport layer", "application layer", "network layer" }, "session layer", "Medium"));
                qQuestions14.Add(new Question("The main contents of the routing table in datagram networks are ___________", new List<string> { "Source and Destination address", "Destination address and Output port", "Source address and Output port", "Input port and Output port" }, "Destination address and Output port", "Easy"));
                quizzes.Add(new Quiz("Network Administration", "Extensive quiz on network management, protocols, and security measures.", categories[6], qQuestions14));
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while creating our precious quizzes and questions :( " + ex.Message);
            }
        }
        // method to loop through the categories list and output each each element details in the list, obviously the required list is passed as a parameter
        public void LoadCategories(List<Category> categories)
        {
            // try-catch block for error n exception handling and output appropriate message
            try
            {
                // using foreach loop you go through each element of the list
                foreach (Category category in categories)
                {
                    // for every element, containing a category object, you call the LoadCategory() method within Category Class
                    // this method called, will output the details stored in that particular element
                    category.LoadCategory(); // category info outputted
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to load categories due to this error --> " + ex.Message);
            }
        }
        // method to loop through the quiz list, looking to output only quizzes that have the matching required category id that is passed as a parameter
        public void LoadQuizforCategory(List<Quiz> quizzes, int catID)
        {
            //try-catch block for error n exception handling and output appropriate message
            try
            {
                // looping through each element in the quizzes list
                foreach (Quiz quiz in quizzes)
                {
                    // checking if that specific quiz contains the matching category ID we passed
                    if (quiz.QuizCategory.CategoryID == catID)
                    {
                        // now that the quiz has the right category, we print its details
                        // we call method LoadQuiz() from the Quiz class to display the quiz info to the console
                        quiz.LoadQuiz();
                        Console.WriteLine();
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to load quizzes for this category due to this error --> " + ex.Message);
            }
        }

        // method to remove the certain category and its matching quizzes, using the category ID passed
        public void RemoveCategory(List<Category> categories, int catID, List<Quiz> quizzes)
        {
            // Note: due to category and quiz having a composition relationship, when category is removed so is quiz because its dependent
            //try-catch block for error n exception handling and output appropriate message
            try
            {
                // using the RemoveAll() method within the System.Linq
                // the method goes through each element in the category list and if it has the matching category ID, then that element is removed
                categories.RemoveAll(c => c.CategoryID == catID);
                // once again the method is called for the quiz list
                // each element is checked in the quiz list if it has the matching ID passed, if it does then the quiz is removed
                quizzes.RemoveAll(q => q.QuizCategory.CategoryID == catID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to remove a category due to this error --> " + ex.Message);
            }
        }
        // method to loop through the students list and output each each element details in the list, obviously the required list is passed as a parameter
        public void LoadStudents(List<Student> students)
        {
            //try-catch block for error n exception handling and output appropriate message
            try
            {
                // outputting the type of the user is displayed to the console
                Console.WriteLine("STUDENTS");
                // looping through each element in the students list
                foreach (Student student in students)
                {
                    // the LoadUser() is called for each element
                    //LoadUser() is inherited by the student class from User class
                    student.LoadUser(); // the details of student user is displayed
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to load students due to this error --> " + ex.Message);
            }
        }
        //method to loop through the quizzes list and output each each element details in the list, obviously the required list is passed as a parameter
        public void LoadQuizzes(List<Quiz> quizzes)
        {
            //try-catch block for error n exception handling and output appropriate message
            try
            {
                // looping through each element in the quiz list
                foreach (Quiz quiz in quizzes)
                {
                    // call LoadQuiz() is called for each element, from Quiz Class
                    quiz.LoadQuiz(); // the details of the quiz are displayed
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to load quizzes due to this error --> " + ex.Message);
            }

        }
        // method is used to save all the quiz questions in the list, into an excel sheet
        public void SaveQuiztoCSV(List<Quiz> quizzes, string filePath)
        {
            // handle exception for file not found or in use
            //try-catch block for error n exception handling and output appropriate message
            // Note: the file is created and stored in the bin
            try
            {
                // initialize an instance of streamWriter , aka a writer because we are writing to a file
                using (StreamWriter writer = new StreamWriter(filePath)) // the file to be written to is passed as a filepath here
                {
                    // the column names are established
                    writer.WriteLine("Quiz ID ,Question ID ,Question Text ,Question Options ,Question Correct Answer ,Question Difficulty Level ");
                    // looping through each quiz in the quizzes list
                    foreach (Quiz quiz in quizzes)
                    {
                        // looping through each question in the quiz
                        foreach (Question question in quiz.QuizQuestions)
                        {
                            // extracting information
                            // for the options we want them in one cell so then the list is joined by ; into one string 
                            string options = string.Join(";", question.QuestionOptions);
                            // in a new row, each attribute is put in each cell
                            writer.WriteLine($"{quiz.QuizID},{question.QuestionID},{question.QuestionText},{options},{question.QuestionCorrectAnswer},{question.QuestionDifficultLevel}");

                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("An error occurred while saving the quiz to CSV: " + ex.Message);
            }

        }
        // method to remove the certain Admin from the list by its matching Admin ID passed as a parameter
        public void RemoveAdmin(List<Admin> admins, int adminID)
        {
            //try-catch block for error n exception handling and output appropriate message
            try
            {
                // using the RemoveAll() method within the System.Linq
                // the method goes through each element in the admins list and if it has the matching admin ID, then that element is removed
                admins.RemoveAll(a => a.UserId == adminID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to remove admin due to this error --> " + ex.Message);
            }
        }
        // method to remove the certain Student from the list by its matching student ID passed as a parameter
        public void RemoveStudent(List<Student> students, int studentID)
        {
            //try-catch block for error n exception handling and output appropriate message
            try
            {
                // using the RemoveAll() method within the System.Linq
                // the method goes through each element in the students list and if it has the matching student ID, then that element is removed
                students.RemoveAll(s => s.UserId == studentID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to remove student due to this error --> " + ex.Message);
            }

        }
        // method to check if the admin credentials inputted are valid and exist in the system, returns true for successful login
        public bool VerifyAdminLogin(List<Admin> admins, string username, string password)
        {
            //try-catch block for error n exception handling and output appropriate message
            try
            {
                // we are looping through each admin in the admins list that is passed as a parameter
                foreach (Admin admin in admins)
                {
                    // we are checking if the admin at the list shares the same password AND username as the parameters passed
                    if (admin.UserName == username && admin.UserPassword == password)
                    {
                        // considering we have found the matching admin
                        //LoggedIn() method inherited from the User class, is used to output a message showing successful login
                        admin.LoggedIn();
                        // LoggedDate() method from admin class is called so that the login attribute is updated for this admin
                        admin.LoggedDate();
                        return true; // successful login
                    }
                }
                // we could not find the admin, hence invalid, doesn't exist
                Console.WriteLine("Invalid admin credentials.");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during admin login verification: " + ex.Message);
                return false;
            }
        }
        // method to check if the student credentials inputted are valid and exist in the system, returns true if its successful login
        public bool VerifyStudentLogin(List<Student> students, string username, string password)
        {
            //try-catch block for error n exception handling and output appropriate message
            try
            {
                // we are looping through each student in the students list that is passed as a parameter
                foreach (Student student in students)
                {
                    // we are checking if the student at the list shares the same password AND username as the parameters passed
                    if (student.UserName == username && student.UserPassword == password)
                    {

                        // considering we have found the matching student
                        //LoggedIn() method inherited from the User class, is used to output a message showing successful login
                        student.LoggedIn();
                        return true; // YAY TRUE SUCCESS
                    }
                }
                // unfortunately, either student parameters had invalid details or doesn't exist
                Console.WriteLine("Invalid student credentials.");
                return false; // FAILL
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during student login verification: " + ex.Message);
                return false;
            }
        }
        // BIG BOSS, Main Menu is the method that is called for the user interface, providing options for the users
        public void MainMenu(List<Admin> admins, List<Student> students, List<Category> categories, List<Quiz> quizzes) // passes all the lists to ensure smooth function
        {
            // the menu options are displayed with their matching numbers
            Console.WriteLine("Welcome to the Quiz System!");
            Console.WriteLine("1. Admin Login");
            Console.WriteLine("2. Student Login");
            Console.WriteLine("0. Exit");
            // the user is prompted to input an option
            Console.Write("Select an option: ");
            string choice = "";
            // this menu is looped until the user asks to exit by their choice
            do
            {
                // in this loop there is a switch case statements for the varying codes depending on which option chosen
                //try-catch block for error n exception handling and output appropriate message
                try
                {
                    // the choice is read
                    choice = Console.ReadLine();
                    // we check the choice across the give conditions
                    switch (choice)
                    {
                        case "1":
                            // The User would like to be taken to admin login
                            //try-catch block for error n exception handling and output appropriate message
                            try
                            {
                                // admin credentials required
                                Console.Write("Enter admin username: ");
                                string adminUsername = Console.ReadLine();  // the username inputted is stored
                                Console.Write("Enter admin password: ");
                                string adminPassword = Console.ReadLine(); // the password inputted is stored
                                // create a local variable to hold boolean value which shows if credentials are valid
                                bool isAdminValid = false; //initialized to false
                                // keeps looping until what is inputted is valid
                                while (!isAdminValid)
                                {
                                    // the VerifyAdminLogin() is called to check if the password and username of admin exist or valid
                                    isAdminValid = VerifyAdminLogin(admins, adminUsername, adminPassword);
                                    if (!isAdminValid)
                                    {

                                        // since they are not valid/exist here
                                        // they are prompted to input the credentials again until correct option given
                                        Console.Write("Enter admin username: ");
                                        adminUsername = Console.ReadLine();
                                        Console.Write("Enter admin password: ");
                                        adminPassword = Console.ReadLine();



                                    }
                                    else
                                    {
                                        // they luckily do exist and valid 
                                        Console.WriteLine("Press Enter to continue ");
                                        Console.ReadLine();
                                        // the Admin Menu is called to redirect Admin to correct interface
                                        AdminMenu(admins, adminUsername, quizzes, categories, students);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("An error occurred during admin login: " + ex.Message);
                            }

                            break;
                        case "2":
                            //try-catch block for error n exception handling and output appropriate message
                            // the user would like to be taken to Student Login
                            try
                            {
                                // prompt the user to input the credentials
                                Console.Write("Enter student username: ");
                                string studentUsername = Console.ReadLine(); // store the username
                                Console.Write("Enter student password: ");
                                string studentPassword = Console.ReadLine(); // store the password
                                // create a local variable to hold boolean value which shows if credentials are valid
                                bool isStudentValid = false; // initialized to false
                                // keeps looping until the input is valid
                                while (!isStudentValid)
                                {
                                    // the VerifyStudentLogin() is called to check if the password and username of student exist or valid
                                    isStudentValid = VerifyStudentLogin(students, studentUsername, studentPassword);
                                    // checks the boolean in variable
                                    if (!isStudentValid)
                                    {
                                        // they dont exist/valid, hence user is prompted to re-enter credentials
                                        Console.Write("Enter student username: ");
                                        studentUsername = Console.ReadLine();
                                        Console.Write("Enter student password: ");
                                        studentPassword = Console.ReadLine();
                                    }
                                    else
                                    {
                                        // YAY THEY DO EXIST AND VALID
                                        Console.WriteLine("Press Enter to continue ");
                                        Console.ReadLine();
                                        // User is redirected to the student interface :)
                                        StudentMenu(students, studentUsername, quizzes, categories);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("An error occurred during student login: " + ex.Message);
                            }
                            break;
                        case "0":
                            // User wants to exit the system, message received
                            Console.WriteLine("Exiting the system. Goodbye!");
                            Environment.Exit(0); // this method is called to terminate application
                            break;
                        default:
                            // incase user inputs an invalid option, they are prompted to select an option again
                            Console.WriteLine("Invalid option. Please try again.");
                            Console.Write("Select an option: ");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                    Console.Write("Select an option: ");
                }
            } while (choice != "0"); // as long as the option is not zero we are looping and not leaving the menu

        }
       // method used to display the quiz and allow the student to play the quiz, the specific quiz that is passed as a parameter
        public void PlayQuiz(Quiz quiz)
        {
            // As I have been coding this, I realised that the load question method is not effective because it displays the answer PLEASE :((
            // this method has been coded with the help auto completion from github copilot which is why the layout is very different and contains new functions i have learnt along the way
            //try-catch block for error n exception handling and output appropriate message
            try
            {
                // initialize the score to 0, which is effective to provide feedback for the student 
                int score = 0;
                // initialize the question number for aesthetic reason
                int questionNumber = 1;
                // looping through each question in the question list of the quiz
                foreach (Question question in quiz.QuizQuestions)
                {
                    // display the question number and then increment the variable
                    // get the question text from the question object and display it
                    // get the difficulty level from the question object and display it
                    Console.WriteLine($"Question {questionNumber++}: " + question.QuestionText + " Level: " + question.QuestionDifficultLevel);
                   
                    // loop through the list of strings of options in the question object
                    // in this for loop you have declared and initialized i, created condition and you increment i after every iteration
                    for (int i = 0; i < question.QuestionOptions.Count; i++)
                    {
                        // for each element in the list you output the text and its number
                        Console.WriteLine($"{i + 1}. {question.QuestionOptions[i]}");
                    }
                    // user is prompted to pick an answer from the range of options by number
                    Console.Write("Select your answer (1-{0}): ", question.QuestionOptions.Count);
                    int answerIndex; // variable to hold answer number
                    // this loop is to validate the answer input by the user
                    // the loop changes the input to an integer, makes sure its not 0, and its not a number above the options available
                    while (!int.TryParse(Console.ReadLine(), out answerIndex) || answerIndex < 1 || answerIndex > question.QuestionOptions.Count)
                    {
                        // if any of the conditions are satisfied ( returning true)
                        // the user is prompted to input the option again
                        Console.Write("Invalid input. Please select a valid option (1-{0}): ", question.QuestionOptions.Count);
                    }
                    // then the answer number is converted to its matching string answer
                    // stored in this variable below
                    string selectedAnswer = question.QuestionOptions[answerIndex - 1];
                   // you must check if there answer is correct
                    if (question.CheckAnswer(selectedAnswer))
                    {
                        // its correct then the score is incremented
                        score++;
                        // we let the student know they are right and they get a message
                        Console.WriteLine($"Correct! The correct answer is: {question.QuestionCorrectAnswer}");
                    }
                    else
                    {
                        // the answer is wrong and they get a message giving them the right answer
                        Console.WriteLine($"Wrong! The correct answer is: {question.QuestionCorrectAnswer}");
                    }
                    // to move onto the next question you press enter for pleasing looks
                    Console.WriteLine("Press ENTER for the next question");
                    Console.ReadLine();
                    Console.Clear();
                }
                // the total score is inputted as the student has finished
                Console.WriteLine($"Quiz completed! Your score: {score}/{quiz.QuizQuestions.Count}");
                Console.WriteLine("Thank you for playing the quiz!");
                // they press enter to return to student menu and from there they know what they can do
                Console.WriteLine("Press ENTER to return to the menu");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("NOOOOO an error occurred while playing the quiz :( " + ex.Message);
            }
        }
        // method used to display the menu for the student and their options
        public void StudentMenu(List<Student> students, string username, List<Quiz> quizzes, List<Category> categories)
        {
            // Clearing console
            Console.Clear();
            // welcome message
            Console.WriteLine("WELCOME STUDENT");
            string studentChoice = "";
            do
            {
                // now we keep repeating this message as long as the option is not 0 for exit, the condition is at the bottom
                //try-catch block for error n exception handling and output appropriate message
                try
                {
                    // options are displayed
                    Console.WriteLine("Select an option:");
                    Console.WriteLine("1. Play Quiz");
                    Console.WriteLine("0. Exit");
                    studentChoice = Console.ReadLine(); // chosen option is stored
                    // the choice is then gone through condition statements to see which case it matches
                    switch (studentChoice)
                    {
                        case "1":
                            // the student wants to play the quiz
                            //try-catch block for error n exception handling and output appropriate message
                            try
                            {
                                // clearing console
                                Console.Clear();
                                // display the available categories in the system
                                Console.WriteLine("Available Categories:");
                                LoadCategories(categories);
                                Console.WriteLine();
                                // the student is prompted to pick a category by its ID
                                Console.Write("Enter Category ID: ");
                                int categoryId = int.Parse(Console.ReadLine());
                                // loop validating input by going through the elements in the category list and check if the category exists by using the System.Linq method called Any()
                                while (!categories.Any(c => c.CategoryID == categoryId))
                                {
                                    // if it doesn't exist they are prompted to input again until they get the right one
                                    Console.WriteLine("Invalid Category ID. Please enter a valid Category ID: ");
                                    categoryId = int.Parse(Console.ReadLine());
                                }
                                Console.Clear();
                                // load all the available quizzes for this category
                                Console.WriteLine("Available Quizzes:");
                                Console.WriteLine("Please note that each quiz contains 10 QUESTIONS!");
                                // this method takes quizzes list and category id and output all the right quizzes for the category
                                LoadQuizforCategory(quizzes, categoryId);
                                Console.WriteLine();
                                // prompt student to input the quiz ID
                                Console.Write("Enter Quiz ID to play: ");
                                int quizId = int.Parse(Console.ReadLine());
                                // once again we loop to validate the input, making sure the quiz exists and that exists within the category they are referencing
                                while (!quizzes.Any(q => q.QuizID == quizId && q.QuizCategory.CategoryID == categoryId))
                                {
                                    //not a valid choice, so they input again until its valid option
                                    Console.WriteLine("Invalid Quiz ID. Please enter a valid Quiz ID: ");
                                    quizId = int.Parse(Console.ReadLine()); // every time Parse method is called it converts the string into integer
                                }
                                Console.Clear();
                                // local variable to hold the quiz needed
                                // using the System.Linq method FirstOrDefault() going through all elements looking for quiz with matching ID first and taking that object stored in that element and gets stored in this variable
                                Quiz selectedQuiz = quizzes.FirstOrDefault(q => q.QuizID == quizId);
                                // making sure the quiz is not empty
                                if (selectedQuiz != null)
                                {
                                    // not empty
                                    // we pass the quiz as a parameter, to start the quiz to be played by the student
                                    PlayQuiz(selectedQuiz);
                                    Console.Clear();
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Don't fret! There seems to be an error: " + ex.Message);
                            }

                            break;
                        case "0":
                            // THEY WANT TO LEAVE THE SYSTEM
                            Console.WriteLine("Goodbye!");
                            // looping through each student in the students list 
                            foreach (Student student in students)
                            {
                                // if we find the student that is currently logged in
                                if (student.UserName == username)
                                {
                                    // WE LOG THEM OUT and say byee
                                    student.Logout();
                                }
                            }
                            // this method is called to exit the application
                            Environment.Exit(0);
                            break;
                        default:
                            // for any invalid option the student is prompted to try again by pressing enter and starting the loop again
                            Console.WriteLine("Invalid option. Please try again. (PRESS ENTER TO TRY AGAIN)");
                            Console.ReadLine();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                    Console.Write("Select an option: ");
                }

            } while (studentChoice != "0");
        }
        // method used to display the menu for the admin and their functionalities
        public void AdminMenu(List<Admin> admins, string username, List<Quiz> quizzes, List<Category> categories, List<Student> students)
        {   // oh admins do a lot of work 
            // clean the console
            Console.Clear();
            // welcome message
            Console.WriteLine("WELCOME ADMIN");
            string adminChoice = "";
            do
            { // we loop this menu until the Admin chooses to exit the system
                //try-catch block for error n exception handling and output appropriate message
                try
                {
                    // Main Admin menu content
                    // prompt user to input an option
                    Console.WriteLine("What would you like to edit?");
                    Console.WriteLine("1. Users");
                    Console.WriteLine("2. Categories");
                    Console.WriteLine("3. Quiz Questions");
                    Console.WriteLine("0. Exit");
                    adminChoice = Console.ReadLine(); // store the option
                    // we are checking this option against all condition cases available to see which one it matches
                    switch (adminChoice)
                    {
                        case "1":
                            // Manage Users
                            // Clean console
                            Console.Clear();
                            string userChoice = "";
                            do
                            {
                                // the admin will continue to be in this management user section until they press 0 to exit and go back to main menu
                                //try-catch block for error n exception handling and output appropriate message
                                try
                                {
                                    // clean console
                                    Console.Clear();
                                    //the options of management user menu
                                    // prompt the admin to pick
                                    Console.WriteLine("Select an option: ");
                                    Console.WriteLine("1. Remove Admin");
                                    Console.WriteLine("2. Remove Student");
                                    Console.WriteLine("3. Add Admin");
                                    Console.WriteLine("4. Add Student");
                                    Console.WriteLine("5. Edit Admin");
                                    Console.WriteLine("6. Edit Student");
                                    Console.WriteLine("7. Manage Student Status");
                                    Console.WriteLine("0. Back to Admin Menu");
                                    userChoice = Console.ReadLine(); // admin Userchoice is stored
                                    // user choice is checked against all the conditions and see which one it matches
                                    switch (userChoice) 
                                    {

                                        case "1":
                                            // they want to remove an admin
                                            // clean the console
                                            Console.Clear();
                                            // load all the admins in the system
                                            LoadAdmins(admins);
                                            Console.WriteLine();
                                            // a note for the admin
                                            Console.WriteLine("Press 0 to GO BACK");
                                            // admin prompted to input the admin ID they wanna remove
                                            Console.Write("Enter Admin ID to remove: ");
                                            int adminId = int.Parse(Console.ReadLine());
                                            if (adminId != 0) // if the ID aint zero then they don't want to leave
                                            {
                                                // you check if that admin ID exists
                                                while (!admins.Any(a => a.UserId == adminId))
                                                {
                                                    // the admin doesn't exist then they try again
                                                    Console.WriteLine("Invalid Admin ID. Please enter a valid Admin ID: ");
                                                    adminId = int.Parse(Console.ReadLine());
                                                }
                                            }
                                            else { break; } // they leave
                                            // the list of admins is removed and the ID of admin needed to be removed is passed
                                            RemoveAdmin(admins, adminId);
                                            Console.WriteLine();
                                            // the admin is removed
                                            Console.WriteLine("Admin removed! New List :D");
                                            // new list is shown
                                            LoadAdmins(admins);
                                            // press enter to continue
                                            Console.WriteLine("Press ENTER to continue...");
                                            Console.ReadLine();
                                            break;
                                        case "2":
                                            // clean console
                                            Console.Clear();
                                            // load students available 
                                            LoadStudents(students);
                                            Console.WriteLine();
                                            // note to the admin
                                            Console.WriteLine("Press 0 to GO BACK");
                                            // prompt the admin to pick which student to remove
                                            Console.Write("Enter Student ID to remove: ");
                                            int studentId = int.Parse(Console.ReadLine());
                                            // if it aint 0 then they dont want to leave
                                            if (studentId != 0)
                                            {
                                                // you check if the student ID exists
                                                while (!students.Any(s => s.UserId == studentId))
                                                {
                                                    //does not exist and prompt the admin to input a valid ID
                                                    // repeats until they are valid
                                                    Console.WriteLine("Invalid Student ID. Please enter a valid Student ID: ");
                                                    studentId = int.Parse(Console.ReadLine());
                                                }
                                            }
                                            else { break; } // they want to leave
                                            // the list of students is removed and the ID of student needed to be removed is passed
                                            RemoveStudent(students, studentId);
                                            Console.WriteLine();
                                            // student is removed
                                            Console.WriteLine("Student removed! New List :D");
                                            // new list of student is shown
                                            LoadStudents(students);
                                            Console.WriteLine("Press ENTER to continue...");
                                            Console.ReadLine();
                                            break;
                                        case "3":
                                            // clean console
                                            Console.Clear();
                                            string confirmChoice = "";
                                            // prompt the admin to input the new admin info
                                            Console.WriteLine("Please provide the information for the new admin:)");
                                            Console.Write("Admin's Username:");
                                            string aUsername = Console.ReadLine();
                                            Console.Write("Admin's Password:");
                                            string aPassword = Console.ReadLine();
                                            Console.Write("Admin's Email:");
                                            string aEmail = Console.ReadLine();
                                            // check if the admin wants confirm the information
                                            Console.WriteLine("Would you like to CONFIRM? (yes/no)");
                                            confirmChoice = Console.ReadLine();
                                            // if its yes that means you can add the admin
                                            if (confirmChoice.ToLower() == "yes")
                                            {
                                                //clean console
                                                Console.Clear();
                                                // pass the new info for the new admin to be added
                                                admins.Add(new Admin(aUsername, aPassword, aEmail));
                                                Console.WriteLine();
                                                Console.WriteLine("Admin added! New List :D");
                                                LoadAdmins(admins);
                                                Console.WriteLine("Press ENTER to continue...");
                                                Console.ReadLine();

                                            }
                                            else { break; } // leave this section and back to management user menu

                                            break;
                                        case "4":
                                            // clean console
                                            Console.Clear();
                                            //prompt the admin to input the new student info
                                            Console.WriteLine("Please provide the information for the new student:)");
                                            Console.Write("Student's Username:");
                                            string sUsername = Console.ReadLine();
                                            Console.Write("Student's Password:");
                                            string sPassword = Console.ReadLine();
                                            Console.Write("Student's Email:");
                                            string sEmail = Console.ReadLine();
                                            string confirmChoice1 = "";
                                            //// check if the student wants confirm the information
                                            Console.WriteLine("Would you like to CONFIRM? (yes/no)");
                                            confirmChoice1 = Console.ReadLine();
                                            // if its yes that means you can add the student
                                            if (confirmChoice1.ToLower() == "yes")
                                            {
                                                // clean console
                                                Console.Clear();
                                                
                                                // pass the new info for the new student to be added
                                                students.Add(new Student(sUsername, sPassword, sEmail));
                                                Console.WriteLine();
                                                Console.WriteLine("Student added! New List");
                                                LoadStudents(students);
                                                Console.WriteLine("Press ENTER to continue...");
                                                Console.ReadLine();
                                            }
                                            else { break; } // no save new student

                                            break;
                                        case "5":
                                            // clean console
                                            Console.Clear();
                                            // load admins list
                                            LoadAdmins(admins);
                                            Console.WriteLine();
                                            // note to the admin
                                            Console.WriteLine("Press 0 to GO BACK");
                                            // prompt the admin to input the admin to be edited
                                            Console.Write("Enter Admin ID to edit: ");
                                            int editAdminId = int.Parse(Console.ReadLine());
                                            // if not 0 then they want to leave 
                                            if (editAdminId != 0)
                                            {
                                                // check if the admin ID inputted is valid
                                                while (!admins.Any(a => a.UserId == editAdminId))
                                                {
                                                    // not valid that means it repeats until they put the righ ID
                                                    Console.WriteLine("Invalid Admin ID. Please enter a valid Admin ID: ");
                                                    editAdminId = int.Parse(Console.ReadLine());
                                                }
                                            }
                                            else { break; } // they want to leave 

                                            // clean console
                                            Console.Clear();
                                            // looping through each admin in admins list 
                                            foreach (Admin a in admins)
                                            {
                                                // if the admin id in the list matches the admin to be edited then 
                                                if (a.UserId == editAdminId)
                                                {
                                                    // we load that admins details
                                                    a.LoadUser();
                                                }
                                            }
                                            // new info inputted and press enter if they wanna keep it same
                                            Console.WriteLine("Enter the new details!");
                                            Console.WriteLine("Note: to keep the same info, just press ENTER.");
                                            Console.Write("New Admin Username:");
                                            string newAdminName = Console.ReadLine();
                                            Console.Write("New Admin Password:");
                                            string newAdminPassword = Console.ReadLine();
                                            Console.Write("New Admin Email:");
                                            string newAdminEmail = Console.ReadLine();
                                            // looping through each admin in admins list 
                                            foreach (Admin a in admins)
                                            {
                                                // if the admin id in the list matches the admin to be edited then 
                                                if (a.UserId == editAdminId)
                                                {
                                                    // update that specific admin with the new info
                                                    a.UpdateUser(newAdminName, newAdminPassword, newAdminEmail);
                                                }
                                            }
                                            Console.WriteLine();
                                            // feedback
                                            Console.WriteLine("Admin updated! New List :D");

                                            // load the new list of admin
                                            LoadAdmins(admins);
                                            Console.WriteLine("Press ENTER to continue...");
                                            Console.ReadLine();
                                            break;
                                        case "6":
                                            // clean console
                                            Console.Clear();
                                            // load students list
                                            LoadStudents(students);
                                            Console.WriteLine();
                                            // note the admins
                                            Console.WriteLine("Press 0 to GO BACK");
                                            // prompt the admin to put student id to edit
                                            Console.Write("Enter Student ID to edit: ");
                                            //exception can be thrown with parse thing
                                            int editStudentId = int.Parse(Console.ReadLine());
                                            // if the student Id is not zero that means they dont want to leave
                                            if (editStudentId != 0)
                                            {
                                                // check if the input is valid and exists as a student
                                                while (!students.Any(s => s.UserId == editStudentId))
                                                {
                                                    // it doesnt exist then keep looping until they put a valid option
                                                    Console.WriteLine("Invalid Student ID. Please enter a valid Student ID: ");
                                                    editStudentId = int.Parse(Console.ReadLine());
                                                }
                                            }
                                            else { break; } // they want to leave
                                            //clean console
                                            Console.Clear();
                                            // loop through each student in the students lists 
                                            foreach (Student s in students)
                                            {
                                                // if student has matching ID given by the admin
                                                if (s.UserId == editStudentId)
                                                {
                                                    // load the student details for reference
                                                    s.LoadUser();
                                                }
                                            }
                                            // prompt the admin to input new details for the student but to keep same press enter
                                            Console.WriteLine("Enter the new details!");
                                            Console.WriteLine("Note: to keep the same info, just press ENTER.");
                                            Console.Write("New Student Username:");
                                            string newStudentName = Console.ReadLine();
                                            Console.Write("New Student Password:");
                                            string newStudentPassword = Console.ReadLine();
                                            Console.Write("New Student Email:");
                                            string newStudentEmail = Console.ReadLine();
                                            // loop through each student in student list
                                            foreach (Student s in students)
                                            {
                                                // if the student has matching ID inputted 
                                                if (s.UserId == editStudentId)
                                                {
                                                    // UPDATE THE STUDENT WITH THE NEW INFO
                                                    s.UpdateUser(newStudentName, newStudentPassword, newStudentEmail);
                                                }
                                            }
                                            Console.WriteLine();
                                            // positive feedback
                                            Console.WriteLine("Student updated! New List :D");
                                            // load the new student list
                                            LoadStudents(students);
                                            Console.WriteLine("Press ENTER to continue...");
                                            Console.ReadLine();
                                            break;
                                        case "7":
                                            // clean console
                                            Console.Clear();
                                            // load students list
                                            LoadStudents(students);
                                            Console.WriteLine();
                                            //note to the admin
                                            Console.WriteLine("Press 0 to GO BACK");
                                            // prompt admin to input the student to manage status
                                            Console.Write("Enter Student ID to manage status: ");
                                            int statusStudentId = int.Parse(Console.ReadLine());
                                            // if the ID isnt 0 that means they dont want to leave
                                            if (statusStudentId != 0)
                                            {
                                                // validate the ID inputted by looking through the lists
                                                while (!students.Any(s => s.UserId == statusStudentId))
                                                {
                                                    // prompt the admin to input student ID again until they are right
                                                    Console.WriteLine("Invalid Student ID. Please enter a valid Student ID: ");
                                                    statusStudentId = int.Parse(Console.ReadLine());
                                                }
                                            }
                                            else { break; } // they want to leave
                                            //prompt user to input which status they want
                                            Console.WriteLine("Which status? active/inactive");
                                            string uStatus = Console.ReadLine();
                                            // loop through each student in the students list
                                            foreach (Student s in students)
                                            {
                                                // if student has matching student ID inputted
                                                if (s.UserId == statusStudentId)
                                                {
                                                    // call manage status for this student
                                                    s.ManageStatus(uStatus);
                                                }
                                            }
                                            // positive feedback
                                            Console.WriteLine("status updated!");
                                            Console.WriteLine("Press ENTER to continue...");
                                            Console.ReadLine();
                                            break;
                                        case "0":
                                            // Back to Admin Menu
                                            break;
                                        default:
                                            // they go back to user management menu and try again
                                            Console.WriteLine("Invalid option. Please try again.(PRESS ENTER TO TRY AGAIN)");
                                            Console.ReadLine();
                                            break;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Don't worry! An error has occurred: " + ex.Message);
                                    Console.WriteLine("Press ENTER to return to the User Management Menu :D");
                                    Console.ReadLine();
                                }
                            } while (userChoice != "0"); // loops until the admin exits user management menu
                            break;

                        case "2":
                            // Manage Categories
                            string categoryChoice = "";
                            do
                            {
                                //try-catch block for error n exception handling and output appropriate message
                                try
                                {
                                    // clean console
                                    Console.Clear();
                                    // category management menu options
                                    Console.WriteLine("Select an option: ");
                                    Console.WriteLine("1. Remove Category");
                                    Console.WriteLine("2. Add Category");
                                    Console.WriteLine("3. Edit Category");
                                    Console.WriteLine("0. Back to Admin Menu");
                                    // admin option is captured
                                    categoryChoice = Console.ReadLine();
                                    // check the choices against conditions
                                    switch (categoryChoice)
                                    {
                                        case "1":
                                            // Remove category
                                            //Clean Console
                                            Console.Clear();
                                            // load categories
                                            LoadCategories(categories);
                                            Console.WriteLine();
                                            // note to the admin
                                            Console.WriteLine("Press 0 to GO BACK");
                                            // prompt the admin to pick category ID
                                            Console.Write("Enter Category ID to remove: ");
                                            int categoryId = int.Parse(Console.ReadLine());
                                            // check if they want to leave
                                            if (categoryId != 0)
                                            {
                                                // they díd not want to leave 
                                                // validate input, category must exist
                                                while (!categories.Any(c => c.CategoryID == categoryId))
                                                {
                                                    // its not valid so they keep repeating input until its valid
                                                    Console.WriteLine("Invalid Category ID. Please enter a valid Category ID: ");
                                                    categoryId = int.Parse(Console.ReadLine());
                                                }
                                            }
                                            else { break; } // THEY LEAVING
                                            // remove the category wanted
                                            RemoveCategory(categories, categoryId, quizzes);
                                            Console.WriteLine();
                                            // positive feedback
                                            Console.WriteLine("Category removed! New List :D");
                                            // load the new list
                                            LoadCategories(categories);

                                            Console.WriteLine("Press ENTER to continue...");
                                            Console.ReadLine();
                                            break;
                                        case "2":
                                            // clean console
                                            Console.Clear();
                                            // provide new info for the new category
                                            Console.WriteLine("Please provide the necessary information for the new category");
                                            Console.Write("Category Name:");
                                            string cName = Console.ReadLine();
                                            Console.Write("Category Description:");
                                            string cDescription = Console.ReadLine();
                                            // ask them if they want confirm and added category
                                            Console.WriteLine("Would you like to CONFIRM? (yes/no)");
                                            string confirmChoiceC = Console.ReadLine();
                                            // check if the choice was yes
                                            if (confirmChoiceC.ToLower() == "yes")
                                            {
                                                // clean console
                                                Console.Clear();
                                                // append the list of categories with new category
                                                categories.Add(new Category(cName, cDescription));
                                                Console.WriteLine();
                                                // positive feedback
                                                Console.WriteLine("Category added! New List :D");
                                                // load the new categories list
                                                LoadCategories(categories);
                                                Console.WriteLine("Press ENTER to continue...");
                                                Console.ReadLine();
                                            }
                                            else { break; } // they want to leave back to the category management menu
                                            break;
                                        case "3":
                                            // clean console
                                            Console.Clear();
                                            // load the categories list
                                            LoadCategories(categories);
                                            Console.WriteLine();
                                            // note to admin
                                            Console.WriteLine("Press 0 to GO BACK");
                                            // prompt admin to input category id to edit
                                            Console.Write("Enter Category ID to edit: ");
                                            int editCategoryId = int.Parse(Console.ReadLine());
                                            // check if they didnt put 0 to leave
                                            if (editCategoryId != 0)
                                            {
                                                // they dont want to leave
                                                // validate the category ID that inputted
                                                while (!categories.Any(c => c.CategoryID == editCategoryId))
                                                {
                                                    // not a valid ID inputted so repeat until they input a valid one
                                                    Console.WriteLine("Invalid Category ID. Please enter a valid Category ID: ");
                                                    editCategoryId = int.Parse(Console.ReadLine());
                                                }
                                            }
                                            else { break; }  // they want to leave to the Category management menu
                                            Console.Clear();
                                            // loop through each category in category list
                                            foreach (Category cat in categories)
                                            {
                                                // check if its the category wanted
                                                if (cat.CategoryID == editCategoryId)
                                                {
                                                    // load this specific category info
                                                    cat.LoadCategory();
                                                }
                                            }
                                            Console.WriteLine();
                                            // prompt admin to add new info but keep them same with enter/ whitespace
                                            Console.WriteLine("Enter the new details!");
                                            Console.WriteLine("Note:to keep the same info, just press ENTER.");
                                            Console.Write("New Category Name:");
                                            string newCategoryName = Console.ReadLine();
                                            Console.Write("New Category Description:");
                                            string newCategoryDescription = Console.ReadLine();
                                            //loop through each category in categories list
                                            foreach (Category cat in categories)
                                            {
                                                // category we want we are looking for
                                                if (cat.CategoryID == editCategoryId)
                                                {
                                                    // for that specific category its updated with new info
                                                    cat.UpdateCategory(newCategoryName, newCategoryDescription);
                                                }
                                            }

                                            Console.WriteLine();
                                            // positive feedback
                                            Console.WriteLine("Category updated! New List :D");
                                            // load the new list of categories
                                            LoadCategories(categories);
                                            Console.WriteLine("Press ENTER to continue...");
                                            Console.ReadLine();
                                            break;
                                        case "0":
                                            // Back to Admin Menu
                                            break;
                                        default:
                                            // invalid option so they are brought back to the category manaegement menu, to try again
                                            Console.WriteLine("Invalid option. Please try again. (PRESS ENTER TO TRY AGAIN)");
                                            Console.ReadLine();
                                            break;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Don't worry! An error has occurred: " + ex.Message);
                                    Console.WriteLine("Press ENTER to return to the Category Management Menu :D");
                                    Console.ReadLine();
                                }
                            } while (categoryChoice != "0"); // keep going until they go back to admin menu 
                            break;
                        case "3":
                            // Manage Quiz Questions
                            string questionChoice = "";
                            do
                            {
                                // this is looping the quiz question management menu until the admin chooses to go back to the admin menu
                                //try-catch block for error n exception handling and output appropriate message
                                try
                                {
                                    // clean console
                                    Console.Clear();
                                    // display all the options in question management menu
                                    Console.WriteLine("Select an option: ");
                                    Console.WriteLine("1. Remove a quiz question");
                                    Console.WriteLine("2. Add a quiz question");
                                    Console.WriteLine("3. Edit a quiz question");
                                    Console.WriteLine("0. Back to Admin Menu");
                                    // prompt the admin to pick an option and store the option
                                    questionChoice = Console.ReadLine();
                                    switch (questionChoice)
                                    {
                                        case "1":
                                            // clean the console
                                            Console.Clear();
                                            // load all the quizzes in the system
                                            LoadQuizzes(quizzes);
                                            // note to the admin
                                            Console.WriteLine("Press 0 to GO BACK");
                                            // prompt the admin to pick a quiz to manage 
                                            Console.WriteLine("Which quiz would you like to remove a question from? (Enter QuizId)");
                                            int quizId = int.Parse(Console.ReadLine());
                                            // check if the quizID is not 0 meaning the admin wants to stay
                                            if (quizId != 0)
                                            {
                                                // validate the admin input for the quizID
                                                while (!quizzes.Any(q => q.QuizID == quizId))
                                                {
                                                    // its not valid input, so prompt the admin to put another value 
                                                    Console.WriteLine("Invalid Quiz ID. Please enter a valid Quiz ID: ");
                                                    quizId = int.Parse(Console.ReadLine());
                                                }
                                            }
                                            else { break; } // they want to leave and go back to the quiz question management menu
                                            // clean console
                                            Console.Clear();
                                            // display all the quiz questions
                                            Console.WriteLine("Here are the questions in the quiz:");
                                            // looping through each quiz in quizzes
                                            foreach (Quiz q in quizzes)
                                            {
                                                // if the quiz matches the quiz ID
                                                if (q.QuizID == quizId)
                                                {
                                                    //load the questions within this specific quiz
                                                    q.LoadQuizQs();
                                                }
                                            }

                                            Console.WriteLine();
                                            // prompt the admin to pick question within the quiz to remove
                                            Console.Write("Enter Question ID to remove: ");
                                            int questionId = int.Parse(Console.ReadLine()); // ID inputted stored
                                            // looping through each quiz in quizzes
                                            foreach (Quiz q in quizzes)
                                            {
                                                // we are validating the  question ID inputted
                                                // using the loop if the quiz question ID doesn't exist in the list of quiz questions of this quiz 
                                                while (!q.QuizQuestions.Any(qs => qs.QuestionID == questionId) && q.QuizID == quizId)
                                                {
                                                    // invalid ID inputted, admin is prompted to input again the Question ID
                                                    Console.WriteLine("Invalid Question ID. Please enter a valid Question ID: ");
                                                    questionId = int.Parse(Console.ReadLine());
                                                }
                                                if (q.QuizID == quizId)
                                                {
                                                    // the question exists and the quiz is found in the list of quizzes
                                                    // then remove the question from the list of question in this quiz using the RemoveQuestion() method in the Quiz class
                                                    q.RemoveQuestion(questionId);
                                                    Console.WriteLine();
                                                    // positive feedback
                                                    Console.WriteLine("Question removed! New List :D");
                                                    // load the new list of questions in the quiz with new removal
                                                    q.LoadQuizQs();
                                                }
                                            }
                                            // to continue and move on prompt the admin to press enter 
                                            Console.WriteLine("Press Enter to continue...");
                                            Console.ReadLine();
                                            break;
                                        case "2":
                                            // Add quiz question
                                            Console.Clear();
                                            // load quizzes of the system
                                            LoadQuizzes(quizzes);
                                            Console.WriteLine();
                                            // note to the admin
                                            Console.WriteLine("Press 0 to GO BACK");
                                            // prompt the admin to pick which quiz they would like to manaage
                                            Console.WriteLine("Which quiz would you like to add a question to? (Enter QuizId)");
                                            int quizId2 = int.Parse(Console.ReadLine()); // store input
                                            // if the input is not 0 then they do not want to leave this section
                                            if (quizId2 != 0)
                                            {
                                                // validate the ID inputted to see if it belongs to a valid quiz
                                                while (!quizzes.Any(q => q.QuizID == quizId2))
                                                {
                                                    // not a valid ID inputted, so the admin must re-enter another ID 
                                                    // it keeps going until they pick a valid ID
                                                    Console.WriteLine("Invalid Quiz ID. Please enter a valid Quiz ID: ");
                                                    quizId2 = int.Parse(Console.ReadLine());
                                                }
                                            }
                                            else { break; } // they leave this section and return to the quiz question management menu
                                            // clean console
                                            Console.Clear();
                                            // prompt the admin to input the info for this new question
                                            Console.WriteLine("Please provide details for new question to the quiz.");
                                            Console.Write("Enter Question (text): ");
                                            string qText = Console.ReadLine();
                                            Console.Write("Enter Question Options (separated by commas): ");
                                            string optionsInput = Console.ReadLine();
                                            // because the constructor requires a list of strings to be passed as options
                                            // we initialize a new list of strings, and split the given string into separate elements by the comma
                                            List<string> qOptions = optionsInput.Split(',').Select(o => o.Trim()).ToList();
                                            Console.Write("Enter Correct Answer: ");
                                            string correctAnswer = Console.ReadLine();
                                            Console.Write("Enter Difficulty Level (Easy/Medium/Hard): ");
                                            string difficultyLevel = Console.ReadLine();
                                            // looping through each quiz in list of quizzes
                                            foreach (Quiz q in quizzes)
                                            {
                                                // we are looking for the quiz to input this question into
                                                if (q.QuizID == quizId2)
                                                {
                                                    // it has the correct ID, matches
                                                    // we call AddQuestion() method from Quiz Class and pass the info for the parameters
                                                    q.AddQuestion(new Question(qText, qOptions, correctAnswer, difficultyLevel));
                                                }
                                            }
                                            Console.WriteLine();
                                            //positive feedback
                                            Console.WriteLine("Question added! New List :D");
                                            // looping through each quiz in list of quizzes
                                            foreach (Quiz q in quizzes)
                                            {
                                                // looking for the quiz we have just modified
                                                if (q.QuizID == quizId2)
                                                {
                                                    //quiz found, so we output the questions inside the quiz
                                                    q.LoadQuizQs();
                                                }
                                            }
                                            // for the admin to move one they press enter and get redirected to the quiz management menu
                                            Console.WriteLine("Press Enter to continue...");
                                            Console.ReadLine();
                                            break;
                                        case "3":
                                            // edit quiz question
                                            // clean console
                                            Console.Clear();
                                            // load all the quizzes in the system
                                            LoadQuizzes(quizzes);
                                            Console.WriteLine();
                                            // note to the admin
                                            Console.WriteLine("Press 0 to GO BACK");
                                            // prompt the admin to input which quiz they would like to modify
                                            Console.WriteLine("Which quiz would you like to edit a question? (Enter QuizId)");
                                            int quizId3 = int.Parse(Console.ReadLine()); // store the option input
                                            // check if the input is not 0, to make sure the admin wants to continue
                                            if (quizId3 != 0) 
                                            {
                                                // they want to stay
                                                // validate the quiz ID input, see if it exists or belongs to a quiz
                                                while (!quizzes.Any(q => q.QuizID == quizId3))
                                                {
                                                    // the quiz ID does not belong to any quiz
                                                    // prompt the admin to input Quiz ID again until they put a valid option
                                                    Console.WriteLine("Invalid Quiz ID. Please enter a valid Quiz ID: ");
                                                    quizId3 = int.Parse(Console.ReadLine());
                                                }
                                            }
                                            else { break; } // they are leaving back to the quiz question management menu
                                            //clean console
                                            Console.Clear();
                                            // looping through each quiz in list of quizzes
                                            foreach (Quiz q in quizzes)
                                            {
                                                // looking for the quiz we want to modify
                                                if (q.QuizID == quizId3)
                                                {
                                                    //quiz found, so we output the questions inside the quiz
                                                    q.LoadQuizQs();
                                                }
                                            }
                                            //quizzes[quizId3 - 1].LoadQuizQs();
                                            Console.WriteLine();
                                            // prompt the admin to input the question ID they want to edit
                                            Console.Write("Enter Question ID to edit: ");
                                            int editQuestionId = int.Parse(Console.ReadLine());
                                            // loop through each quiz in quizzes
                                            foreach (Quiz q in quizzes)
                                            {
                                                // looking for the question ID if it belongs to any quiz
                                                while (!q.QuizQuestions.Any(qs => qs.QuestionID == editQuestionId) && q.QuizID == quizId3)
                                                {
                                                    // invalid quiz ID option
                                                    // prompt the admin to input a valid Question ID, they repeat until they get the right one
                                                    Console.WriteLine("Invalid Question ID. Please enter a valid Question ID: ");
                                                    editQuestionId = int.Parse(Console.ReadLine());
                                                }
                                            }
                                            // clean console
                                            Console.Clear();
                                            // in order to avoid any error this looping is a bit extra
                                            // loop through each quiz in the list of quizzes
                                            foreach (Quiz q in quizzes)
                                            {
                                                // looking for the quiz needed to modify
                                                if(q.QuizID == quizId3)
                                                {
                                                    // quiz needed has been found
                                                    // now we loop through each question in the quiz questions
                                                    foreach(Question ques in q.QuizQuestions)
                                                    {
                                                        // looking for the question we would like to edit
                                                        if (ques.QuestionID == editQuestionId)
                                                        {
                                                            // question found and the question details is displayed 
                                                            ques.LoadQuestion();
                                                        }
                                                    }
                                                }
                                            }
                                            // prompt the admin to input the new details for this questions, and to keep the same info they just keep it empty and enter
                                            Console.WriteLine("Enter the new details!");
                                            Console.WriteLine("To keep the same info, just press ENTER.");
                                            Console.Write("New Question (text): ");
                                            string newQuestionText = Console.ReadLine();
                                            Console.Write("New Question Options (separated by commas): ");
                                            string newOptionsInput = Console.ReadLine();
                                            // because the constructor requires a list of strings to be passed as options
                                            // we initialize a new list of strings, and split the given string into separate elements by the comma
                                            List<string> newqOptions = newOptionsInput.Split(',').Select(o => o.Trim()).ToList();
                                            Console.Write("New Correct Answer: ");
                                            string newCorrectAnswer = Console.ReadLine();
                                            Console.Write("New Difficulty Level (Easy/Medium/Hard): ");
                                            string newDifficultyLevel = Console.ReadLine();
                                            // looping through each quiz in the list of quizzes
                                            foreach (Quiz q in quizzes)
                                            {
                                                // looking for the quiz we are modifying
                                                if (q.QuizID == quizId3)
                                                {
                                                    // we found the quiz
                                                    // we call the appropriate method, passs the new info as parameters and update the question in this quiz
                                                    q.updateQuizQuestions(editQuestionId, newQuestionText, newqOptions, newCorrectAnswer, newDifficultyLevel);
                                                }
                                            }
                                            Console.WriteLine();
                                            // positive feedback
                                            Console.WriteLine("Question updated! New List :D");
                                            // load the new list of questions of this particular quiz 
                                            foreach (Quiz q in quizzes)
                                            {
                                                if (q.QuizID == quizId3)
                                                {
                                                    q.LoadQuizQs();
                                                }
                                            }
                                            // for the admin to move on they press enter
                                            Console.WriteLine("Press Enter to continue...");
                                            Console.ReadLine();
                                            break;
                                        case "0":
                                            // Back to Admin Menu
                                            break;
                                        default:
                                            // invalid option, so they admin is prompted to return the quiz question management menu to try again
                                            Console.WriteLine("Invalid option. Please try again. (PRESS ENTER TO TRY AGAIN)");
                                            Console.ReadLine();
                                            break;
                                    }
                                    // save all the quiz questions to contain the changes
                                    SaveQuiztoCSV(quizzes, "quizzes.csv");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Don't worry! An error has occurred: " + ex.Message);
                                    Console.WriteLine("Press ENTER to return to the Quiz Question Management Menu :D");
                                    Console.ReadLine();
                                }
                            } while (questionChoice != "0"); // keeps going until the admin picks 0 to return to admin Menu
                            break;
                        case "0":
                            // THEY WANT TO LEAVE 
                            Console.WriteLine("Goodbye!");
                            // looping through each admin in admins
                            foreach (Admin admin1 in admins)
                            {
                                // check if admin is there that is currently logged in
                                if (admin1.UserName == username)
                                {
                                    // admin logs out
                                    admin1.Logout();
                                }
                            }
                            Environment.Exit(0);
                            break;
                        default:
                            // invalid input so they are brought back to the main menu for retry
                            Console.WriteLine("Invalid option. Please try again. (PRESS ENTER TO TRY AGAIN)");
                            Console.ReadLine();
                            break;
                    }
                    // clean console
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Don't fret! An error has occurred: " + ex.Message);
                    Console.WriteLine("Press ENTER to return to the Admin Menu...");
                    Console.ReadLine();
                }
            } while (adminChoice != "0"); // loops until the admins exit
        }

    }
}