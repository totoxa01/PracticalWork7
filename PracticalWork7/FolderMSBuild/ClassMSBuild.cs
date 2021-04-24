using System;
using System.Collections.Generic;
using System.Text;

namespace PracticalWork7.FolderMSBuild
{
    class ClassMSBuild
    {
        public static void WorkMethod()
        {
            Console.WriteLine($"Результат выражения: (a > b) && (c < b) = "
                + MethodForMSBuild(DataEntryA(), DataEntryB(), DataEntryC()));
        }
        
        private static bool MethodForMSBuild(int a, int b, int c)
        {
            bool x = (a > b) && (c < b);
            return x;
        }

        private static int DataEntryA()
        {
            Console.Write("Ввеедите a = ");
            int a = Int32.Parse(Console.ReadLine());           
            return a;                
        }
        private static int DataEntryB()
        {            
            Console.Write("Ввеедите b = ");           
            int b = Int32.Parse(Console.ReadLine());
            return b;            
        }
        private static int DataEntryC()
        {           
            Console.Write("Ввеедите c = ");
            int c = Int32.Parse(Console.ReadLine());
            return c;
        }


        /*------------------------------Отчет по MSBuild---------------------------------
         * C:\Program Files (x86)\Microsoft Visual Studio\2019\Community>cd C:\Users\Totiki\YandexDisk\GeekBrains\C#\PracticalWork7

        C:\Users\Totiki\YandexDisk\GeekBrains\C#\PracticalWork7>msbuild PracticalWork7
        Microsoft (R) Build Engine версии 16.8.2+25e4d540b для .NET Framework
        (C) Корпорация Майкрософт (Microsoft Corporation). Все права защищены.

        Сборка начата 24.04.2021 13:19:04.
        Проект "C:\Users\Totiki\YandexDisk\GeekBrains\C#\PracticalWork7\PracticalWork7\PracticalWork7.csproj" в узле 1 (целевые
         объекты по умолчанию).
        GenerateTargetFrameworkMonikerAttribute:
        Целевой объект "GenerateTargetFrameworkMonikerAttribute" пропускается, так как все выходные файлы актуальны по отношени
        ю к входным.
        CoreGenerateAssemblyInfo:
        Целевой объект "CoreGenerateAssemblyInfo" пропускается, так как все выходные файлы актуальны по отношению к входным.
        CoreCompile:
        Целевой объект "CoreCompile" пропускается, так как все выходные файлы актуальны по отношению к входным.
        _CreateAppHost:
        Целевой объект "_CreateAppHost" пропускается, так как все выходные файлы актуальны по отношению к входным.
        _CopyOutOfDateSourceItemsToOutputDirectory:
        Целевой объект "_CopyOutOfDateSourceItemsToOutputDirectory" пропускается, так как все выходные файлы актуальны по отнош
        ению к входным.
        GenerateBuildDependencyFile:
        Целевой объект "GenerateBuildDependencyFile" пропускается, так как все выходные файлы актуальны по отношению к входным.
        GenerateBuildRuntimeConfigurationFiles:
        Целевой объект "GenerateBuildRuntimeConfigurationFiles" пропускается, так как все выходные файлы актуальны по отношению
         к входным.
        CopyFilesToOutputDirectory:
          PracticalWork7 -> C:\Users\Totiki\YandexDisk\GeekBrains\C#\PracticalWork7\PracticalWork7\bin\Debug\netcoreapp3.1\Prac
          ticalWork7.dll
        Сборка проекта "C:\Users\Totiki\YandexDisk\GeekBrains\C#\PracticalWork7\PracticalWork7\PracticalWork7.csproj" завершена
         (целевые объекты по умолчанию).


        Сборка успешно завершена.
            Предупреждений: 0
            Ошибок: 0

        Прошло времени 00:00:00.61
         */

    }
}
