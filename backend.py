import hashlib
import threading
import time
import socket

# Selenium
import selenium
from selenium import webdriver
#from selenium.webdriver.chrome.options import Options
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from selenium.webdriver.common.by import By
import chromedriver_autoinstaller, os

# Check if chrome driver is installed or not
chrome_ver = chromedriver_autoinstaller.get_chrome_version().split('.')[0]
driver_path = f'./{chrome_ver}/chromedriver.exe'
if os.path.exists(driver_path):
    print(f"chrom driver is insatlled (ver: {chrome_ver})")
else:
    print(f"install the chrome driver (ver: {chrome_ver})")
    try:
        driver_path=chromedriver_autoinstaller.install(True)
    except:
        print("Please install chrome driver")

# Socket
server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
port=9000
while port<65535:
    try:
        server_socket.bind(("127.0.0.1", port))
        print(f"Bound to {port}")
        break
    except:
        port+=1
    
server_socket.listen() # Be ready to accept incoming connection requests

# Execute frontend
import subprocess, sys
if getattr(sys, 'frozen', False):
    application_path = os.path.dirname(sys.executable)
else:
    application_path = os.path.dirname(__file__)
subprocess.Popen(application_path+f"\Frontend\Information_notifier_frontend.exe {str(port)}")
accepted_client, address= server_socket.accept() # Accept the client socket

# Get driver and open url
browser_for_login = webdriver.Chrome(driver_path)
try:
    browser_for_login.get("http://Here_deal_with_webpages_that_require_something_like_login.")
except:
    pass
def open_webbrowser(is_show_webbrowser):
    options=webdriver.ChromeOptions()
    #options=Options()
    user_agent='Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.0.0 Safari/537.36'
    options.add_argument('user-agent=' + user_agent)
    options.add_argument("incognito")
    options.add_argument("lang=en_US")
    options.add_experimental_option("excludeSwitches", ["enable-logging"])
    if not(is_show_webbrowser=="show_webbrowser"):
        options.add_argument("headless")
    driver = webdriver.Chrome(driver_path, options=options)
    driver.execute_script("Object.defineProperty(navigator, 'plugins', {get: function() {return[1, 2, 3, 4, 5];},});")
    return driver

# Default database
try:
    open("./webpage_list.txt", 'r', encoding='utf-8')
except:
    database = open("./webpage_list.txt", 'w', encoding='utf-8')
    database.write('((Youtube)) ((https://www.youtube.com/)) ((/html/body/div[2]/div[2]/div[2]/div/div/div/div/div/div[1]/div/div[1]/div[1]/a/div/div[1]/img))')
    database.close()

webpage_names=[]
URLs = [] # URLs to be monitored
XPaths=[] # Find element by XPATH
#backOfHtmlElements=[] # Find element by css selector
show_webbrowser=False

def parse_database(accepted_client):
    database = open("./webpage_list.txt", 'r', encoding='utf-8')
    database.seek(0)
    document=database.read()
    database.close()

    parsedStrings=[]
    i=0
    while i<len(document):
        if document[i]=='(' and document[i+1]=='(': # First distinguisher found
            beginningOfString=i+2
            i=beginningOfString
            while i<len(document)-1: # Look for second distinguisher
                if document[i]==')' and document[i+1]==')':
                    closingOfString=i
                    i=closingOfString+1 # Because )) is 2 pieces
                    break
                i+=1
            parsedStrings.append(document[beginningOfString:closingOfString]) 
        i+=1

    # Add the parsed data to the lists
    for i in range(0, len(parsedStrings), 3):
        webpage_names.append(parsedStrings[i])
        URLs.append(parsedStrings[i+1])
        XPaths.append(parsedStrings[i+2])

        # Response to frontend
        accepted_client.sendall(f'{parsedStrings[i]},{parsedStrings[i+1]},{parsedStrings[i+2]}$'.encode())
        accepted_client.recv(1) # Wait for client's response      
    accepted_client.sendall("$".encode()) # Notify it was the last row

def delete_from_database(targetRow):
    currentRow=0
    beginningOfTargetRow=0
    beginningOfNextRow=0

    database = open("./webpage_list.txt", 'r', encoding='utf-8')
    document=database.read()
    for i in range(len(document)):
        if document[i]=='\n':
            currentRow+=1
        if currentRow==targetRow: # If target index found
            beginningOfTargetRow=i+1 # Go to the right side of \n
            for j in range(beginningOfTargetRow, len(document)):
                if document[j]=='\n': # Next row found
                    beginningOfNextRow=j+1
                    break
            break

    database = open("./webpage_list.txt", 'w', encoding='utf-8')
    if currentRow!=0: # To handle deleting the first row
        database.write(document[:beginningOfTargetRow])
    database.write(document[beginningOfNextRow:])
    database.close()

    del webpage_names[targetRow]
    del URLs[targetRow]
    del XPaths[targetRow]

def append_webpage(webpage_name, URL, XPath):
    webpage_names.append(webpage_name)
    URLs.append(URL)
    XPaths.append(XPath)
    # Write on the end of database
    database = open("./webpage_list.txt", 'a', encoding='utf-8')
    database.write(f'(({webpage_name})) (({URL})) (({XPath}))\n')
    database.close()

drivers=[]
monitoring=False
def start_monitoring(accepted_client, driver, beginning_index, ending_index):
    global monitoring
    monitoring=True
    prev_hashes=[]
    i=0
    while i<ending_index:
        if not monitoring:
            return
        try:
            driver.get(URLs[i])
        except:
            print(f"URL error: {webpage_names[i]}")
            continue
        try:
            WebDriverWait(driver, 5).until(EC.presence_of_element_located((By.XPATH, XPaths[i])))
            time.sleep(1)
        except:
            print(f"Timeout ({webpage_names[i]})")   
            continue 
        try:
            element=driver.find_element(By.XPATH, XPaths[i])
            #element.screenshot(f'./test/initial.png')
        except: # Element not found
            print(f"(X path error) There is no such element on {webpage_names[i]}")
            continue
        prev_hashes.append(hashlib.sha224(element.screenshot_as_png).hexdigest())
        i+=1

    while True:
        for i in range(beginning_index, ending_index): # Webpage index
            if not monitoring:
                return
            try:
                driver.get(URLs[i])
            except:
                print(f"URL error: {webpage_names[i]}")
                continue
            try:
                WebDriverWait(driver, 5).until(EC.presence_of_element_located((By.XPATH, XPaths[i])))
                time.sleep(1)
            except:
                print("Timeout")
                continue   
            try:
                element=driver.find_element(By.XPATH, XPaths[i])
            except: # Element not found
                print(f"(X path error) There is no such element on {webpage_names[i]}")
                continue
            new_hash=hashlib.sha224(element.screenshot_as_png).hexdigest()
            # New information found
            try: 
                prev_hashes[i-beginning_index]
            except:
                print("error",i-beginning_index)
            if prev_hashes[i-beginning_index]!=new_hash:
                #element.screenshot(f'./test/{str(i)}.png')
                screenshot=element.screenshot_as_base64
                # Get href
                try:
                    element.click()
                except:
                    print(f"Click impossible ({webpage_names[i]})")
                try:
                    time.sleep(0.2)
                    href=driver.current_url
                except:
                    print("Invalid href")
                    href=URLs[i]
                # Send the new formation
                response=f"{webpage_names[i]},{screenshot},{href}$"
                accepted_client.sendall(response.encode())

                prev_hashes[i-beginning_index]=new_hash

def start_monitoring_thread_maker(accepted_client, is_show_webbrowser, n_of_browsers):
    beginning_index=0
    fraction=len(webpage_names)/n_of_browsers
    webpage_length_per_browser=int(fraction)+1 if fraction > int(fraction) else int(fraction) # Ceiling
    ending_index=beginning_index+webpage_length_per_browser
    for i in range(n_of_browsers):
        drivers.append(open_webbrowser(is_show_webbrowser))
        threading.Thread(target=start_monitoring, 
        args=[accepted_client, drivers[i], beginning_index, ending_index], daemon=True).start()
        beginning_index=int( (beginning_index+webpage_length_per_browser)%len(webpage_names) )
        ending_index=beginning_index+webpage_length_per_browser

import atexit
def exit_drivers():
    for i, driver in enumerate(drivers):
        try:
            print('Browser quit',i)
            driver.quit()
        except:
            continue
def atexit_func():
    global monitoring
    monitoring=False
    exit_drivers()
    accepted_client.close()
    server_socket.close()
atexit.register(atexit_func)

def stop_monitoring():
    global monitoring
    if not monitoring:
        return
    monitoring=False
    exit_drivers()
    drivers.clear()

is_exit=False
def request_handler(accepted_client): # Handling requests from client
    global is_exit
    import sys
    while True:
        if is_exit:
            return
        try:
            message = accepted_client.recv(999).decode() # Wait for client's request
        except: # Client exited
            print("Client disconencted")
            sys.exit()
        # Parsing
        params=[]
        beginning_of_string=0
        for i in range(len(message)):
            if message[i]==',': # First distinguisher found
                params.append(message[beginning_of_string:i])
                beginning_of_string=i+1
            if i==len(message)-1: # Last index
                params.append(message[beginning_of_string:])

        # Event loop
        if params[0]=="start_monitoring":
            print("start_monitoring")
            start_monitoring_thread_maker(accepted_client, params[1], int(params[2]))
             
        if params[0]=="stop_monitoring":
            print("stop_monitoring")
            stop_monitoring()
            
        if params[0]=="append_webpage":
            print("append_webpage")
            append_webpage(params[1], params[2], params[3])
        
        if params[0]=="parse_database":
            print("parse_database")
            parse_database(accepted_client)
                    
        if params[0]=="delete_from_database":    
            print("delete_from_database")      
            delete_from_database(int(params[1]))
        
        if params[0]=="get_URL":
            print("get_URL")
            accepted_client.sendall(URLs[int(params[1])].encode())

        if params[0]=="exit":
            print('exit')
            is_exit=True
            try:
                sys.exit()
            except:
                atexit_func()
            return

        if params[0]=="edit_webpage":
            print("edit_webpage")
            delete_from_database(int(params[1]))
            append_webpage(params[2],params[3],params[4])

threading.Thread(target=request_handler, args=[accepted_client]).start()