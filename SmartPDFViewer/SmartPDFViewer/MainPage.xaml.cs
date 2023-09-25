using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;
using System.ComponentModel;
using System.Reflection;
using ChatGptNet;
using ChatGptNet.Models;

namespace SmartPDFViewer;

public partial class MainPage : ContentPage
{

    PdfViewerViewModel viewModel = new PdfViewerViewModel();

    private IChatGptClient _chatGptClient;

    public MainPage()
	{
		InitializeComponent();
        this.BindingContext = viewModel;
        this.Loaded += MainPage_Loaded;
    }

    private void MainPage_Loaded(object sender, EventArgs e)
    {
        _chatGptClient = Handler.MauiContext.Services.GetService<IChatGptClient>();
    }

    private void ShowSummary_Tapped(object sender, TappedEventArgs e)
    {
        this.popupDisplay.Show();
        viewModel.GenerateSummary(_chatGptClient);
    }

    private void RefreshSummary_Tapped(object sender, TappedEventArgs e)
    {
        viewModel.GenerateSummary(_chatGptClient, true);
    }
}

class PdfViewerViewModel : INotifyPropertyChanged
{
    private Stream? m_pdfDocumentStream;

    public event PropertyChangedEventHandler? PropertyChanged;

    private Guid _sessionGuid = Guid.Empty;

    public Stream PdfDocumentStream
    {
        get
        {
            return m_pdfDocumentStream;
        }
        set
        {
            m_pdfDocumentStream = value;
            OnPropertyChanged("PdfDocumentStream");
        }
    }

    private bool isBusy = false;

    public bool IsBusy
    {
        get
        {
            return isBusy;
        }
        set
        {
            isBusy = value;
            OnPropertyChanged("IsBusy");
        }
    }


    private String processedText = String.Empty;

    public String ProcessedText
    {
        get
        {
            return processedText;
        }
        set
        {
            processedText = value;
            OnPropertyChanged("ProcessedText");
        }
    }

    private int summaryIntensity = 50;

    public int SummaryIntensity
    {
        get
        {
            return summaryIntensity;
        }
        set
        {
            summaryIntensity = value;
            OnPropertyChanged("SummaryIntensity");
        }
    }



    public PdfViewerViewModel()
    {
        m_pdfDocumentStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("SmartPDFViewer.Assets.pdfexample.pdf");
    }

    public void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
    string extractedText = string.Empty;

    public  void LoadFile()
    {
        PdfLoadedDocument loadedDocument = new PdfLoadedDocument(PdfDocumentStream);
        PdfLoadedPageCollection loadedPages = loadedDocument.Pages;
        TextLineCollection lineCollection = new TextLineCollection();
        foreach (PdfLoadedPage loadedPage in loadedPages)
        {
            extractedText += loadedPage.ExtractText(out lineCollection);
        }
        loadedDocument.Close(true);
    }

    internal async void GenerateSummary(IChatGptClient _chatGptClient, bool isFileLoaded = false)
    {
        if (!isFileLoaded)
        {
            LoadFile();
        }

        this.IsBusy = true;

        if (_sessionGuid == Guid.Empty)
        {
            _sessionGuid = Guid.NewGuid();
        }
        ChatGptResponse response = await _chatGptClient.AskAsync(_sessionGuid,
        "Please provide a summary("+ this.SummaryIntensity +" words) of the content in the PDF file below :" + extractedText);

        this.ProcessedText = response.GetMessage(); ;
        this.IsBusy = false;
    }
}



