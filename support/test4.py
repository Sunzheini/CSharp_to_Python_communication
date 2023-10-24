""" C# project is of type Class Library (.Net Framework) and its name is 'TiaTest' """

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
# dll_path = os.path.abspath(os.path.join(project_dir, "CSTestProjects", "TiaTest", "TiaTest", "bin", "Debug"))
# when using the project from the local machine
dll_path = os.path.abspath(r"C:\Appl\Projects\C#\TiaTest\TiaTest\bin\Debug")

project_file_path = "C:\\Appl\\Projects\\Siemens\\FBW_Siemens_PLC_OPC_UA_V18\\FBW_Siemens_PLC_OPC_UA_V18.ap18"
project_dir_path = "C:\\Appl\\Projects\\Siemens\\FBW_Siemens_PLC_OPC_UA_V18"
locationOfTiaExe = "C:\\Program Files\\Siemens\\Automation\\Portal V18\\Bin\\Siemens.Automation.Portal.exe"
sys.path.append(dll_path)
# -----------------------------------------------------------------------------------------------------------


# -----------------------------------------------------------------------------------------------------------
# DLL usage
# -----------------------------------------------------------------------------------------------------------
# name must be usable by python, not i.e. "09.Some text"
clr.AddReference("TiaTest")

# ------------------------------------------------------------------------
# --- Trying the class that implements the interface and it is working ---
# ------------------------------------------------------------------------
# Name of the namespace is "TiaTest.Core"
# from TiaTest.Core import *

# The name of the class is "TiaController" and it is public
# new_instance = TiaController()

# ------------------------------------------------------------------------
# -- Trying the interface, and it is not working --
# ------------------------------------------------------------------------
# Name of the namespace is "TiaTest.Core.Contracts"
# from TiaTest.Core.Contracts import *

# The name of the interface is "ITiaController" and it is public
# new_instance = ITiaController()

# ------------------------------------------------------------------------
# --- Create a python class that inherits (implements) the interface ---
# ------------------------------------------------------------------------
# Name of the namespace is "TiaTest.Core.Contracts"
from TiaTest.Core.Contracts import *

# The name of the interface is "ITiaController" and it is public
class TiaController(ITiaController):
    def __init__(self):
        pass

    def CreateTiaInstance(self, isVisible):
        print("CreateTiaInstance")

    def OpenProject(self, projectDirPath, projectFilePath):
        print("OpenProject")

    def CloseProjectAndTia(self, locationOfTiaExe):
        print("CloseProjectAndTia")


new_instance = TiaController()

# -----------------------------------------------------------------------------------------------------------


# -----------------------------------------------------------------------------------------------------------
# Usage of the class
# -----------------------------------------------------------------------------------------------------------
# Start Tia portal
new_instance.CreateTiaInstance(True)
sleep(1)

# Open project
new_instance.OpenProject(project_dir_path, project_file_path)
sleep(5)

# Close project and Tia Portal
new_instance.CloseProjectAndTia(locationOfTiaExe)
# -----------------------------------------------------------------------------------------------------------
