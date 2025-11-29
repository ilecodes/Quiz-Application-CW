using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjectTester
{
    public class QuizSystem
    {
        public List<Admin> admins = new List<Admin>();
        public List<Student> students = new List<Student>();
        public List<Category> categories = new List<Category>();
        public List<Quiz> quizzes = new List<Quiz>();
        static void Main(string[] args)
        {
            QuizSystem quizSystem = new QuizSystem();

            quizSystem.CreateAdmins(quizSystem.admins);
            quizSystem.CreateStudents(quizSystem.students);
            quizSystem.CreateCategories(quizSystem.categories);
            quizSystem.CreateQuizzes(quizSystem.quizzes);
            quizSystem.SaveQuiztoCSV(quizSystem.quizzes, "quizzes.csv");

            Console.Clear();
            quizSystem.LoadAdmins(quizSystem.admins);
            quizSystem.LoadStudents(quizSystem.students);
            Console.WriteLine("Please scroll upwards and find your login credentials :D");
            quizSystem.MainMenu(quizSystem.admins, quizSystem.students, quizSystem.categories, quizSystem.quizzes);

            Console.ReadLine();
            quizSystem.SaveQuiztoCSV(quizSystem.quizzes, "quizzes.csv");

        }
        public QuizSystem() { }
        public void CreateAdmins(List<Admin> admins)
        {
            admins.Add(new Admin("Fatima", "mEs#1245", "f.benmesmia@ulster.ac.uk"));
            admins.Add(new Admin("James", "coN#2345", "jp.connolly@ulster.ac.uk"));
            admins.Add(new Admin("Sophie", "smIt#3456", "s.mardine@ulster.ac.uk"));
            admins.Add(new Admin("Liam", "owEn#4567", "l.owens@ulster.ac.uk"));
        }
        public void CreateStudents(List<Student> students)
        {
            students.Add(new Student("Leanne", "meow2006", "Alhussein-L@ulster.ac.uk"));
            students.Add(new Student("Ilhem", "iLeR2005", "Cherif-I@ulster.ac.uk"));
            students.Add(new Student("Izzah", "iZzaH2005", "Imtiaz-I@ulster.ac.uk"));
            students.Add(new Student("Rend", "pInk2006", "Alshekhlee-R@ulster.ac.uk"));
            students.Add(new Student("Guest", "CuQC@2025", "City-G@ulster.ac.uk"));


        }

        public void LoadAdmins(List<Admin> admins)
        {
            Console.WriteLine("ADMINS");
            foreach (Admin admin in admins)
            {
                admin.LoadUser();
                Console.WriteLine();
            }

        }
        public void CreateCategories(List<Category> categories)
        {
            categories.Add(new Category("Programming Concepts", "Concepts of object-oriented programming and coding principles"));
            categories.Add(new Category("Data Structures", "Arrays, lists, stacks, queues, trees, and their applications"));
            categories.Add(new Category("Software Design", "Design patterns, architecture principles, and system modelling"));
            categories.Add(new Category("Web Development", "HTML, CSS, JavaScript, and client-server interactions"));
            categories.Add(new Category("Database Systems", "SQL queries, relational models, normalization, and transactions"));
            categories.Add(new Category("Cybersecurity Basics", "Encryption, authentication, and common security threats"));
            categories.Add(new Category("Computer Networks", "Protocols, IP addressing, routing, and network layers"));
        }
        public void CreateQuizzes(List<Quiz> quizzes)
        {
            List<Question> qQuestions1 = new List<Question>();
            qQuestions1.Add(new Question("What does OOP stand for?", new List<string> { "Object-Oriented Programming", "Operational Output Processing", "OpenOrder Protocol", "OverloadedOperator Procedure" }, "Object-Oriented Programming", "Easy"));
            qQuestions1.Add(new Question("Which of the following is NOT a core principle of OOP? ", new List<string> { "Encapsulation", "Polymorphism", "Abstraction", "Compilation" }, "Compilation", "Easy"));
            qQuestions1.Add(new Question("What is encapsulation in object-oriented programming?", new List<string> { "Binding data and methods", "Inheritance", "Overloading", "Creating objects" }, "Binding data and methods", "Medium"));
            qQuestions1.Add(new Question("Which keyword is used in C# to inherit a class?", new List<string> { "extends", "inherits", ":", "base" }, ":", "Medium"));
            qQuestions1.Add(new Question("What is the purpose of a constructor in a class?", new List<string> { "To destroy objects", "To initialize objects", "To inherit methods", "To override properties" }, "To initialize objects", "Easy"));
            qQuestions1.Add(new Question("Which concept allows multiple methods with the same name but different parameters?", new List<string> { "Inheritance", "Polymorphism", "Overloading", "Encapsulation" }, "Overloading", "Medium"));
            qQuestions1.Add(new Question("What is the base class for all classes in C#?", new List<string> { "System.Object", "BaseClass", "RootClass", "MainClass" }, "System.Object", "Hard"));
            qQuestions1.Add(new Question("What is the difference between a class and an object?", new List<string> { "Class is an instance, object is a blueprint", "Class is a blueprint,object is an instance", "They are the same", "Object inherits class" }, "Class is a blueprint,object is an instance", "Medium"));
            qQuestions1.Add(new Question("Which access modifier makes a member accessible only within its own class? ", new List<string> { "public", "private", "protected", "internal" }, "private", "Easy"));
            qQuestions1.Add(new Question("What is polymorphism in OOP?", new List<string> { "Ability to hide data", "Ability to inherit methods", "Ability to take many forms", "Ability to override constructors" }, "Ability to take many forms", "Medium"));
            quizzes.Add(new Quiz("OOP fundamentals", "Covers basics of object-oriented programming", categories[0], qQuestions1));

            List<Question> qQuestions2 = new List<Question>();
            qQuestions2.Add(new Question("Which data structure uses LIFO (Last In First Out) principle?", new List<string> { "Queue", "Stack", "Array", "Linked List" }, "Stack", "Easy"));
            qQuestions2.Add(new Question("What is the time complexity of accessing an element in an array?", new List<string> { "O(1)", "O(n)", "O(log n)", "O(n^2)" }, "O(1)", "Easy"));
            qQuestions2.Add(new Question("Which data structure is best suited for implementing a FIFO (First In First Out) system?", new List<string> { "Stack", "Queue", "Tree", "Graph" }, "Queue", "Easy"));
            qQuestions2.Add(new Question("What is a linked list?", new List<string> { "A collection of nodes", "A type of array", "A stack implementation", "A queue implementation" }, "A collection of nodes", "Medium"));
            qQuestions2.Add(new Question("Which data structure is used for hierarchical data representation?", new List<string> { "Array", "Linked List", "Tree", "Graph" }, "Tree", "Hard"));
            qQuestions2.Add(new Question("What is the main difference between a stack and a queue?", new List<string> { "Stack is FIFO, Queue is LIFO", "Stack is LIFO, Queue is FIFO", "Both are FIFO", "Both are LIFO" }, "Stack is LIFO, Queue is FIFO", "Easy"));
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
            qQuestions4.Add(new Question("Which HTTP method is used to retrieve data from a server?", new List<string> { "POST", "GET", "PUT", "DELETE" }, "GET", "`Medium"));
            qQuestions4.Add(new Question("In JavaScript, which symbol is used to denote a comment?", new List<string> { "//", "/* */", "#", "<!-- -->" }, "//", "Easy"));
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
            qQuestions6.Add(new Question("Which of the following is NOT a strong password practice?", new List<string> { "Using a mix of letters, numbers, and symbols", "Using common words or phrases", "Changing passwords regularly", "Using long passwords" }, "Using common words or phrases", "Easy"));
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
            qQuestions8.Add(new Question("In OOP, what is the term for a class that cannot be instantiated?", new List<string> { "Abstract Class", "Concrete Class", "Interface", "Static Class" }, "Abstract Class", "Hard"));
            qQuestions8.Add(new Question("What is the main advantage of using interfaces in OOP?", new List<string> { "Code Reusability", "Multiple Inheritance", "Data Encapsulation", "Polymorphism" }, "Multiple Inheritance", "Hard"));
            qQuestions8.Add(new Question("Which of the following is NOT a type of inheritance in OOP?", new List<string> { "Single Inheritance", "Multiple Inheritance", "Hierarchical Inheritance", "Sequential Inheritance" }, "Sequential Inheritance", "Hard"));
            qQuestions8.Add(new Question("What is method overriding in OOP?", new List<string> { "Defining a method in a subclass with the same name and signature as in the superclass", "Defining multiple methods with the same name but different parameters", "Hiding data within a class", "Creating objects from a class" }, "Defining a method in a subclass with the same name and signature as in the superclass", "Medium"));
            qQuestions8.Add(new Question("Which OOP principle emphasizes the bundling of data and methods that operate on that data within a single unit?", new List<string> { "Encapsulation", "Abstraction", "Inheritance", "Polymorphism" }, "Encapsulation", "Easy"));
            qQuestions8.Add(new Question("In OOP, what is the term for a class that serves as a blueprint for creating objects?", new List<string> { "Object", "Method", "Class", "Interface" }, "Class", "Easy"));
            qQuestions8.Add(new Question("What is the difference between composition and inheritance in OOP?", new List<string> { "Composition is a 'has-a' relationship, while inheritance is an 'is-a' relationship", "Composition allows code reuse, while inheritance does not", "Inheritance is more flexible than composition", "There is no difference" }, "Composition is a 'has-a' relationship, while inheritance is an 'is-a' relationship", "Hard"));
            qQuestions8.Add(new Question("Which of the following is a benefit of using OOP?", new List<string> { "Improved code organization and maintainability", "Faster execution speed", "Reduced memory usage", "Simplified syntax" }, "Improved code organization and maintainability", "Easy"));
            quizzes.Add(new Quiz("Advanced OOP", "In-depth exploration of advanced object-oriented programming concepts.", categories[0], qQuestions8));

            List<Question> qQuestions9 = new List<Question>();
            qQuestions9.Add(new Question("What is a balanced binary search tree?", new List<string> { "A tree where each node has at most two children", "A tree where the left and right subtrees of every node differ in height by at most one", "A tree that allows duplicate values", "A tree that is always complete" }, "A tree where the left and right subtrees of every node differ in height by at most one", "Hard"));
            qQuestions9.Add(new Question("Which of the following points is/are not true about Linked List data structure when it is compared with an array?", new List<string> { "Random access is not allowed in a typical implementation of Linked Lists", "Access of elements in linked list takes less time than compared to arrays", "Arrays have better cache locality that can make them better in terms of performance", " It is easy to insert and delete elements in Linked List" }, "Access of elements in linked list takes less time than compared to arrays", "Medium"));
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
            qQuestions10.Add(new Question(" In the Analysis phase, the development of the ____________ occurs, which is a clear statement of the goals and objectives of the project.", new List<string> { "documentation", "program specification", "system design", "flowchart" }, "program specification", "Medium"));
            qQuestions10.Add(new Question("Actual programming of software code is done during the ____________ step in the SDLC.", new List<string> { "Testing and Integration", "Design", "Development and Documentation", "Analysis" }, "Development and Documentation", "Easy"));
            qQuestions10.Add(new Question("Which design pattern allows behavior to be added to an individual object, either statically or dynamically, without affecting the behavior of other objects from the same class?", new List<string> { "Decorator Pattern", "Strategy Pattern", "Command Pattern", "Mediator Pattern" }, "Decorator Pattern", "Hard"));
            quizzes.Add(new Quiz("Software Design II ", "Harder questions related to designing a good software and includes all design patterns", categories[2], qQuestions10));

            List<Question> qQuestions11 = new List<Question>();
            qQuestions11.Add(new Question("Which HTML5 element is used to define the main content of a document?", new List<string> { "<header>", "<main>", "<section>", "<article>" }, "<main>", "Easy"));
            qQuestions11.Add(new Question("What is the purpose of the 'defer' attribute in a <script> tag?", new List<string> { "To load the script asynchronously", "To delay the execution of the script until after the document has been parsed", "To block the rendering of the page until the script is loaded", "To prioritize the script loading" }, "To delay the execution of the script until after the document has been parsed", "Medium"));
            qQuestions11.Add(new Question("Which CSS property is used to create a flex container?", new List<string> { "display: block;", "display: inline;", "display: flex;", "display: grid;" }, "display: flex;", "Hard"));
            qQuestions11.Add(new Question("In JavaScript, which method is used to add an event listener to an element?", new List<string> { "addEventListener()", "attachEvent()", "onEvent()", "bindEvent()" }, "addEventListener()", "Medium"));
            qQuestions11.Add(new Question("What is the purpose of the 'this' keyword in JavaScript?", new List<string> { "To refer to the current function", "To refer to the global object", "To refer to the object that is executing the current function", "To refer to the parent object" }, "To refer to the object that is executing the current function", "Hard"));
            qQuestions11.Add(new Question("Which HTTP status code indicates a successful request?", new List<string> { "200", "404", "500", "301" }, "200", "Easy"));
            qQuestions11.Add(new Question("What is the purpose of the 'async' attribute in a <script> tag?", new List<string> { "To load the script asynchronously", "To delay the execution of the script until after the document has been parsed", "To block the rendering of the page until the script is loaded", "To prioritize the script loading" }, "To load the script asynchronously", "Medium"));
            qQuestions11.Add(new Question("Which CSS property is used to create a grid container?", new List<string> { "display: block;", "display: inline;", "display: flex;", "display: grid;" }, "display: grid;", "Hard"));
            qQuestions11.Add(new Question("In JavaScript, which method is used to remove an event listener from an element?", new List<string> { "removeEventListener()", "detachEvent()", "offEvent()", "unbindEvent()" }, "removeEventListener()", "Medium"));
            qQuestions11.Add(new Question("What is the purpose of the 'bind()' method in JavaScript?", new List<string> { "To create a new function with a specific 'this' value", "To call a function with a specific 'this' value", "To apply a function with a specific 'this' value", "To create a closure" }, "To create a new function with a specific 'this' value", "Hard"));
            quizzes.Add(new Quiz("Further Web Development", "Comprehensive quiz covering more aspects of JavaScript.", categories[3], qQuestions11));

            List<Question> qQuestions12 = new List<Question>();
            qQuestions12.Add(new Question("Who designs and implement database structures?", new List<string> { "Programmer", "Architect", "Technical writers", "Database administrators" }, "Database administrators", "Easy"));
            qQuestions12.Add(new Question("What is DBMS?", new List<string> { "DBMS is a collection of queries", "DBMS is a high-level language", "DBMS is a programming language", "DBMS stores,modifies and retrieves data" }, "DBMS stores,modifies and retrieves data", "Easy"));
            qQuestions12.Add(new Question("Which of the following is a type of DBMS?", new List<string> { "Hierarchical DBMS", "Network DBMS", "Relational DBMS", "All of the mentioned" }, "All of the mentioned", "Medium"));
            qQuestions12.Add(new Question("Which of the following is not a function of DBMS?", new List<string> { "Data storage management", "Data transformation", "Data security", "Data retrieval" }, "Data transformation", "Easy"));
            qQuestions12.Add(new Question("Which of the following is a NoSQL database?", new List<string> { "MySQL", "PostgreSQL", "MongoDB", "SQLite" }, "MongoDB", "Hard"));
            qQuestions12.Add(new Question("Which of the following is not an example of DBMS?", new List<string> { "MySQL", "Microsoft Access", "Google", "IBM DB2" }, "Google", "Easy"));
            qQuestions12.Add(new Question("Which of the following is not a feature of DBMS?", new List<string> { "Minimum Duplication and Redundancy of Data", "High Level of Security", "Single-user Access only", "Support ACID property" }, "Single-user Access only", "Medium"));
            qQuestions12.Add(new Question("What does ACID stand for in database systems?", new List<string> { "Atomicity, Consistency, Isolation, Durability", "Accuracy, Consistency, Integrity, Durability", "Atomicity, Clarity, Isolation, Durability", "Accuracy, Clarity, Integrity, Durability" }, "Atomicity, Consistency, Isolation, Durability", "Hard"));
            qQuestions12.Add(new Question("Which of the following is known as a set of entities of the same type that share same properties, or attributes?", new List<string> {"Relation set","Tuples", "Entity Relation Model", "Entity set" }, "Entity set", "Medium"));
            qQuestions12.Add(new Question("In a relational database, what is a 'tuple'?", new List<string> { "A column in a table", "A row in a table", "A relationship between tables", "A type of index" }, "A row in a table", "Easy"));
            quizzes.Add(new Quiz("Database Management System", "General quiz covering aspects of DBMS", categories[4], qQuestions12));

            List<Question> qQuestions13 = new List<Question>();
            qQuestions13.Add(new Question("You receive an email from your “college admin” asking you to update your student credentials via a link. What should you do first?", new List<string> { "Click the link and log in immediately DUh","Forward the email to classmates","Reply with your password for verification","Verify the sender's email domain and contact the admin office directly"}, "Verify the sender's email domain and contact the admin office directly","Easy"));
            qQuestions13.Add(new Question("Your laptop shows a pop-up saying “Your computer is infected, click to clean now!” What’s the right step?", new List<string> {"Click to fix it","Restart your system immediately","Run your verified antivirus instead","Ignore and continue browsing" }, "Run your verified antivirus instead","Medium"));
            qQuestions13.Add(new Question("During an online internship, your supervisor asks you to install unfamiliar monitoring software. What should you do?", new List<string> {"Install immediately","Download from a random site","Disable antivirus before installation","Ask for written verification from your organization"}, "Ask for written verification from your organization", "Easy"));
            qQuestions13.Add(new Question("You notice unusual activity on your bank account after using public Wi-Fi. What’s your immediate action?", new List<string> {"Ignore it","Change your online banking password and notify the bank","Continue using public Wi-Fi for banking","Share your account details with a friend for safety"}, "Change your online banking password and notify the bank", "Medium"));
            qQuestions13.Add(new Question("What does DoS attack stand for?", new List<string> { "Denial of Security", "Denial of Safety", "Denial of Simplicity", "Denial of Service" }, "Denial of Service", "Easy"));
            qQuestions13.Add(new Question("What does EDR stand for?", new List<string> { "Endlevel and Development Response", "Endpoint Detection and Response", "End Detect and Respond", "Extract Diffuse and Relay" },"Endpoint Detection and Response","Medium"));
            qQuestions13.Add(new Question("What is a black hat hacker?", new List<string> { "A hacker who uses their skills for ethical purposes", "A hacker who exploits vulnerabilities for malicious purposes", "A hacker who works for government agencies", "A hacker who focuses on network security" }, "A hacker who exploits vulnerabilities for malicious purposes", "Hard"));
            qQuestions13.Add(new Question("What is a zero-day vulnerability?", new List<string> {"A type of virus","A flaw unknown to developers but exploited by hackers","An old attack","A security patch"}, "A flaw unknown to developers but exploited by hackers","Hard"));
            qQuestions13.Add(new Question("Which of protocol encrypts data at the network level?", new List<string> { "IPV6", "IPFec", "IPSev", "IPSec" }, "IPSec", "Hard"));
            qQuestions13.Add(new Question("Which attack type employs a fake server with a relay address?", new List<string> {"Man-in-the-Center (MITC)","Man-in-the-Middle (MITM)","Man-in-the-Top (MITP)","Man-in-the-West (MITW)"},"Man-in-the-Middle (MITM)","Hard"));
            quizzes.Add(new Quiz("Cybersecurity Advanced", "Detailed quiz on cybersecurity topics and some scenarios to handle.", categories[5], qQuestions13));

            List<Question> qQuestions14 = new List<Question>();
            qQuestions14.Add(new Question("How is a single channel shared by multiple signals in a computer network?",new List<string> { "multiplexing","phase modulation","analog modulation","digital modulation"},"multiplexing","Medium"));
            qQuestions14.Add(new Question("What is the term for an endpoint of an inter-process communication flow across a computer network?", new List<string> { "port","machine","socket","pipe"},"socket","Medium"));
            qQuestions14.Add(new Question("When discussing IDS/IPS, what is a signature?", new List<string> { "It refers to 'normal' baseline network behavior", "It is used to authorize the users on a network", "An electronic signature used to authenticate the identity of a user on the network", "Attack-definition file" } , "An electronic signature used to authenticate the identity of a user on the network","Medium"));
            qQuestions14.Add(new Question("Which of the following are Gigabit Ethernets?", new List<string> {"1000 BASE-LX","1000 BASE-CX","1000 BASE-SX","All of the mentioned"},"All of the mentioned","Hard"));
            qQuestions14.Add(new Question("What does each packet contain in a virtual circuit network?",new List<string> { "only source address","only destination address","full source and destination address","a short VC number"},"a short VC number","Hard"));
            qQuestions14.Add(new Question("What was the name of the first network?", new List<string> { "ASAPNET","ARPANET","CNNET","NSFNET"},"ARPANET","Hard"));
            qQuestions14.Add(new Question("Which of the following is not a routing protocol?", new List<string> { "BGP","RIP","OSPF","FTP"},"FTP","Medium"));
            qQuestions14.Add(new Question("Which of the following allows you to connect and login to a remote computer?", new List<string> {"SMTP","HTTP","FTP","Telnet"},"Telnet","Easy"));
            qQuestions14.Add(new Question("TCP/IP model does not have ______ layer but OSI model have this layer.", new List<string> {"session layer","transport layer","application layer","network layer"},"session layer","Medium"));
            qQuestions14.Add(new Question("The main contents of the routing table in datagram networks are ___________",new List<string> {"Source and Destination address","Destination address and Output port","Source address and Output port","Input port and Output port"},"Destination address and Output port","Easy"));
            quizzes.Add(new Quiz("Network Administration", "Extensive quiz on network management, protocols, and security measures.", categories[6], qQuestions14));

        }
        public void LoadCategories(List<Category> categories)
        {
            foreach (Category category in categories)
            {
                category.LoadCategory();
                Console.WriteLine();
            }
        }
        public void LoadQuizforCategory(List<Quiz> quizzes, int catID)
        {
            foreach (Quiz quiz in quizzes)
            {
                if (quiz.QuizCategory.CategoryID == catID)
                { quiz.LoadQuiz(); }
                Console.WriteLine();
            }
        }

        public void RemoveCategory(List<Category> categories, int catID, List<Quiz> quizzes)
        {
            //foreach (Category category in categories)
            //{
            //    if (category.CategoryID == catID)
            //    {
            //        categories.Remove(category);
            //    }
            //}
            categories.RemoveAll(c => c.CategoryID == catID);
            quizzes.RemoveAll(q => q.QuizCategory.CategoryID == catID);
            //foreach (Quiz quiz in quizzes)
            //{
            //    if (quiz.QuizCategory.CategoryID == catID)
            //    {
            //        quizzes.Remove(quiz);
            //    }
            //}
        }
        public void LoadStudents(List<Student> students)
        {
            Console.WriteLine("STUDENTS");
            foreach (Student student in students)
            {
                student.LoadUser();
                Console.WriteLine();
            }
        }
        public void LoadQuizzes(List<Quiz> quizzes)
        {
            foreach (Quiz quiz in quizzes)
            {
                quiz.LoadQuiz();
                Console.WriteLine();
            }
        }
        public void SaveQuiztoCSV(List<Quiz> quizzes, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("QuizID,QuizTitle,QuizDescription,CategoryID,CategoryName,QuestionID,QuestionText,QuestionOptions,QuestionCorrectAnswer,QuestionDifficultLevel");
                foreach (Quiz quiz in quizzes)
                {
                    writer.WriteLine($"{quiz.QuizID},{quiz.QuizTitle},{quiz.QuizDescription},{quiz.QuizCategory.CategoryName}");
                    foreach (Question question in quiz.QuizQuestions)
                    {
                        string options = string.Join(";", question.QuestionOptions);
                        writer.WriteLine($"{question.QuestionID},{question.QuestionText},{options},{question.QuestionCorrectAnswer},{question.QuestionDifficultLevel}");

                    }
                }
            }
        }
        public void RemoveAdmin(List<Admin> admins, int adminID)
        {
            admins.RemoveAll(a => a.UserId == adminID);

        }
        public void RemoveStudent(List<Student> students, int studentID)
        {
            students.RemoveAll(s => s.UserId == studentID);
        }
        public bool VerifyAdminLogin(List<Admin> admins, string username, string password)
        {
            foreach (Admin admin in admins)
            {
                if (admin.UserName == username && admin.UserPassword == password)
                {
                    admin.LoggedIn();
                    admin.LoggedDate();
                    return true;
                }
            }
            Console.WriteLine("Invalid admin credentials.");
            return false;
        }
        public void MainMenu(List<Admin> admins, List<Student> students, List<Category> categories, List<Quiz> quizzes)
        {
            Console.WriteLine("Welcome to the Quiz System!");
            Console.WriteLine("1. Admin Login");
            Console.WriteLine("2. Student Login");
            Console.WriteLine("0. Exit");
            Console.Write("Select an option: ");
            string choice = "";
            do
            {
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter admin username: ");
                        string adminUsername = Console.ReadLine();
                        Console.Write("Enter admin password: ");
                        string adminPassword = Console.ReadLine();
                        bool isAdminValid = VerifyAdminLogin(admins, adminUsername, adminPassword);
                        if (isAdminValid)
                        {
                            //Console.Clear();
                            Console.WriteLine("Press Enter to continue ");
                            Console.ReadLine();
                            AdminMenu(admins, adminUsername, quizzes, categories, students);
                        }
                        break;
                    case "2":
                        Console.Write("Enter student username: ");
                        string studentUsername = Console.ReadLine();
                        Console.Write("Enter student password: ");
                        string studentPassword = Console.ReadLine();
                        bool isStudentValid = VerifyStudentLogin(students, studentUsername, studentPassword);
                        if (isStudentValid)
                        {
                            //Console.Clear();
                            Console.WriteLine("Press Enter to continue ");
                            Console.ReadLine();
                            StudentMenu(students, studentUsername, quizzes, categories);
                        }
                        break;
                    case "0":
                        Console.WriteLine("Exiting the system. Goodbye!");
                        Environment.Exit(0);
                        break;
                    default:
                        // fix the error here
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            } while (choice != "0");
        }
        public bool VerifyStudentLogin(List<Student> students, string username, string password)
        {
            foreach (Student student in students)
            {
                if (student.UserName == username && student.UserPassword == password)
                {
                    student.LoggedIn();
                    return true;
                }
            }
            Console.WriteLine("Invalid student credentials.");
            return false;
        }
        public void PlayQuiz(Quiz quiz)
        {
            // As I have been coding this, I realised that the load question method is not effective because it displays the answer PLEASE :((
            // this method has been coded with auto completion from github copilot which is why the layout is very different and contains new functions i have learnt along the way
            int score = 0;
            int questionNumber = 1;
            foreach (Question question in quiz.QuizQuestions)
            {
                Console.WriteLine($"Question {questionNumber++}: " + question.QuestionText + " Level: " + question.QuestionDifficultLevel);
                //Console.WriteLine("Question: " + question.QuestionText + " Level: " + question.QuestionDifficultLevel);

                for (int i = 0; i < question.QuestionOptions.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {question.QuestionOptions[i]}");
                }
                Console.Write("Select your answer (1-{0}): ", question.QuestionOptions.Count);
                int answerIndex;
                while (!int.TryParse(Console.ReadLine(), out answerIndex) || answerIndex < 1 || answerIndex > question.QuestionOptions.Count)
                {
                    Console.Write("Invalid input. Please select a valid option (1-{0}): ", question.QuestionOptions.Count);
                }
                string selectedAnswer = question.QuestionOptions[answerIndex - 1];
                if (selectedAnswer == question.QuestionCorrectAnswer)
                {
                    score++;
                    Console.WriteLine($"Correct! The correct answer is: {question.QuestionCorrectAnswer}");
                }
                else
                {
                    Console.WriteLine($"Wrong! The correct answer is: {question.QuestionCorrectAnswer}");
                }
            }
            Console.WriteLine($"Quiz completed! Your score: {score}/{quiz.QuizQuestions.Count}");
        }
        public void StudentMenu(List<Student> students, string username, List<Quiz> quizzes, List<Category> categories)
        {
            // Student menu logic here
            Console.Clear();
            Console.WriteLine("WELCOME STUDENT");
            string studentChoice = "";
            do
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Play Quiz");
                Console.WriteLine("0. Exit");
                studentChoice = Console.ReadLine();

                switch (studentChoice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Available Categories:");
                        LoadCategories(categories);
                        Console.WriteLine();
                        Console.Write("Enter Category ID: ");
                        int categoryId = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("Available Quizzes:");
                        Console.WriteLine("Please note that each quiz contains 10 QUESTIONS!");
                        LoadQuizforCategory(quizzes, categoryId);
                        Console.WriteLine();
                        Console.Write("Enter Quiz ID to play: ");
                        int quizId = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Quiz selectedQuiz = quizzes.FirstOrDefault(q => q.QuizID == quizId);
                        if (selectedQuiz != null)
                        {
                            PlayQuiz(selectedQuiz);
                        }
                        else
                        {
                            // Handle invalid quiz ID
                            Console.WriteLine("Invalid Quiz ID.");

                        }
                        break;
                    case "0":
                        Console.WriteLine("Goodbye!");
                        foreach (Student student in students)
                        {
                            if (student.UserName == username)
                            {
                                student.Logout();
                            }
                        }
                        Environment.Exit(0);
                        break;
                    default:
                        // fix the error here
                        Console.WriteLine("Invalid option. Please try again.");
                        studentChoice = Console.ReadLine();
                        break;
                }

            } while (studentChoice != "0");
        }
        public void AdminMenu(List<Admin> admins, string username, List<Quiz> quizzes, List<Category> categories, List<Student> students)
        {   // Admin menu logic here
            Console.Clear();
            Console.WriteLine("WELCOME ADMIN");
            string adminChoice = "";
            do
            {
                Console.WriteLine("What would you like to edit?");
                Console.WriteLine("1. Users");
                Console.WriteLine("2. Categories");
                Console.WriteLine("3. Quiz Questions");
                Console.WriteLine("0. Exit");
                adminChoice = Console.ReadLine();
                switch (adminChoice)
                {
                    case "1":
                        // Manage Users
                        Console.Clear();
                        string userChoice = "";
                        do
                        {
                            Console.WriteLine("Select an option: ");
                            Console.WriteLine("1. Remove Admin");
                            Console.WriteLine("2. Remove Student");
                            Console.WriteLine("3. Add Admin");
                            Console.WriteLine("4. Add Student");
                            Console.WriteLine("5. Edit Admin");
                            Console.WriteLine("6. Edit Student");
                            Console.WriteLine("7. Manage Student Status");
                            Console.WriteLine("0. Back to Admin Menu");
                            userChoice = Console.ReadLine();
                            switch (userChoice)
                            {

                                case "1":
                                    Console.Clear();
                                    LoadAdmins(admins);
                                    Console.WriteLine();
                                    Console.Write("Enter Admin ID to remove: ");
                                    int adminId = int.Parse(Console.ReadLine());
                                    RemoveAdmin(admins, adminId);
                                    Console.WriteLine();
                                    Console.WriteLine("Admin removed! New List :D");
                                    LoadAdmins(admins);

                                    break;
                                case "2":
                                    Console.Clear();
                                    LoadStudents(students);
                                    Console.WriteLine();
                                    Console.Write("Enter Student ID to remove: ");
                                    int studentId = int.Parse(Console.ReadLine());
                                    RemoveStudent(students, studentId);
                                    Console.WriteLine();
                                    Console.WriteLine("Student removed! New List :D");
                                    LoadStudents(students);
                                    break;
                                case "3":
                                    Console.Clear();
                                    Console.WriteLine("Please provide the information for the new admin:)");
                                    Console.Write("Admin's Username:");
                                    string aUsername = Console.ReadLine();
                                    Console.Write("Admin's Password:");
                                    string aPassword = Console.ReadLine();
                                    Console.Write("Admin's Email:");
                                    string aEmail = Console.ReadLine();
                                    admins.Add(new Admin(aUsername, aPassword, aEmail));
                                    Console.WriteLine();
                                    Console.WriteLine("Admin added! New List :D");
                                    LoadAdmins(admins);

                                    break;
                                case "4":
                                    Console.Clear();
                                    Console.WriteLine("Please provide the information for the new student:)");
                                    Console.Write("Student's Username:");
                                    string sUsername = Console.ReadLine();
                                    Console.Write("Student's Password:");
                                    string sPassword = Console.ReadLine();
                                    Console.Write("Student's Email:");
                                    string sEmail = Console.ReadLine();
                                    students.Add(new Student(sUsername, sPassword, sEmail));
                                    Console.WriteLine();
                                    Console.WriteLine("Student added! New List");
                                    LoadStudents(students);
                                    break;
                                case "5":
                                    Console.Clear();
                                    LoadAdmins(admins);
                                    Console.WriteLine();
                                    Console.Write("Enter Admin ID to edit: ");
                                    int editAdminId = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter the new details!");
                                    Console.WriteLine("Note: to keep the same info, just press ENTER.");
                                    Console.Write("New Admin Username:");
                                    string newAdminName = Console.ReadLine();
                                    Console.Write("New Admin Password:");
                                    string newAdminPassword = Console.ReadLine();
                                    Console.Write("New Admin Email:");
                                    string newAdminEmail = Console.ReadLine();
                                    admins[editAdminId - 1].UpdateUser(newAdminName, newAdminPassword, newAdminEmail);
                                    Console.WriteLine();
                                    Console.WriteLine("Admin updated! New List :D");
                                    LoadAdmins(admins);
                                    break;
                                case "6":
                                    Console.Clear();
                                    LoadStudents(students);
                                    Console.WriteLine();
                                    Console.Write("Enter Student ID to edit: ");
                                    int editStudentId = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter the new details!");
                                    Console.WriteLine("Note: to keep the same info, just press ENTER.");
                                    Console.Write("New Student Username:");
                                    string newStudentName = Console.ReadLine();
                                    Console.Write("New Student Password:");
                                    string newStudentPassword = Console.ReadLine();
                                    Console.Write("New Student Email:");
                                    string newStudentEmail = Console.ReadLine();
                                    students[editStudentId - 1].UpdateUser(newStudentName, newStudentPassword, newStudentEmail);
                                    Console.WriteLine();
                                    Console.WriteLine("Student updated! New List :D");
                                    LoadStudents(students);
                                    break;
                                case "7":
                                    Console.Clear();
                                    LoadStudents(students);
                                    Console.WriteLine();
                                    Console.Write("Enter Student ID to manage status: ");
                                    int statusStudentId = int.Parse(Console.ReadLine());
                                    Console.Write("Which status? active/inactive");
                                    string uStatus = Console.ReadLine();
                                    students[statusStudentId - 1].ManageStatus(uStatus);
                                    Console.WriteLine("status updated!");
                                    break;
                                case "0":
                                    // Back to Admin Menu
                                    break;
                                default:
                                    // fix the error here
                                    Console.WriteLine("Invalid option. Please try again.");
                                    userChoice = Console.ReadLine();
                                    break;
                            }

                            Console.WriteLine("Press Enter to continue...");
                            Console.ReadLine();
                            Console.Clear();
                        } while (userChoice != "0");
                        break;

                    case "2":
                        // Manage Categories
                        string categoryChoice = "";
                        do
                        {

                            Console.WriteLine("Select an option: ");
                            Console.WriteLine("1. Remove Category");
                            Console.WriteLine("2. Add Category");
                            Console.WriteLine("3. Edit Category");
                            Console.WriteLine("0. Back to Admin Menu");
                            categoryChoice = Console.ReadLine();

                            switch (categoryChoice)
                            {
                                case "1":
                                    Console.Clear();
                                    LoadCategories(categories);
                                    Console.WriteLine();
                                    Console.Write("Enter Category ID to remove: ");
                                    int categoryId = int.Parse(Console.ReadLine());
                                    RemoveCategory(categories, categoryId, quizzes);
                                    Console.WriteLine();
                                    Console.WriteLine("Category removed! New List :D");
                                    LoadCategories(categories);
                                    break;
                                case "2":
                                    Console.Clear();
                                    Console.WriteLine("Please provide the necessary information for the new category");
                                    Console.Write("Category Name:");
                                    string cName = Console.ReadLine();
                                    Console.Write("Category Description:");
                                    string cDescription = Console.ReadLine();
                                    categories.Add(new Category(cName, cDescription));
                                    Console.WriteLine();
                                    Console.WriteLine("Category added! New List :D");
                                    LoadCategories(categories);
                                    break;
                                case "3":
                                    Console.Clear();
                                    LoadCategories(categories);
                                    Console.WriteLine();
                                    Console.Write("Enter Category ID to edit: ");
                                    int editCategoryId = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter the new details!");
                                    Console.WriteLine("Note:to keep the same info, just press ENTER.");
                                    Console.Write("New Category Name:");
                                    string newCategoryName = Console.ReadLine();
                                    Console.Write("New Category Description:");
                                    string newCategoryDescription = Console.ReadLine();
                                    categories[editCategoryId - 1].UpdateCategory(newCategoryName, newCategoryDescription);
                                    Console.WriteLine();
                                    Console.WriteLine("Category updated! New List :D");
                                    LoadCategories(categories);
                                    break;
                                case "0":
                                    // Back to Admin Menu
                                    break;
                                default:
                                    // fix the error here
                                    Console.WriteLine("Invalid option. Please try again.");
                                    categoryChoice = Console.ReadLine();
                                    break;
                            }
                            Console.WriteLine("Press Enter to continue...");
                            Console.ReadLine();
                            Console.Clear();
                        } while (categoryChoice != "0");
                        break;
                    case "3":
                        // Manage Quiz Questions
                        string questionChoice = "";
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Select an option: ");
                            Console.WriteLine("1. Remove a quiz question");
                            Console.WriteLine("2. Add a quiz question");
                            Console.WriteLine("3. Edit a quiz question");
                            Console.WriteLine("0. Back to Admin Menu");
                            questionChoice = Console.ReadLine();
                            switch (questionChoice)
                            {
                                case "1":
                                    Console.Clear();
                                    LoadQuizzes(quizzes);
                                    Console.WriteLine("Which quiz would you like to remove a question from? (Enter QuizId)");
                                    int quizId = int.Parse(Console.ReadLine());

                                    Console.Clear();
                                    Console.WriteLine("Here are the questions in the quiz:");
                                    quizzes[quizId - 1].LoadQuizQs();
                                    Console.WriteLine();
                                    Console.Write("Enter Question ID to remove: ");
                                    int questionId = int.Parse(Console.ReadLine());
                                    quizzes[quizId - 1].RemoveQuestion(questionId);
                                    Console.WriteLine();
                                    Console.WriteLine("Question removed! New List :D");
                                    quizzes[quizId - 1].LoadQuizQs();
                                    break;
                                case "2":
                                    LoadQuizzes(quizzes);
                                    Console.WriteLine("Which quiz would you like to add a question to? (Enter QuizId)");
                                    int quizId2 = int.Parse(Console.ReadLine());
                                    Console.Clear();
                                    Console.WriteLine("Please provide details for new question to the quiz.");
                                    Console.Write("Enter Question (text): ");
                                    string qText = Console.ReadLine();
                                    Console.Write("Enter Question Options (separated by commas): ");
                                    string optionsInput = Console.ReadLine();
                                    List<string> qOptions = optionsInput.Split(',').Select(o => o.Trim()).ToList();
                                    Console.Write("Enter Correct Answer: ");
                                    string correctAnswer = Console.ReadLine();
                                    Console.Write("Enter Difficulty Level (Easy/Medium/Hard): ");
                                    string difficultyLevel = Console.ReadLine();
                                    quizzes[quizId2 - 1].AddQuestion(new Question(qText, qOptions, correctAnswer, difficultyLevel));
                                    Console.WriteLine();
                                    Console.WriteLine("Question added! New List :D");
                                    quizzes[quizId2 - 1].LoadQuizQs();
                                    break;
                                case "3":
                                    Console.Clear();
                                    LoadQuizzes(quizzes);
                                    Console.WriteLine("Which quiz would you like to edit a question? (Enter QuizId)");
                                    int quizId3 = int.Parse(Console.ReadLine());
                                    Console.WriteLine();
                                    quizzes[quizId3 - 1].LoadQuizQs();
                                    Console.WriteLine();
                                    Console.Write("Enter Question ID to edit: ");
                                    int editQuestionId = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter the new details!");
                                    Console.WriteLine("To keep the same info, just press ENTER.");
                                    Console.Write("New Question (text): ");
                                    string newQuestionText = Console.ReadLine();
                                    Console.Write("New Question Options (separated by commas): ");
                                    string newOptionsInput = Console.ReadLine();
                                    List<string> newqOptions = newOptionsInput.Split(',').Select(o => o.Trim()).ToList();
                                    Console.Write("New Correct Answer: ");
                                    string newCorrectAnswer = Console.ReadLine();
                                    Console.Write("New Difficulty Level (Easy/Medium/Hard): ");
                                    string newDifficultyLevel = Console.ReadLine();
                                    quizzes[quizId3 - 1].updateQuizQuestions(editQuestionId, newQuestionText, newqOptions, newCorrectAnswer, newDifficultyLevel);
                                    Console.WriteLine();
                                    Console.WriteLine("Question updated! New List :D");
                                    quizzes[quizId3 - 1].LoadQuizQs();
                                    break;
                                case "0":
                                    // Back to Admin Menu
                                    break;
                                default:
                                    // fix the error here
                                    Console.WriteLine("Invalid option. Please try again.");
                                    questionChoice = Console.ReadLine();
                                    break;
                            }
                            Console.WriteLine("Press Enter to continue...");
                            Console.ReadLine();
                            Console.Clear();
                        } while (questionChoice != "0");
                        break;
                    case "0":
                        // Exit
                        Console.WriteLine("Goodbye!");
                        foreach (Admin admin1 in admins)
                        {
                            if (admin1.UserName == username)
                            {
                                admin1.Logout();
                            }
                        }
                        Environment.Exit(0);
                        break;
                    default:
                        // fix the error here
                        Console.WriteLine("Invalid option. Please try again.");
                        adminChoice = Console.ReadLine();
                        break;
                }

                Console.Clear();
            } while (adminChoice != "0");
        }

    }
}