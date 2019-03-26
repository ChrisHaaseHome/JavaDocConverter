using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JavaDocConverter
{
    class Reference
    {
        private static readonly Dictionary<String, String> FolderLookUp = new Dictionary<string, string>
        {
            { "olf_mts_jvs_docs", "MTS"},
            { "olf_openjvs_acs_accounting_docs", "Accounting"},
            { "olf_openjvs_automatch_docs", "Auto Match"},
            { "olf_openjvs_docs", "Open JVS"},
            { "olf_openjvs_ops_dashboard_docs", "Dashboard"},
            { "olf_openjvs_report_builder_docs", "Report Builder"},
            { "olf_openjvs_tpm_docs", "TPM"},
            { "olf_payment_auth_jvs_docs", "Payment Authorization"},
            { "OlStandard_Include_doc", "Standard Include"}
        };

        public static void Process(string folderPath, string targetFolder)
        {
            List<string> indexList = new List<string>();

            RecreateFolders(folderPath, targetFolder, indexList);
            for (int index = 0; index < indexList.Count; index++)
            {
                String cutOff = indexList[index].Substring(targetFolder.Length + 1); //+2 to handle the "\\"
                indexList[index] = cutOff;
            }

            return;
        }

        private static void RecreateFolders(String filePath, String destPath, List<string> indexList)
        {
            Directory.CreateDirectory(destPath);

            DirectoryInfo dir = new DirectoryInfo(filePath);
            DirectoryInfo[] dirs = dir.GetDirectories();

            for (int index = 0; index < dirs.Length; index++)
            {
                DirectoryInfo folder = dirs[index];
                String dirString = destPath + "\\" + folder.Name;
                RecreateFolders(folder.FullName, dirString, indexList);
            }

            RecreateFiles(filePath, destPath, indexList);
            return;
        }

        private static void RecreateFiles(string filePath, string destPath, List<string> indexList)
        {
            string[] files = Directory.GetFiles(filePath);

            foreach (string fullFileName in files)
            {
                FileInfo fileInfo = new FileInfo(fullFileName);
                String ext = Path.GetExtension(fileInfo.ToString());

                if (ext.Equals(".html"))
                {
                    string destFile = destPath + "\\" + Path.GetFileNameWithoutExtension(fileInfo.ToString()) + ".aspx";
                    File.Copy(fullFileName, destFile);
                    ReplaceTextInFiles(destFile);

                    if (Path.GetFileName(fullFileName).Equals("index.html"))
                    {
                        indexList.Add(destFile);
                    }

                }
                else
                {
                    string destFile = destPath + "\\" + fileInfo.Name;
                    File.Copy(fullFileName, destFile);
                }
            }

        }

        private static void ReplaceTextInFiles(String filePath)
        {
            String file = File.ReadAllText(filePath);
            file = file.Replace(".html", ".aspx");
            File.WriteAllText(filePath, file);
            return;
        }


        private static void GetHtmlName(List<string> indexList, int index, StringBuilder htmlBuilder)
        {
            String lookupValue;
            int endIndex = indexList[index].IndexOf("\\", StringComparison.Ordinal);
            String tpmString = indexList[index].Substring(0, endIndex);
            String key = tpmString;
            if (FolderLookUp.TryGetValue(key, out lookupValue))
            {
                htmlBuilder.Append(lookupValue);
            }

            return;
        }
    }
}
