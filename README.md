# Information notifier
![image](https://user-images.githubusercontent.com/67142421/175791197-45eee1c5-5e88-49e6-9767-fdfd4647b531.png)

## Why I made this
My friend told me it would be great if he could get notifications whenever stock market information webpages that he kept track of were updated.<br>
He told me about bugs and his opinions to improve the program and I applied them.

## About this program
It is a program that sends notifications each time new information is uploaded to specified webpages.

## 🧰 Used things
* Frontend : C#
* Backend : python
* Inter Process Communication between C# frontend and Python backend
* Database : txt file

## How to use
1. Deal with webpages that require something like login on the web browser that is opened first.
2. Put any name you want in Webpage name box.
3. Put the webpage address you want to keep track of.
4. What to put in Full XPath box:
  Execute chrome -> Press Ctrl + Shift + C and click on the place whose change you want to know -> Right click on the selected part
  -> Click on Copy -> Click on Copy Full XPath
5. Execute Information notifier.cmd

## Database (txt file)
![image](https://user-images.githubusercontent.com/67142421/177424709-c8829e8a-1b7e-4389-9f03-80aec3b6d01e.png)

## Information
* ### The bigger "Number of browsers", the faster notifying becomes, and the more computing resource is taken.
* ### Each piece of information can be clicked as a hyperlink.
* ### The executable file is in Information notifier.zip

## Installation
**backend**<br>
>pip install requirements.txt -> backend.py<br>

**frontend**<br>
>Information notifier frontend/Information notifier.sln
