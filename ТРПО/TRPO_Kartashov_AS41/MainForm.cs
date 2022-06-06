using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Application = Microsoft.Office.Interop.Word.Application;

namespace TRPO_Kartashov_AS41
{
    public partial class MainForm : Form
    {
        #region Переменные

        private readonly List<int> LinksInTextList = new List<int>();
        private string FileText, FileTextFromLinksListToEnd;
        private bool FileTextContainsLinksList;

        private int LinksInTextAmount,
            LinksListPosition,
            ApplicationTextPosition,
            LastFileCheckingPosition,
            LinksAmountInLinksList;

        #endregion

        #region Конструктор
        public MainForm()
        {
            InitializeComponent();
            pbFileReading.Value = 0;
            Text = "Ожидание выбора файла";
        }

        #endregion

        #region Методы
        private string CurrentPositionLinkNumber(int i)
        {
            if (FileText[i] == '[' && char.IsDigit(FileText[i + 1]) && FileText[i + 2] == ']')
                return FileText[i + 1].ToString();

            if (FileText[i] == '[' && char.IsDigit(FileText[i + 1]) && char.IsDigit(FileText[i + 2]) &&
                FileText[i + 3] == ']')
            {
                var temp = FileText[i + 1] + FileText[i + 2].ToString();
                return temp;
            }

            if (FileText[i] == '[' && char.IsDigit(FileText[i + 1]) && char.IsDigit(FileText[i + 2]) &&
                char.IsDigit(FileText[i + 3]) && FileText[i + 4] == ']')
            {
                var temp = FileText[i + 1] + FileText[i + 2].ToString() + FileText[i + 3];
                return temp;
            }

            return "-1";
        }

        private static bool LinksUsedCorrectly(IReadOnlyCollection<int> list)
        {
            var tempList = new List<int>(list);
            tempList.Sort();
            return list.SequenceEqual(tempList);
        }

        private bool EveryLinkIsUsed()
        {
            var everyLinkIsUsed = false;
            var tempList = new List<int>();
            for (var i = 1; i <= LinksAmountInLinksList; i++) tempList.Add(i);
            foreach (var item in LinksInTextList) everyLinkIsUsed = tempList.Contains(item);
            return everyLinkIsUsed;
        }

        #endregion

        #region Событие по нажатию кнопки "Выбрать файл"
        private void openFileBtn_Click(object sender, EventArgs e)
        {
            btnClear_Click(null, null);
            try
            {
                using (var openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory =
                        Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                    openFileDialog.Filter = "Word files (*.docx)|*.docx";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var wordApp = new Application();
                        Text = "Обработка файла";
                        var wordDoc = wordApp.Documents.OpenNoRepairDialog(openFileDialog.FileName);
                        FileText = wordDoc.Content.Text;
                        var litListName = string.Empty;
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
                        else
                        {
                            FileTextContainsLinksList = false;
                            wordApp.Quit(false);
                            btnClear_Click(null, null);
                            tbResult.Text = "В документе отсутствует список использованных источников";
                            return;
                        }
                        LinksListPosition = FileText.LastIndexOf(litListName, StringComparison.Ordinal);
                        for (var i = LinksListPosition; i < FileText.Length; i++) FileTextFromLinksListToEnd += FileText[i];
                        if (FileTextFromLinksListToEnd.Contains("ПРИЛОЖЕНИЕ"))
                        {
                            ApplicationTextPosition = FileTextFromLinksListToEnd.IndexOf("ПРИЛОЖЕНИЕ", StringComparison.Ordinal) + LinksListPosition;
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
                            if (CurrentPositionLinkNumber(i) != "-1")
                            {
                                LinksInTextAmount++;
                                LinksInTextList.Add(Convert.ToInt32(CurrentPositionLinkNumber(i)));
                            }
                            pbFileReading.Value++;
                        }
                        tbLinksAmountInText.Text = LinksInTextAmount.ToString();
                        foreach (var item in LinksInTextList) tbTextLinksList.Text += item + "  ";
                        tbLinksAmountInList.Text = "0";
                        var t = new Thread(new ThreadStart(delegate
                        {
                            Invoke(new ThreadStart(delegate
                            {
                                for (var i = LinksListPosition; i < LastFileCheckingPosition; i++)
                                {
                                    if (FileText[i] == '\r') LinksAmountInLinksList++;
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

                                if (EveryLinkIsUsed()) tbResult.Text += "Все ссылки из списка литературы использованы в тексте. ";
                                else tbResult.Text += "Не все ссылки из списка литературы использованы в тексте. ";
                                LinksInTextList.Clear();
                            }));
                            wordApp.Quit(false);
                        }));
                        if (FileTextContainsLinksList) t.Start();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        #endregion

        #region Событие по нажатию кнопки "Очистить"
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

        #endregion

        #region Событие по нажатию кнопки "Закрыть"
        private void btnClose_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        #endregion
    }
}