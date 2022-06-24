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
from selenium.webdriver.common.keys import Keys

driver = webdriver.Chrome()
def open_webbrowser(hide):
    options=webdriver.ChromeOptions()
    #options=Options()
    user_agent='Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.0.0 Safari/537.36'
    options.add_argument('user-agent=' + user_agent)
    options.add_argument("incognito")
    options.add_argument("lang=en_US")
    options.add_experimental_option("excludeSwitches", ["enable-logging"])
    if hide=="hide_webbrowser":
        options.add_argument("headless")
    global driver
    driver = webdriver.Chrome(".\chromedriver.exe", options=options)
    driver.execute_script("Object.defineProperty(navigator, 'plugins', {get: function() {return[1, 2, 3, 4, 5];},});")

# Default database
try:
    open("./webpage_list.txt", 'r', encoding='utf-8')
except:
    database = open("./webpage_list.txt", 'w', encoding='utf-8')
    database.write('((CNN)) ((https://edition.cnn.com/)) ((//*[@id="intl_homepage1-zone-1"]))')
    database.write('((Youtube)) ((https://www.youtube.com/)) ((//*[@id="contents"]/ytd-rich-grid-row[1]))')
    database.close()

webpage_names=[]
URLs = [] # URLs to be monitored
X_paths=[] # Find element by XPATH
#backOfHtmlElements=[] # Find element by css selector
show_webbrowser=False

def parse_database(accepted_client):
    parsedStrings=[]
    database = open("./webpage_list.txt", 'r', encoding='utf-8')
    database.seek(0)
    document=database.read()
    database.close()

    i=0
    while i<len(document):
        if document[i]=='(' and document[i+1]=='(': # First distinguisher found
            beginningOfString=i+2
            i=beginningOfString
            while i<len(document)-1: # Look for second distinguisher
                if document[i]==')' and document[i+1]==')':
                    closingOfString=i
                    break
                i+=1
            parsedStrings.append(document[beginningOfString:closingOfString])
            i+=1
        i+=1

    # Add the parsed data to the lists
    for i in range(0, len(parsedStrings), 3):
        webpage_names.append(parsedStrings[i])
        URLs.append(parsedStrings[i+1])
        X_paths.append(parsedStrings[i+2])
    # Response to frontend
    for i in range(len(webpage_names)):
        accepted_client.sendall(f'Webpage name: {webpage_names[i]}, X path: {X_paths[i]}$'.encode())
        accepted_client.recv(1) # Wait for client's response
    accepted_client.sendall("$".encode()) # Notify it was the last row

def delete_from_database(targetRow):
    currentRow=0
    beginningOfTargetRow=0
    beginningOfNextRow=0

    database = open("./webpage_list.txt", 'r', encoding='utf-8')
    document=database.read()
    for i in range(len(document)):
        # Go to target index
        if document[i]=='\n':
            currentRow+=1
        if currentRow==targetRow: # If target index found
            beginningOfTargetRow=i+1
            for j in range(beginningOfTargetRow, len(document)):
                if document[j]=='\n':
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
    del X_paths[targetRow]

def append_webpage(webpage_name, URL, X_path):
    webpage_names.append(webpage_name)
    URLs.append(URL)
    X_paths.append(X_path)
    # Write on the end of database
    database = open("./webpage_list.txt", 'a', encoding='utf-8')
    database.write(f'(({webpage_name})) (({URL})) (({X_path}))\n')
    database.close()\

monitoring=False
def start_monitoring(accepted_client):
    global monitoring
    monitoring=True
    prev_hashes=[]
    for i, url in enumerate(URLs): # Create initial hashes
        try:
            driver.get(URLs[i])
        except:
            print(f"URL error: {webpage_names[i]}")
            continue
        try:
            WebDriverWait(driver, 9).until(EC.presence_of_element_located((By.XPATH, X_paths[i])))
        except:
            print("Timeout")   
            continue 
        try:
            element=driver.find_element(By.XPATH, X_paths[i])
        except: # Element not found
            print(f"(X path error) There is no such element on {webpage_names[i]}")
            continue
        prev_hashes.append(hashlib.sha224(element.screenshot_as_png).hexdigest())

    while monitoring:
        for i, url in enumerate(URLs):
            try:
                driver.get(URLs[i])
            except:
                print(f"URL error: {webpage_names[i]}")
                continue
            try:
                WebDriverWait(driver, 9).until(EC.presence_of_element_located((By.XPATH, X_paths[i])))
            except:
                print("Timeout")
                continue   
            try:
                element=driver.find_element(By.XPATH, X_paths[i])
            except: # Element not found
                print(f"(X path error) There is no such element on {webpage_names[i]}")
                continue
            new_hash=hashlib.sha224(element.screenshot_as_png).hexdigest()
            # New information found
            if prev_hashes[i]!=new_hash:
                screenshot=element.screenshot_as_base64
                # get href
                try: # Ignore even if ENTER does nothing
                    element.click()
                except:
                    print("Click impossible")
                href=driver.current_url
                # Send the new formation
                response=f"{webpage_names[i]},{screenshot},{href}$"
                accepted_client.sendall(response.encode())

                prev_hashes[i]=new_hash

def stop_monitoring():
    global monitoring
    monitoring=False
    driver.quit()

def request_handler(accepted_client): # Handling requests from client
    while True:
        try:
            message = accepted_client.recv(999).decode() # Wait for client's request
        except: # Client exited
            exit()
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
            open_webbrowser(params[1])
            threading.Thread(target=start_monitoring, args=[accepted_client]).start()
        
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
            exit()

def connect_to_frontend():
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
    import os, subprocess
    subprocess.Popen(os.path.abspath(os.path.dirname(__file__))+f"\Frontend\Information_notifier_frontend.exe {str(port)}")
    accepted_client, address= server_socket.accept() # Accept a client socket

    threading.Thread(target=request_handler, args=[accepted_client]).start()

connect_to_frontend()