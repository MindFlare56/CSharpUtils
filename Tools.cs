using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CSharpUtils
{

    static class Tools
    {

        public static void removeRandomElementFromList<T>(List<T> list, Random random)
        {
            int randomNumber = random.Next(0, list.Count);
            list.RemoveAt(randomNumber);
        }

        public static void removeRandomElementsFromList<T>(List<T> list, Random random, int occurence)
        {
            for (int i = 0; i < occurence; ++i)
            {
                int randomNumber = random.Next(0, list.Count);
                list.RemoveAt(randomNumber);
            }
        }

        public static void removeRandomElementsFromListUntil<T>(List<T> list, Random random, int size)
        {
            if (list.Count > size)
            {
                for (; list.Count != size;)
                {
                    int randomNumber = random.Next(0, list.Count);
                    list.RemoveAt(randomNumber);
                }
            }
        }

        public static void addListToComboBox<T>(ComboBox comboBox, List<T> list)
        {
            foreach (T element in list)
            {
                comboBox.Items.Add(element);
            }
        }

        public static void addAll<T>(List<T> from, List<T> to)
        {
            List<T> tempList = new List<T>();
            foreach (T t in from)
            {
                to.Add(t);
            }
        }

        public static void shuffle<T>(this IList<T> list, Random random)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static bool equalsIgnoreCase(String string1, String string2)
        {
            return string.Equals(string1, string2, StringComparison.OrdinalIgnoreCase);
        }

        public static void createFile(String path, String text_info)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                using (FileStream fs = File.Create(path))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(text_info);
                    fs.Write(info, 0, info.Length);
                }
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void createFile(String path)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void writeInFile(String path, String text)
        {
            using (StreamWriter writetext = new StreamWriter(path))
            {
                writetext.WriteLine(text);
            }
        }

        public static void rewriteInFile(String path, String text)
        {

            Tools.writeInFile(path, readInFile(path) + text);
        }

        public static String readInFile(String path)
        {
            using (StreamReader streamReader = new StreamReader(path))
            {
                return streamReader.ReadToEnd();
            }
        }

        public static bool fileExist(String path)
        {
            return File.Exists(path);
        }

        public static List<T> readJsonInFile<T>(String path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                List<T> items = JsonConvert.DeserializeObject<List<T>>(json);
                return items;
            }
        }

        public static void writeJsonInFile<T>(String path, List<T> data)
        {
            string json = JsonConvert.SerializeObject(data.ToArray());
            writeInFile(path, json);
        }
    }
}