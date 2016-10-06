using System.Reflection;

[assembly: AssemblyDescription("Adds support for a Maybe type")]
[assembly: AssemblyCompany("Stugo Ltd")]
[assembly: AssemblyProduct("Stugo.Maybe")]
[assembly: AssemblyCopyright("Copyright © Stugo Ltd 2016")]

#if DEBUG
[assembly: AssemblyConfiguration("DEBUG")]
#else
[assembly: AssemblyConfiguration("RELEASE")]
#endif