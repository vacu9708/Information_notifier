# Information notifier
![image](https://user-images.githubusercontent.com/67142421/175791197-45eee1c5-5e88-49e6-9767-fdfd4647b531.png)

# Why I made this
My friend told me it would be great if he could get notifications whenever stock market information webpages that he kept track of were updated.<br>
He told me about bugs and his opinions to improve the program and I applied them.

# About this program
It is a program that sends notifications each time new information is uploaded to specified webpages.

# 🧰 Used things
* Frontend : C#
* Backend : python
* Inter Process Communication between C# frontend and Python backend
* Database : txt file

# How to use
1. Deal with webpages that require something like login on the web browser that is opened first.
2. Put any name you want in Webpage name box.
3. Put the webpage address you want to keep track of.
4. What to put in Full XPath box:
  Execute chrome -> Press Ctrl + Shift + C and click on the place whose change you want to know -> Right click on the selected part
  -> Click on Copy -> Click on Copy Full XPath
5. Execute Information notifier.cmd

# Database (txt file)
![image](https://user-images.githubusercontent.com/67142421/177424709-c8829e8a-1b7e-4389-9f03-80aec3b6d01e.png)

# Information
* ### The bigger "Number of browsers", the faster notifying becomes, and the more computing resource is taken.
* ### Each piece of information can be clicked as a hyperlink.
* ### The executable file is in Information notifier.zip

# Installation
#### Frontend:
1. Build the C# source in /Information notifier frontend/Information notifier.sln
2. Move the built source to /Frontend/Information_notifier_frontend.exe
#### Backend:
1. pip install requirements.txt
2. Execute backend.py

# Knowledge to bypass selenium detections
- #### User-Agent Detection: (bypassed in this code)
Websites can detect Selenium usage by analyzing the User-Agent header sent by the browser. If a website detects a User-Agent associated with Selenium, it may take preventive actions or display different content.
- #### Headless Browser Detection: (bypassed in this code)
Headless browsers, such as those used by Selenium, operate without a visible user interface. Websites can check for the presence of specific browser configurations to identify and prevent selenium.
- #### navigator.webdriver:
This property is present in the JavaScript navigator object and is set to true when the browser is controlled by WebDriver, including Selenium. Websites can check for the value of navigator.webdriver to identify if the browser is being automated.
