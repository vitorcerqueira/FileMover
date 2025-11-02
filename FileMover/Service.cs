using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FileMover
{
    public class Service
    {
        public static bool validaSubMalhaSul(string valor)
        {
            HashSet<string> valoresPermitidos = new HashSet<string>();

            valoresPermitidos.Add("Sub 01");
            valoresPermitidos.Add("Sub 02");
            valoresPermitidos.Add("Sub 03");
            valoresPermitidos.Add("Sub 04");
            valoresPermitidos.Add("Sub 05");
            valoresPermitidos.Add("Sub 06");
            valoresPermitidos.Add("Sub 07");
            valoresPermitidos.Add("Sub 08");
            valoresPermitidos.Add("Sub 09");
            valoresPermitidos.Add("Sub 10");
            valoresPermitidos.Add("Sub 11");
            valoresPermitidos.Add("Sub 12");
            valoresPermitidos.Add("Sub 13");
            valoresPermitidos.Add("Sub 14");
            valoresPermitidos.Add("Sub 15");
            valoresPermitidos.Add("Sub 16");
            valoresPermitidos.Add("Sub 17");
            valoresPermitidos.Add("Sub 18");
            valoresPermitidos.Add("Sub 19");
            valoresPermitidos.Add("Sub 20");
            valoresPermitidos.Add("Sub 21");
            valoresPermitidos.Add("Sub 22");
            valoresPermitidos.Add("Sub 23");
            valoresPermitidos.Add("Sub 24");
            valoresPermitidos.Add("Sub 25");
            valoresPermitidos.Add("Sub 26");
            valoresPermitidos.Add("Sub 27");
            valoresPermitidos.Add("Sub 28");
            valoresPermitidos.Add("Sub 29");
            valoresPermitidos.Add("Sub 30");
            valoresPermitidos.Add("Sub 31");
            valoresPermitidos.Add("Sub 32");
            valoresPermitidos.Add("Sub 33");
            valoresPermitidos.Add("Sub 34");
            valoresPermitidos.Add("Sub 35");
            valoresPermitidos.Add("Sub 36");
            valoresPermitidos.Add("Sub 37");
            valoresPermitidos.Add("Sub 38");
            valoresPermitidos.Add("Sub 39");
            valoresPermitidos.Add("Sub 40");
            valoresPermitidos.Add("Sub 41");
            valoresPermitidos.Add("Sub 45");

            return valoresPermitidos.Contains(valor);
        }

        public static string getTamanhoFile(double tamanhoMB = 0)
        {
            string tamanhoFileSource = $"{Math.Round(tamanhoMB / (1024.0 * 1024.0), 2)} MB";

            return (tamanhoFileSource);
        }

        public static string getPathDisciplinaDestino(string disciplina)
        {
            /*
                01. Pontes = PT 
                02. Infraestrutura = AT = ATERRO / SM = SEÇAO MISTA / CT = CORTE / BU = BUEIRO / CO = CONTENÇAO 
                03. PNs = PN
                04. Túneis = TU  
            */

            if (disciplina.ToUpper().Equals("PT"))
            {
                return "01. Pontes";
            }
            else if (disciplina.ToUpper().Equals("AT"))
            {
                return "02. Infraestrutura";
            }
            else if (disciplina.ToUpper().Equals("SM"))
            {
                return "02. Infraestrutura";
            }
            else if (disciplina.ToUpper().Equals("CT"))
            {
                return "02. Infraestrutura";
            }
            else if (disciplina.ToUpper().Equals("BU"))
            {
                return "02. Infraestrutura";
            }
            else if (disciplina.ToUpper().Equals("CO"))
            {
                return "02. Infraestrutura";
            }
            else if (disciplina.ToUpper().Equals("PN"))
            {
                return "03. PNs";
            }
            else if (disciplina.ToUpper().Equals("TU"))
            {
                return "04. Túneis";
            }

            return "";
        }

        public static (string sub, string km, string ano, string disciplina, string modalidade, string nomePastaFoto) ProcessPathParts(string[] pathFilePart, int posPathSource)
        {
            string sub = ExtractSub(pathFilePart, posPathSource);
            string km = ExtractKm(pathFilePart, posPathSource);
            string disciplina = ExtractDisciplina(pathFilePart, posPathSource);
            string ano = ExtractYear(pathFilePart, posPathSource);
            string modalidade = ExtractModalidade(pathFilePart, posPathSource);
            string nomePastaFoto = ExtractNomePastaFoto(pathFilePart, posPathSource);

            return (sub, km, ano, disciplina, modalidade, nomePastaFoto);
        }

        public static string ExtractNomePastaFoto(string[] pathFilePart, int posPathSource)
        {
            string[] formatos =
            {
                "yyyy-MM-dd", "yyyyMMdd", "dd-MM-yyyy", "dd.MM.yyyy", "dd_MM_yyyy"
            };

            foreach (var namePath in pathFilePart.Skip(posPathSource))
            {
                foreach (var formato in formatos)
                {
                    var match = Regex.Match(namePath, "(\\d{4}-\\d{2}-\\d{2})|(\\d{8})|(\\d{2}-\\d{2}-\\d{4})|(\\d{2}\\.\\d{2}\\.\\d{4})|(\\d{2}_\\d{2}_\\d{4})");

                    if (match.Success && DateTime.TryParseExact(match.Value, formato, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime data))
                    {
                        return $"foto_{data:yyyy-MM-dd}";
                    }
                }
            }

            return "";
        }

        public static string ExtractYear(string[] pathFilePart, int posPathSource)
        {
            foreach (var namePath in pathFilePart.Skip(posPathSource))
            {
                string regexDot = @"(19|20)\d{2}";

                if (Regex.IsMatch(namePath, regexDot))
                {
                    return Regex.Match(namePath, regexDot).Value;
                }
            }

            return "";
        }

        public static string ExtractSub(string[] pathFilePart, int posPathSource)
        {
            foreach (var namePath in pathFilePart.Skip(posPathSource))
            {
                if (namePath.StartsWith("sub", StringComparison.CurrentCultureIgnoreCase) && !namePath.Contains("km", StringComparison.CurrentCultureIgnoreCase))
                {
                    string numericPart = new string(namePath.Where(char.IsDigit).ToArray());
                    return int.TryParse(numericPart, out int number) ? $"Sub {number:00}" : namePath;
                }
            }
            return "";
        }

        public static string ExtractKm(string[] pathFilePart, int posPathSource)
        {
            foreach (var namePath in pathFilePart.Skip(posPathSource))
            {
                if (namePath.StartsWith("km", StringComparison.CurrentCultureIgnoreCase))
                {
                    //string[] namePathList = namePath.Split(' ');

                    //if (namePathList.Length > 0)
                    //{
                    //    return namePathList[0] + " " + (namePathList.Length > 1 ? namePathList[1] : "");
                    //}

                    return namePath;
                }
            }

            return "";
        }

        public static string ExtractDisciplina(string[] pathFilePart, int posPathSource)
        {
            foreach (var namePath in pathFilePart.Skip(posPathSource))
            {
                if (namePath.StartsWith("km", StringComparison.CurrentCultureIgnoreCase))
                {
                    string[] namePathList = namePath.Split(' ');

                    return namePathList.Length == 3 ? namePathList[^1] : "";
                }
            }

            return "";
        }

        public static string ExtractModalidade(string[] pathFilePart, int posPathSource)
        {
            for (int i = posPathSource; i < pathFilePart.Length - 1; i++)
            {
                string namePathFile = pathFilePart[i];

                // primeira tentativa
                if (!namePathFile.StartsWith("sub", StringComparison.CurrentCultureIgnoreCase) && !namePathFile.StartsWith("km", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (namePathFile.StartsWith("Inspeção", StringComparison.CurrentCultureIgnoreCase))
                    {
                        return "01. Inspeções";
                    }

                    if (namePathFile.StartsWith("Sinalização", StringComparison.CurrentCultureIgnoreCase))
                    {
                        return "02. Sinalização";
                    }
                }
            }
            ;

            return "01. Inspeções"; // default
        }

        public static string GetPathUntil(string path, string find)
        {
            string[] list = path.Split("\\");

            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].ToUpper().StartsWith(find.ToUpper()))
                {
                    return list[i];
                }
            }

            return "";
        }

        public static string GetPathUntil2(string path, string find)
        {
            string[] list = path.Split("\\");
            string aux = "";

            for (int i = 0; i < list.Length; i++)
            {
                aux += list[i] + "\\";

                if (list[i].ToUpper().StartsWith(find.ToUpper()))
                {
                    return aux;
                }
            }

            return "";
        }
    }
}