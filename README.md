I. test1.py:
1. Successfully tested using the .dll from a Class Library .Net Framework 
project using clr python package. Take care of the paths and have an available Tia Portal project.

II. test2.py:
1. Trying to test with a WPF Application and a Console App, which are .Net Framework projects.
**However, the .dll is not generated in the bin folder.**
2. There is the option to use ILMerge: https://github.com/dotnet/ILMerge, 
however I have not tried it. Also, I have encountered the option: SignalR

III. test3.py ():
1.  A dll is generated if the App is not a .Net Framework project (i.e. for a Console App)! So trying with a console
app which is not a .Net Framework project. 
**But using Siemens dlls gives errors1**

IV. test4.py ():
1. Inside the CLass Library .Net Framework now I have included an interface and another class which implements
the interface. The class itself can be used similar to test1, however the interface cannot. The
only option is inside the python code to use the class that implements the interface.



