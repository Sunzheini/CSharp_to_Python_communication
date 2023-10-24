using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

//namespace Festo.MoKAsin.StdFunc.CommonHelpers
namespace TiaTest3
{
    /// <summary>
    /// Load dynamically all dependencies of a dll file. All dependencies and also their dependencies will be loaded recursive till all dependencies are loaded.
    /// </summary>
    public static class DynamicDependencyLoader
    {
        private static List<string> _assemblyList;

        /// <summary>
        /// The Method Load all Dependencies in the Runtime of the Project.
        /// </summary>
        /// <param name="dllFilePath">Complete Path with File Name and extension (e.g.: C:/.../UnitTests.dll)</param>
        /// <exception cref="FileNotFoundException">No File Found under the <paramref name="dllFilePath"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Complete Path with File Name and extension is no *.dll</exception>
        public static void Load(string dllFilePath)
        {
            if (!File.Exists(dllFilePath))
            {
                throw new FileNotFoundException(dllFilePath);
            }

            if (Path.GetExtension(dllFilePath)?.ToLower() != ".dll")
            {
                throw new ArgumentOutOfRangeException(nameof(dllFilePath), "file hast to be *.dll");
            }

            LoadAppDomainDependencies();
            var assembly = Assembly.LoadFrom(dllFilePath);
            LoadDependecies(assembly, Path.GetDirectoryName(dllFilePath));
        }

        private static void LoadAppDomainDependencies()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            AddToAsseblyList(assemblies);
            foreach (var assembly in assemblies)
            {
                LoadDependecies(assembly, null);
            }
        }

        private static void LoadDependecies(Assembly assembly, string appBasePath)
        {
            if (assembly == null)
            {
                return;
            }

            var referenced = assembly.GetReferencedAssemblies();

            if (referenced.Length == 0)
            {
                return;
            }

            foreach (var assemblyName in referenced)
            {
                //Console.WriteLine("Check: " + assemblyName.FullName);


                if (!AddToAsseblyList(assemblyName.FullName))
                {
                    continue;
                }

                try
                {
                    var tmpAssembly = Assembly.Load(assemblyName);
                    LoadDependecies(tmpAssembly, appBasePath);
                }
#pragma warning disable 168
                catch (Exception e)
#pragma warning restore 168
                {
                    if (String.IsNullOrEmpty(appBasePath))
                    {
                        throw new ArgumentNullException(nameof(appBasePath));
                    }
                    var dllPath = Path.Combine(appBasePath, assemblyName.Name + ".dll");

                    if (File.Exists(dllPath))
                    {
                        var tmpAssembly = Assembly.LoadFrom(dllPath);
                        LoadDependecies(tmpAssembly, appBasePath);
                    }
                    else
                    {
                        throw new FileNotFoundException("Find no Assembly with Name: " + assemblyName.Name + ".dll");
                    }
                }
            }
        }

        private static bool AddToAsseblyList(string assemblyFullName)
        {
            if (String.IsNullOrEmpty(assemblyFullName))
            {
                return false;
            }

            if (_assemblyList == null)
            {
                _assemblyList = new List<string>();
            }

            if (_assemblyList.Contains(assemblyFullName))
            {
                return false;
            }

            _assemblyList.Add(assemblyFullName);
            Console.WriteLine("Add: " + assemblyFullName);
            return true;
        }

        private static void AddToAsseblyList(Assembly assembly)
        {
            if (assembly == null)
            {
                return;
            }

            if (_assemblyList == null)
            {
                _assemblyList = new List<string>();
            }

            if (_assemblyList.Contains(assembly.FullName))
            {
                return;
            }

            _assemblyList.Add(assembly.FullName);
        }

        private static void AddToAsseblyList(Assembly[] assemblies)
        {
            if (assemblies == null)
            {
                return;
            }

            if (assemblies.Length == 0)
            {
                return;
            }

            foreach (var assembly in assemblies)
            {
                AddToAsseblyList(assembly);
            }
        }
    }
}