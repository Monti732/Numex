using System.Windows;

namespace Numex.Utilities.User_Controls;

public partial class FaqViewer : Window {
  public FaqViewer(Uri faqUri) {
    InitializeComponent();
    Faq.Source = faqUri;
  }
}