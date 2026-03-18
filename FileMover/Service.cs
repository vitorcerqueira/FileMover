using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileMover
{
    public class Service
    {
        public class InfraKmRange
        {
            public string Sub { get; set; } = string.Empty;
            public string EquipInfra { get; set; } = string.Empty;
            public double KmInicio { get; set; }
            public double KmFim { get; set; }
        }

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

            return tamanhoFileSource;
        }

        public static string getPathDisciplinaDestino(string disciplina)
        {
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
                    string[] namePathList = namePath.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    return namePathList.Length >= 2 ? namePathList[^1] : "";
                }
            }

            return "";
        }

        public static string ExtractModalidade(string[] pathFilePart, int posPathSource)
        {
            for (int i = posPathSource; i < pathFilePart.Length - 1; i++)
            {
                string namePathFile = pathFilePart[i];

                if (!namePathFile.StartsWith("sub", StringComparison.CurrentCultureIgnoreCase) &&
                    !namePathFile.StartsWith("km", StringComparison.CurrentCultureIgnoreCase))
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

            return "01. Inspeções";
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

        public static string[] GetArquivosOrigem(string caminho)
        {
            string[] resultado = Array.Empty<string>();

            using (Form loadingForm = new Form())
            {
                loadingForm.Text = "Aguarde...";
                loadingForm.StartPosition = FormStartPosition.CenterScreen;
                loadingForm.Size = new System.Drawing.Size(250, 100);
                loadingForm.ControlBox = false;
                loadingForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                loadingForm.TopMost = true;

                Label label = new Label()
                {
                    Text = "Aguarde carregando arquivos...",
                    AutoSize = true,
                    Location = new System.Drawing.Point(35, 20)
                };

                loadingForm.Controls.Add(label);
                loadingForm.Shown += async (sender, e) =>
                {
                    resultado = await Task.Run(() =>
                        Directory.GetFiles(caminho, "*", SearchOption.AllDirectories)
                            .Where(arquivo =>
                            {
                                FileAttributes atributos = File.GetAttributes(arquivo);
                                bool ret = (atributos & FileAttributes.Hidden) == 0 &&
                                           (atributos & FileAttributes.System) == 0;

                                return ret;
                            })
                            .OrderBy(arquivo => arquivo, StringComparer.OrdinalIgnoreCase)
                            .ToArray());

                    loadingForm.Close();
                };

                loadingForm.ShowDialog();
            }

            return resultado;
        }

        public static List<InfraKmRange> LoadInfraKmRanges(string planilhaPath)
        {
            if (!File.Exists(planilhaPath))
            {
                throw new FileNotFoundException("Planilha não encontrada.", planilhaPath);
            }

            using var workbook = new XLWorkbook(planilhaPath);
            var worksheet = workbook.Worksheets.FirstOrDefault(ws => ws.RangeUsed() != null)
                ?? throw new InvalidOperationException("Nenhuma aba com dados foi encontrada na planilha.");

            var headerRow = worksheet.FirstRowUsed()
                ?? throw new InvalidOperationException("Não foi possível localizar o cabeçalho da planilha.");

            var headers = headerRow.CellsUsed()
                .ToDictionary(
                    cell => NormalizeHeader(cell.GetString()),
                    cell => cell.Address.ColumnNumber);

            if (!headers.TryGetValue("SUB", out int subColumn) ||
                !headers.TryGetValue("EQUIP_INFRA", out int equipColumn) ||
                !headers.TryGetValue("KM INICIO", out int kmInicioColumn) ||
                !headers.TryGetValue("KM FIM", out int kmFimColumn))
            {
                throw new InvalidOperationException("A planilha precisa conter as colunas SUB, EQUIP_INFRA, KM INICIO e KM FIM.");
            }

            var ranges = new List<InfraKmRange>();

            foreach (var row in worksheet.RowsUsed().Skip(1))
            {
                string sub = row.Cell(subColumn).GetString().Trim();
                string equipInfra = row.Cell(equipColumn).GetString().Trim();

                if (string.IsNullOrWhiteSpace(sub) || string.IsNullOrWhiteSpace(equipInfra))
                {
                    continue;
                }

                string kmInicioText = row.Cell(kmInicioColumn).GetFormattedString();
                string kmFimText = row.Cell(kmFimColumn).GetFormattedString();

                if (!TryParseKilometerValue(kmInicioText, out double kmInicio))
                {
                    continue;
                }

                if (!TryParseKilometerValue(kmFimText, out double kmFim))
                {
                    continue;
                }

                if (kmFim < kmInicio)
                {
                    (kmInicio, kmFim) = (kmFim, kmInicio);
                }

                ranges.Add(new InfraKmRange
                {
                    Sub = sub,
                    EquipInfra = equipInfra,
                    KmInicio = kmInicio,
                    KmFim = kmFim
                });
            }

            return ranges.OrderBy(item => item.KmInicio).ToList();
        }

        public static bool TryFindEquipInfra(string kmFolderName, IEnumerable<InfraKmRange> ranges, out string equipInfra)
        {
            equipInfra = string.Empty;

            if (!TryFindInfraKmRange(kmFolderName, ranges, out InfraKmRange match))
            {
                return false;
            }

            equipInfra = match.EquipInfra;
            return true;
        }

        public static bool TryFindInfraKmRange(string kmFolderName, IEnumerable<InfraKmRange> ranges, out InfraKmRange range)
        {
            range = null;

            if (!TryParseKilometerValue(kmFolderName, out double kmValue))
            {
                return false;
            }

            var match = ranges.FirstOrDefault(item => kmValue >= item.KmInicio && kmValue <= item.KmFim);

            if (match == null)
            {
                return false;
            }

            range = match;
            return true;
        }

        public static bool TryParseKilometerValue(string input, out double value)
        {
            value = 0;

            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            string normalized = input.Trim();

            var plusMatch = Regex.Match(normalized, @"(\d+)\s*\+\s*(\d+)");
            if (plusMatch.Success)
            {
                string km = plusMatch.Groups[1].Value;
                string meters = plusMatch.Groups[2].Value.PadLeft(3, '0');
                string text = $"{km}.{meters}";

                return double.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out value);
            }

            normalized = normalized
                .Replace("Km", "", StringComparison.OrdinalIgnoreCase)
                .Replace("KM", "", StringComparison.OrdinalIgnoreCase)
                .Trim();

            var decimalMatch = Regex.Match(normalized, @"\d+(?:[.,]\d+)?");
            if (!decimalMatch.Success)
            {
                return false;
            }

            string decimalText = decimalMatch.Value.Replace(',', '.');
            return double.TryParse(decimalText, NumberStyles.Any, CultureInfo.InvariantCulture, out value);
        }

        private static string NormalizeHeader(string header)
        {
            return Regex.Replace(header ?? string.Empty, @"\s+", " ").Trim().ToUpperInvariant();
        }
    }
}
