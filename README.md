# ATM Console App
Automated Teller Machine - first project in C#, also using JSON to store data. 

# Description
Project is divided into different folders in which classes are responsible for different functionalities.

1. **View**
* We have 2 classes which build for us interface for every possible user in our app. It enables user to register/login or exit app. Also separated interface for signed in customers.
2. **Data**
* I've chosen storing data in JSON in order to learn about writing/reading data in this file format and also improve my knowledge about this task. Folder contains class which is responsible for every aspect connected with updating/storing/reading data and also json file.
3. **Login**
* Folder contains class which gives us possibility to login. It checks if provided login/password is correct and if we can find these parametres in file. 
4. **Users**
* It stores two classes: User and Customer. 
5. **Registration**
* There are two classes: Registration which enables us to register to our app (at the start we have "Entry Info" which which gives us some necessary pieces of information how to properly register) and also Validation which checks every provided data if it's correct and if it's not used (like login/email).

# Improvements of app
1. Connect C# to database such as MySQL, SQL Server etc.
2. Cleaning code -> make it more readable and also shorter.
3. Adding other "users" to our app like "Administrator" etc.

# Summary
Project still has a lot to add and improve in future. My goal was to walk through C# language, strenghten programming in this language and also to learn other useful skills in this aspect. 