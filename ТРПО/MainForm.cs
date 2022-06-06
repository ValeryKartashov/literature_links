using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Application = Microsoft.Office.Interop.Word.Application;

namespace TRPO_Kartashov_AS41
{
    public partial class MainForm : Form
    {
        private readonly List<string> LinksInTextList = new List<string>();
        private string FileText, FileTextFromLinksListToEnd;
        private bool FileTextContainsLinksList;
        private int LinksInTextAmount;
        private int LinksListPosition;
        private int ApplicationTextPosition;
        private int LastFileCheckingPosition;
        private static int LinksAmountInLinksList;

        #region Constructor

        public MainForm()
        {
            InitializeComponent();
            pbFileReading.Value = 0;
            Text = "Ожидание выбора файла";
        }

        #endregion

        #region Method

        private void CurrentPositionLinkNumber(int i)
        {
            var result = string.Empty;

            // [x]
            if (FileText[i] is '[' &&
                char.IsDigit(FileText[i + 1]) &&
                FileText[i + 2] is ']')
            {
                result = FileText[i + 1].ToString();
                LinksInTextAmount++;
                LinksInTextList.Add(result);
            }

            // [xy]
            if (FileText[i] is '[' &&
                char.IsDigit(FileText[i + 1]) &&
                char.IsDigit(FileText[i + 2]) &&
                FileText[i + 3] is ']')
            {
                result = FileText[i + 1] + FileText[i + 2].ToString();
                LinksInTextAmount++;
                LinksInTextList.Add(result);
            }

            // [x-y]
            if (FileText[i] is '[' &&
                char.IsDigit(FileText[i + 1]) &&
                FileText[i + 2] is '-' &&
                char.IsDigit(FileText[i + 3]) &&
                FileText[i + 4] is ']')
                for (int j = int.Parse(FileText[i + 1].ToString()); j <= int.Parse(FileText[i + 3].ToString()); j++)
                {
                    LinksInTextAmount++;
                    LinksInTextList.Add(j.ToString());
                }

            // [x-yy]
            if (FileText[i] is '[' &&
                char.IsDigit(FileText[i + 1]) &&
                FileText[i + 2] is '-' &&
                char.IsDigit(FileText[i + 3]) &&
                char.IsDigit(FileText[i + 4]) &&
                FileText[i + 5] is ']')
            {
                string secondNumber = FileText[i + 3] + FileText[i + 4].ToString();
                for (int j = int.Parse(FileText[i + 1].ToString()); j <= int.Parse(secondNumber); j++)
                {
                    LinksInTextAmount++;
                    LinksInTextList.Add(j.ToString());
                }
            }

            // [xx-yy]
            if (FileText[i] is '[' &&
                char.IsDigit(FileText[i + 1]) &&
                char.IsDigit(FileText[i + 2]) &&
                FileText[i + 3] is '-' &&
                char.IsDigit(FileText[i + 4]) &&
                char.IsDigit(FileText[i + 5]) &&
                FileText[i + 6] is ']')
            {
                string firstNumber = FileText[i + 1] + FileText[i + 2].ToString();
                string secondNumber = FileText[i + 3] + FileText[i + 4].ToString();
                for (int j = int.Parse(firstNumber); j <= int.Parse(secondNumber); j++)
                {
                    LinksInTextAmount++;
                    LinksInTextList.Add(j.ToString());
                }
            }

            // [x,y]
            if (FileText[i] is '[' &&
                char.IsDigit(FileText[i + 1]) &&
                FileText[i + 2] is ',' &&
                char.IsDigit(FileText[i + 3]) &&
                FileText[i + 4] is ']')
            {
                LinksInTextAmount++;
                LinksInTextList.Add(FileText[i + 1].ToString());
                LinksInTextAmount++;
                LinksInTextList.Add(FileText[i + 3].ToString());
            }

            // [x, y]
            if (FileText[i] is '[' &&
                char.IsDigit(FileText[i + 1]) &&
                FileText[i + 2] is ',' &&
                FileText[i + 3] is ' ' &&
                char.IsDigit(FileText[i + 4]) &&
                FileText[i + 5] is ']')
            {
                LinksInTextAmount++;
                LinksInTextList.Add(FileText[i + 1].ToString());
                LinksInTextAmount++;
                LinksInTextList.Add(FileText[i + 4].ToString());
            }

            // [x,yy]
            if (FileText[i] is '[' &&
                char.IsDigit(FileText[i + 1]) &&
                FileText[i + 2] is ',' &&
                char.IsDigit(FileText[i + 3]) &&
                char.IsDigit(FileText[i + 4]) &&
                FileText[i + 5] is ']')
            {
                LinksInTextAmount++;
                LinksInTextList.Add(FileText[i + 1].ToString());
                string secondNumber = FileText[i + 3] + FileText[i + 4].ToString();
                LinksInTextAmount++;
                LinksInTextList.Add(secondNumber);
            }

            // [x, yy]
            if (FileText[i] is '[' &&
                char.IsDigit(FileText[i + 1]) &&
                FileText[i + 2] is ',' &&
                FileText[i + 3] is ' ' &&
                char.IsDigit(FileText[i + 4]) &&
                char.IsDigit(FileText[i + 5]) &&
                FileText[i + 6] is ']')
            {
                LinksInTextAmount++;
                LinksInTextList.Add(FileText[i + 1].ToString());
                string secondNumber = FileText[i + 4] + FileText[i + 5].ToString();
                LinksInTextAmount++;
                LinksInTextList.Add(secondNumber);
            }

            // [xx,yy]
            if (FileText[i] is '[' &&
                char.IsDigit(FileText[i + 1]) &&
                char.IsDigit(FileText[i + 2]) &&
                FileText[i + 3] is ',' &&
                char.IsDigit(FileText[i + 4]) &&
                char.IsDigit(FileText[i + 5]) &&
                FileText[i + 6] is ']')
            {
                string firstNumber = FileText[i + 1] + FileText[i + 2].ToString();
                LinksInTextAmount++;
                LinksInTextList.Add(firstNumber);
                string secondNumber = FileText[i + 4] + FileText[i + 5].ToString();
                LinksInTextAmount++;
                LinksInTextList.Add(secondNumber);
            }

            // [xx, yy]
            if (FileText[i] is '[' &&
                char.IsDigit(FileText[i + 1]) &&
                char.IsDigit(FileText[i + 2]) &&
                FileText[i + 3] is ',' &&
                FileText[i + 4] is ' ' &&
                char.IsDigit(FileText[i + 5]) &&
                char.IsDigit(FileText[i + 6]) &&
                FileText[i + 7] is ']')
            {
                string firstNumber = FileText[i + 1] + FileText[i + 2].ToString();
                LinksInTextAmount++;
                LinksInTextList.Add(firstNumber);
                string secondNumber = FileText[i + 5] + FileText[i + 6].ToString();
                LinksInTextAmount++;
                LinksInTextList.Add(secondNumber);
            }
        }

        private static bool LinksUsedCorrectly(List<string> list)
        {
            var LinksInLinksList = new List<int>();
            for (var i = 1; i <= LinksAmountInLinksList; i++)
                LinksInLinksList.Add(i);
            
            var LinksAlreadyPassed = new List<string>();
            var currentPosition = 0;

            foreach (string item in list)
            {
                if (LinksInLinksList.Contains(int.Parse(item)))
                    LinksAlreadyPassed.Add(item);

                if (currentPosition > 0 && int.Parse(list[currentPosition]) < int.Parse(list[currentPosition - 1]) && LinksAlreadyPassed.Contains(list[currentPosition]) == false)
                    return false;

                currentPosition++;
            }

            return true;
        }

        private bool EveryLinkIsUsed()
        {
            var tempList = new List<string>();

            for (var i = 1; i <= LinksAmountInLinksList; i++)
                tempList.Add(i.ToString());

            foreach (string item in tempList)
                if (LinksInTextList.Contains(item) is false)
                    return false;

            return true;
        }

        private void openFileBtn_Click(object sender, EventArgs e)
        {
            btnClear_Click(null, null);
            try
            {
                using (var openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                    openFileDialog.Filter = ".Docx files (*.docx)|*.docx|.Doc files (*.doc)|*.doc";
                    if (openFileDialog.ShowDialog() is DialogResult.OK)
                    {
                        var wordApp = new Application();
                        Text = "Обработка файла";
                        Document wordDoc = wordApp.Documents.OpenNoRepairDialog(openFileDialog.FileName);
                        FileText = wordDoc.Content.Text;

                        string litListName;

                        if (FileText.Contains("СПИСОК ИСПОЛЬЗОВАННЫХ ИСТОЧНИКОВ"))
                        {
                            FileTextContainsLinksList = true;
                            litListName = "СПИСОК ИСПОЛЬЗОВАННЫХ ИСТОЧНИКОВ";
                        }

                        else if (FileText.Contains("БИБЛИОГРАФИЧЕСКИЙ СПИСОК"))
                        {
                            FileTextContainsLinksList = true;
                            litListName = "БИБЛИОГРАФИЧЕСКИЙ СПИСОК";
                        }

                        else if (FileText.Contains("СПИСОК ИСПОЛЬЗОВАННОЙ ЛИТЕРАТУРЫ"))
                        {
                            FileTextContainsLinksList = true;
                            litListName = "СПИСОК ИСПОЛЬЗОВАННОЙ ЛИТЕРАТУРЫ";
                        }

                        else if (FileText.Contains("СПИСОК ЛИТЕРАТУРЫ"))
                        {
                            FileTextContainsLinksList = true;
                            litListName = "СПИСОК ЛИТЕРАТУРЫ";
                        }

                        else
                        {
                            FileTextContainsLinksList = false;
                            wordApp.Quit(false);
                            btnClear_Click(null, null);
                            tbResult.Text = "В документе отсутствует список использованных источников";
                            return;
                        }

                        LinksListPosition = FileText.LastIndexOf(litListName, StringComparison.Ordinal);

                        for (int i = LinksListPosition; i < FileText.Length; i++)
                            FileTextFromLinksListToEnd += FileText[i];

                        if (FileTextFromLinksListToEnd.Contains("ПРИЛОЖЕНИЕ"))
                        {
                            ApplicationTextPosition =
                                FileTextFromLinksListToEnd.IndexOf("ПРИЛОЖЕНИЕ", StringComparison.Ordinal) + LinksListPosition;
                            pbFileReading.Maximum = ApplicationTextPosition;
                            LastFileCheckingPosition = ApplicationTextPosition;
                        }

                        else
                        {
                            pbFileReading.Maximum = FileText.Length;
                            LastFileCheckingPosition = FileText.Length;
                        }


                        for (var i = 0; i < LinksListPosition; i++)
                        {
                            CurrentPositionLinkNumber(i);
                            pbFileReading.Value++;
                        }

                        tbLinksAmountInText.Text = LinksInTextAmount.ToString();

                        foreach (string item in LinksInTextList)
                            tbTextLinksList.Text += item + ">";

                        tbLinksAmountInList.Text = "0";

                        var t = new Thread(new ThreadStart(delegate
                        {
                            Invoke(new ThreadStart(delegate
                            {
                                for (int i = LinksListPosition; i < LastFileCheckingPosition; i++)
                                {
                                    if (FileText[i] is '\r') LinksAmountInLinksList++;
                                    pbFileReading.Value++;
                                }

                                LinksAmountInLinksList--;

                                tbLinksAmountInList.Text = LinksAmountInLinksList.ToString();

                                if (LinksUsedCorrectly(LinksInTextList))
                                {
                                    Text = "Обработка файла завершена";
                                    tbResult.Text = "Порядок указания ссылок корректен. ";
                                }

                                else
                                {
                                    Text = "Обработка файла завершена";
                                    tbResult.Text =
                                        "В порядке указания источников допущена ошибка. Ссылки на источники должны использоваться в порядке возрастания. ";
                                }

                                if (EveryLinkIsUsed())
                                    tbResult.Text += "\r\nВсе ссылки из списка литературы использованы в тексте. ";
                                else
                                    tbResult.Text += "\r\nНе все ссылки из списка литературы использованы в тексте. ";

                                LinksInTextList.Clear();
                            }));
                            wordApp.Quit(false);
                        }));

                        if (FileTextContainsLinksList)
                            t.Start();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Text = "Ожидание выбора файла";
            tbLinksAmountInText.Text = string.Empty;
            tbLinksAmountInList.Text = string.Empty;
            tbResult.Text = string.Empty;
            tbTextLinksList.Text = string.Empty;
            FileTextFromLinksListToEnd = string.Empty;
            btnOpenFile.Focus();
            pbFileReading.Value = 0;
            LinksInTextList.Clear();
            LinksInTextAmount = 0;
            LinksAmountInLinksList = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        #endregion
    }
}