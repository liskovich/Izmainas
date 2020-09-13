# Izmainas

This is a project that makes the changes to the school schedule more accessible for students and their parents by making it online.

# About how to use the system

* To enable email sending, go to "appsettings.json" and in section "EmailOptions", fill the fields with your own credentials.

# How to install the system

* Import the MySQL database (if necessary, change connection string with name "Default" in appsettings.json. MySQL Workbench is useful for this.
* In "EmailOptions" section, add your email credentials.
* In "ApplicationOptions" section, specify the domain of the frontend application ("WebsiteURL").
* ...
