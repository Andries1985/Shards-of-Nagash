using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using Server;
using Server.Commands;

namespace Custom
{
    public class FileReader
    {
        public static readonly string MainDirectory = "Data\\Text Descriptions\\";

        static Dictionary<string, SortedDictionary<string, string>> m_LoadedFiles;
        public static Dictionary<string, SortedDictionary<string, string>> LoadedFiles { get { return m_LoadedFiles; } set { m_LoadedFiles = value; } }

        public static void Initialize()
        {
            LoadFiles();
            CommandSystem.Register("RED", AccessLevel.Administrator, new CommandEventHandler(ReloadExternalDocuments_Command));
            CommandSystem.Register("ReloadExternalDocuments", AccessLevel.Administrator, new CommandEventHandler(ReloadExternalDocuments_Command));
        }

        [Usage("RED")]
        [Aliases("ReloadExternalDocuments")]
        [Description("Reloads the description & MotD files.")]
        private static void ReloadExternalDocuments_Command(CommandEventArgs e)
        {
            m_LoadedFiles.Clear();
            LoadFiles();
            e.Mobile.SendMessage("External Documents Updated.");
        }

        public static void LoadFiles()
        {
            LoadDirectory(MainDirectory);
            Console.WriteLine();
        }

        public static void LoadDirectory(string directory)
        {
            if (m_LoadedFiles == null)
                m_LoadedFiles = new Dictionary<string, SortedDictionary<string, string>>();

            if (!Directory.Exists(directory))
            {
                Console.WriteLine("File Loader: Directory not found [{0}]", directory);
                return;
            }

            Console.Write("File Loader: Loading files in [{0}]...", directory);

            string[] foundfiles = Directory.GetFiles(directory);
            for (int i = 0; i < foundfiles.Length; i++)
                LoadFile(foundfiles[i]);

            Console.WriteLine(" Done.");

            string[] subdir = Directory.GetDirectories(directory);
            for (int i = 0; i < subdir.Length; i++)
                LoadDirectory(subdir[i]);
        }

        public static void LoadFile(string file)
        {
            if (!File.Exists(file))
            {
                Console.WriteLine("File Loader: File not found [{0}]", file);
                return;
            }

            string basedir, name, contents;
            name = file; basedir = contents = String.Empty;

            basedir = name.Remove(0, MainDirectory.Length);
            if (basedir.Contains("\\"))
                basedir = basedir.Remove(basedir.LastIndexOf("\\"));

            name = name.Remove(0, (name.LastIndexOf("\\") + 1));//strip dir path
            name = name.Remove(name.IndexOf("."));//strip file ext

            StreamReader reader = new StreamReader(file);
            StringBuilder builder = new StringBuilder();

            while (!reader.EndOfStream)
            {
                builder.Append(reader.ReadLine());
                builder.Append("\n");
            }

            reader.Close();
            contents = builder.ToString();

            SortedDictionary<string, string> info = new SortedDictionary<string, string>();
            info.Add(name, contents);
            if (!m_LoadedFiles.ContainsKey(basedir))
                m_LoadedFiles.Add(basedir, info);
            else
            {
                if (!m_LoadedFiles[basedir].ContainsKey(name))
                    m_LoadedFiles[basedir].Add(name, contents);
                else
                    m_LoadedFiles[basedir][name] += "\n" + "\n" + contents;
            }
        }

        public static int FileCount(string directory)
        {
            if (m_LoadedFiles.ContainsKey(directory))
                return m_LoadedFiles[directory].Count;
            else
                return 0;
        }

        public static string FileFromIndex(string directory, int index)
        {
            if (!m_LoadedFiles.ContainsKey(directory))
                return String.Empty;

            int i = 0;
            string treturn = string.Empty;
            foreach (KeyValuePair<string, string> files in m_LoadedFiles[directory])
            {
                if (i == index)
                    treturn = files.Value;

                i++;
            }

            return treturn;
        }
    }
}