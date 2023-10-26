""" C# project of type Class Library (.Net Framework) inside the TiaAutomation solution and
its name is 'TiaAutomationLibrary' """

from time import sleep
import clr
import sys
import os


# -----------------------------------------------------------------------------------------------------------
# Paths
# -----------------------------------------------------------------------------------------------------------
script_dir = os.path.dirname(__file__)
project_dir = os.path.dirname(script_dir)

# when using the project from the repository
# dll_path = os.path.abspath(os.path.join(project_dir, "CSTestProjects", "TiaAutomation", "TiaAutomationLibrary", "bin", "Debug"))
# when using the project from the local machine
dll_path = os.path.abspath(r"C:\Appl\Projects\C#\TiaAutomation\TiaAutomationLibrary\bin\Debug")

project_file_path = "C:\\Appl\\Projects\\Siemens\\FBW_Siemens_PLC_OPC_UA_V18\\FBW_Siemens_PLC_OPC_UA_V18.ap18"
project_dir_path = "C:\\Appl\\Projects\\Siemens\\FBW_Siemens_PLC_OPC_UA_V18"
locationOfTiaExe = "C:\\Program Files\\Siemens\\Automation\\Portal V18\\Bin\\Siemens.Automation.Portal.exe"
sys.path.append(dll_path)
# -----------------------------------------------------------------------------------------------------------


# -----------------------------------------------------------------------------------------------------------
# DLL usage
# -----------------------------------------------------------------------------------------------------------
# name must be usable by python, not i.e. "09.Some text"
clr.AddReference("TiaAutomationLibrary")

# Name of the namespace is "TcAutomationLibrary"
from TiaAutomationLibrary import *

# The name of the class is "Class1" and it is public
new_instance = StartupClass()
# -----------------------------------------------------------------------------------------------------------


# -----------------------------------------------------------------------------------------------------------
# Usage of the class
# -----------------------------------------------------------------------------------------------------------
# Start Tia and open project
new_instance.StartTia()
sleep(1)

# Compile project
new_instance.Compile()
sleep(5)

# Close
new_instance.Close()
# -----------------------------------------------------------------------------------------------------------
