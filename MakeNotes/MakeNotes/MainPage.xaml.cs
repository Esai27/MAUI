namespace MakeNotes
{
    public partial class MainPage : ContentPage
    {
        string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");
        public MainPage()
        {
            InitializeComponent();
            if (File.Exists(_fileName))
            {
                editorText.Text = File.ReadAllText(_fileName);
            }
        }

       

        private void Save_Button_Clicked(object sender, EventArgs e)
        {

        }

        private void Delete_Button_Clicked(object sender, EventArgs e)
        {
            editorText.Text = string.Empty;

        }
    }

}
